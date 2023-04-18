using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WPFAutoFormGeneration.LIB;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.WPF
{
    public partial class MainWindow : Window
    {
        private ItemsList _itemsList;
        
        public MainWindow()
        {
            InitializeComponent();
            
            CreateFieldsMain();
        }

        private void CreateFieldsMain()
        {
            var style = new Style()
            {
                Setters =
                {
                    new Setter { Property = FontFamilyProperty, Value = new FontFamily("Verdana") },
                    new Setter { Property = FontSizeProperty, Value = 20.0 },
                    new Setter { Property = MarginProperty, Value = new Thickness(20.0, 5.0, 20.0, 5.0) },
                }
            };
            
            var items = new List<Item>
            {
                new()
                {
                    LabelText = "Введите ваше имя",
                    ControlName = "name",
                    ControlType = ControlType.TextBox,
                    Style = style
                },

                new()
                {
                    LabelText = "Выберите ваш(-и) гендер(-ы)",
                    ControlName = "gender",
                    ControlType = ControlType.CheckBox,
                    ControlContent = new List<string>
                    {
                        "вертолет",
                        "посудомоечная машина",
                        "игорк в осу"
                    },
                    ControlValues = new List<string>
                    {
                        "вертолет"
                    },
                    Style = style
                }
            };

            var headerStyle = new Style()
            {
                Setters =
                {
                    new Setter { Property = FontFamilyProperty, Value = new FontFamily("Verdana") },
                    new Setter { Property = FontSizeProperty, Value = 30.0 }
                }
            };

            _itemsList = new ItemsList("Настройки", "header", items, headerStyle);
            
            StackPanelItemsController.CreateFields(_itemsList, ref MyPanel);
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            var list = StackPanelItemsController.ReadValuesFromFields(_itemsList, MyPanel);

            foreach (var item in list.Items)
            {
                switch (item.ControlType)
                {
                    case ControlType.CheckBox:
                        var result = item.ControlValues
                            .Aggregate(string.Empty, (current, value) => current + $"{value} ");
                        MessageBox.Show($"{item.ControlName} - {result}");
                        break;
                        
                    case ControlType.TextBox:
                        MessageBox.Show($"{item.ControlName} - {item.ControlValues.FirstOrDefault()}");
                        break;
                }
            }
        }
    }
}