using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Todo> Todos { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "ToDo List";

            Todos = new ObservableCollection<Todo>();
            AddCommand = new DelegateCommand(() =>
            {
                Todos.Add(new Todo()
                {
                    Complete = false,
                    Description = DescriptionText
                });

                DescriptionText = string.Empty;
            });

        }

        public ICommand AddCommand { get; }

        private string _descriptionText;

        public string DescriptionText
        {
            get { return _descriptionText; }
            set { SetProperty(ref _descriptionText, value); }
        }

    }
}
