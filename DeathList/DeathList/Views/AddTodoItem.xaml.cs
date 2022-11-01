using DeathList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeathList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTodoItem : ContentPage
    {
        public AddTodoItem()
        {
            InitializeComponent();
            BindingContext = new AddTodoItemView(Navigation);
        }
    }
}