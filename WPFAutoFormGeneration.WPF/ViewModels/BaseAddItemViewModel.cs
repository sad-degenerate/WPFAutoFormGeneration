using System.Collections.Generic;
using System.Windows.Controls;
using WPFAutoFormGeneration.WPF.Models;

namespace WPFAutoFormGeneration.WPF.ViewModels;

public class BaseAddItemViewModel
{
    public void CreateFields(string header, List<BaseItem> items, ref StackPanel panel)
    {
        panel.Children.Clear();
        panel.Children.Add(new Label() { Content = header });

        foreach (var item in items)
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
                    };
                    break;
                
                case "listbox":
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
        
    }
}