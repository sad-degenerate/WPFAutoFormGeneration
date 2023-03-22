using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPFAutoFormGeneration.LIB.Models;

public class Item : IValidatableObject
{
    public string LabelText { get; set; }
    public string ControlName { get; set; }
    public ControlType ControlType { get; set; }
    public string ControlValue { get; set; }
    public List<string> ControlValuesList { get; set; }
    public string Style { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(ControlName))
        {
            errors.Add(new ValidationResult("Control name is null or empty"));
        }

        return errors;
    }
}