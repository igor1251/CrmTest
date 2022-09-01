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
        ICommand? addCompanyCommand, addDepartmentCommand, addStaffCommand, addPostCommand, closeWindowCommand;

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

        public ICommand? CloseWindowCommand => closeWindowCommand ??= ReactiveCommand.Create<Window>(CloseWindow);
        public ICommand? AddCompanyCommand => addCompanyCommand ??= ReactiveCommand.CreateFromTask(AddCompany);
        public ICommand? AddDepartmentCommand => addDepartmentCommand ??= ReactiveCommand.CreateFromTask(AddDepartment);
        public ICommand? AddStaffCommand => addStaffCommand ??= ReactiveCommand.CreateFromTask(AddStaff);
        public ICommand? AddPostCommand => addPostCommand ??= ReactiveCommand.CreateFromTask(AddPost);

        #endregion

        #region Auxiliary methods

        async void Prepare()
        {
            await repo.InitRepoAsync();
            var data = await repo.LoadCompaniesAsync();
            if (data != null) Companies.AddRange(data);
        }

        void CloseWindow(Window window)
        {
            window.Close();
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

        async Task AddDepartment()
        {
            var dialog = new AddDepartmentWindow();
            var dialogResult = dialog.ShowDialog() ?? false;
            if (dialogResult)
            {
                var newDepartment = dialog.GetDepartment();
                await repo.InsertDepartmentAsync(newDepartment);
            }
        }

        async Task AddStaff()
        {
            var dialog = new AddStaffWindow();
            var dialogResult = dialog.ShowDialog() ?? false;
            if (dialogResult)
            {
                var newStaff = dialog.GetStaff();
                await repo.InsertStaffAsync(newStaff);
            }
        }

        async Task AddPost()
        {
            var dialog = new AddPostWindow();
            var dialogResult = dialog.ShowDialog() ?? false;
            if (dialogResult)
            {
                var newPost = dialog.GetPost();
                await repo.InsertPostAsync(newPost);
            }
        }

        #endregion

        #region Constructors

        public CrmViewModel()
        {
            Prepare();

            Companies = new ObservableCollectionExtended<Company>();
            Companies.ToObservableChangeSet()
                     .Subscribe();
        }

        #endregion
    }
}
