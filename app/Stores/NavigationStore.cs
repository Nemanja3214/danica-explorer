using app.Model;
using app.ViewModels;

namespace app.Stores;
using System;


public class NavigationStore
{

    private static NavigationStore instance;
    
    public BaseViewModel _currentViewModel;
    public BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public User _currentUser;
    public User CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            OnCurrentUserChanged();
        }
    }

    public event Action CurrentViewModelChanged;
    public event Action CurrentUserChanged;

    protected NavigationStore()
    {
    }

    public static NavigationStore Instance()
    {
        if (instance is null)
        {
            instance = new NavigationStore();
        }
        return instance;
    }


    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
    
    
    private void OnCurrentUserChanged()
    {
        CurrentUserChanged?.Invoke();
    }

}
