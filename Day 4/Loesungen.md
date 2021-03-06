# Lösungen Xamarin Android

## Aufgabe 1 Activity Zustände

[Nachlesen ](https://developer.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/saving_state_walkthrough/)

```csharp
[Activity(Label = "Intro", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

             Log.Debug(GetType().FullName,"OnCreate executed, not visible");
            SetContentView(Resource.Layout.Main);
        }

        protected override void OnStart()
        {
            base.OnStart();

             Log.Debug(GetType().FullName,"OnStart executed, going to be visible");
        }

        protected override void OnResume()
        {
            base.OnResume();

             Log.Debug(GetType().FullName,"OnResume executed, visible in foreground");
        }

        protected override void OnPause()
        {
            base.OnPause();

             Log.Debug(GetType().FullName,"OnPause executed, partially visible");
        }

        protected override void OnStop()
        {
            base.OnStop();

             Log.Debug(GetType().FullName,"OnStop executed, hidden");
        }

        protected override void OnRestart()
        {
            base.OnRestart();

             Log.Debug(GetType().FullName,"OnPause executed, hidden but going to visible");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

             Log.Debug(GetType().FullName,"OnPause executed, no more available");
        }
    }
```

## Aufgabe 2: Implizite Intents und Eventhandling

Main.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:minWidth="25px"
    android:minHeight="25px"
   >
    <Button
        android:text="Go to other Activity"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/main_button_gotoactivity" />
</LinearLayout>
```

MainActiviy.cs
```csharp
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var gotoToast = FindViewById<Button>(Resource.Id.main_button_gotoactivity);
            gotoToast.Click += (sender, args) =>
            {
                var startToastIntent = new Intent(this, typeof(ToastActivity));
                StartActivity(startToastIntent);
            };
        }
    }
```

Toast.axml
``` xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <EditText
        android:id="@+id/toast_edit_text"
        android:layout_width="match_parent"
        android:layout_height="wrap_content" />
    <Button
        android:id="@+id/toast_button_show"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text="@string/toast_showalert" />
</LinearLayout>
```

ToastActiviy.cs
```csharp
    [Activity(Label = "...")]
    public class ToastActivity : Activity
    {
        private EditText _textToShow;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Toast);

            _textToShow = FindViewById<EditText>(Resource.Id.toast_edit_text);
            var showToast = FindViewById<Button>(Resource.Id.toast_button_show);
            showToast.Click += (sender, args) =>
            {
                var toast = Toast.MakeText(this, _textToShow.Text, ToastLength.Long);
                toast.Show();
            };
        }
    }
```

## Aufgabe 3: Long running tasks und ListViews

Basic.axml
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:minWidth="25px"
    android:minHeight="25px">
    <Button
        android:text="Get Monkeys"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/basic_button_getmonkeys" />
    <ListView
        android:minWidth="25px"
        android:minHeight="25px"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/basic_list_monkeys" />
</LinearLayout>
```

BasicActivity.cs
```csharp
     [Activity(Label = "Basic simple list")]
    public class BasicActivity : Activity
    {
        private const string MonkeysBundleKey = "monkeys";
        private Button _getMonkeys;
        private ListView _monkeyList;
        private readonly List<string> _monkeyAsStrings = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Basic);

            _getMonkeys = FindViewById<Button>(Resource.Id.basic_button_getmonkeys);
            _monkeyList = FindViewById<ListView>(Resource.Id.basic_list_monkeys);

            _getMonkeys.Click += (sender, args) =>
            {
                _monkeyAsStrings.AddRange(MonkeyService.LoadMonkeys(10000).Select(_ => _.Name).ToList());
                SetListAdapter();
            };

            if (bundle == null) return;

            _monkeyAsStrings.AddRange(bundle.GetStringArray(MonkeysBundleKey));
            SetListAdapter();
        }


        private void SetListAdapter()
        {
            var listAdapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItem1,
                _monkeyAsStrings);

            _monkeyList.Adapter = listAdapter;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutStringArray(MonkeysBundleKey, _monkeyAsStrings.ToArray());
            base.OnSaveInstanceState(outState);
        }
    }
```

1. Wie könnte dies bei der Basic Implementation zum Problem werden ?
Wenn das Laden der Daten zu lange dauert kann dies zu einer ANR-Exception führen. Dies führt zu schlechten Reviews für eine App obwohl die Gründe nicht zwigend darin ligen z.B. Latenz beim Zugriff auf die externe Resource.


2. Lade die Daten mittels Android.OS.AsyncTask

