using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.CustomValidationAttributes;

public class DistinctPropertyValue : ValidationAttribute
{
    public string PropertyName { get; set; }

    public DistinctPropertyValue(string propertyName)
    {
        PropertyName = propertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IEnumerable<object>)
        {
            var enumerable = value as IEnumerable<object>;

            var propertyValues = from object element in enumerable
                                 select element.GetType().GetProperty(PropertyName).GetValue(element);

            return propertyValues.Distinct().Count() != enumerable.Count() ?
                  new ValidationResult($"All elements must have distinct values for the {PropertyName.ToLower()} property.") :
                    ValidationResult.Success;
        }

        return new ValidationResult($"Value must be a collection of objects.");
    }
}