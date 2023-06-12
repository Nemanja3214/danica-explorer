using System;
using System.ComponentModel;
using ReactiveUI;
using ReactiveValidation;

namespace app.ViewModels;

public class BaseViewModel : ValidatableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
