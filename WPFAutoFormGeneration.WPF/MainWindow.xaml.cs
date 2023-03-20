using System.Collections.Generic;
using System.Windows;
using WPFAutoFormGeneration.LIB;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            CreateFieldsMain();
        }

        private void CreateFieldsMain()
        {
            var items = new List<Item>
            {
                new("Экран", "Screen", ControlType.TextBox, "empty"),
                new("Звук", "Sound", ControlType.CheckBox, "quite", new List<string>
                {
                    "loud",
                    "quite",
                }),
            };

            var itemsList = new ItemsList("Настройки", items);
            
            StackPanelItemsController.CreateFields(itemsList, ref MyPanel);
        }
    }
}