using app.Views;
using Avalonia.Controls;

namespace app.ViewModels;

public class AccomodationCreateViewModel
{
    private readonly Window _parent;

    public AccomodationCreateViewModel(Window parent)
    {
        _parent = parent;
        Uvm = new UploadViewModel(_parent);
    }

    public UploadViewModel Uvm { get; set; }
}