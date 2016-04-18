using System;

namespace MyJoints.Core.Exceptions
{
    public class MyJointsException : Exception
    {
        public MyJointsException(){ }
        public MyJointsException(string message) : base(message) { }
        public MyJointsException(string message, Exception inner) : base(message, inner) { }
    }
}
