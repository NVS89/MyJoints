using System;

namespace MyJoints.Core.Exceptions
{
    public class DataAccessException: MyJointsException
    {
        public DataAccessException() { }
        public DataAccessException(string message) : base(message) { }
        public DataAccessException(string message, Exception inner) : base(message, inner) { }
    }
}
