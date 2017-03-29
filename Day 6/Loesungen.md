# Aufgaben Tag 6 MVVM Teil 2

## Aufgabe 1 Listview mit MVVM Cross 

### In der PCL

ViewModels\TodoViewModel.cs
```csharp
using System.Collections.ObjectModel; 
using MvvmCross.Core.ViewModels; 
using Mvx.Exercises.Two.Models; 
 
namespace Mvx.Exercises.Two.ViewModels 
{ 
    public class TodoViewModel : MvxViewModel 
    { 
        private static int _todoCount = 1; 
        private string _todoText; 
        private ObservableCollection<Todo> _todos; 
 
        public ObservableCollection<Todo> Todos 
        { 
            get { return _todos; } 
            set 
            { 
                _todos = value; 
                RaisePropertyChanged(); 
            } 
        } 
 
        public string TodoText 
        { 
            get { return _todoText; } 
            set 
            { 
                _todoText = value; 
                RaisePropertyChanged(); 
                RaisePropertyChanged(nameof(AddTodo)); 
            } 
        } 
 
        public MvxCommand AddTodo 
        { 
            get 
            { 
                return new MvxCommand(() => 
                    { 
                        Todos.Add(new Todo 
                        { 
                            Id = _todoCount++, 
                            Done = false, 
                            Text = TodoText 
                        }); 
                    }, 
                    () => !string.IsNullOrWhiteSpace(TodoText)); 
            } 
        } 
 
        protected override void InitFromBundle(IMvxBundle parameters) 
        { 
            base.InitFromBundle(parameters); 
            Todos = new MvxObservableCollection<Todo>(); 
        } 
    } 
}
```
App.cs
```csharp
using System.Text; 
using System.Threading.Tasks; 
using MvvmCross.Core.ViewModels; 
using Mvx.Exercises.Two.ViewModels; 
 
namespace Mvx.Exercises.Two 
{ 
        public override void Initialize() 
        { 
            base.Initialize(); 
            RegisterAppStart(new MvxAppStart<TodoViewModel>()); 
        } 
    } 
} 
```

### Im Android Projekt

Resources\Layout\Todo.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent"
              xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.Two.Android">
  <EditText
      android:id="@+id/addText"
      android:layout_width="match_parent"
      android:layout_height="wrap_content"
      local:MvxBind="Text TodoText,Mode=TwoWay"/>
  <Button
      android:id="@+id/myButton"
      android:layout_width="match_parent"
      android:layout_height="wrap_content"
      android:text="Add Todo"
      local:MvxBind="Click AddTodo"/>
  <Mvx.MvxListView
      android:id="@+id/grades_list"
      android:divider="@null"
      android:scrollbars="vertical"
      android:choiceMode="singleChoice"
      android:layout_width="match_parent"
      android:layout_height="match_parent"
      android:layout_gravity="left|start"
      local:MvxItemTemplate="@layout/todo_list_item"
      local:MvxBind="ItemsSource Todos" />

</LinearLayout>

```
Resources\Layout\Todo_list_item.axml
```xml
<?xml version="1.0" encoding="utf-8"?>

<GridLayout xmlns:android="http://schemas.android.com/apk/res/android"
              android:orientation="horizontal"
              android:layout_width="match_parent"
              android:layout_height="match_parent"
              android:columnCount="3"
              xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.Two.Android">
  <TextView
    android:id="@+id/todo_id"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:paddingRight="20dp"
    android:text="id ..."
    android:layout_column="0"
    local:MvxBind="Text Id" />
  <TextView
    android:id="@+id/todo_text"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:paddingRight="20dp"
    android:text="Text ..."
    android:layout_column="1"
    local:MvxBind="Text Text" />
  <Switch   
    android:id="@+id/todo_done"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:layout_column="2"
    local:MvxBind="Checked Done"
    />
</GridLayout>
```

```csharp
using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using Mvx.Exercises.Two.ViewModels;

namespace Mvx.Exercises.Two.Droid
{
	[Activity (Label = "Todo APP", MainLauncher = true, Icon = "@drawable/icon")]
	public class TodoActivity : MvxActivity<TodoViewModel>
	{
	    protected override void OnViewModelSet()
	    {
	        base.OnViewModelSet();
            SetContentView(Resource.Layout.Todo);
        }
	}
}
```


## Aufgabe 2 Listview mit MVVM und Xamarin.Forms

### Nur in der PCL

ViewModels\TodoViewModel.cs
```csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FormsMvvm.Exercise.Annotations;
using FormsMvvm.Exercise.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace FormsMvvm.Exercise.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        private static int _todoCount = 1;
        private string _todoText;
        private ObservableCollection<Todo> _todos = new ObservableCollection<Todo>();

        public TodoViewModel()
        {
        }

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { _todos = value; }
        }


        public string TodoText
        {
            get { return _todoText; }
            set
            {
                SetProperty(ref _todoText, value);
                OnPropertyChanged(nameof(AddTodo));
            }
        }

        public Command AddTodo
        {
            get
            {
                return new Command( () =>
                {
                    Todos.Add(new Todo()
                    {
                        Id = _todoCount++,
                        Done = false,
                        Text = TodoText
                    });
                },
                ()=> !string.IsNullOrWhiteSpace(TodoText));
            }
        }
    }
}

