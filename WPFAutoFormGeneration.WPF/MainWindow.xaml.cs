using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            var items = new List<Item>
            {
                new Item
                {
                    LabelText = "Введите ваше имя",
                    ControlName = "name",
                    ControlType = ControlType.TextBox
                },

                new Item
                {
                    LabelText = "Выберите ваш(-и) гендер(-ы)",
                    ControlName = "gender",
                    ControlType = ControlType.CheckBox,
                    ControlValuesList = new List<string>
                    {
                        "вертолет",
                        "посудомоечная машина",
                        "игорк в осу"
                    }
                }
            };

            _itemsList = new ItemsList("Натсройки", items);
            
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
                        var result = item.ControlValuesList
                            .Aggregate(string.Empty, (current, value) => current + $"{value} ");
                        MessageBox.Show($"{item.ControlName} - {result}");
                        break;
                        
                    case ControlType.TextBox:
                        MessageBox.Show($"{item.ControlName} - {item.ControlValue}");
                        break;
                }
            }
        }
    }
}