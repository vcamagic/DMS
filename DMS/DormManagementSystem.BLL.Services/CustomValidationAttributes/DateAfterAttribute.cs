using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.CustomValidationAttributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class DateAfterAttribute : ValidationAttribute
{
    public string FirstDateProperty { get; set; }
    public string SecondDateProperty { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        object firstDateValue = GetPropertyValue(validationContext.ObjectInstance, FirstDateProperty);
        object secondDateValue = GetPropertyValue(validationContext.ObjectInstance, SecondDateProperty);

        if (firstDateValue == null || secondDateValue == null || 
            !(firstDateValue is DateTime) || !(secondDateValue is DateTime))
        {
           return new ValidationResult("Dates are not valid.");
        }

        DateTime firstDate = (DateTime)firstDateValue;
        DateTime secondDate = (DateTime)secondDateValue;

        if (DateTime.Compare(firstDate, secondDate) > 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }

    private object GetPropertyValue(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
    }
}
