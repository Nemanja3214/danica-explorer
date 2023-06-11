using System;

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
        this._dragVm = new DragNDropViewModel("Hotels");

    }

}