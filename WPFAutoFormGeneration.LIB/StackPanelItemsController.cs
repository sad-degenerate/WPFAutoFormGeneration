using System.Collections.Generic;
using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public class StackPanelItemsController
{
    public static void CreateFields(ItemsList itemsList, ref StackPanel panel)
    {
        panel.Children.Clear();
        panel.Children.Add(new Label() { Content = itemsList.Header });

        foreach (var item in itemsList.Items)
        {
            ControlsCreator.AddControlToStackPanel(ref panel, item);
        }
    }

    // public static Dictionary<string, string> ReadValuesFromFields(ItemsList itemsList, StackPanel panel)
    // {
    //     var result = new Dictionary<string, string>();
    //     var controls = panel.Children;
    //     
    //     foreach (var item in itemsList.Items)
    //     {
    //         result.Add(ControlsReader.ReadControl(item, ));
    //     }
    // }
}