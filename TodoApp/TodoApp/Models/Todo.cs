using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    public class Todo : BindableBase
    {
        private bool _complete;
        private string _description;

        public string Description
        {
            get => _description;
            set { SetProperty(ref _description, value); }
        }
        public bool Complete
        {
            get => _complete;
            set { SetProperty(ref _complete, value); }
        }
    }
}
