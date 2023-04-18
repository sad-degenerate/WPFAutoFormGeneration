using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class ControlsReader
{
    public static BaseItem ReadControl(BaseItem baseItem, UIElementCollection controls)
    {
        var name = baseItem.ControlName;

        return baseItem.ControlType switch
        {
            ControlType.CheckBox => ReadCheckBox(name, controls),
            ControlType.ListBox => ReadListBox(name, controls),
            ControlType.RadioButton => ReadRadioButton(name, controls),
            _ => ReadTextBox(name, controls)
        };
    }

    private static BaseItem ReadCheckBox(string name, UIElementCollection controls)
    {
        var resultsList = new List<string>();

        foreach (var control in controls)
        {
            if (control is not CheckBox checkBox || checkBox.Tag.ToString() != name || checkBox.IsChecked == false)
            {
                continue;
            }
            
            resultsList.Add(checkBox.Content.ToString());
        }

        return new ResultItems(name, ControlType.CheckBox, resultsList);
    }

    private static BaseItem ReadListBox(string name, UIElementCollection controls)
    {
        var resultsList = new List<string>();

        foreach (var control in controls)
        {
            if (control is not ListBox listBox || listBox.Name != name)
            {
                continue;
            }

            resultsList.AddRange(from object? selectedItem in listBox.SelectedItems select selectedItem.ToString());
            break;
        }

        return new ResultItems(name, ControlType.ListBox, resultsList);
    }

    private static BaseItem ReadRadioButton(string name, UIElementCollection controls)
    {
        var result = string.Empty;

        foreach (var control in controls)
        {
            if (control is not RadioButton radioButton || radioButton.GroupName != name || radioButton.IsChecked == false)
            {
                continue;
            }
            
            result = radioButton.Content.ToString();
            break;
        }

        return new ResultItem(name, ControlType.RadioButton, result);
    }

    private static BaseItem ReadTextBox(string name, UIElementCollection controls)
    {
        var result = string.Empty;
        
        foreach (var control in controls)
        {
            if (control is not TextBox textBox || textBox.Name != name)
            {
                continue;
            }

            result = textBox.Text;
            break;
        }

        return new ResultItem(name, ControlType.TextBox, result);
    }
}