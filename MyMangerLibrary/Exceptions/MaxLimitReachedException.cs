﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMangerLibrary.Exceptions
{
    public class MaxLimitReachedException:Exception
    {
        public MaxLimitReachedException(string message) : base(message) { }
    }
}
