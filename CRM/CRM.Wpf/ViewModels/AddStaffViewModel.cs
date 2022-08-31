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
    public class AddStaffViewModel : Default
    {
        #region Definitions

        string name = string.Empty, surname = string.Empty, lastname = string.Empty;
        DateTime birthdate = DateTime.Now, hireddate = DateTime.Now;
        decimal money = 0.0M;
        Post? post;
        readonly ObservableAsPropertyHelper<bool> acceptAllowed;

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => this.RaiseAndSetIfChanged(ref surname, value);
        }

        public string Lastname
        {
            get => lastname;
            set => this.RaiseAndSetIfChanged(ref lastname, value);
        }

        public DateTime Birthdate
        {
            get => birthdate;
            set => this.RaiseAndSetIfChanged(ref birthdate, value);
        }

        public DateTime Hireddate
        {
            get => hireddate;
            set => this.RaiseAndSetIfChanged(ref hireddate, value);
        }

        public decimal Money
        {
            get => money;
            set => this.RaiseAndSetIfChanged(ref money, value);
        }

        public Post? Post
        {
            get => post;
            set => this.RaiseAndSetIfChanged(ref post, value);
        }

        public ObservableCollectionExtended<Post> Posts { get; }

        public bool AcceptAllowed => acceptAllowed.Value;

        public Staff? CreatedStaff;

        #endregion

        #region Auxiliary methods

        public override void Accept(Window window)
        {
            CreatedStaff = new Staff(0, Name, Surname, Lastname, Birthdate, Hireddate, Post ?? new Post(), Money);
            base.Accept(window);
        }

        #endregion

        public AddStaffViewModel()
        {
            acceptAllowed = this.WhenAnyValue(
                                    vm => vm.Name, 
                                    vm => vm.Surname, 
                                    vm => vm.Lastname, 
                                    vm => vm.Hireddate, 
                                    vm => vm.Birthdate, 
                                    vm => vm.Money, 
                                    vm => vm.Post)
                                .Select(
                                    tuple => !string.IsNullOrEmpty(tuple.Item1) && 
                                    !string.IsNullOrEmpty(tuple.Item2) && 
                                    !string.IsNullOrEmpty(tuple.Item3) && 
                                    tuple.Item4 <= DateTime.Now && 
                                    tuple.Item5 <= DateTime.Now && 
                                    tuple.Item5 < tuple.Item4 && 
                                    tuple.Item6 >= 0 && 
                                    tuple.Item7 != null)
                                .ToProperty(this, vm => vm.AcceptAllowed);

            Posts = new ObservableCollectionExtended<Post>();
            Posts.ToObservableChangeSet()
                 .Subscribe();

            Posts.Add(new Post(1, "манагер"));
            Posts.Add(new Post(2, "админ"));

            Post = Posts.First();
        }
    }
}
