using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RubiksCube.UI
{
    public interface IAppDomainSetup
    {
        void Start();

        void Stop();
    }

    public class AnimationEngine : IAppDomainSetup
    {
        private readonly IList<FacieAnimation> movements;
        private readonly AutoResetEvent movementAvailable;
        private readonly ReaderWriterLockSlim movementLock;
        private readonly ReaderWriterLockSlim stoppingLock;
        private Thread thread;
        private bool isStopping;

        public AnimationEngine()
        {
            movements = new List<FacieAnimation>();
            movementAvailable = new AutoResetEvent(false);
            movementLock = new ReaderWriterLockSlim();
            stoppingLock = new ReaderWriterLockSlim();
        }

        private bool IsStopping
        {
            get
            {
                try
                {
                    stoppingLock.EnterReadLock();
                    return isStopping;
                }
                finally
                {
                    stoppingLock.ExitReadLock();
                }
            }

            set
            {
                try
                {
                    stoppingLock.EnterWriteLock();
                    isStopping = true;
                }
                finally
                {
                    stoppingLock.ExitWriteLock();
                }
            }
        }

        public void Start()
        {
            thread = new Thread(Core) { IsBackground = false };
            thread.Start();
        }

        public void Stop()
        {
            IsStopping = true;
        }

        public void BeginAnimation(FacieAnimation movement)
        {
            Push(movement);
            movementAvailable.Set();
        }

        private void Core()
        {
            while(!IsStopping)
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