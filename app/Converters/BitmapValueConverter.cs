﻿using System.IO;

namespace app.Converters;

using Avalonia;
using Avalonia.Markup;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;
using Avalonia.Data.Converters;
public class BitmapValueConverter : IValueConverter
{
    public static BitmapValueConverter Instance = new BitmapValueConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is string && targetType.IsAssignableFrom(typeof(Bitmap)))
            {
                var uri = new Uri((string)value, UriKind.RelativeOrAbsolute);
                var scheme = uri.IsAbsoluteUri ? uri.Scheme : "file";

                switch (scheme)
                {
                    case "file":
                        return new Bitmap((string)value);

                    default:
                        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                        return new Bitmap(assets.Open(uri));
                }
            }

            throw new NotSupportedException();
        }
        catch (FileNotFoundException)
        {

        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}