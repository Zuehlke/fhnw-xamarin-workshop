# Musterlösungen
## Frage 1:
Im Platformspezifischen Projekt ist der Startpunkt.

Android: `MainActivity.cs` wo App instanziert wird.
iOS: `AppDelegate.cs`

In `App.xaml.cs` wird dann `MainPage` instanziiert.

## Aufgabe 2
```csharp
public class Aufgabe2 : ContentPage
{
    public Aufgabe2()
    {
        Content = new StackLayout
        {
            Children = {
                new Button() { Text = "John Wick" },
                new Button() { Text = "Jack Bauer" },
                new Button() { Text = "James Bond" }
            },
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };
    }
}
```

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage 
	xmlns="http://xamarin.com/schemas/2014/forms" 
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
	x:Class="BindingDemo.Aufgabe2Xaml">
	<ContentPage.Content>
		<StackLayout HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand">
			<Button Text="John Wick" />
			<Button Text="Jack Bauer" />
			<Button Text="James Bond" />
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
```

### Vertikal

* XAML: `Orientation="Horizontal"`
* C#: `Orientation = StackOrientation.Horizontal`

## Frage 2
Im `App.xaml.cs` muss die `MainPage =` neu gesetzt werden. 

## Aufgabe 3a
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage 
	xmlns="http://xamarin.com/schemas/2014/forms" 
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
	x:Class="BindingDemo.Aufgabe3a">
	<ContentPage.Content>
		<ScrollView>
			<StackLayout>
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
				<Label Text="Red" BackgroundColor="Red" />
				<Label Text="Blue" BackgroundColor="Blue" />
				<Label Text="Yellow" BackgroundColor="Yellow" />
			</StackLayout>
		</ScrollView>
	</ContentPage.Content>
</ContentPage>
```

## Aufgabe 3b
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage 
	xmlns="http://xamarin.com/schemas/2014/forms" 
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
	x:Class="BindingDemo.Aufgabe3a">
	<ContentPage.Content>
		<StackLayout>
			<ScrollView>
				<StackLayout>
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
					<Label Text="Red" BackgroundColor="Red" />
					<Label Text="Blue" BackgroundColor="Blue" />
					<Label Text="Yellow" BackgroundColor="Yellow" />
				</StackLayout>
			</ScrollView>
			<StackLayout Orientation="Horizontal" HorizontalOptions="CenterAndExpand">
				<Button Text="Ok" />
				<Button Text="Cancel" />
			</StackLayout>
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
```

## Frage 3
### Absolut Layout
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage 
	xmlns="http://xamarin.com/schemas/2014/forms" 
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
	x:Class="Excercises.AbsoulteLayout">
	<AbsoluteLayout>
		<Label Text="Hi" AbsoluteLayout.LayoutBounds="115,300,100,100" BackgroundColor="Blue" />
	</AbsoluteLayout>
</ContentPage>
```

Wenn das Device gedreht wird, verschwindet das absolut positionierte Element. Mit den verschachtelten `StackLayouts` passt sich das Layout an das Bildschirmformat an. Interessant ist auch dass nicht alle Devices denselben Formfaktor haben, was die Positinierung mit dem Absolut Layout nur in speziellen Situation zum richtigen Werkzeug macht.


