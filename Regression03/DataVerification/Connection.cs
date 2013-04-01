using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerification
{
    class Connection : IDisposable
    {
        public DataModelDataContext _repository;

        public Connection()
        {
            _repository = new DataModelDataContext();
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }
        }
    }
}
