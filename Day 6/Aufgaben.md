# Aufgaben Tag 6 MVVM Teil 2

## Aufgabe 1 Listview mit MVVM Cross

1. Kopiere Projekt von Template von Github
    [Template Zip](templates/mvxtemplate.zip)

2. Erstelle ein Viewmodel das `TodoViewModel`
```csharp
    public class TodoViewModel : MvxViewModel 
```

3. Registriere das im der `App` Klasse
```csharp
    RegisterAppStart(new MvxAppStart<TodoViewModel>());
```
 

4. Erstelle ein Property `Todos` mit ObservableCollection<Todo> und intialisiere wie folgt
```csharp
        protected override void InitFromBundle(IMvxBundle parameters) 
        { 
            base.InitFromBundle(parameters); 
            Todos = new ObservableCollection<Todo>(); 
        } 
```

5. Ändere die eine Activity `TodoActivity` das sie von `MvxActivity<TodoViewModel>` ableitet und setzte die ContentView
```csharp
  protected override void OnViewModelSet() 
      { 
          base.OnViewModelSet(); 
          // TODO ...
      } 
```
6. Passe das `Todo.axml` an indem eine `Mvx.ListView`,`EditText` und ein `Button` hinzugefügt werden.
- ` xmlns:local="http://schemas.android.com/apk/res/Mvx.Exercises.Two.Android"` auf Linear Layout nicht vergessen !
```xml     
  <EditText 
      android:id="@+id/addText" 
      android:layout_width="match_parent" 
      android:layout_height="wrap_content" 
       <!-- TODO binding here  -->
      /> 
  <Button 
      android:id="@+id/myButton" 
      android:layout_width="match_parent" 
      android:layout_height="wrap_content" 
      android:text="Add Todo" 
       <!-- TODO here  -->
      /> 
  <Mvx.MvxListView 
      android:id="@+id/grades_list" 
      android:divider="@null" 
      android:scrollbars="vertical" 
      android:choiceMode="singleChoice" 
      android:layout_width="match_parent" 
      android:layout_height="match_parent" 
      android:layout_gravity="left|start" 
      local:MvxItemTemplate="@layout/todo_list_item" 
       <!-- TODO and here  -->
     /> 
 
</LinearLayout>
```

7. Erstelle ein Item template `Todo_item_template.axml`und erstelle die Bindings für den `Todo` auf `Id`,`Text` und `Done`
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
    <!-- TODO binding here  -->
     /> 
  <TextView 
    android:id="@+id/todo_text" 
    android:layout_width="wrap_content" 
    android:layout_height="wrap_content" 
    android:paddingRight="20dp" 
    android:text="Text ..." 
    android:layout_column="1" 
     <!-- TODO here  -->
      /> 
  <Switch    
    android:id="@+id/todo_done" 
    android:layout_width="wrap_content" 
    android:layout_height="wrap_content" 
    android:layout_column="2" 
    <!-- TODO and here  -->
    /> 
</GridLayout>
```

8. Erstelle einen Command `AddTodo` und ein Binding auf den Click-Event
```csharp
    public MvxCommand AddTodo {get // ...
```

9. Der Add-Command darf nur aktiv sein, wenn ein Text eingegeben wurde (Whitespaces zählen nicht)
- Tipp für der Command hat eine CanExecute-Methode
```csharp
public Command(Action execute, Func<bool> canExecute)
```


## Aufgabe 2 Listview mit MVVM und Xamarin.Forms

1. Erstelle neuese Xamarin.Forms Projekt mit einer PCL

2. Füge die Nuget Referenz auf `Refractored.MvvmHelpers` der PCL hinzu
    - PCL Projekt => Rechts Klick => Manage Nuget packages => Packet suchen & installieren

3. Erstelle ein `TodoViewModel` und den Folder `ViewModels`
```csharp
 public class TodoViewModel : BaseViewModel
```

4. Erstelle den Folder `Models` und erstelle das `Todo`-Model
```csharp
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }
```

4. Erstelle Property `Todos` als `ObservableCollection<Todo>` im `TodoViewModel`

5. Erstelle einen Folder `Views` und füge eine ContentPage  `TodoView` hinzu

- Achtung: Im TodoView.xaml.cs muss der `BindingContext` gesetzt werden
```xml
    <StackLayout Orientation="Vertical">
        <ListView "here is a binding missing  ...">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        ... define the item template
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Entry "here is a binding missing  ..."/>
        <Button Text="Add Todo" "here is a binding missing  ..." />
    </StackLayout>
```


6. ListView mit Binding auf `Todos` und ItemTemplate erstellen
    - Die List hat eine `ItemsSource` binde dies auf die `Todos` des `TodoViewModels`
    - Das Itemtemplate muss im Kontext eine `Todo` geschrieben werden

7. Erstelle einen Command `AddTodo` im `TodoViewModel` und binde ihn auf den Button-Command der View

8. Der Add-Command darf nur aktiv sein, wenn ein Text eingegeben wurde (Whitespaces zählen nicht)
    - Tipp siehe Aufgabe 1 Punkt 9

## Aufgabe 3 Constructor Injection mit Forms
1. Erstelle den Folder `Repositories`

2. Extrahiere `TodoRepository` Klasse aus Viewmodel (3min)
```csharp
    IEnumerable<Todo> GetAll();
    void Add(string todo);
```

3. Verwende das Repository im `TodoViewModel`
- im `AddTodo`-Command
```csharp
    _repository.Add(TodoText);
```
- Um die Todos zu "laden"
```csharp
    private void LoadData()
    {
        Todos = new ObservableCollection<Todo>(_repository.GetAll());
    }
```

4. Erstelle nun eine manuelle Constructor Injection für das Repository


## Aufgabe 4 IoC mit MVVM Cross

1. Extrahiere Repository für das PCL Projekt
    - gleich wie bei Aufgabe 3 Punkte 1+2

2. Extrahiere ein Interface `ITodoRepository`
    - lasse das `TodoRepository` das Interface implementieren
    
3. Registriere das Repository im Mvx IoC Container in der `App.Initialize`

```csharp
  MvvmCross.Platform.Mvx.Register ....
```

4. Erstelle die Abhängigkeit vom `TodoViewModel` zu `ITodoRepository` 
    - Lasse dir das `ITodoRepository` via Konstruktor injecten

5. Verwende das Repository analog zu Aufgabe 3 Punkt 3




