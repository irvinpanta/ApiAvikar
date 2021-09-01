﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services.Interface
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}
