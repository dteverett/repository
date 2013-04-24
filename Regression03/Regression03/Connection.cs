using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regression03
{
    public class Connection
    {
        public ClaimStakerEntities _repository;

        public Connection()
        {
            _repository = new ClaimStakerEntities();
        }
    }
}
