using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public static class ContainerManager
    {
        private static IKernel _container;
        private static readonly ReaderWriterLockSlim ContainerLock = new ReaderWriterLockSlim();

        public static IKernel Container
        {
            get
            {
                ContainerLock.EnterReadLock();
                try
                {
                    return _container;
                }
                finally
                {
                    ContainerLock.ExitReadLock();
                }
            }
            set
            {
                ContainerLock.EnterWriteLock();
                try
                {
                    if (_container != null)
                    {
                        throw new InvalidOperationException("Container already set");
                    }

                    _container = value;
                }
                finally
                {
                    ContainerLock.ExitWriteLock();
                }
            }
        }

        public static T Resolve<T>()
        {
            return Container.Get<T>();
        }
    }
}
