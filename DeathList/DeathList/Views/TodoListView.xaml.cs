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
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();
            BindingContext = new TodoView(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as TodoView).RefreshTaskList();
        }

    }
}