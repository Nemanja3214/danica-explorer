using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using app.DragNDrop;
using app.Models;
using app.Utils;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia.VisualTree;
using Mapsui.Extensions;
using Mapsui.Projections;
using ReactiveUI;

namespace app.ViewModels;

public class DragNDropViewModel
{
    public DragNDropViewModel(string title)
    {
        Title = title;
        _removeCommand = ReactiveCommand.Create<Button>((e) =>
        {
            DragItem dataObject = e.DataContext as DragItem;
            AddedItems.Remove(dataObject);
        });
        _optionItems = new ObservableCollection<DragItem>();
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
    public string _query;

    public string Query
    {
        get => _query;
        set{
            _query = value;
            UpdateSuggestions();
        }
    }

    public object Title { get; set; }

    private async void UpdateSuggestions()
    {
        List<DragItem> locations = await GetItems(_query);
        locations = locations.Except(AddedItems).ToList();

        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            OptionItems.Clear();
            int i = 0;
            foreach (var suggestion in locations)
            {
                if(i == 10)
                    break;
                OptionItems.Add(suggestion);
                i++;
            }
        });
    }

    // TODO simulation function delete
    private async static Task<List<DragItem>> GetItems(string query)
    {
        return new List<DragItem>()
        {
            new DragItem()
            {
            Name = "dqwd",
            },
            new DragItem()
            {
                Name = "azxcaw",
            }
        };
    }
}


