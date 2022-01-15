using AnimalPlanet.Core;
using AnimalPlanet.Modules.NotificationTools.ViewModels.Base;
using AnimalsLib;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels
{
    internal class EditDialogViewModel : DialogViewModel
    {
        public EditDialogViewModel()
        {
            Title = "Edit Dialog";
        }
        protected readonly Dictionary<string, object> _values = new();

        private IAnimal _orginalAnimal;

        public string Name { get => GetValue(_orginalAnimal?.Name); set => SetValue(value); }
        public string AnimalFamily { get => GetValue(_orginalAnimal?.AnimalFamily); set => SetValue(value); }
        public string AnimalKind { get => GetValue(_orginalAnimal?.AnimalKind); set => SetValue(value); }
        public AnimalSquard AnimalSquard { get => GetValue(_orginalAnimal.AnimalSquard); set => SetValue(value); }
        public bool IsExtinct { get => GetValue(_orginalAnimal.IsExtinct); set => SetValue(value); }


        public override void OnDialogOpened(IDialogParameters parameters)
        {
            _orginalAnimal = parameters.GetValue<IAnimal>(CommonTypesPrism.Editableobject);
            var type = this.GetType();
            var props = type.GetProperties();
            foreach (var item in props)
            {
                RaisePropertyChanged(item.Name);
            }
        }

        private DelegateCommand _saveChangesCommand;
        /// <summary>
        /// Выполняет сохранение изменений
        /// </summary>
        public DelegateCommand SaveChangesCommand =>
           _saveChangesCommand ??= _saveChangesCommand = new(() =>
           {
               SaveChanges(_orginalAnimal);
               DialogResult result = new DialogResult(ButtonResult.OK);
               RaiseRequestClose(result);
           });

        private DelegateCommand _cancelCommand;
        /// <summary>
        /// Отменяет изменения и закрывает диалоговое окно
        /// </summary>
        public DelegateCommand CancelCommand =>
           _cancelCommand ??= _cancelCommand = new(() =>
           {
               CancelChanges();
               var result = new DialogResult(ButtonResult.Cancel);
               RaiseRequestClose(result);
           });
       
        protected virtual bool SetValue(object value, [CallerMemberName] string property = null)
        {
            if (_values.TryGetValue(property, out var oldValue) && Equals(oldValue, value))
                return false;
            _values[property] = value;
            return true;
        }

        protected virtual T GetValue<T>(T Default, [CallerMemberName] string property = null)
        {
            if (_values.TryGetValue(property, out var value))
                return (T)value;
            return Default;
        }

        /// <summary>
        /// Сохраняет значения изменившихся свойств редактируемого объекта
        /// </summary>
        /// <param name="namedEntity"></param>
        protected void SaveChanges(IAnimal animal)
        {
            var type = animal.GetType();
            foreach (var (propertyName, value) in _values)
            {
                var property = type.GetProperty(propertyName);
                if (property is null || !property.CanWrite) continue;
                property.SetValue(animal, value);
            }
            _values.Clear();
        }

        /// <summary>
        /// Отменяет запланированные изменения
        /// </summary>
        protected void CancelChanges()
        {
            var properties = _values.Keys.ToArray();
            _values.Clear();
            foreach (var property in properties)
                RaisePropertyChanged(property);
        }
    }
}
