using System;

namespace app.ViewModels;

public class TripCreateFormViewModel : BaseViewModel
{
    private string _title;

    public string Title
    {
        get => _title;
        set { _title = value ?? throw new ArgumentNullException(nameof(value)); OnPropertyChanged(nameof(Title)); }
    }

    public string Description
    {
        get => _description;
        set  { _description = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged(nameof(value));
        }
}

    private string _description;
    public TripCreateFormViewModel()
    {
        Title = "Naziv";
        Description = "Opis";
        SelectedDate = DateTime.Now;
        Price = 0;
    }

    private Double _price;
    private DateTime _selectedDate;
    private int _lasting;


    public double Price
    {
        get => _price;
        set { _price = value; 
        OnPropertyChanged(nameof(value));
    }
}

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set { _selectedDate = value; 
        OnPropertyChanged(nameof(value));
    }
}

    public int Lasting
    {
        get => _lasting;
        set { _lasting = value; 
        OnPropertyChanged(nameof(value));
    }
}
}