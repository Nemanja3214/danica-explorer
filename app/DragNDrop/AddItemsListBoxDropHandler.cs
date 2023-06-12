using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.DragNDrop;
using app.Models;
using app.ViewModels;

namespace app.DragNDrop;

using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.DragAndDrop;

public class AddItemsListBoxDropHandler : DropHandlerBase
{
    private bool Validate<T>(ListBox listBox, DragEventArgs e, object? sourceContext, object? targetContext, bool bExecute) where T : Sightseeing    {
        if (sourceContext is not T sourceItem
            || targetContext is not DragNDropViewModel vm
            || listBox.GetVisualAt(e.GetPosition(listBox)) is not Control targetControl
             )
        {
            return false;
        }

        var targetItems = listBox.Items as ObservableCollection<Sightseeing>;
        var targetItem = targetControl.DataContext as T ;
        if (vm.AddedItems.Contains(targetItem) && vm.AddedItems.Contains(sourceItem))
            return handleShuffle(vm, sourceItem, targetItem, e, bExecute);
        else if ((vm.AddedItems.Contains(targetItem) && vm.OptionItems.Contains(sourceItem)) || (targetItem == null && vm.OptionItems.Contains(sourceItem)) )
            return handleAdding(vm, sourceItem, targetItem, targetItems, e, bExecute);
        else
            return false;

    }

    private bool handleAdding(DragNDropViewModel vm, Sightseeing sourceItem, Sightseeing targetItem,
        IList<Sightseeing> targetItems, DragEventArgs e, bool bExecute)
    {
        
        if ((targetItems.Contains(targetItem) && targetItems.Contains(sourceItem)) || targetItems.Equals(vm.OptionItems))
            return false;
        
        var sourceItems = vm.OptionItems;

        var sourceIndex = -1;
        var targetIndex = -1;
        if (sourceItems.Contains(sourceItem))
        {
            sourceIndex = sourceItems.IndexOf(sourceItem);
            targetIndex = targetItems.IndexOf(targetItem);
        }
        else
        {
            sourceIndex = sourceItems.IndexOf(targetItem);
            targetIndex = targetItems.IndexOf(sourceItem);
        }
        
        
        if (sourceIndex < 0)
        {
            return false;
        }

        if (targetItem == null)
            targetIndex = 0;
        
        switch (e.DragEffects)
        {
            case DragDropEffects.Move:
            {
                if (bExecute)
                {
                    MoveItem(sourceItems, targetItems, sourceIndex, targetIndex);
                }
                return true;
            }
            default:
                return false;
        }
    }

    private bool handleShuffle(DragNDropViewModel vm, Sightseeing sourceItem, Sightseeing targetItem, DragEventArgs e,
        bool bExecute)
    {
        var items = vm.AddedItems;

        var sourceIndex = -1;
        var targetIndex = -1;
        sourceIndex = items.IndexOf(targetItem);
        targetIndex = items.IndexOf(sourceItem);


        if (sourceIndex < 0 || targetIndex < 0)
        {
            return false;
        }

        switch (e.DragEffects)
        {
            case DragDropEffects.Move:
            {
                if (bExecute)
                {
                    MoveItem(items, sourceIndex, targetIndex);
                }

                return true;
            }
            default:
                return false;
        }
    }

    public override bool Validate(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return Validate<Sightseeing>(listBox, e, sourceContext, targetContext, true);
        }
        return false;
    }

    public override bool Execute(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return Validate<Sightseeing>(listBox, e, sourceContext, targetContext, true);
        }
        return false;
    }
}