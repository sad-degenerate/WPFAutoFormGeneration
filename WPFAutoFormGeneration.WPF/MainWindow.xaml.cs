using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFAutoFormGeneration.WPF.Models;
using WPFAutoFormGeneration.WPF.ViewModels;

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
                    new("Звук", "Sound", "textbox", "loud"),
                }
            };

            var viewModel = new BaseAddItemViewModel();
            viewModel.CreateFields(itemsList, ref MyPanel);
        }
    }
}