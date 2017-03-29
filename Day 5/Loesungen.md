# Aufgabe Day 5 Mvvm mit Mvvm Cross

## Aufgabe 1: Projekt initialisieren 

### Im Android Projekt

Setup.cs
```csharp
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Platform;

namespace Mvx.Exercises.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new MvxDebugTrace();
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}
```
Views\MainActivity
```csharp
using Android.App;
using MvvmCross.Droid.Views;
using Mvx.Exercises.ViewModels;

namespace Mvx.Exercises.Droid.Views
{
    [Activity(Label = "Mvvm with Mvx", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {

    }
}
```


### In der portable class library (PCL)
App.cs
```csharp
using MvvmCross.Core.ViewModels;

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
```
AppStart.cs
```csharp
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
```

ViewModels\MainViewModel.cs
```csharp
using MvvmCross.Core.ViewModels;

namespace Mvx.Exercises.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

    }
}
```

## Aufgabe 2: Databinding 

### Im Android Projekt 

Views\MainActivity
```csharp
using Android.App;
using MvvmCross.Droid.Views;
using Mvx.Exercises.ViewModels;

namespace Mvx.Exercises.Droid.Views
{
    [Activity(Label = "Mvvm with Mvx", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.Main);
        }
    }
}
```

Resources\Layout\Main.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.AndroidTest"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent">
    <EditText
        android:id="@+id/main_text"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text=""
        local:MvxBind="Text BindingDemo" />
    <TextView
        android:id="@+id/main_text_view"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text=""
        local:MvxBind="Text BindingDemo, Mode=OneWay" />
</LinearLayout>
```

### Im PCL Projekt 

ViewModels\MainViewModel.cs
```csharp
using MvvmCross.Core.ViewModels;

namespace Mvx.Exercises.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _bindingDemo;
        public string BindingDemo
        {
            get { return _bindingDemo; }
            set
            {
                _bindingDemo = value;
                // hier werden die changes ans UI gereicht
                RaisePropertyChanged();
            }
        }
    }
}
```

## Aufgabe 3: Commands 

### Im Android Projekt 

Views\MainActivity
```csharp
using Android.App;
using MvvmCross.Droid.Views;
using Mvx.Exercises.ViewModels;

namespace Mvx.Exercises.Droid.Views
{
    [Activity(Label = "Mvvm with Mvx", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.Main);
        }
    }
}
```

Resources\Layout\Main.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.AndroidTest"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent">
    <Button
        android:id="@+id/myButton"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text="@string/show_students"
        local:MvxBind="Click ShowStudentsCommand" />
    <EditText
        android:id="@+id/main_text"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text=""
        local:MvxBind="Text BindingDemo" />
    <TextView
        android:id="@+id/main_text_view"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text=""
        local:MvxBind="Text BindingDemo, Mode=OneWay" />
</LinearLayout>
```

### Im PCL Projekt 

ViewModels\MainViewModel.cs
```csharp
using System.Diagnostics;
using MvvmCross.Core.ViewModels;

namespace Mvx.Exercises.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _bindingDemo;

        public string BindingDemo
        {
            get { return _bindingDemo; }
            set
            {
                _bindingDemo = value;
                RaisePropertyChanged();
            }
        }

        public MvxCommand ShowStudentsCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("TEST XXX");
                });
            }
        }
    }
}
```

## Aufgabe 4: Navigation

### Im Android Projekt 

Views\StudentActivity.cs
```csharp
using Mvx.Exercises.ViewModels;

namespace Mvx.Exercises.Droid.Views
{
    [Activity(Label = "Student")]
    public class StudentActivity : MvxActivity<StudentViewModel>
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.Student);
        }
    }
}
```

Resources\Layout\Student.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
              xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.AndroidTest"
              android:orientation="vertical"
              android:layout_width="match_parent"
              android:layout_height="match_parent">
  <GridLayout
    android:orientation="horizontal"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:columnCount="2">
    <TextView
      android:text="Student Id"
      android:textAppearance="?android:attr/textAppearanceLarge"
      android:layout_width="wrap_content"
      android:layout_height="wrap_content"
      android:layout_column="0"
      android:id="@+id/textView1" />
    <TextView
      android:text="Large Text"
      android:textAppearance="?android:attr/textAppearanceLarge"
      android:layout_width="match_parent"
      android:layout_height="wrap_content"
      android:id="@+id/textView2"
      android:paddingLeft="50dp"
      android:layout_column="1"
      local:MvxBind="Text CurrentStudent.Id" />
  </GridLayout>
  <TextView
    android:text="Large Text"
    android:textAppearance="?android:attr/textAppearanceLarge"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:id="@+id/textView4"
    local:MvxBind="Text CurrentStudent.Name"
    android:paddingTop="20dp"
    android:paddingBottom="20dp" />
