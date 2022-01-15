using AnimalPlanet.Modules.NotificationTools.ViewModels;
using AnimalPlanet.Modules.NotificationTools.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace AnimalPlanet.Modules.NotificationTools
{
    public class NotificationToolsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<EditDialog, EditDialogViewModel>();
            containerRegistry.RegisterDialog<AddDialog, AddDialogViewModel>();
            containerRegistry.RegisterDialog<ErrorNotification, ErrorNotificationViewModel>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }
    }
}
