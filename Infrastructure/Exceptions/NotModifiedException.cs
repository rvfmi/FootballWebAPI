﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
   public class NotModifiedException : Exception
    {
        public NotModifiedException(string exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
