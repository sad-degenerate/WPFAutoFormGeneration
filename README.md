# WPF Auto form generator
## Description
This library can create simple forms with simple controls like textboxes, checkboxes, listboxes, roundbuttons and labels.

## How install

Just add this library to yout project dependencies.

## How to use

First, you should create list of controls, that will be in your form. Create new list of **BaseItems**. Textboxes and roundbuttons are **OneValueItems**, listboxes and checkboxes are **MultipleValueItems**. First argument of each constructor is label text, that placed before control. Next argument is control name, it's used to write and read data to/from it. Next argument is control type, just choose it from enum. Next argument is control style, later I'll show how to create styles, but if you don't want to use styles just put **"new Style()"** instead of it. Further differences appears between thees classes. In **OneValueItem** class there is last argument, responsible for control default value.

    var items = new List<BaseItem>
    {
    	new OneValueItem("Text box sample:", "text", ControlType.TextBox, controlsStyle, string.Empty),

In **MultipleValueItem** class there are two last arguments. First argument is collection of control options. Last argument responsible for control default values. You can leave last argument empty.

    	new MultipleValueItem("Round button sample:", "round", ControlType.RadioButton, controlsStyle, new List<string> { "Yes", "No" }, new List<string>()),
    	new MultipleValueItem("Checkbox sample:", "check", ControlType.CheckBox, controlsStyle, new List<string> { "text 1", "text 2", "text 3" }, new List<string> { "text 1" }),
    	new MultipleValueItem("Listbox sample:", "listbox", ControlType.ListBox, controlsStyle, new List<string>() { "text 1", "text 2", "text 3", "text 4" }, new List<string>())
    };

You can attach style to your component, just create style like showed bellow and put it in place showed higher.

```csharp
var controlsStyle = new Style()
{
	Setters =
	{
		new Setter { Property = FontFamilyProperty, Value = new FontFamily("Verdana") },
		new Setter { Property = FontSizeProperty, Value = 20.0 },
		new Setter { Property = MarginProperty, Value = new Thickness(20.0, 5.0, 20.0, 5.0) },
	}
};
```

Than you need to create **ItemsList**, write main header text, add main header style. Next pass created ItemsList and reference to your **StackPanel** to static method **CreateFields** like written bellow.

```csharp
_itemsList = new ItemsList("Header text", items, headerStyle);
StackPanelItemsController.CreateFields(_itemsList, ref MyPanel);
```

Use static method **ReadValuesFromFields** to read data from your form. It's return list of BaseItem, cast it to **ResultItem** if it roundbutton or textbox, cast it to **ResultItems** otherwise. User input placed in **Result/ResultList**.

```csharp
var list = StackPanelItemsController.ReadValuesFromFields(_itemsList, MyPanel);
var resultText = string.Empty;

foreach (var item in list)
{
	if (item.ControlType is ControlType.TextBox or ControlType.RadioButton)
	{
		var resultItem = item as ResultItem;
		resultText += $"{resultItem.ControlName} - {resultItem.Result}\n";
		continue;
	}

	var resultItems = item as ResultItems;
	var itemText = resultItems.ResultsList.Aggregate(string.Empty, (current, el) => current + el);
	resultText += $"{resultItems.ControlName} - {itemText}\n";
}

MessageBox.Show(resultText);
```

## Afterword

This program was made to making work eazyer in my other project. It will have updates if I think I need new features.
