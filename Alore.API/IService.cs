namespace Alore.API
{
    public interface IService
    {
        void Initialize(IControllerContext context);

        void AddEvents(IEventProvider eventProvider, IControllerContext controllerContext);
    }
}