```

Views\TodoView.xaml
```xml
<?xml version="1.0" encoding="utf-8"?>

<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:FormsMvvm.Exercise"
             x:Class="FormsMvvm.Exercise.TodoView"
             Title="Todo APP">

    <StackLayout Orientation="Vertical">
        <ListView ItemsSource="{Binding Todos}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="2*" />
                                <ColumnDefinition Width="6*" />
                                <ColumnDefinition Width="2*" />
                            </Grid.ColumnDefinitions>
                            <Label Text="{Binding Id}" Grid.Column="0" FontSize="Medium" />
                            <Label Text="{Binding Text}" Grid.Column="1" FontSize="Medium" />
                            <Switch IsToggled="{Binding Done}" Grid.Column="2" />
                        </Grid>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Entry Text="{Binding TodoText}" />
        <Button Text="Add Todo" Command="{Binding AddTodo}" />
    </StackLayout>
</ContentPage>
```

Views\TodoView.xaml.cs
```csharp
using FormsMvvm.Exercise.ViewModels;
using Xamarin.Forms;

namespace FormsMvvm.Exercise
{
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            BindingContext = new TodoViewModel();
        }
    }
}
```

## Aufgabe 3 Constructor Injection mit Forms
### Nur in der PCL
Repositories\TodoRepository.cs
```csharp
using System.Collections.Generic;
using FormsMvvm.Exercise.Models;

namespace FormsMvvm.Exercise.Repositories
{
    public class TodoRepository
    {
        private static int _todoCount = 1;
        private readonly List<Todo> _todos = new List<Todo>();

        public IList<Todo> GetAll()
        {
            return _todos;
        }

        public void Add(string todo)
        {
            _todos.Add(new Todo
            {
                Id = ++_todoCount,
                Done = false,
                Text = todo
            });
        }
    }
}
```

ViewModels\TodoViewModel.cs
```csharp
using System.Collections.ObjectModel;
using FormsMvvm.Exercise.Models;
using FormsMvvm.Exercise.Repositories;
using MvvmHelpers;
using Xamarin.Forms;

namespace FormsMvvm.Exercise.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        private static int _todoCount = 1;
        private string _todoText;
        private ObservableCollection<Todo> _todos = new ObservableCollection<Todo>();
        private readonly TodoRepository _todoRepository;

        public TodoViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            LoadData();
        }

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { _todos = value; }
        }


        public string TodoText
        {
            get { return _todoText; }
            set
            {
                SetProperty(ref _todoText, value);
                OnPropertyChanged(nameof(AddTodo));
            }
        }

        private void LoadData()
        {
            Todos = new ObservableCollection<Todo>(_todoRepository.GetAll());
        }

        public Command AddTodo
        {
            get
            {
                return new Command( () =>
                {
                   _todoRepository.Add(TodoText);
                    LoadData();
                },
                ()=> !string.IsNullOrWhiteSpace(TodoText));
            }
        }
    }
}

```

Views\TodoView.xaml.cs
```csharp
using FormsMvvm.Exercise.Repositories;
using FormsMvvm.Exercise.ViewModels;
using Xamarin.Forms;

namespace FormsMvvm.Exercise
{
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            BindingContext = new TodoViewModel(new TodoRepository());
        }
    }
}
```

## Aufgabe 4 IoC mit MVVM Cross 

Repositories\TodoRepository.cs
```csharp
using System.Collections.Generic;
using Mvx.Exercises.Two.Models;

namespace Mvx.Exercises.Two.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        void Add(string todo);
    }

    public class TodoRepository : ITodoRepository
    {
        private static int _todoCount = 1;
        private readonly List<Todo> _todos = new List<Todo>();
        public IEnumerable<Todo> GetAll()
        {
            return _todos;
        }

        public void Add(string todo)
        {
            _todos.Add(new Todo
            {
                Id = ++_todoCount,
                Done = false,
                Text = todo
            });
        }
    }
}

```
ViewModels\TodoViewModel.cs
```csharp
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using Mvx.Exercises.Two.Models;
using Mvx.Exercises.Two.Repositories;

namespace Mvx.Exercises.Two.ViewModels
{
    public class TodoViewModel : MvxViewModel
    {
        private readonly ITodoRepository _repository;
        private string _todoText;
        private ObservableCollection<Todo> _todos;

        public TodoViewModel(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set
            {
                _todos = value;
                RaisePropertyChanged();
            }
        }

        public string TodoText
        {
            get { return _todoText; }
            set
            {
                _todoText = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(AddTodo));
            }
        }

        public MvxCommand AddTodo
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        _repository.Add(TodoText);
                        LoadData();
                    },
                    () => !string.IsNullOrWhiteSpace(TodoText));
            }
        }


        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
            LoadData();
        }

        private void LoadData()
        {
            Todos = new MvxObservableCollection<Todo>(_repository.GetAll());
        }
    }
}
```

App.cs
```csharp
using MvvmCross.Core.ViewModels;
using Mvx.Exercises.Two.Repositories;
using Mvx.Exercises.Two.ViewModels;

namespace Mvx.Exercises.Two
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            MvvmCross.Platform.Mvx.RegisterType<ITodoRepository, TodoRepository>();
            RegisterAppStart(new MvxAppStart<TodoViewModel>());
        }
    }
}

```