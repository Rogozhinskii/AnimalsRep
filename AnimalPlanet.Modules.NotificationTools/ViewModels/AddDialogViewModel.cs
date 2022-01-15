using AnimalPlanet.Core;
using AnimalPlanet.Modules.NotificationTools.ViewModels.Base;
using AnimalsLib;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels
{
    internal class AddDialogViewModel:DialogViewModel
    {
        private readonly IAnimalFactory _animalFactory;
        public string Name {get;set;}
        public string AnimalFamily { get; set; }
        public string AnimalKind { get; set; }
        public AnimalSquard AnimalSquard { get; set; }
        public bool IsExtinct { get; set; }

        public AddDialogViewModel(IAnimalFactory animalFactory)
        {
            _animalFactory = animalFactory;
        }

        private DelegateCommand _saveNewAnimalCommand;
        /// <summary>
        /// Выполняет сохранение изменений
        /// </summary>
        public DelegateCommand SaveNewAnimalCommand =>
           _saveNewAnimalCommand ??= _saveNewAnimalCommand = new(() =>
           {
               var newAnimal=_animalFactory.GetAnimal(Name,AnimalFamily,AnimalKind,IsExtinct);
               DialogResult result = new DialogResult(ButtonResult.OK);
               result.Parameters.Add(CommonTypesPrism.Editableobject,newAnimal);
               RaiseRequestClose(result);
           });

        private DelegateCommand _cancelCommand;
        

        /// <summary>
        /// Отменяет изменения и закрывает диалоговое окно
        /// </summary>
        public DelegateCommand CancelCommand =>
           _cancelCommand ??= _cancelCommand = new(() =>
           {               
               var result = new DialogResult(ButtonResult.Cancel);
               RaiseRequestClose(result);
           });


    }
}
