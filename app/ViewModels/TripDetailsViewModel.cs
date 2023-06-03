namespace app.ViewModels;

public class TripDetailsViewModel
{
    public TripDetailsViewModel()
    {
        Gvm = new GalleryViewModel();
    }

    public GalleryViewModel Gvm { get; set; }
}