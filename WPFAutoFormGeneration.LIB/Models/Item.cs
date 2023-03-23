using System.Collections.Generic;

namespace WPFAutoFormGeneration.LIB.Models;

public class Item
{
    public string? LabelText { get; set; }
    public string? ControlName { get; set; }
    public ControlType ControlType { get; set; }
    public List<string>? ControlValues { get; set; }
    public List<string>? ControlContent { get; set; }
}