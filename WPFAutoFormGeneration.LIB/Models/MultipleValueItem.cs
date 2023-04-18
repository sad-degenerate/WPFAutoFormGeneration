using System;
using System.Collections.Generic;
using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public class MultipleValueItem : BaseItem
{
    public List<string> ControlValues { get; }
    public List<string> ControlContents { get; }
    
    public MultipleValueItem(string labelText, string controlName, ControlType controlType, Style itemStyle,
                            List<string> controlContents, List<string> controlValues) 
        : base(labelText, controlName, controlType, itemStyle)
    {
        if ((controlContents.Count < 1 && ControlType == ControlType.CheckBox) ||
            (controlContents.Count < 2 && ControlType != ControlType.CheckBox))
        {
            throw new ArgumentException("Control contents must have at least 2 elements (1 for checkboxes).", 
                nameof(controlContents));
        }

        ControlContents = controlContents;
        ControlValues = controlValues;
    }
}