using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
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
