﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTester
{
    public class Connection
    {
        public ClaimStakerDEVDataSet _repository;

        public Connection()
        {
            _repository = new ClaimStakerDEVDataSet();
        }
    }
}
