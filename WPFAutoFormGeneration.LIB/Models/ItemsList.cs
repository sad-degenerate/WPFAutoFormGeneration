using System.Collections.Generic;

namespace WPFAutoFormGeneration.LIB.Models;

public class ItemsList
{
    public string HeaderText { get; }
    public string HeaderName { get; }
    public List<Item> Items { get; }

    public ItemsList(string headerText, string headerName, List<Item> items)
    {
        HeaderText = headerText;
        HeaderName = headerName;
        Items = items;
    }
}