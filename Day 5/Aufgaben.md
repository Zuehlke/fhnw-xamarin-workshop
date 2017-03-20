# Aufgabe Day 5 Mvvm mit Mvvm Cross

## Aufgabe 1: Projekt initialisieren 10'min

1. File => New => C# => Crossplattform => Nativ or Forms App
2. Native + PCL
3. Name "Mvx.Exercises"
4. Für alle 3 projekte die nuget referenzen hinzufügen
    - MvvmCross Version 4.4
5. Im Shared Projekt (PCL)
    - Erstelle eine Klasse 'App'
    
     `public class App : MvxApplication`
    - Erstelle eine Klasse 'AppStart'
    
    `public class AppStart : MvxNavigatingObject, IMvxAppStart`
    - Erstelle einen Folder `ViewModels`
    - Erstelle darin eine Klasse 'MainViewModel'
    
     `public class MainViewModel : MvxViewModel`

6. Im Android Projekt
    - Lösche die `MainActivity`
    - Erstelle einen Folder `Views`
    - Erstelle die Klasse 'MainActivity'

`
    [Activity(Label = "Students App", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    `


## Aufgabe 2: Databinding 5' min

1. Android Layout erstellen

2. Activity erstellen

3. Layout in Activity Laden

4. Binding erstellen

## Aufgabe 3: Commands 5'min

1. Command erstellen für Button Click

2. Binding erstellen

## Aufgabe 4: Navigation 5'min

1. Neue Activity erstellen

2. Command erstllen und binden

3. NavigateTo

## Aufgabe 5: IoC und Services 15'min

1. Interface für eigenen Service

2. Implementation Android und IOS

3. Registrieren

4. Resolve

<!--## Aufgabe 6: Plugins
Allenfalls noch einen FileService, DialogService pro Plattform
-->



