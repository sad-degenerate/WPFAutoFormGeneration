using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class ControlsReader
{
    public static Item ReadControl(Item item, UIElementCollection controls)
    {
        var name = item.ControlName;

        return item.ControlType switch
        {
            ControlType.CheckBox => ReadCheckBox(name, controls),
            ControlType.ListBox => ReadListBox(name, controls),
            ControlType.RadioButton => ReadRadioButton(name, controls),
            _ => ReadTextBox(name, controls)
        };
    }

    private static Item ReadCheckBox(string name, UIElementCollection controls)
    {
        var resultsList = new List<string>();

        foreach (var control in controls)
        {
            if (control is not CheckBox checkBox || checkBox.Tag.ToString() != name ||
                checkBox.IsChecked.Value == false)
            {
                continue;
            }

            resultsList.Add(checkBox.Content.ToString());
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.CheckBox,
            ControlValuesList = resultsList
        };
    }

    private static Item ReadListBox(string name, UIElementCollection controls)
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

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.ListBox,
            ControlValuesList = resultsList
        };
    }

    private static Item ReadRadioButton(string name, UIElementCollection controls)
    {
        var result = string.Empty;
        
        foreach (var control in controls)
        {
            if (control is not RadioButton radioButton || radioButton.GroupName != name ||
                radioButton.IsChecked.Value == false)
            {
                continue;
            }

            result = radioButton.Content.ToString();
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.RadioButton,
            ControlValue = result
        };
    }

    private static Item ReadTextBox(string name, UIElementCollection controls)
    {
        var result = string.Empty;
        
        foreach (var control in controls)
        {
            if (control is not TextBox textBox || textBox.Name != name)
            {
                continue;
            }

            result = textBox.Text;
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.TextBox,
            ControlValue = result
        };
    }
}