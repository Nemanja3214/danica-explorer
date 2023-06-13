using System;

namespace app.ViewModels;

public class TripCreateFormViewModel : BaseViewModel
{
    private string _title;

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _description;
    public TripCreateFormViewModel()
    {
        Title = "Naziv";
        Description = "Opis";
        SelectedDate = DateTime.Now;
        Price = 0;
    }
    
    public DateTime SelectedDate { get; set; }
    public Double Price { get; set; }
    public int Lasting { get; set; }
}