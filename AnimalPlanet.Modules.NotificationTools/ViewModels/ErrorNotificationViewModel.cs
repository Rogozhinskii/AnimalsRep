using AnimalPlanet.Core;
using AnimalPlanet.Modules.NotificationTools.ViewModels.Base;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels
{
    internal class ErrorNotificationViewModel:DialogViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _closeDialogCommand;

        public DelegateCommand CloseDialogCommand =>
           _closeDialogCommand ??= _closeDialogCommand = new(() =>
           {
               DialogResult result = new(ButtonResult.OK);
               RaiseRequestClose(result);
           });
       
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>(CommonTypesPrism.DialogMessage);
        }
    }
}
