using System;
using System.Collections.Generic;
using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public class ResultItems : BaseItem
{
    public List<string> ResultsList { get; }
    
    public ResultItems(string controlName, ControlType controlType, List<string> resultsList) 
        : base("result", controlName, controlType, new Style())
    {
        if (resultsList.Count == 0 && ControlType != ControlType.CheckBox && ControlType != ControlType.ListBox)
        {
            throw new ArgumentNullException(nameof(resultsList), "Results list can't be empty.");
        }

        ResultsList = resultsList;
    }
}