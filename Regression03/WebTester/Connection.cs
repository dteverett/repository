using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTester
{
    class Connection
    {
        public ClaimStakerDEVEntities _repository;

        public Connection()
        {
            _repository = new ClaimStakerDEVEntities();
        }
    }
}
