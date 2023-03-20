using System.Collections.Generic;

namespace WPFAutoFormGeneration.LIB.Models;

public class Item
{
    public string LabelText { get; }
    public string ControlName { get; }
    public ControlType ControlType { get; }
    public string ControlValue { get; }
    public List<string>? ControlValuesList { get; }
    public string? Style { get; }

    public Item(string labelText, string controlName, ControlType controlType, string controlValue,
        List<string>? controlValuesList = null, string? style = null)
    {
        LabelText = labelText;
        ControlName = controlName;
        ControlType = controlType;
        ControlValue = controlValue;
        ControlValuesList = controlValuesList;
        Style = style;
    }
}