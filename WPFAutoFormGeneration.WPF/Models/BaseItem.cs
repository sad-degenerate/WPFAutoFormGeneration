using System.Collections.Generic;

namespace WPFAutoFormGeneration.WPF.Models;

public class BaseItem
{
    public string LabelText { get; set; }
    public string ControlName { get; set; }
    public string ControlType { get; set; }
    public string ControlValue { get; set; }
    public List<string> ControlValuesList { get; set; }
}