using System;
using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public class ResultItem : BaseItem
{
    public string Result { get; }
    
    public ResultItem(string controlName, ControlType controlType, string result) 
        : base("result", controlName, controlType, new Style())
    {
        if (string.IsNullOrWhiteSpace(result))
        {
            throw new ArgumentNullException(nameof(result), "Result can't be null or empty.");
        }

        Result = result;
    }
}