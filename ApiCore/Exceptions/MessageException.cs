﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Exceptions
{
    public class MessageException : Exception
    {
        public MessageException(){}

        public MessageException(string message):base(message)
        {

        }
    }
}
