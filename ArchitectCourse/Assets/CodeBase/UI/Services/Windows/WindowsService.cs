

public class WindowsService : IWindowsService
{
    private readonly UIFactory _UIFactory;

    public WindowsService(UIFactory uIFactory)
    {
        _UIFactory = uIFactory;
    }

    public void Open(WindowId window)
    {
        switch (window)
        {
            case WindowId.Unknow:
                break;
            case WindowId.Shop:
                _UIFactory.CreateShop();
                break;
        }

    }
}
