﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger : ILogger
    {
        public void LogException(Exception ex)
        {
            // TODO: implement NLog
            Debug.WriteLine(ex.Message);
        }
    }
}