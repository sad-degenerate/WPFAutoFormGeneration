using System.Collections.Generic;
using System.Windows;

namespace WPFAutoFormGeneration.LIB.Models;

public class ItemsList
{
    public string HeaderText { get; }
    public string HeaderName { get; }
    public Style HeaderStyle { get; }
    public List<Item> Items { get; }

    public ItemsList(string headerText, string headerName, List<Item> items, Style headerStyle)
    {
        HeaderText = headerText;
        HeaderName = headerName;
        Items = items;
        HeaderStyle = headerStyle;
    }
}