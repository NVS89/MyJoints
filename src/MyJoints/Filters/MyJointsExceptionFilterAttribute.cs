using Microsoft.AspNet.Mvc;
using MyJoints.Core.Exceptions;

namespace MyJoints.Filters
{
    public class MyJointsExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is MyJointsException)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
