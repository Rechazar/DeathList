using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using DeathList.Views;

namespace DeathList.Models
{
    public class TodoView : BaseFodyObservable
    {

        public TodoView(INavigation navigation)
        {
            _navigation = navigation;
            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
            AddItem = new Command(HandleAddItem);
        }

        private INavigation _navigation;
        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "Reapers To Do List";
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            //new TodoItem { Id = 0, Title = "Create First Todo", IsCompleted = true},
            //new TodoItem { Id = 1, Title = "Run a Marathon"},
            //new TodoItem { Id = 2, Title = "Create TodoXamarinForms blog post"},
        };

        private async Task<ILookup<string, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "Completed" : "Active");
        }

        public async Task RefreshTaskList()
        {
            GroupedTodoList = await GetGroupedTodoList();
        }

        public Command<TodoItem> Delete { get; set; }
        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            //Update displayed List
            GroupedTodoList = await GetGroupedTodoList();
        }

        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            //Update displayed List
            GroupedTodoList = await GetGroupedTodoList();
        }

        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AddTodoItem());
        }
    }
}
