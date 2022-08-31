using CRM.Core.Models;
using CRM.Core.Services;
using CRM.Wpf.Views;
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
    public class AddDepartmentViewModel : Default
    {
        #region Definitions

        string name = string.Empty;
        Staff? master;
        readonly ObservableAsPropertyHelper<bool> acceptAllowed;

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public bool AcceptAllowed => acceptAllowed.Value;

        public Staff? Master
        {
            get => master;
            set => this.RaiseAndSetIfChanged(ref master, value);
        }

        public ObservableCollectionExtended<Staff> Staffs { get; }

        public Department? CreatedDepartment;

        #endregion

        #region Auxiliary methods

        public override void Accept(Window window)
        {
            CreatedDepartment = new Department(0, Name, Master ?? new Staff(), new List<Staff>());
            base.Accept(window);
        }

        #endregion

        public AddDepartmentViewModel()
        {
            acceptAllowed = this.WhenAnyValue(vm => vm.Name, vm => vm.Master)
                                .Select(
                                    tuple => !string.IsNullOrEmpty(tuple.Item1) &&
                                    tuple.Item2 != null)
                                .ToProperty(this, vm => vm.AcceptAllowed);
            
            Staffs = new ObservableCollectionExtended<Staff>();
            Staffs.ToObservableChangeSet()
                  .Subscribe();
        }
    }
}
