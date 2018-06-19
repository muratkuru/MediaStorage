using System;
using System.Web.Mvc;

namespace MediaStorage.Web.Attributes
{
    public enum ConstraintType
    {
        Number,
        Guid
    }

    public class UrlConstraintAttribute : ActionFilterAttribute
    {
        private ConstraintType constraintType;
        private string parameterName;
        private bool isNullable;

        public UrlConstraintAttribute(ConstraintType constraintType = ConstraintType.Number, string parameterName = "id", bool isNullable = true)
        {
            this.constraintType = constraintType;
            this.parameterName = parameterName;
            this.isNullable = isNullable;
        }

        // TODO: Set TempData["result"] and redirect to current controller index.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var parameter = filterContext.RouteData.Values[parameterName];

            bool control = !isNullable && parameter == null;

            if (parameter != null)
            {
                switch (constraintType)
                {
                    case ConstraintType.Number:
                        control = !IsInteger(parameter);
                        break;
                    case ConstraintType.Guid:
                        control = !IsGuid(parameter);
                        break;
                    default: break;

                }
            }

            if (control)
                filterContext.Result = new RedirectResult("/Errors/NotFound");
        }

        private bool IsInteger(object value) => int.TryParse(value.ToString(), out int result);

        private bool IsGuid(object value) => Guid.TryParse(value.ToString(), out Guid result);
    }
}