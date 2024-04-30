using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameApi.Exceptions
{
    public class InvalidInput : Exception
    {
        public ModelStateDictionary ModelState { get; set; }

        public InvalidInput(string message, ModelStateDictionary modelState) : base(message)
        {
            this.ModelState = modelState;
        }
    }
}