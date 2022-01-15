using AnimalPlanet.Core;
using AnimalPlanet.Core.Interfaces;
using AnimalPlanet.Models;
using AnimalPlanet.Modules.NotificationTools;
using AnimalPlanet.Views;
using AnimalsLib;
using AnimalsLib.Factories;
using AnimalsLib.Interfaces;
using AnimalsLib.Repositories;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Threading;

namespace AnimalPlanet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        private IDialogService _dialogService;
        protected override Window CreateShell()
        {
            _dialogService = Container.Resolve<IDialogService>();
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            return Container.Resolve<MainWindow>();            
        }

        /// <summary>
        /// все не обработанные исключения будут идти сюда.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            DialogParameters dialogParameters = new()
            {
                { CommonTypesPrism.DialogMessage, e.Exception.Message }
            };
            _dialogService.ShowDialog(CommonTypesPrism.ErrorNotification, dialogParameters, result => { });
            e.Handled = true;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRepository<IAnimal>, AnimalRepository>()
                             .RegisterSingleton<ISquardsRepository<string>, SquardsRepository>()
                             .Register<IMainWindowModel, MainWindowModel>()
                             .Register<ISquardFactory, AnimalSquardFactory>()
                             .Register<IAnimalFactory, AnimalFactory>()
                             ;           
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NotificationToolsModule>();
        }
    }
}
