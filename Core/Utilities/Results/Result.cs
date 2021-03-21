using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool succes,string message):this(succes)

        {
            message = Message;
        }
        public Result(bool succes)
        {
            succes = Success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
