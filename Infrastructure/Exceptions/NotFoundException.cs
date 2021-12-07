﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
   public class NotFoundException : Exception
    {
        public NotFoundException(string exceptionMessage): base(exceptionMessage)
        {

        }
    }
}
