using LiteDB;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TodoApp.Models
{
    public class Todo : BindableBase
    {
        private bool _complete;
        private string _description;


        public Todo() { }

        [BsonId]
        public int Id { get; set; }

        public string Description
        {
            get => _description;
            set { SetProperty(ref _description, value); }
        }
        public bool Complete
        {
            get => _complete;
            set {
                SetProperty(ref _complete, value);

                if (!string.IsNullOrWhiteSpace(Description))
                    DependencyService.Get<ILiteCollection<Todo>>().Upsert(this);
            }
        }
    }
}
