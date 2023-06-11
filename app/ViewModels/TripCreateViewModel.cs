using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.ViewModels;

public class TripCreateViewModel
{
    private DragNDropViewModel _hotelVm;
    private DragNDropViewModel _restaurantVm;

    public DragNDropViewModel HotelVm
    {
        get => _hotelVm;
        set => _hotelVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DragNDropViewModel RestaurantVm
    {
        get => _restaurantVm;
        set => _restaurantVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TripCreateViewModel()
    {
        _hotelVm = new DragNDropViewModel("Hotels", GetHotelItems);
        _restaurantVm = new DragNDropViewModel("Restaurants", GetRestaurantItems);

    }
    
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetHotelItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Hotel()
            {
                Name = "dqwd",
            },
            new Hotel()
            {
                Name = "azxcaw",
            }
        };
    }
    
       
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetRestaurantItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Restaurant()
            {
                Name = "yutyu",
            },
            new Restaurant()
            {
                Name = "werw",
            }
        };
    }

}