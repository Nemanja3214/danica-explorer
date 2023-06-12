using app.Stores;

namespace app;

public class AppCore
{
    // private User _currentUser;
    // public User CurrentUser { get => _currentUser; set { _currentUser = value; } }

    private NavigationStore _navigation;
    
    private AppCore() { }
    
    private static AppCore s_instance = null;
    public static AppCore Instance()
    {
        if (s_instance is null)
        {
            s_instance = new AppCore();
        }
        return s_instance;
    }
    public static void SetInstance(AppCore instance)
    {
        if (s_instance is null)
        {
            s_instance = instance;
        }
    }

}
