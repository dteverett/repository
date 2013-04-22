using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementsTesting
{
    class Connection : IDisposable
    {
        public StatementsDataModelDataContext _repository;

        public Connection()
        {
            _repository = new StatementsDataModelDataContext();
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
