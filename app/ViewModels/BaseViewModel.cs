using System;
using System.ComponentModel;
using app.Model;
using app.Stores;
using ReactiveUI;
using ReactiveValidation;

namespace app.ViewModels;

public class BaseViewModel : ValidatableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public User CurrentUser => NavigationStore.Instance().CurrentUser;
    public bool IsSessionActive => CurrentUser != null;
    public bool IsSessionNotActive => CurrentUser == null;
    public bool IsAgentSessionActive => CurrentUser != null && CurrentUser.Isagent;
    public string WelcomeMessage => "";//"Dobrodošli, " + CurrentUser.Name + " !";
    
    public BaseViewModel()
    {
        NavigationStore.Instance().CurrentUserChanged += OnCurrentUserChanged;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private void OnCurrentUserChanged()
    {
        OnPropertyChanged(nameof(CurrentUser));
        OnPropertyChanged(nameof(IsSessionActive));
        OnPropertyChanged(nameof(IsSessionNotActive));
        OnPropertyChanged(nameof(IsAgentSessionActive));
        OnPropertyChanged(nameof(WelcomeMessage));
    }
}
