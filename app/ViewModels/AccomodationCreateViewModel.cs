using app.Views;

namespace app.ViewModels;

public class AccomodationCreateViewModel
{
    public AccomodationCreateViewModel()
    {
        Uvm = new UploadViewModel();
    }

    public UploadViewModel Uvm { get; set; }
}