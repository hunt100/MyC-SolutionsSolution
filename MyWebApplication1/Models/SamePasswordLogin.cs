using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models
{
    public class SamePasswordLogin : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((value as string) == "Ali")
            {
                return false;
            }

            return true;
        }
    }
}