MonkeyLoadAsyncTask
```csharp
    internal class MonkeyLoadAsyncTask : AsyncTask<int, int, IEnumerable<MonkeyDto>>
    {
        private readonly AsyncTaskActivity _activity;

        public MonkeyLoadAsyncTask(AsyncTaskActivity activity)
        {
            _activity = activity;
        }

        protected override IEnumerable<MonkeyDto> RunInBackground(params int[] @params)
        {
            return MonkeyService.LoadMonkeys(@params[0]);
        }

        protected override void OnPostExecute(IEnumerable<MonkeyDto> result)
        {
            var monkeyDtos = result as IList<MonkeyDto> ?? result.ToList();
            base.OnPostExecute(monkeyDtos);
            _activity.SetListAdapter(monkeyDtos);
            _activity.SetBusy(false);
         
        }
```

AsyncTaskActivity

```csharp
    [Activity(Label = "Async Task")]
    public class AsyncTaskActivity : Activity
    {
        private const string MonkeysBundleKey = "monkeys";
        private readonly List<MonkeyDto> _monkeyDtos = new List<MonkeyDto>();

        private Button _getMonkeys;
        private ListView _monkeyList;
        private ProgressDialog _progressDialog;
        private MonkeyLoadAsyncTask _monkeyLoadAsyncTask;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Basic);


            _getMonkeys = FindViewById<Button>(Resource.Id.basic_button_getmonkeys);
            _monkeyList = FindViewById<ListView>(Resource.Id.basic_list_monkeys);
            _monkeyLoadAsyncTask = new MonkeyLoadAsyncTask(this);

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Please wait...");
            _progressDialog.SetCancelable(false);

            if (bundle != null)
                SetListAdapter(JsonConvert.DeserializeObject<List<MonkeyDto>>(bundle.GetString(MonkeysBundleKey)));
       

            _getMonkeys.Click += (sender, args) =>
            {
                SetBusy(true);
                _monkeyLoadAsyncTask.Execute(1000);
            };
        }

        public void SetBusy(bool isBusy)
        {
            if (isBusy)
                _progressDialog.Show();
            else
                _progressDialog.Cancel();
        }

        public void SetListAdapter(IEnumerable<MonkeyDto> monkeyDtos)
        {
            var monkeyAsStrings = monkeyDtos.Select(_ => _.Name).ToList();
            var listAdapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItem1,
                monkeyAsStrings);

            _monkeyList.Adapter = listAdapter;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(MonkeysBundleKey, JsonConvert.SerializeObject(_monkeyDtos));
            base.OnSaveInstanceState(outState);
        }
    }
```

3. Lade die Daten mittels System.Threading.Task

```csharp
    [Activity(Label = "Async and advanced stuff")]
    public class AdvancedActivity : Activity
    {
        private const string MonkeysBundleKey = "monkeys";
        private Button _getMonkeys;
        private ListView _monkeyList;
        private readonly List<string> _monkeyAsStrings = new List<string>();
        private ProgressDialog _progressDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Basic);

            _getMonkeys = FindViewById<Button>(Resource.Id.basic_button_getmonkeys);
            _monkeyList = FindViewById<ListView>(Resource.Id.basic_list_monkeys);

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Please wait...");
            _progressDialog.SetCancelable(false);

            if (bundle != null)
            {
                _monkeyAsStrings.AddRange(bundle.GetStringArray(MonkeysBundleKey));
            }

            SetListAdapter();

            _getMonkeys.Click += async (sender, args) =>
            {
                SetBusy(true);
                var monkeyDtos = await MonkeyService.LoadMonkeysAsync(1000);
                _monkeyAsStrings.AddRange(monkeyDtos.Select(_ => _.Name).ToList());
                SetListAdapter();
                SetBusy(false);
            };
        }

        private void SetBusy(bool isBusy)
        {
            if (isBusy)
            {
                _progressDialog.Show();
            }
            else
            {
                _progressDialog.Cancel();
            }
        }

        private void SetListAdapter()
        {
            var listAdapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItem1,
                _monkeyAsStrings);

            _monkeyList.Adapter = listAdapter;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutStringArray(MonkeysBundleKey, _monkeyAsStrings.ToArray());
            base.OnSaveInstanceState(outState);
        }
    }
```

4. Was sind die Unterschidede zwischen den beiden Varianten ? Welche Vor/ Nachteile haben diese ? 

Async Task bietet die Möglichkeit progress zu melden, und eine finalen UI update zu machen.

5. Was ist die Abgrenzung zu einem BoundService / IntentService ?

Ein BoundService kann für eine Client / Server Interaktion verwendet werden. Bei einem IntentService wird einen Queue von Tasks befüllt. Beide machen aber wenig Sinn um sie für einen REST Http call zu verwenden.
