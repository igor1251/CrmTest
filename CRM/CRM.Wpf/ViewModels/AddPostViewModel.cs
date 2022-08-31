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
    public class AddPostViewModel : Default
    {
        #region Definitions

        string name = string.Empty;
        readonly ObservableAsPropertyHelper<bool> acceptAllowed;

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public bool AcceptAllowed => acceptAllowed.Value;

        public Post? CreatedPost;

        #endregion

        #region Auxiliary methods

        public override void Accept(Window window)
        {
            CreatedPost = new Post(0, Name);
            base.Accept(window);
        }

        #endregion

        public AddPostViewModel()
        {
            acceptAllowed = this.WhenAnyValue(vm => vm.Name)
                                .Select(val => !string.IsNullOrEmpty(val))
                                .ToProperty(this, vm => vm.AcceptAllowed);
        }
    }
}
