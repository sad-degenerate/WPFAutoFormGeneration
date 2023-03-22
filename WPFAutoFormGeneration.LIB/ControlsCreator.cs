using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class ControlsCreator
{
    public static void AddControlToStackPanel(ref StackPanel panel, Item item)
    {
        var label = new Label()
        {
            Content = item.LabelText
        };
        panel.Children.Add(label);
        
        switch (item.ControlType)
        {
            case ControlType.TextBox:
                AddTextBox(ref panel, item);
                break;
                
            case ControlType.RadioButton:
                AddRadioButton(ref panel, item);
                break;
                
            case ControlType.CheckBox:
                AddCheckBox(ref panel, item);
                break;
                
            case ControlType.ListBox:
                AddListBox(ref panel, item);
                break;
        }
    }
    
    private static void AddTextBox(ref StackPanel panel, Item item)
    {
        var textBox = new TextBox()
        {
            Name = item.ControlName,
            Text = item.ControlValue
        };
        
        panel.Children.Add(textBox);
    }

    private static void AddRadioButton(ref StackPanel panel, Item item)
    {
        foreach (var value in item.ControlValuesList)
        {
            var radioButton = new RadioButton()
            {
                Content = value,
                GroupName = item.ControlName
            };

            if (item.ControlValue == value)
            {
                radioButton.IsChecked = true;
            }

            panel.Children.Add(radioButton);
        }
    }

    private static void AddCheckBox(ref StackPanel panel, Item item)
    {
        foreach (var value in item.ControlValuesList)
        {
            var checkBox = new CheckBox()
            {
                Content = value,
                Tag = item.ControlName
            };

            if (item.ControlValue == value)
            {
                checkBox.IsChecked = true;
            }

            panel.Children.Add(checkBox);
        }
    }

    private static void AddListBox(ref StackPanel panel, Item item)
    {
        var listBox = new ListBox()
        {
            Name = item.ControlName,
            ItemsSource = item.ControlValuesList
        };

        foreach (var listBoxItem in listBox.ItemsSource)
        {
            if (listBoxItem.ToString() == item.ControlValue)
            {
                listBox.SelectedItem = listBoxItem;
            }
        }

        panel.Children.Add(listBox);
    }
}