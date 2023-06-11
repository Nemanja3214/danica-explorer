using System;
using System.Collections.ObjectModel;
using app.Models;

namespace app.DragNDrop;

public class RemoveContext
{
    public RemoveContext()
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
    }

    private ObservableCollection<DragItem> _addedItems;


    public ObservableCollection<DragItem> AddedItems
    {
        get => _addedItems;
        set => _addedItems = value ?? throw new ArgumentNullException(nameof(value));
    }
}