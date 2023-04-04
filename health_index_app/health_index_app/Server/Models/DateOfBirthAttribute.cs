using System.ComponentModel.DataAnnotations;

namespace health_index_app.Server.Models
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;
            else
            {
                var val = (DateTime)value;
                return val <= DateTime.Now;
            }
                
        }
    }
}
