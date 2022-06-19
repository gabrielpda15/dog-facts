using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFacts.Services
{
    public class BaseService : IDisposable
    {
        protected bool _disposed;

        public BaseService() { _disposed = false; }
        
        ~BaseService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
