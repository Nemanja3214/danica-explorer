using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;

namespace app.Utils;

public static class NominatimUtil
{
    private static bool queryActive = true;
    public static Task<IEnumerable<String>> GetLocations(string query, CancellationToken token)
    {
        queryActive = true;
        using (WebClient wc = new WebClient())
        {
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            wc.Headers.Add("Referer", "http://www.microsoft.com");
            return new Task<IEnumerable<string>>(() =>{
                var json = wc.DownloadData($"https://nominatim.openstreetmap.org/?q=subotica&format=json&limit=10&bounded=1&viewbox=18.471223,46.338158,23.682220,42.202836");
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<LocationDTO>));
                var rootObject = ser.ReadObject(new MemoryStream(json));
                try
                {
                    List<LocationDTO> locations = (List<LocationDTO>)rootObject;
                    return locations.Select(dto => dto.display_name).ToList();
                }
                catch(InvalidCastException e)
                {
                    return new List<String>();
                }
            });
        }
    }
}