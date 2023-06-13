using app.Commands;
using System.Windows.Input;
using app.Model;

namespace app.ViewModels;

public class ServiceCardViewModel : BaseViewModel
{
    private string _imageSource;

    public string ImageSource
    {
        get => _imageSource;
    }

    private string _serviceName;
    public string ServiceName
    {
        get => _serviceName;
        set => _serviceName = value;
    }

    public Service Service { get; set; }

    public ICommand LearnMoreCommand { get; }

    public ServiceCardViewModel()
    {
        //LearnMoreCommand = new AttractionDetailsCommand(this);
        _imageSource = "../Assets/tripimage.jpeg";
        _serviceName = "Sagrada familija";
    }

    public ServiceCardViewModel(Service service)
    {
        //LearnMoreCommand = new AttractionDetailsCommand(this);
        Service = service;
        _imageSource = "../Assets/tripimage.jpeg";
        _serviceName = service.Title;
    }

}