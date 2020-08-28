using Prism;
using Prism.Ioc;
using TodoApp.ViewModels;
using TodoApp.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using LiteDB;
using Xamarin.Essentials;
using System.IO;
using TodoApp.Models;

namespace TodoApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            var db = new LiteDatabase(Path.Combine(FileSystem.AppDataDirectory, "TestDriveDb.db"));
            containerRegistry.RegisterInstance<ILiteDatabase>(db);

            DependencyService.RegisterSingleton<ILiteCollection<Todo>>(db.GetCollection<Todo>());
        }
    }
}
