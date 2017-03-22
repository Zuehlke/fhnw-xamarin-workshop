using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using Mvx.Exercises.Services;

namespace Mvx.Exercises
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart(new AppStart());
        }
    }
}