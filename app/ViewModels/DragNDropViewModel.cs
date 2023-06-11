using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using app.DragNDrop;
using app.Models;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ReactiveUI;

namespace app.ViewModels;

public class DragNDropViewModel
{
    public DragNDropViewModel()
    {

        _removeCommand = ReactiveCommand.Create<Button>((e) =>
        {
            DragItem dataObject = e.DataContext as DragItem;
            AddedItems.Remove(dataObject);
        });
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

    public ReactiveCommand<Button, Unit> RemoveCommand => _removeCommand;
    private readonly ReactiveCommand<Button, Unit> _removeCommand;

    private ObservableCollection<DragItem> _optionItems;

    public ObservableCollection<DragItem> OptionItems
    {
        get => _optionItems;
        set => _optionItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private ObservableCollection<DragItem> _addedItems;


    public ObservableCollection<DragItem> AddedItems
    {
        get => _addedItems;
        set => _addedItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private DragItem _draggedItem;
    private bool _isDragging;

    
}


