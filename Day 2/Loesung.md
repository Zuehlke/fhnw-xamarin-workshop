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

## Frage 4
Das Layouting übernimmt das `AbsolutLayout` und nicht das Label selbst, darum hat das Label auch keine layoutspezifischen Eigenschaften. 

Dies ermöglicht ein Label auch in einem anderen Layouts wie z.B. ein `GridLayout` zu positionieren, ohne dass das Label etwas vom Layout wissen muss.

## Aufgabe 4
```csharp
public class ExerciseSwitcherPage : TabbedPage
{
	public ExerciseSwitcherPage()
	{
		Children.Add(new Aufgabe2());
		Children.Add(new Aufgabe3a());
		Children.Add(new AbsoluteLayout());
		// ...
	}
}
```
### Titel
#### XAML
`<ContentPage ... Title="Titel der Page">...`

#### C#
```csharp
public class ExerciseSwitcherPage : ContentPage
{
	public ExerciseSwitcherPage()
	{
		Title = "My Title";
	}
}
```

## Aufgabe 5
### XAML `TippingCalculator.xaml`
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage 
	xmlns="http://xamarin.com/schemas/2014/forms" 
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
	x:Class="Excercises.TippingCalculator">
	<ContentPage.Content>
		<StackLayout HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand">
			<StackLayout Orientation="Horizontal">
				<Label Text="Betrag" />
				<Entry Text="" WidthRequest="100" x:Name="entryAmount" />
			</StackLayout>
			<StackLayout Orientation="Horizontal">
				<Label Text="Trinkgeld (%)" />
				<Entry Text="" WidthRequest="100" x:Name="entryTipping" />
			</StackLayout>
			<Button Text="Berechnen" Clicked="Handle_Clicked" />
			<Label Text="" x:Name="labelTotal" />
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
````

### Codebehind `TippingCalculator.xaml.cs`
```csharp
public partial class TippingCalculator : ContentPage
{
	public TippingCalculator()
	{
		InitializeComponent();
	}

	void Handle_Clicked(object sender, System.EventArgs e)
	{
		var amount = double.Parse(entryAmount.Text);
		var tipping = double.Parse(entryTipping.Text);

		var total = amount + (tipping / 100 * amount);

		labelTotal.Text = "Bezahle " + total + " für " + tipping + "% Trinkgeld.";
	}
}
```