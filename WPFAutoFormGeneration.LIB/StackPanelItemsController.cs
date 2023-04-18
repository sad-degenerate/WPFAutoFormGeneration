using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WPFAutoFormGeneration.LIB.Models;

namespace WPFAutoFormGeneration.LIB;

public static class StackPanelItemsController
{
    public static void CreateFields(ItemsList itemsList, ref StackPanel panel)
    {
        panel.Children.Clear();
        panel.Children.Add(new Label { Content = itemsList.HeaderText, Style = itemsList.HeaderStyle});

        foreach (var item in itemsList.Items)
        {
            ControlsCreator.AddControlToStackPanel(ref panel, item);
        }
    }

    public static List<BaseItem> ReadValuesFromFields(ItemsList itemsList, StackPanel panel)
    {
        var controls = panel.Children;

        var resultList = itemsList.Items.Select(item => ControlsReader.ReadControl(item, controls)).ToList();

        return resultList;
    }
}