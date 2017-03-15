# Lösungen
## Aufgabe 1: Navigation

`BluePage.cs`
```csharp
using System;

using Xamarin.Forms;

namespace MusterLoesung
{
	public class BluePage : ContentPage
	{
		public BluePage()
		{
			var navigateButton = new Button();
			navigateButton.Text = "Navigate";
			navigateButton.Clicked += async (sender, e) => await Navigation.PushAsync(new RedPage(), true);

			Title = "Blue";

			Content = new StackLayout()
			{
				Children =
				{
					new Label()
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						BackgroundColor = Color.Blue,
					},
					navigateButton
				}
			};
		}
	}
}
```

`RedPage.cs`
```csharp
using System;

using Xamarin.Forms;

namespace MusterLoesung
{
	public class RedPage : ContentPage
	{
		public RedPage()
		{
			var navigateButton = new Button();
			navigateButton.Text = "Navigate";
			navigateButton.Clicked += async (sender, e) => await Navigation.PushAsync(new YellowPage(), true);

			Title = "Red";

			Content = new StackLayout()
			{
				Children =
				{
					new Label()
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						BackgroundColor = Color.Red,
					},
					navigateButton
				}
			};
		}
	}
}```

`YellowPage.cs`
```csharp
using System;

using Xamarin.Forms;

namespace MusterLoesung
{
	public class YellowPage : ContentPage
	{
		public YellowPage()
		{
			var navigateButton = new Button();
			navigateButton.Text = "Zum Start zurück";
			navigateButton.Clicked += async (sender, e) => await Navigation.PopToRootAsync(true);

			Title = "Yellow";

			Content = new StackLayout()
			{
				Children =
				{
					new Label()
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						BackgroundColor = Color.Yellow,
					},
					navigateButton
				}
			};
		}
	}
}
```

`App.xaml.cs`:
```csharp
MainPage = new NavigationPage(new BluePage());
```

## Aufgabe 2: TippingCalculator

`TippingCalculator.xaml`
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="MusterLoesung.TippingCalculator">
	<ContentPage.Content>
		<StackLayout HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand">
			<StackLayout Orientation="Horizontal">
				<Label Text="Betrag" />
				<Entry Text="{Binding Amount}" WidthRequest="100" x:Name="entryAmount" />
			</StackLayout>
			<StackLayout Orientation="Horizontal">
				<Label Text="Trinkgeld (%)" />
				<Entry Text="{Binding Tip}" WidthRequest="100" x:Name="entryTipping" />
			</StackLayout>
			<Label Text="{Binding Total}" x:Name="labelTotal" />
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
````

`TippingCalculator.xaml.cs`
```csharp
public partial class TippingCalculator : ContentPage
{
	public TippingCalculator()
	{
		BindingContext = new TippingModel()
		{
			Amount = 100.00m,
			Tip = 15m,
		};

		InitializeComponent();
	}
}
````

`TippingModel.cs`
```csharp
public class TippingModel : INotifyPropertyChanged
{
	private decimal _amount;
	private decimal _tip;

	public event PropertyChangedEventHandler PropertyChanged;

	public decimal Amount
	{
		get { return _amount; }
		set
		{
			if (value != _amount)
			{
				_amount = value;
				OnPropertyChanged(nameof(Amount));
				OnPropertyChanged(nameof(Total));
			}
		}
	}

	public decimal Tip
	{
		get { return _tip; }
		set
		{
			if (value != _tip)
			{
				_tip = value;
				OnPropertyChanged(nameof(Tip));
				OnPropertyChanged(nameof(Total));
			}
		}
	}

	public decimal Total
	{
		get { return _amount + (_tip / 100 * _amount);; }
	}

	public TippingModel()
	{
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (PropertyChanged != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
```

## Aufgabe 3: Simple Todo App
`TodoModel.cs`:
```csharp
public class TodoModel : INotifyPropertyChanged
{
	private string _description;
	private bool _done;

	public event PropertyChangedEventHandler PropertyChanged;

	public string Description
	{
		get { return _description; }
		set
		{
			if (_description != value)
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}
	}

	public bool Done
	{
		get { return _done; }
		set
		{
			if (_done != value)
			{
				_done = value;
				OnPropertyChanged(nameof(Done));
			}
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (PropertyChanged != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
```

`TodoPage.xaml`:
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="MusterLoesung.TodoPage">
	<ContentPage.Content>
		<StackLayout HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand" Margin="0,15,0,0">
			<ListView VerticalOptions="CenterAndExpand" x:Name="listView">
				<ListView.ItemTemplate>
					<DataTemplate>
						<ViewCell>
							<StackLayout Orientation="Horizontal" Margin="15,0,15,0">
								<Label Text="{Binding Description}" HorizontalOptions="FillAndExpand" VerticalOptions="Center" />
								<Switch IsToggled="{Binding Done}" HorizontalOptions="End" VerticalOptions="Center" />
							</StackLayout>
						</ViewCell>
					</DataTemplate>
				</ListView.ItemTemplate>
			</ListView>
			<StackLayout Orientation="Horizontal" Margin="5,5,5,5">
				<Entry Text="Description" HorizontalOptions="FillAndExpand" x:Name="entryTodoAdd" />
				<Button Text="Add" Margin="5,0,0,0" Clicked="Handle_Clicked" />
			</StackLayout>
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
```

`TodoPage.xaml.cs`:
```csharp
public partial class TodoPage : ContentPage
{
	private ObservableCollection<TodoModel> _todos;

	public TodoPage()
	{
		InitializeComponent();

		_todos = new ObservableCollection<TodoModel>();
		_todos.Add(new TodoModel() { Description = "Todo 1", Done = true });
		_todos.Add(new TodoModel() { Description = "Todo 2", Done = true });
		_todos.Add(new TodoModel() { Description = "Todo 3", Done = true });
		
		listView.ItemsSource = _todos;
	}

	void Handle_Clicked(object sender, System.EventArgs e)
	{
		_todos.Add(new TodoModel() { Description = entryTodoAdd.Text });
	}
}
```
