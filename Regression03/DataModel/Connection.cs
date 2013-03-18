using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class Connection
    {
        public SQLDEVConnect _repository;

        public Connection()
        {
            _repository = new SQLDEVConnect();
        }
    }
}
