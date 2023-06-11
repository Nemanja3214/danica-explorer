using System.Collections.ObjectModel;
using app.DragNDrop;
using app.Models;

namespace app.ViewModels;

using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.DragAndDrop;

public class AddItemsListBoxDropHandler : DropHandlerBase
{
    private bool Validate<T>(ListBox listBox, DragEventArgs e, object? sourceContext, object? targetContext, bool bExecute) where T : DragItem
    {
        if (sourceContext is not T sourceItem
            || targetContext is not RemoveContext vm
            || listBox.GetVisualAt(e.GetPosition(listBox)) is not Control targetControl
            || targetControl.DataContext is not T targetItem)
        {
            return false;
        }
        DragDrop.DoDragDrop()

        var targetItems = listBox.Items as ObservableCollection<DragItem>;
        // if ((targetItems.Contains(targetItem) && targetItems.Contains(sourceItem)) || targetItems.Equals(vm.OptionItems))
        //     return false;
        //
        // var sourceItems = vm.OptionItems;

        // var sourceIndex = -1;
        // var targetIndex = -1;
        // if (sourceItems.Contains(sourceItem))
        // {
        //     sourceIndex = sourceItems.IndexOf(sourceItem);
        //     targetIndex = targetItems.IndexOf(targetItem);
        // }
        // else
        // {
        //     sourceIndex = sourceItems.IndexOf(targetItem);
        //     targetIndex = targetItems.IndexOf(sourceItem);
        // }
        //
        //
        // if (sourceIndex < 0)
        // {
        //     return false;
        // }
        //
        // switch (e.DragEffects)
        // {
        //     case DragDropEffects.Move:
        //     {
        //         if (bExecute)
        //         {
        //             MoveItem(sourceItems, targetItems, sourceIndex, targetIndex);
        //         }
        //         return true;
        //     }
        //     default:
        //         return false;
        // }
        return false;
    }
        
    public override bool Validate(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return Validate<DragItem>(listBox, e, sourceContext, targetContext, true);
        }
        return false;
    }

    public override bool Execute(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return Validate<DragItem>(listBox, e, sourceContext, targetContext, true);
        }
        return false;
    }
}