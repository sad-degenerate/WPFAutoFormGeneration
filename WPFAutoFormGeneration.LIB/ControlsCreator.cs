using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class ControlsCreator
{
    public static void AddControlToStackPanel(ref StackPanel panel, BaseItem baseItem)
    {
        var label = new Label
        {
            Content = baseItem.LabelText,
            Style = baseItem.ItemStyle
        };
        panel.Children.Add(label);
        
        switch (baseItem.ControlType)
        {
            case ControlType.RadioButton:
                AddRadioButton(ref panel, baseItem);
                break;
                
            case ControlType.CheckBox:
                AddCheckBox(ref panel, baseItem);
                break;
                
            case ControlType.ListBox:
                AddListBox(ref panel, baseItem);
                break;

            case ControlType.TextBox:
            default:
                AddTextBox(ref panel, baseItem);
                break;
        }
    }
    
    private static void AddTextBox(ref StackPanel panel, BaseItem baseItem)
    {
        if (baseItem is not OneValueItem item)
        {
            return;
        }

        var textBox = new TextBox
        {
            Name = item.ControlName,
            Text = item.ControlValue,
            Style = item.ItemStyle
        };
        
        panel.Children.Add(textBox);
    }

    private static void AddRadioButton(ref StackPanel panel, BaseItem baseItem)
    {
        if (baseItem is not MultipleValueItem item)
        {
            return;
        }
        
        foreach (var content in item.ControlContents)
        {
            var radioButton = new RadioButton
            {
                Content = content,
                GroupName = item.ControlName,
                Style = item.ItemStyle
            };

            if (item.ControlValues != null && item.ControlValues.Contains(content))
            {
                radioButton.IsChecked = true;
            }

            panel.Children.Add(radioButton);
        }
    }

    private static void AddCheckBox(ref StackPanel panel, BaseItem baseItem)
    {
        if (baseItem is not MultipleValueItem item)
        {
            return;
        }
        
        foreach (var content in item.ControlContents)
        {
            var checkBox = new CheckBox
            {
                Content = content,
                Tag = item.ControlName,
                Style = item.ItemStyle
            };

            if (item.ControlValues != null && item.ControlValues.Contains(content))
            {
                checkBox.IsChecked = true;
            }

            panel.Children.Add(checkBox);
        }
    }

    private static void AddListBox(ref StackPanel panel, BaseItem baseItem)
    {
        if (baseItem is not MultipleValueItem item)
        {
            return;
        }
        
        var listBox = new ListBox
        {
            Name = item.ControlName,
            ItemsSource = item.ControlContents,
            Style = item.ItemStyle
        };
        
        if (item.ControlValues.Count > 1)
        {
            foreach (var listBoxItem in listBox.ItemsSource)
            {
                if (item.ControlValues.Contains(listBoxItem.ToString() ?? string.Empty))
                {
                    listBox.SelectedItem = listBoxItem;
                }
            }
        }

        panel.Children.Add(listBox);
    }
}