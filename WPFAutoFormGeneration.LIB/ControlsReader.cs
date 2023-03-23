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

        if (string.IsNullOrWhiteSpace(name))
        {
            return new Item();
        }

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
                checkBox.IsChecked is null or false || string.IsNullOrWhiteSpace(checkBox.Content.ToString()))
            {
                continue;
            }
            
            resultsList.Add(checkBox.Content.ToString()!);
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.CheckBox,
            ControlValues = resultsList
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
            ControlValues = resultsList
        };
    }

    private static Item ReadRadioButton(string name, UIElementCollection controls)
    {
        var resultsList = new List<string>();

        foreach (var control in controls)
        {
            if (control is not RadioButton radioButton || radioButton.GroupName != name ||
                radioButton.IsChecked == false || string.IsNullOrWhiteSpace(radioButton.Content.ToString()))
            {
                continue;
            }
            
            resultsList.Add(radioButton.Content.ToString()!);
            break;
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.RadioButton,
            ControlValues = resultsList
        };
    }

    private static Item ReadTextBox(string name, UIElementCollection controls)
    {
        var result = new List<string>();
        
        foreach (var control in controls)
        {
            if (control is not TextBox textBox || textBox.Name != name)
            {
                continue;
            }

            result.Add(textBox.Text);
            break;
        }

        return new Item
        {
            ControlName = name,
            ControlType = ControlType.TextBox,
            ControlValues = result
        };
    }
}