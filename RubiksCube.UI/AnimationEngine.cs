using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RubiksCube.UI
{
    public interface IAppDomainSetup
    {
        void Start();
    }

    public class AnimationEngine : IAppDomainSetup
    {
        private readonly IList<FacieAnimation> movements;
        private readonly AutoResetEvent movementAvailable;
        private readonly ReaderWriterLockSlim movementLock;
        private Thread thread;

        public AnimationEngine()
        {
            movements = new List<FacieAnimation>();
            movementAvailable = new AutoResetEvent(false);
            movementLock = new ReaderWriterLockSlim();
        }

        public void Start()
        {
            thread = new Thread(Core) { IsBackground = false };
            thread.Start();
        }

        public void BeginAnimation(IEnumerable<FacieAnimation> animations)
        {
            foreach(var movement in animations)
            {
                Push(movement);
            }

            movementAvailable.Set();
        }

        private void Core()
        {
            while(true)
            {
                var movement = Pop();
                if (movement != null)
                {
                    var animationLock = movement.BeginAnimation();
                    animationLock.WaitOne();
                }
            }
        }

        private void Push(FacieAnimation movement)
        {
            try
            {
                movementLock.EnterWriteLock();
                movements.Add(movement);
            }
            finally
            {
                movementLock.ExitWriteLock();
            }
        }

        private FacieAnimation Pop()
        {
            FacieAnimation movement;
            try
            {
                movementLock.EnterUpgradeableReadLock();

                if (movements.Count == 0)
                {
                    movementLock.ExitUpgradeableReadLock();
                    movementAvailable.WaitOne();
                    movementLock.EnterUpgradeableReadLock();
                }

                movement = movements.FirstOrDefault();

                movementLock.EnterWriteLock();
                movements.Remove(movement);
            }
            finally
            {
                if(movementLock.IsWriteLockHeld)
                {
                    movementLock.ExitWriteLock();
                }

                movementLock.ExitUpgradeableReadLock();
            }

            return movement;
        }
    }
}