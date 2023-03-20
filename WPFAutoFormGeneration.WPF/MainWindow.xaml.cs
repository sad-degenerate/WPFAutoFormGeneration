using System.Collections.Generic;
using System.Windows;
using WPFAutoFormGeneration.LIB.Models;
using WPFAutoFormGeneration.LIB.ViewModels;

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
            var itemsList = new BaseItemsList
            {
                Header = "Настройки",
                Items = new List<BaseItem>
                {
                    new("Экран", "Screen", "textbox", "empty"),
                    new("Звук", "Sound", "checkbox", "quite", new List<string>()
                    {
                        "loud",
                        "quite",
                    }),
                }
            };

            var viewModel = new BaseAddItemViewModel();
            viewModel.CreateFields(itemsList, ref MyPanel);
        }
    }
}