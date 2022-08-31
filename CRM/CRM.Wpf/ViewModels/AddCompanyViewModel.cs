using CRM.Core.Models;
using CRM.Core.Services;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRM.Wpf.ViewModels
{
    public class AddCompanyViewModel : ReactiveObject
    {
        #region Definitions
        
        string address = string.Empty, name = string.Empty;
        DateTime selectedDate = DateTime.Today;
        readonly ObservableAsPropertyHelper<bool> acceptAllowed;
        ICommand? acceptCommand, cancelCommand;

        #endregion

        #region Properties

        public string Address
        {
            get => address;
            set => this.RaiseAndSetIfChanged(ref address, value);
        }

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public DateTime SelectedDate
        {
            get => selectedDate;
            set => this.RaiseAndSetIfChanged(ref selectedDate, value);
        }

        public bool AcceptAllowed => acceptAllowed.Value;

        public Company? CreatedCompany;

        #endregion

        #region Commands

        public ICommand? AcceptCommand => acceptCommand ??= ReactiveCommand.Create<Window>(Accept);
        public ICommand? CancelCommand => cancelCommand ??= ReactiveCommand.Create<Window>(Cancel);

        #endregion

        #region Auxiliary methods

        void Accept(Window window)
        {
            CreatedCompany = new Company(0, Name, SelectedDate, Address, new List<Department>());
            window.DialogResult = true;
        }

        void Cancel(Window window)
        {
            window.DialogResult = false;
        }

        #endregion

        public AddCompanyViewModel()
        {
            acceptAllowed = this.WhenAnyValue(vm => vm.Address, vm => vm.Name, vm => vm.SelectedDate)
                                .Select(tuple => !string.IsNullOrEmpty(tuple.Item1) && !string.IsNullOrEmpty(tuple.Item2) && tuple.Item3 <= DateTime.Now)
                                .ToProperty(this, vm => vm.AcceptAllowed);
        }
    }
}
