using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.ViewModels;

public class TripCreateViewModel
{
    private DragNDropViewModel _dragVm;

    public DragNDropViewModel DragVm
    {
        get => _dragVm;
        set => _dragVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TripCreateViewModel()
    {
        this._dragVm = new DragNDropViewModel("Hotels", GetItems);

    }
    
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetItems(string query)
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

}