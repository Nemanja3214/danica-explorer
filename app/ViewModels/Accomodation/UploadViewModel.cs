using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using ReactiveUI;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using Image = System.Drawing.Image;
using Path = System.IO.Path;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace app.ViewModels;

public class UploadViewModel: BaseViewModel
{
    private string currentPath = "";
    private ReactiveCommand<Unit, Unit> upload;

    public ReactiveCommand<Unit, Unit> Upload
    {
        get => upload;
        set => upload = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Bitmap _image;

    public string? CurrentPath
    {
        get => currentPath;
        set => currentPath = value ?? throw new ArgumentNullException(nameof(value));
    }
    public Bitmap ImageToView { get => _image;   private set => this.RaiseAndSetIfChanged(ref _image, value); }

    public UploadViewModel()
    {
        upload = ReactiveCommand.Create(() =>
        {
            GetPath();
        });
        int width = 400;
        int length = 400;
        byte[] array = new byte[width * length * 4];
        for (int i = 0; i < array.Length; i++) {
            array[i] = i % 3 == 0 && i % 4 != 0 ? (byte)255 : (byte)105;
        }

        _image = CreateBitmapFromPixelData(array, width, length);
    }
    
    public static WriteableBitmap CreateBitmapFromPixelData(byte[] rgbPixelData, int width, int height)
    {
        Vector dpi = new Vector(96, 96);
        var bitmap = new WriteableBitmap(new PixelSize(width, height), dpi, Avalonia.Platform.PixelFormat.Rgba8888);
        using (var frameBuffer = bitmap.Lock())
        {
            Marshal.Copy(rgbPixelData, 0, frameBuffer.Address, rgbPixelData.Length);
        }
            
        
        return bitmap;
    }


    public Bitmap GetImage(string absolutePath)
    {
        using var fileStream = File.OpenRead(absolutePath);
        var bmp = new Bitmap(fileStream);
        return bmp;
    }
    
    public async Task GetPath()
    {
        // TODO add filters for files
        var dialog = new OpenFileDialog();
        var result = await dialog.ShowAsync(MainWindowViewModel.GetMainWindow());

        if (result != null)
        {
            currentPath = result[0];
            ImageToView = GetImage(currentPath);
        }
    }
    
    public static byte[] ImageToByte(Bitmap img)
    {
        Byte[] data;

        using (var memoryStream = new MemoryStream())
        {
            img.Save(memoryStream);

            data = memoryStream.ToArray();
        }

        return data;
    }


}