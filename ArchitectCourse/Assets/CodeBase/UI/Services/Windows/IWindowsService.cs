using Assets.CodeBase.Infrastructure.AllServices;


public interface IWindowsService : IService
{
    void Open(WindowId windowId);
}