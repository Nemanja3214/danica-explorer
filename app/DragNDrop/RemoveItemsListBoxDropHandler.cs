using System.Collections.ObjectModel;
using app.Models;
using app.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.DragAndDrop;

namespace app.DragNDrop;

public class RemoveItemsListBoxDropHandler : DropHandlerBase
{ 
        private bool Validate<T>(ListBox listBox, DragEventArgs e, object? sourceContext, object? targetContext, bool bExecute) where T : DragItem
    {
        if (sourceContext is not T sourceItem
            || targetContext is not DragNDropViewModel vm
            || listBox.GetVisualAt(e.GetPosition(listBox)) is not Control targetControl
            || targetControl.DataContext is not T targetItem)
        {
            return false;
        }

        var targetItems = listBox.Items as ObservableCollection<DragItem>;
        if (!targetItems.Equals(vm.AddedItems) || !targetItems.Contains(sourceItem))
            return false;
        
        var targetIndex = targetItems.IndexOf(targetItem);

        if (targetIndex < 0)
        {
            return false;
        }

        switch (e.DragEffects)
        {
            case DragDropEffects.Move:
            {
                if (bExecute)
                {
                    targetItems.RemoveAt(targetIndex);
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