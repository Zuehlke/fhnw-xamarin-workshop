using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Mvx.Exercises.ViewModels;

namespace Mvx.Exercises
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {           
            ShowViewModel<MainViewModel>();
        }
    }
}
