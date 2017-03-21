# Aufgaben Tag 4 Xamarin Android

## Aufgabe 1: Activity Zustände
1. Neues Xamarin Android Projekt erstellen 'Fundamentals.Intro'
2. Logge `Console.WriteLine(...` jeden möglichen Zustand
- Tipp `protected override void On...`

3. Starte die App auf den Emulator / Gerät und notiere Beobachtugen, welche Zustände werden durchlaufen wenn ...
    1. Das Geräte gedreht wird 
    2. Die App im Hintergrund läuft
    3. App wieder in den Vordergrund kommt


## Aufgabe 2: Explizite Intents und Eventhandling

![Mockup Aufgabe 2](https://github.com/Zuehlke/fhnw-xamarin-workshop/blob/master/Day%204/Images/Mockup_Exercise_I.png?raw=true)

1. Neues Xamarin Android Projekt erstellen 'Fundamentals.ExerciseOne'
2. Setze das Activity Label der `MainActivity` auf "First App"
3. Füge dem MainActivity Layout den Button `Go to Activity 2` hinzu
    - Implementiere einen `explicit intent`
4. Erstelle eine neue Activity `ToastActivity`
5. Erstelle ein dazugehöriges Android Layout `.axml`
    1. Platziere die `TextView` sowie eine `ButtonView`
    2. Aboniere den `OnClick` Event des erstellten Buttons
6. Zeige beim den `Toast` mit dem eingegeben Text an.

Optional: Löse die Aufgabe mit einem expliziten Intent

## Aufgabe 3: Long running tasks und ListViews

![Mockup Aufgabe 2](https://github.com/Zuehlke/fhnw-xamarin-workshop/blob/master/Day%204/Images/Mockup_Exercise_II.png?raw=true)

### ListView Basics
1. Neues Xamarin Android Projekt erstellen 'Fundamentals.ExerciseTwo'
2. Erstelle das Layout mit einer ListView und dem Button analog des Mockups
3. Zeige beim Clicken des Button die Liste alles Monkeys als string an.

`
 public static class MonkeyService
    {

        public static async Task<IEnumerable<MonkeyDto>> LoadMonkeysAsync(int delayInMilliseconds = 0)
        {
            await Task.Delay(delayInMilliseconds);
            return LoadMonkeys();
        }

        public static IEnumerable<MonkeyDto> LoadMonkeys(int delayInMilliseconds = 0)
        {
            // let the app crash ?
            // https://developer.android.com/training/articles/perf-anr.html#Avoiding

            Thread.Sleep(delayInMilliseconds);

            return new List<MonkeyDto>
            {
                new MonkeyDto
                {
                    Name = "Baboon",
                    Location = "Africa & Asia",
                    Details =
                        "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new MonkeyDto
                {
                    Name = "Capuchin Monkey",
                    Location = "Central & South America",
                    Details =
                        "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
                },
                new MonkeyDto
                {
                    Name = "Blue Monkey",
                    Location = "Central and East Africa",
                    Details =
                        "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
                },
                new MonkeyDto
                {
                    Name = "Squirrel Monkey",
                    Location = "Central & South America",
                    Details =
                        "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
                },
                new MonkeyDto
                {
                    Name = "Golden Lion Tamarin",
                    Location = "Brazil",
                    Details =
                        "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"
                },
                new MonkeyDto
                {
                    Name = "Howler Monkey",
                    Location = "South America",
                    Details =
                        "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"
                },
                new MonkeyDto
                {
                    Name = "Japanese Macaque",
                    Location = "Japan",
                    Details =
                        "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg"
                },
                new MonkeyDto
                {
                    Name = "Mandrill",
                    Location = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                    Details =
                        "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg"
                },
                new MonkeyDto
                {
                    Name = "Proboscis Monkey",
                    Location = "Borneo",
                    Details =
                        "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
                    ImageUrl =
                        "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg"
                }
            };
        }
    }

    public class MonkeyDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string NameSort => Name[0].ToString();
    }
` 

### Asynchronität

Um einen App responsive zu halten kennt Android eine ANR- Excpetion [ANR](https://developer.android.com/training/articles/perf-anr.html#Avoiding) 
1. Wie könnte dies bei der Basic Implementation zum Problem werden ?
2. Lade die Daten mittels Android.OS.AsyncTask
3. Lade die Daten mittels System.Threading.Task
4. Was sind die Unterschidede zwischen den beiden Varianten ? Welche Vor/ Nachteile haben diese ? 
5. Was ist die Abgrenzung zu einem BoundService / IntentService ?


## Referenzen 
1. First place to go [ Xamarin Android Guides](https://developer.xamarin.com/guides/android/)

2. Second place to go [Android Developer Documentation](https://developer.android.com/guide/index.html)

3. Source Code [Xamarin Android Source](https://github.com/xamarin/xamarin-android)

4. The Xamarin Show
    - [Android Sdks](https://channel9.msdn.com/Shows/XamarinShow/Snack-Pack-6-Managing-Android-SDKs)

    - [Android Emulatoren](https://channel9.msdn.com/Shows/XamarinShow/Snack-Pack-1-Android-Emulators)

    - Youtube [Developing Android Apps](https://www.youtube.com/playlist?list=PLAwxTw4SYaPnMwH5-FNkErnnq_aSy706S)
