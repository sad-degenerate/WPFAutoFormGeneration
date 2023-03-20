using System.Windows.Controls;
using WPFAutoFormGeneration.WPF.Models;

namespace WPFAutoFormGeneration.WPF.ViewModels;

public class BaseAddItemViewModel
{
    public void CreateFields(BaseItemsList itemsList, ref StackPanel panel)
    {
        panel.Children.Clear();
        panel.Children.Add(new Label() { Content = itemsList.Header });

        foreach (var item in itemsList.Items)
        {
            var label = new Label()
            {
                Content = item.LabelText
            };
            panel.Children.Add(label);
            
            switch (item.ControlType)
            {
                case "textbox":
                    AddTextBox(ref panel, item);
                    break;
                
                case "radiobutton":
                    AddRadioButton(ref panel, item);
                    break;
                
                case "checkbox":
                    AddCheckBox(ref panel, item);
                    break;
                
                case "listbox":
                    AddListBox(ref panel, item);
                    break;
            }
        }
    }
    
    private void AddTextBox(ref StackPanel panel, BaseItem item)
    {
        var textBox = new TextBox()
        {
            Name = item.ControlName,
            Text = item.ControlValue
        };
        
        panel.Children.Add(textBox);
    }

    private void AddRadioButton(ref StackPanel panel, BaseItem item)
    {
        foreach (var value in item.ControlValuesList)
        {
            var radioButton = new RadioButton()
            {
                Name = $"{value}",
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

    private void AddCheckBox(ref StackPanel panel, BaseItem item)
    {
        foreach (var value in item.ControlValuesList)
        {
            var checkBox = new CheckBox()
            {
                Name = $"{value}",
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

    private void AddListBox(ref StackPanel panel, BaseItem item)
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