</LinearLayout>
```

### Im PCL Projekt 

ViewModels\MainViewModel.cs
```csharp
using System.Diagnostics;
using MvvmCross.Core.ViewModels;

namespace Mvx.Exercises.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        // ...

        public MvxCommand ShowStudentsCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<StudentViewModel>();
                });
            }
        }
    }
}
```
ViewModels\StudenViewModel.cs
```csharp
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using Mvx.Exercises.Models;
using Mvx.Exercises.Repositories;

namespace Mvx.Exercises.ViewModels
{
    public class StudentViewModel : MvxViewModel
    {
        private readonly IStudentRepository _studentRepository;
        private ObservableCollection<Course> _courses;

        private Student _currentStudent;

        public StudentViewModel()
        {
        }

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                RaisePropertyChanged();
            }
        }

        protected override async void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            CurrentStudent = new Student
            {
                Id = 2,
                Name = "Hausi Hinterseeher",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Id = 1,
                        Name = "Emoba",
                        Teacher = "someone"
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Other Course",
                        Teacher = "someone else"
                    }
                },
                Grades = new List<Grade>()
            }
        }
    }
}
```



## Aufgabe 5: ListViews für Courses

### Im Android Projekt 


Resources\Layout\Student.axml
```xml
<?xml version="1.0" encoding="utf-8"?>

<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
              xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.AndroidTest"
              android:orientation="vertical"
              android:layout_width="match_parent"
              android:layout_height="match_parent">
  <GridLayout
    android:orientation="horizontal"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:columnCount="2">
    <TextView
      android:text="Student Id"
      android:textAppearance="?android:attr/textAppearanceLarge"
      android:layout_width="wrap_content"
      android:layout_height="wrap_content"
      android:layout_column="0"
      android:id="@+id/textView1" />
    <TextView
      android:text="Large Text"
      android:textAppearance="?android:attr/textAppearanceLarge"
      android:layout_width="match_parent"
      android:layout_height="wrap_content"
      android:id="@+id/textView2"
      android:paddingLeft="50dp"
      android:layout_column="1"
      local:MvxBind="Text CurrentStudent.Id" />
  </GridLayout>

  <TextView
    android:text="Large Text"
    android:textAppearance="?android:attr/textAppearanceLarge"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:id="@+id/textView4"
    local:MvxBind="Text CurrentStudent.Name"
    android:paddingTop="20dp"
    android:paddingBottom="20dp" />
  <Mvx.MvxListView
    android:id="@+id/students_courses"
    android:divider="?android:dividerHorizontal"
    android:scrollbars="vertical"
    android:choiceMode="singleChoice"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:layout_gravity="left|start"
    local:MvxItemTemplate="@layout/course_list_item"
    local:MvxBind="ItemsSource Courses;ItemClick ShowGrades" />
</LinearLayout>
```
Resources\Layout\course_list_item.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.AndroidTest"
    android:orientation="horizontal"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:padding="15dp">
    <TextView
        android:id="@+id/course_title"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:paddingRight="15dp"
        android:textAppearance="?android:attr/textAppearanceMedium"
        android:text="Course" />
    <TextView
        android:id="@+id/course_title_value"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:textAppearance="?android:attr/textAppearanceMedium"
        android:paddingRight="15dp"
        android:text="..."
        local:MvxBind="Text Name"
        android:textStyle="bold" />
    <TextView
        android:id="@+id/course_teacher"
        android:textAppearance="?android:attr/textAppearanceSmall"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="..."
        local:MvxBind="Text Teacher"
        android:textStyle="italic"
        android:textColor="@android:color/holo_blue_dark" />
</LinearLayout>
```

### Im PCL Projekt 

ViewModels\MainViewModel.cs
```csharp
using System.Diagnostics;
using MvvmCross.Core.ViewModels;

namespace Mvx.Exercises.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        // ...

        public MvxCommand ShowStudentsCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<StudentViewModel>();
                });
            }
        }
    }
}
```
ViewModels\StudenViewModel.cs
```csharp
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using Mvx.Exercises.Models;
using Mvx.Exercises.Repositories;

namespace Mvx.Exercises.ViewModels
{
    public class StudentViewModel : MvxViewModel
    {
        private readonly IStudentRepository _studentRepository;
        private ObservableCollection<Course> _courses;

        private Student _currentStudent;

        public StudentViewModel()
        {
        }

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                Courses = new MvxObservableCollection<Course>(_currentStudent.Courses);
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                RaisePropertyChanged();
            }
        }


        protected override async void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            CurrentStudent = new Student
            {
                Id = 2,
                Name = "Hausi Hinterseeher",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Id = 1,
                        Name = "Emoba",
                        Teacher = "someone"
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Other Course",
                        Teacher = "someone else"
                    }
                },
                Grades = new List<Grade>()
            }
        }
    }
}
```