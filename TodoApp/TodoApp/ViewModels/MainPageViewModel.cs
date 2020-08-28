using LiteDB;
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
        private readonly ILiteDatabase _liteDatabase;



        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ILiteDatabase liteDatabase)
            : base(navigationService, pageDialogService)
        {
            Title = "ToDo List";

            Todos = new ObservableCollection<Todo>();
            this._liteDatabase = liteDatabase;
        }

        public override void OnAppearing()
        {
            var l = _liteDatabase.GetCollection<Todo>().FindAll();
            foreach (var item in l)
            {
                Todos.Add(item);
            }
        }

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand =>
            _addCommand ?? (_addCommand = new DelegateCommand(ExecuteAddCommand));

        void ExecuteAddCommand()
        {
            var newtodo = new Todo()
            {
                Complete = false,
                Description = DescriptionText
            };

            Todos.Add(newtodo);

            _liteDatabase.GetCollection<Todo>().Upsert(newtodo);

            DescriptionText = string.Empty;
        }

        private string _descriptionText;

        public string DescriptionText
        {
            get { return _descriptionText; }
            set { SetProperty(ref _descriptionText, value); }
        }

    }
}
