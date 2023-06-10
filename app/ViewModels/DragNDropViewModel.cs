using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Models;

namespace app.ViewModels;

public class DragNDropViewModel
{
    public DragNDropViewModel()
    {
        _addedItems = new ObservableCollection<DragItem>
        {
            new DragItem()
            {
                Name = "asd",
            },
            new DragItem()
            {
                Name = "azxcaw",
            }
        };
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

    private ObservableCollection<DragItem> _addedItems;
    private ObservableCollection<DragItem> _optionItems;

    public ObservableCollection<DragItem> OptionItems
    {
        get => _optionItems;
        set => _optionItems = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ObservableCollection<DragItem> AddedItems
    {
        get => _addedItems;
        set => _addedItems = value ?? throw new ArgumentNullException(nameof(value));
    }

}