using System.Text.RegularExpressions;
using System.Windows.Input;
using app.Commands;
using app.Commands.Auth;
using app.Stores;
using ReactiveValidation;
using ReactiveValidation.Extensions;

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
            LoginValidate();
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Password
    {
        get => password;
        set
        {
            password = value;
            LoginValidate();
            OnPropertyChanged(nameof(Password));
        }
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            RegisterValidate();
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Phone
    {
        get => phone;
        set
        {
            phone = value;
            RegisterValidate();
            OnPropertyChanged(nameof(Phone));
        }
    }

    public string RegEmail
    {
        get => regEmail;
        set
        {
            regEmail = value;
            RegisterValidate();
            OnPropertyChanged(nameof(RegEmail));
        }
    }

    public string RegPassword
    {
        get => regPassword;
        set
        {
            regPassword = value;
            RegisterValidate();
            OnPropertyChanged(nameof(RegPassword));
        }
    }

    public bool IsLoginButtonEnabled { get; set; }
    public bool IsRegisterButtonEnabled { get; set; }

    private void LoginValidate()
    {
        IsLoginButtonEnabled = Email != null && Password != null && Password.Length >= 8 && Regex.IsMatch(Email, "[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        OnPropertyChanged(nameof(IsLoginButtonEnabled));
    }

    private void RegisterValidate()
    {
        IsRegisterButtonEnabled = RegEmail != null && RegPassword != null && regPassword.Length >= 8 && Regex.IsMatch(regEmail, "[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")
            && Name != null && Name.Length > 0 && Phone != null && Regex.IsMatch(Phone, "^\\d{1,12}$");
        OnPropertyChanged(nameof(IsRegisterButtonEnabled));
    }

    public BaseCommand LoginCommand { get; }
    public BaseCommand RegisterCommand { get; }

    public AuthViewModel()
    {
        LoginCommand = new LoginCommand(this);
        RegisterCommand = new RegisterCommand(this);
        Validator = GetValidator();
    }

    private IObjectValidator GetValidator()
    {
        var builder = new ValidationBuilder<AuthViewModel>();

        builder.RuleFor(vm => vm.Name)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .AllWhen(vm => vm.Name != null);

        builder.RuleFor(vm => vm.Email)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
            .WithMessage("Email nije u validnom obliku")
            .AllWhen(vm => vm.Email != null);

        builder.RuleFor(vm => vm.Password)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .MinLength(8)
            .WithMessage("Lozinka mora imati minimum 8 karaktera")
            .When(vm => vm.Password.Length > 0)
            .AllWhen(vm => vm.Password != null);

        builder.RuleFor(vm => vm.RegEmail)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
            .WithMessage("Email nije u validnom obliku")
            .AllWhen(vm => vm.RegEmail != null);

        builder.RuleFor(vm => vm.RegPassword)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .MinLength(8)
            .WithMessage("Lozinka mora imati minimum 8 karaktera")
            .When(vm => vm.RegPassword.Length > 0)
            .AllWhen(vm => vm.RegPassword != null);

        builder.RuleFor(vm => vm.Phone)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .Matches(@"^\d{1,12}$")
            .WithMessage("Telefon mora sadrzati samo brojeve")
            .AllWhen(vm => vm.Phone != null);

        return builder.Build(this);
    }
}