using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Todo> Todos { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Main Page";

            Todos = new ObservableCollection<Todo>
            {
                new Todo()
                {
                    Complete = false,
                    Description = "todo 01"
                },
                new Todo()
                {
                    Complete = true,
                    Description = "todo 02"
                },
                new Todo()
                {
                    Complete = false,
                    Description = "todo com nome longo 3"
                },
                new Todo()
                {
                    Complete = false,
                    Description = "todo 04"
                },
            };
        }
    }
}
