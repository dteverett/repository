using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    class Connection : IDisposable
    {
        public DataClassDataContext _repository;
        //public ClaimStakerEntities _repository;

        public Connection()
        {
          //  _repository = new ClaimStakerEntities();
            _repository = new DataClassDataContext();
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
