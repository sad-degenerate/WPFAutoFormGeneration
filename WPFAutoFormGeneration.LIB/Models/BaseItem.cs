using System;
using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public abstract class BaseItem
{
    public string LabelText { get; }
    public string ControlName { get; }
    public ControlType ControlType { get; }
    public Style ItemStyle { get; }

    protected BaseItem(string labelText, string controlName, ControlType controlType, Style itemStyle)
    {
        if (string.IsNullOrWhiteSpace(labelText))
        {
            throw new ArgumentNullException(nameof(labelText), "Label text can't be null or whitespace.");
        }
        
        if (string.IsNullOrWhiteSpace(controlName))
        {
            throw new ArgumentNullException(nameof(controlName), "Control name can't be null or whitespace.");
        }

        LabelText = labelText;
        ControlName = controlName;
        ControlType = controlType;
        ItemStyle = itemStyle;
    }
}