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
    private Func<string, Task<List<Sightseeing>>> _getSuggestionsFunc;
    public DragNDropViewModel(string title, Func<string, Task<List<Sightseeing>>> updateFunc)
    {
        _getSuggestionsFunc = updateFunc;
        Title = title;
        _removeCommand = ReactiveCommand.Create<Button>((e) =>
        {
            Sightseeing dataObject = e.DataContext as Sightseeing;
            AddedItems.Remove(dataObject);
        });
        _optionItems = new ObservableCollection<Sightseeing>();
        _addedItems = new ObservableCollection<Sightseeing>();
        _addedItems.Add(new Attraction()
        {
            Name = "asdqw"
        });
    }

    public ReactiveCommand<Button, Unit> RemoveCommand => _removeCommand;
    private readonly ReactiveCommand<Button, Unit> _removeCommand;

    private ObservableCollection<Sightseeing> _optionItems;

    public ObservableCollection<Sightseeing> OptionItems
    {
        get => _optionItems;
        set => _optionItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private ObservableCollection<Sightseeing> _addedItems;


    public ObservableCollection<Sightseeing> AddedItems
    {
        get => _addedItems;
        set => _addedItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private Sightseeing _draggedItem;
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
        List<Sightseeing> locations = await _getSuggestionsFunc(_query);
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
}

