using System;
using Honeywell.Portable.Interfaces;
using Honeywell.Portable.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using BooksApp.Core.ViewModels;

namespace BooksApp.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<ISettingsService, SimpleFileSettingsService>();

            CheckAndSetAppStart();
        }

        private void CheckAndSetAppStart()
        {
            var settings = Mvx.Resolve<ISettingsService>();
            string user = settings.Get<string>("UserName")?.ToString();
            if(string.IsNullOrWhiteSpace(user))
            {
                settings.Set("UserName", "HansDampf");
                RegisterAppStart<LoginViewModel>();
                return;
            }

            RegisterAppStart<WelcomeViewModel>();
            // check for last active viewmodel
        }
    }
}
