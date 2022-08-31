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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRM.Wpf.ViewModels
{
    public class CrmViewModel : ReactiveObject
    {
        #region Definitions
        
        readonly CrmRepo repo = new();
        IDefault? selectedItem;
        ReactiveCommand<object, Unit>? closeWindowCommand;
        ICommand? addCompanyCommand, addDepartmentCommand, addStaffCommand;

        #endregion

        #region Properties

        public ObservableCollectionExtended<Company> Companies { get; }
        public IDefault? SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }

        #endregion

        #region Commands

        public ReactiveCommand<object, Unit> CloseWindowCommand => closeWindowCommand ??= ReactiveCommand.Create<object>(CloseWindow);
        public ICommand? AddCompanyCommand => addCompanyCommand ??= ReactiveCommand.CreateFromTask(AddCompany);
        public ICommand? AddDepartmentCommand => addDepartmentCommand ??= ReactiveCommand.Create(AddDepartment);
        public ICommand? AddStaffCommand => addStaffCommand ??= ReactiveCommand.Create(AddStaff);

        #endregion

        #region Auxiliary methods

        async void PrepareServices()
        {
            await repo.InitRepoAsync();
        }

        void CloseWindow(object window)
        {
            ((Window)window).Close();
        }

        async Task AddCompany()
        {
            var dialog = new AddCompanyWindow();
            var dialogResult = dialog.ShowDialog() ?? false;
            if (dialogResult)
            {
                var newCompany = dialog.GetCompany();
                await repo.InsertCompanyAsync(newCompany);
            }
        }

        void AddDepartment()
        {
            MessageBox.Show("Add department clicked");
        }

        void AddStaff()
        {
            MessageBox.Show("Add staff clicked");
        }

        #endregion

        #region Constructors

        public CrmViewModel()
        {
            PrepareServices();

            Companies = new ObservableCollectionExtended<Company>();
            Companies.ToObservableChangeSet()
                     .Subscribe();

            List<Staff> slaves = new()
            {
                new Staff(1, "test", "test", "test", DateTime.Today, DateTime.Today, null, 0),
                new Staff(2, "test1", "test1", "test1", DateTime.Today, DateTime.Today, null, 0),
            };

            List<Staff> slaves2 = new()
            {
                new Staff(1, "test2", "test2", "test2", DateTime.Today, DateTime.Today, null, 0),
                new Staff(2, "test3", "test3", "test3", DateTime.Today, DateTime.Today, null, 0),
                new Staff(2, "test4", "test4", "test4", DateTime.Today, DateTime.Today, null, 0),
                new Staff(2, "test4", "test5", "test5", DateTime.Today, DateTime.Today, null, 0),
            };

            List<Department> departments = new()
            {
                new Department(1, "dep1", slaves.First(), slaves),
                new Department(2, "dep2", slaves2.First(), slaves2),
            };

            Companies.Add(new Company(1, "test", DateTime.Today, "-", departments));
        }

        #endregion
    }
}
