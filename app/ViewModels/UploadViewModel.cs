using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using Path = System.IO.Path;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace app.ViewModels;

public class UploadViewModel: ViewModelBase
{
    private string currentPath= @"avares://App/Assets/slika.jpg";

    public string CurrentPath
    {
        get => currentPath;
        set => currentPath = value ?? throw new ArgumentNullException(nameof(value));
    }
    public Bitmap ImageToView { get; set; }

    public UploadViewModel()
    {
        // var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        // ImageToView = new Bitmap(assets.Open(new Uri(currentPath)));
        ImageToView = GetImage(currentPath);
    }
    
    public Bitmap GetImage(string rawUri)
    {
        Uri uri;

        // Allow for assembly overrides
        if (rawUri.StartsWith("avares://"))
        {
            uri = new Uri(rawUri);
        }
        else
        {
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            uri = new Uri($"avares://{assemblyName}/{rawUri}");
        }

        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var asset = assets.Open(uri);

        return new Bitmap(asset);
    }


}