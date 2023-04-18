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
            var headerStyle = new Style()
            {
                Setters =
                {
                    new Setter { Property = FontFamilyProperty, Value = new FontFamily("Verdana") },
                    new Setter { Property = FontSizeProperty, Value = 30.0 }
                }
            };
            
            var controlsStyle = new Style()
            {
                Setters =
                {
                    new Setter { Property = FontFamilyProperty, Value = new FontFamily("Verdana") },
                    new Setter { Property = FontSizeProperty, Value = 20.0 },
                    new Setter { Property = MarginProperty, Value = new Thickness(20.0, 5.0, 20.0, 5.0) },
                }
            };
            
            var items = new List<BaseItem>
            {
                new OneValueItem("Введи своё имя:", "name", ControlType.TextBox, controlsStyle, string.Empty),
                new MultipleValueItem("Ты гей?", "gay", ControlType.RadioButton, controlsStyle, 
                    new List<string> { "Да", "Нет" }, new List<string>()),
                new MultipleValueItem("Выбери подходящие тебе гендеры:", "genders", ControlType.CheckBox, controlsStyle,
                    new List<string> { "вертолет", "посудомоечная машина", "игрок в осу" }, new List<string> { "вертолет" }),
                new MultipleValueItem("Выбери жанры игр которые тебе нравятся:", "genres", ControlType.ListBox, controlsStyle,
                    new List<string>() { "RPG", "СтРеЛяЛкИ", "БрОдИлКи", "Пазлы на раздевание" }, new List<string>())
            };
            
            _itemsList = new ItemsList("Опрос \"Какой ты геймер?\"", items, headerStyle);
            
            StackPanelItemsController.CreateFields(_itemsList, ref MyPanel);
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            var list = StackPanelItemsController.ReadValuesFromFields(_itemsList, MyPanel);

            var name = list.Where(x => x.ControlName == "name").First() as ResultItem;
            var genders = list.Where(x => x.ControlName == "genders").First() as ResultItems;
            var gay = list.Where(x => x.ControlName == "gay").First() as ResultItem;
            var genres = list.Where(x => x.ControlName == "genres").First() as ResultItems;

            var text = $"Так, посмотри твои результаты... Тебя зовут {name.Result}? Странное имя...\n";
            
            text += "Ты ";
            if (gay.Result == "Нет")
            {
                text += "не ";
            }
            text += "гей... интересно...\n";
            
            text += "Ты указал в списке гендеров... ";
            if (genders.ResultsList.Count == 0)
            {
                text += "ничего ты не указал!";
            }
            else
            {
                text = genders.ResultsList.Aggregate(text, (current, value) => current + $"{value}...");
            }
            text += "...хммм... \n";
            
            text += "Так, а что у нас с жанрами? ";
            if (genres.ResultsList.Count == 0)
            {
                text += "ничего ты не указал!";
            }
            else
            {
                text = genres.ResultsList.Aggregate(text, (current, value) => current + $"{value}...");
            }
            
            text += "Ну ладно, ты сдал экзамен, давай зачетную книжку!";

            MessageBox.Show(text);
        }
    }
}