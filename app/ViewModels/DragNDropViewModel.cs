using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
    
    
    // private async void DoDrag(object sender, Avalonia.Input.PointerPressedEventArgs e)
    // {
    //     Debug.WriteLine("DoDrag");
    //     DataObject dragData = new DataObject();
    //     dragData.Set(DataFormats.Text, $"You have dragged");
    //
    //     var result = await DragDrop.DoDragDrop(e, dragData, DragDropEffects.Copy);
    //     switch (result)
    //     {
    //         case DragDropEffects.Copy:
    //             Console.WriteLine("The text was copied"); break;
    //         case DragDropEffects.Link:
    //             Console.WriteLine("The text was linked"); break;
    //         case DragDropEffects.None:
    //             Console.WriteLine("The drag operation was canceled"); break;
    //     }
    // }
    //
    // private void DragOver(object sender, DragEventArgs e)
    // {
    //     Debug.WriteLine("DragOver");
    //     // Only allow Copy or Link as Drop Operations.
    //     e.DragEffects = e.DragEffects & (DragDropEffects.Copy | DragDropEffects.Link);
    //
    //     // Only allow if the dragged data contains text or filenames.
    //     if (!e.Data.Contains(DataFormats.Text) && !e.Data.Contains(DataFormats.FileNames))
    //         e.DragEffects = DragDropEffects.None;
    // }
    //
    // private void Drop(object sender, DragEventArgs e)
    // {
    //     Debug.WriteLine("Drop");
    //     if (e.Data.Contains(DataFormats.Text))
    //         Console.WriteLine(e.Data.GetText());
    //     else if (e.Data.Contains(DataFormats.FileNames))
    //         Console.WriteLine(string.Join(Environment.NewLine, e.Data.GetFileNames()));
    // }
    

    // private void OnDragLeave(object sender, RoutedEventArgs e)
    // {
    //     // Clear any visual cues or effects when leaving the ListBox
    // }
    //
    // private void OnDragEnter(object sender, RoutedEventArgs e)
    // {
    //     // Apply visual cues or effects when entering the ListBox
    // }
    //
    // private bool _isSourceListBoxDragOver = false;
    //
    // public bool IsSourceListBoxDragOver
    // {
    //     get => _isSourceListBoxDragOver;
    //     set =>  _isSourceListBoxDragOver = value;
    // }
    //
    //
    // private bool _isTargetListBoxDragOver = false;
    //
    // public bool IsTargetListBoxDragOver
    // {
    //     get => _isTargetListBoxDragOver;
    //     set => _isTargetListBoxDragOver = value;
    // }
    //
    // public void OnDragOver(object sender, DragEventArgs e)
    // {
    //     Console.WriteLine("Drag over");
    //     e.DragEffects = DragDropEffects.Copy | DragDropEffects.Move;
    //     e.Handled = true;
    // }
    //
    //
    // private void OnDrop(object sender, DragEventArgs e)
    // {
    //     Console.WriteLine("Drop");
    //     if (e.Source is ListBoxItem targetItem && targetItem.DataContext is DragItem targetObject)
    //     {
    //         if (e.Data.Contains(CustomDataFormats.YourCustomFormat) && e.Data.Get(CustomDataFormats.YourCustomFormat) is DragItem sourceObject)
    //         {
    //             var listBox = (ListBox)sender;
    //             var sourceItems = listBox.Items.Cast<DragItem>().ToList();
    //             var targetItems = listBox.Items as IList<DragItem>;
    //
    //             // Perform the necessary logic to move or reorder the items within the collection
    //             int sourceIndex = sourceItems.IndexOf(sourceObject);
    //             int targetIndex = targetItems.IndexOf(targetObject);
    //
    //             // Remove the item from the source position
    //             sourceItems.RemoveAt(sourceIndex);
    //
    //             // Adjust the target index if the item is moving within the same ListBox
    //             if (sourceIndex < targetIndex)
    //             {
    //                 targetIndex--;
    //             }
    //
    //             // Insert the item at the target position
    //             targetItems.Insert(targetIndex, sourceObject);
    //         }
    //     }
    // }
    //
    // private void OnPointerMoved(object sender, PointerEventArgs e)
    // {
    //     // Update the cursor or any visual cues during the drag operation
    // }
    //
    //
    // public static class CustomDataFormats
    // {
    //     public static readonly string YourCustomFormat = "serializable";
    // }
    private DragItem _draggedItem;
    private bool _isDragging;

    public void SourceListBox_PreviewMouseMove(object sender, PointerEventArgs e)
        {
            Console.WriteLine("SourceListBox_PreviewMouseMove");
            if (_isDragging && _draggedItem != null && e.GetCurrentPoint(sender as IVisual).Properties.IsLeftButtonPressed)
            {
                ListBox listBox = sender as ListBox;
                DragDropEffects effects = DragDropEffects.Copy;
                var dataObject = new DataObject();
                dataObject.Set("DraggedItem", _draggedItem);
                DragDrop.DoDragDrop(e, dataObject, effects);
            }
        }

        public void TargetListBox_PreviewMouseMove(object sender, PointerEventArgs e)
        {
            Console.WriteLine("TargetListBox_PreviewMouseMove");
            if (_isDragging && _draggedItem != null && e.GetCurrentPoint(sender as IVisual).Properties.IsLeftButtonPressed)
            {
                ListBox listBox = sender as ListBox;
                DragDropEffects effects = DragDropEffects.Copy;
                var dataObject = new DataObject();
                dataObject.Set("DraggedItem", _draggedItem);
                DragDrop.DoDragDrop(e, dataObject, effects);
            }
        }

        public void SourceListBox_PreviewMouseUp(object sender, PointerReleasedEventArgs e)
        {
            Console.WriteLine("SourceListBox_PreviewMouseUp");
            _isDragging = false;
            _draggedItem = null;
        }

        public void TargetListBox_PreviewMouseUp(object sender, PointerReleasedEventArgs e)
        {
            Console.WriteLine("TargetListBox_PreviewMouseUp");
            _isDragging = false;
            _draggedItem = null;
        }

        // public void SourceListBox_Drop(object sender, DragEventArgs e)
        // {
        //     Console.WriteLine("SourceListBox_Drop");
        //     ListBox listBox = (ListBox)sender;
        //     DragItem draggedItem = e.Data.Get("DraggedItem") as DragItem;
        //     if (draggedItem != null && listBox != null)
        //     {
        //         if (listBox.Items.Equals(AddedItems))
        //             AddedItems.Remove(draggedItem);
        //         else if (listBox.Items.Equals(OptionItems))
        //             OptionItems.Remove(draggedItem);
        //     }
        // }
        //
        // public void TargetListBox_Drop(object sender, DragEventArgs e)
        // {
        //     Console.WriteLine("TargetListBox_Drop");
        //     ListBox listBox = (ListBox)sender;
        //     DragItem draggedItem = e.Data.Get("DraggedItem") as DragItem;
        //     if (draggedItem != null && listBox != null)
        //     {
        //         if (listBox.Items.Equals(AddedItems))
        //             AddedItems.Remove(draggedItem);
        //         else if (listBox.Items.Equals(OptionItems))
        //             OptionItems.Remove(draggedItem);
        //     }
        // }
    }


