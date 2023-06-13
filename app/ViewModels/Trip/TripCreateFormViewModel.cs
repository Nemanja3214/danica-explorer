using ReactiveValidation;
using System;
using ReactiveValidation.Extensions;

namespace app.ViewModels;

public class TripCreateFormViewModel : BaseViewModel
{
    private string _title;

    public string Title
    {
        get => _title;
        set {
            _title = value;
            OnPropertyChanged(nameof(Title));
            IsButtonEnabled();
        }
    }

    public string Description
    {
        get => _description;
        set  { _description = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged(nameof(Description));
        }
}

    private string _description;
    public TripCreateFormViewModel()
    {
        //Title = "Naziv";
        //Description = "Opis";
        SelectedDate = DateTime.Now;
        Validator = GetValidator();
        //Price = 0;
    }

    private Double _price;
    private DateTime _selectedDate;
    private int _lasting;


    public double Price
    {
        get => _price;
        set { _price = value; 
        OnPropertyChanged(nameof(Price));
        IsButtonEnabled();
        }
}

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set { _selectedDate = value; 
        OnPropertyChanged(nameof(SelectedDate));
        IsButtonEnabled();
        }
}

    public int Lasting
    {
        get => _lasting;
        set { 
            _lasting = value; 
            OnPropertyChanged(nameof(Lasting));
            IsButtonEnabled();
        }
    }

    private IObjectValidator GetValidator()
    {
        var builder = new ValidationBuilder<TripCreateFormViewModel>();

        builder.RuleFor(vm => vm.Title)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .AllWhen(vm => vm.Title != null);

        builder.RuleFor(vm => vm.Price)
            .GreaterThan(0)
            .WithMessage("Cena mora biti pozitivna")
            .AllWhen(vm => vm.Price != null);

        builder.RuleFor(vm => vm.Lasting)
            .GreaterThan(0)
            .WithMessage("Trajanje mora biti pozitivno")
            .AllWhen(vm => vm.Lasting != null);

        builder.RuleFor(vm => vm.SelectedDate)
            .Must(checkDate)
            .WithMessage("Datum mora biti u buducnosti");

        //builder.RuleFor(vm => vm.Query)
        //    .Must(validLocation)
        //    .WithMessage("Obavezno polje")
        //    .AllWhen(vm => vm.SelectedLocation == null && vm.Query != null);

        return builder.Build(this);
    }

    private static bool checkDate(DateTime dateTime)
    {
        if (dateTime == null)
        {
            return false;
        }
        bool b = DateOnly.FromDateTime(dateTime).CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0;
        return b;
    }

    public bool ButtonEnabled { get; set; }

    public void IsButtonEnabled()
    {
        ButtonEnabled = Title != null && Title.Length > 0 && Price != null && Price > 0 && Lasting != null && Lasting > 0 && checkDate(SelectedDate);
        OnPropertyChanged(nameof(ButtonEnabled));
    }
}