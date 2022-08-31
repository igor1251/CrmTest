using CRM.Core.Models;
using CRM.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPostWindow.xaml
    /// </summary>
    public partial class AddPostWindow : Window
    {
        public AddPostWindow()
        {
            InitializeComponent();
        }

        public Post GetPost()
        {
            return ((AddPostViewModel)DataContext).CreatedPost ?? new Post();
        }
    }
}
