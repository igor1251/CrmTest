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
using System.Net;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace CRM.Wpf.ViewModels
{
    public class Default : ReactiveObject
    {
        ICommand? acceptCommand, cancelCommand;
        public ICommand? AcceptCommand => acceptCommand ??= ReactiveCommand.Create<Window>(Accept);
        public ICommand? CancelCommand => cancelCommand ??= ReactiveCommand.Create<Window>(Cancel);

        public virtual void Accept(Window window)
        {
            window.DialogResult = true;
        }

        public virtual void Cancel(Window window)
        {
            window.DialogResult = false;
        }
    }
}
