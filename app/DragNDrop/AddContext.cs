using System;
using System.Collections.ObjectModel;
using app.Models;

namespace app.DragNDrop;

public class AddContext
{
    public AddContext()
    {
        _optionItems = new ObservableCollection<DragItem>
        {
            new DragItem()
            {
                Name = "uyiu",
            },
            new DragItem()
            {
                Name = "xzccxz",
            }
        };
    }

    private ObservableCollection<DragItem> _optionItems;

    public ObservableCollection<DragItem> OptionItems
    {
        get => _optionItems;
        set => _optionItems = value ?? throw new ArgumentNullException(nameof(value));
    }
}