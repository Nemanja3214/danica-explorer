using System.Windows.Input;
using app.Commands;
using app.Commands.Auth;
using app.Stores;

namespace app.ViewModels;

public class AuthViewModel : BaseViewModel
{
    private string email;
    private string password;
    private string name;
    private string phone;
    private string regEmail;
    private string regPassword;

    public string Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Password
    {
        get => password;
        set
        {
            password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Phone
    {
        get => phone;
        set
        {
            phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    public string RegEmail
    {
        get => regEmail;
        set
        {
            regEmail = value;
            OnPropertyChanged(nameof(RegEmail));
        }
    }

    public string RegPassword
    {
        get => regPassword;
        set
        {
            regPassword = value;
            OnPropertyChanged(nameof(RegPassword));
        }
    }

    public BaseCommand LoginCommand { get; }
    public BaseCommand RegisterCommand { get; }

    public AuthViewModel()
    {
        LoginCommand = new LoginCommand(this);
        RegisterCommand = new RegisterCommand(this);
    }
}