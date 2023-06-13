using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using app.DragNDrop;
using app.Model;
using app.Utils;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
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
    public event EventHandler SelectionChanged;
    
    private Func<string, Task<List<ISigthSeeing>>> _getSuggestionsFunc;
    private ISigthSeeing _selected;

    public ISigthSeeing Selected
    {
        get => _selected;
        set
        {
            if (_selected == value)
                return;
            _selected= value;
            SelectionChanged.Invoke(_selected, new EventArgs());
        }
    }

    public DragNDropViewModel(string title, Func<string, Task<List<ISigthSeeing>>> updateFunc)
    {
        _getSuggestionsFunc = updateFunc;
        Title = title;
        _removeCommand = ReactiveCommand.Create<Button>((e) =>
        {
            ISigthSeeing dataObject = e.DataContext as ISigthSeeing;
            AddedItems.Remove(dataObject);
        });
        
        _selectCommand = ReactiveCommand.Create<ListBox>((e) =>
        {
            if (e?.ItemCount > 0)
            {
                SelectionModel<ISigthSeeing> selection = new SelectionModel<ISigthSeeing>();
                var selectedListBoxItem = (ListBoxItem)e.ItemContainerGenerator.ContainerFromIndex(0);
                selectedListBoxItem.Focus();

                selection.Select(0);
                e.Selection = selection;
            }
        });
        
        _moveCommand = ReactiveCommand.Create<ListBox>((e) =>
        {
            ISigthSeeing selected = e.SelectedItem as ISigthSeeing;
            AddedItems.Add(selected);
            OptionItems.Remove(selected);
        });
        _optionItems = new ObservableCollection<ISigthSeeing>();
        _addedItems = new ObservableCollection<ISigthSeeing>();
    }

    public ReactiveCommand<ListBox, Unit> MoveCommand => _moveCommand;

    public ReactiveCommand<Button, Unit> RemoveCommand => _removeCommand;
    private readonly ReactiveCommand<Button, Unit> _removeCommand;
    
    public ReactiveCommand<ListBox, Unit> SelectListBoxCommand => _selectCommand;
    private readonly ReactiveCommand<ListBox, Unit> _selectCommand;

    private ObservableCollection<ISigthSeeing> _optionItems;

    public ObservableCollection<ISigthSeeing> OptionItems
    {
        get => _optionItems;
        set => _optionItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private ObservableCollection<ISigthSeeing> _addedItems;


    public ObservableCollection<ISigthSeeing> AddedItems
    {
        get => _addedItems;
        set => _addedItems = value ?? throw new ArgumentNullException(nameof(value));
    }
    private ISigthSeeing _draggedItem;
    private bool _isDragging;
    public string _query;
    private readonly ReactiveCommand<ListBox, Unit> _dragNdropCommand;
    private readonly ReactiveCommand<ListBox, Unit> _moveCommand;

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
        List<ISigthSeeing> locations = await _getSuggestionsFunc(_query);
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


