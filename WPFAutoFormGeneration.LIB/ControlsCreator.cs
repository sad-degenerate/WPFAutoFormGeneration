using System.Linq;
using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class ControlsCreator
{
    public static void AddControlToStackPanel(ref StackPanel panel, Item item)
    {
        var label = new Label
        {
            Content = item.LabelText
        };
        panel.Children.Add(label);
        
        switch (item.ControlType)
        {
            case ControlType.RadioButton:
                AddRadioButton(ref panel, item);
                break;
                
            case ControlType.CheckBox:
                AddCheckBox(ref panel, item);
                break;
                
            case ControlType.ListBox:
                AddListBox(ref panel, item);
                break;

            case ControlType.TextBox:
            default:
                AddTextBox(ref panel, item);
                break;
        }
    }
    
    private static void AddTextBox(ref StackPanel panel, Item item)
    {
        var text = item.ControlValues == null || item.ControlValues.Count == 0 
            ? string.Empty 
            : item.ControlValues.First();
        
        var textBox = new TextBox
        {
            Name = item.ControlName,
            Text = text
        };
        
        panel.Children.Add(textBox);
    }

    private static void AddRadioButton(ref StackPanel panel, Item item)
    {
        if (item.ControlContent == null || item.ControlContent.Count < 2)
        {
            return;
        }
        
        foreach (var content in item.ControlContent)
        {
            var radioButton = new RadioButton
            {
                Content = content,
                GroupName = item.ControlName
            };

            if (item.ControlValues != null && item.ControlValues.Contains(content))
            {
                radioButton.IsChecked = true;
            }

            panel.Children.Add(radioButton);
        }
    }

    private static void AddCheckBox(ref StackPanel panel, Item item)
    {
        if (item.ControlContent == null || item.ControlContent.Count < 1)
        {
            return;
        }
        
        foreach (var content in item.ControlContent)
        {
            var checkBox = new CheckBox
            {
                Content = content,
                Tag = item.ControlName
            };

            if (item.ControlValues != null && item.ControlValues.Contains(content))
            {
                checkBox.IsChecked = true;
            }

            panel.Children.Add(checkBox);
        }
    }

    private static void AddListBox(ref StackPanel panel, Item item)
    {
        if (item.ControlContent == null || item.ControlContent.Count < 2)
        {
            return;
        }
        
        var listBox = new ListBox
        {
            Name = item.ControlName,
            ItemsSource = item.ControlContent
        };
        
        if (item.ControlValues == null || item.ControlValues.Count < 1)
        {
            panel.Children.Add(listBox);
            return;
        }

        foreach (var listBoxItem in listBox.ItemsSource)
        {
            if (item.ControlValues.Contains(listBoxItem.ToString() ?? string.Empty))
            {
                listBox.SelectedItem = listBoxItem;
            }
        }

        panel.Children.Add(listBox);
    }
}