using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels.Base
{
    internal class DialogViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "";

        public void RaiseRequestClose(IDialogResult result)
        {
            RequestClose?.Invoke(result);
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() 
            => true;

        public void OnDialogClosed() { }

        public virtual void OnDialogOpened(IDialogParameters parameters) { }
    }
}
