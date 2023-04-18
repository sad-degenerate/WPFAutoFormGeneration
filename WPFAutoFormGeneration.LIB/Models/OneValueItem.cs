using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public class OneValueItem : BaseItem
{
    public string ControlValue { get; }
    
    public OneValueItem(string labelText, string controlName, ControlType controlType, Style itemStyle, string controlValue) 
        : base(labelText, controlName, controlType, itemStyle)
    {
        ControlValue = controlValue;
    }
}