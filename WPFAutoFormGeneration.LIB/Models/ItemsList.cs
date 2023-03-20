using System.Collections.Generic;

namespace WPFAutoFormGeneration.LIB.Models;

public class ItemsList
{
    public string Header { get; }
    public List<Item> Items { get; }

    public ItemsList(string header, List<Item> items)
    {
        Header = header;
        Items = items;
    }
}