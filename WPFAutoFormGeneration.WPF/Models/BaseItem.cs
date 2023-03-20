using System.Collections.Generic;

namespace WPFAutoFormGeneration.WPF.Models;

public class BaseItem
{
    public string LabelText { get; set; }
    public string ControlName { get; set; }
    public string ControlType { get; set; }
    public string ControlValue { get; set; }
    public List<string>? ControlValuesList { get; set; }

    public BaseItem(string labelText, string controlName, string controlType, string controlValue,
        List<string>? controlValuesList = null)
    {
        LabelText = labelText;
        ControlName = controlName;
        ControlType = controlType;
        ControlValue = controlValue;
        ControlValuesList = controlValuesList;
    }
}