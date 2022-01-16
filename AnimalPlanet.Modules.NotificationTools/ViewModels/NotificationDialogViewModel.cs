using AnimalPlanet.Core;
using AnimalPlanet.Modules.NotificationTools.ViewModels.Base;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels
{
    /// <summary>
    /// Модель диалогового окна ошибок
    /// </summary>
    internal class NotificationDialogViewModel : DialogViewModel
    {
        private string _message;
        /// <summary>
        /// Информационное сообщение
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _closeDialogCommand;
        /// <summary>
        /// Закрывает диалоговое окно
        /// </summary>
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
