using System;
using System.Windows;
using System.Collections.Generic;

namespace WPFAutoFormGeneration.LIB.Models;

public class ItemsList
{
    public string HeaderText { get; }
    public Style HeaderStyle { get; }
    public List<BaseItem> Items { get; }

    public ItemsList(string headerText, List<BaseItem> items, Style headerStyle)
    {
        if (string.IsNullOrWhiteSpace(headerText))
        {
            throw new ArgumentNullException(nameof(headerText), "Header can't be null or whitespace.");
        }

        if (items.Count == 0)
        {
            throw new ArgumentException("Items count can't be 0.", nameof(items));
        }

        HeaderText = headerText;
        Items = items;
        HeaderStyle = headerStyle;
    }
}