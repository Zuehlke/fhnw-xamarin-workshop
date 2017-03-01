# Aufgaben

## Aufgabe 1
Wir starten mit einer `Blank Xaml App (Xamarin.Forms Portable)`. Mac: `Forms -> Forms ContentPage Xaml`

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/BlankAppTemplate.png)

* Allfällige Windows Phone Projekte entfernen. 
* Windows: iOS Projekt entfernen
* Mac: Droid Projekt kann verwendet werden um den Unterschied Android vs iOS anzuschauen

Das müsste dann etwa so aussehen:

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/SolutionExplorer.png)

Frage 1
Wenn ihr die Applikation startet kommt der Inhalt von MainPage.xaml. Warum? Versucht herauszufinden welches der Startpunkt eurer Applikation ist und wer MainPage instanziert. [1]

## Aufgabe 2

Mit XAML soll folgende App Gebaut werden:

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/Aufgabe2.png)

Tipps:
* Benutze das `StackLayout`
* Prüfe die eigenschaften welches ein StackLayout hat (Ctrl + Space drücken während der Cursor im Tag ist: `<StackLayout $CURSOR$>` um die Buttons in der Mitte zu zentrieren.

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/intellisense.png)

* Probiere das StackLayout horizontal zu machen.

Versuche nun dasselbe ohne XAML zu machen. Hierzu fügen wir dem portable project ein neue `Page` hinzu: 

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/AddNewFormsPage1.png)

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/AddNewFormsPage2.png)

> Verwendet bei Pages immer das Suffix `Page` wie z.B. `MySuperPage`

Nennen wir die neue Page `ButtonsInCodePage.cs`.

Nun haben wir eine nackte C# Klasse anstatt eine XAML Datei welche eine `Page` repräsentiert.

Frage 2:
Schaue dir den Code im Portable Projekt an. Wo muss nun etwas geändert werden, dass anstatt MainPage.xaml die neu erstellte Klasse als startpage verwendet wird?

> Tipp: Finde MainPage...

Probier nun in `ButtonsInCodePage.cs` dasselbe wie mit XAML zu machen, diesesmal einfach in C#.

> Tipp: Content = ...

## Aufgabe 3: Scrollen
### Aufgabe 3a
Die nächste Übung zeigt wie man Scrolling implementieren wird. Füge eine neue `Forms XAML Page` dem Projekt hinzu. Wir nennen diese `ScrollingPage`. Füge nun einige Labels hinzu, z.B. mit unterschiedlichen Hintegrundfarben, jedoch so viele dass nicht alle auf einem Screen platz haben. 

> Tipp: Hierzu eignet sich wieder das `StackPanel` in Kombination mit zum Beispiel mehreren `Label` und unterschiedlichen Hintegrundfarben.

Ein Beispiel:

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/Aufgabe3Beispiel.png)

Versuche mithilfe der `ScrollView` dein Inhalt scrollbar zu machen. Falls es nicht klappt kann in der [Dokumentation](https://developer.xamarin.com/guides/xamarin-forms/user-interface/layouts/scroll-view/) nachgeschlagen werden.

## Aufgabe 3b
Wir wollen nun 2 Buttons unterhalb des `ScrollViews` machen:

![](https://raw.githubusercontent.com/Zuehlke/fhnw-xamarin-workshop/master/Day%202/images/Aufgabe3b.png)

Wie kann dies bewerkstelligt werden? Es müsste mit dem bereits erlangtem Wissen machbar sein.

Frage 3:
Würde es Sinn machen die Position in Form von Zahlen (px/cm/whatever) zu definieren? Warum ja/nein?

Als Hilfe für die Frage kannst du eine neue Page (XAML) erstellen, nennen wir diese `AbsoluteLayoutPage`. Füge anschliessend ein AbsolutLayout hinzu. Füge z.B. ein Label innerhalb des AbsolutLayout ein welches zur einfacheren Auffindung eine Hintergrundfarbe hat. Nun kann die absolute Position wiefolgt definiert werden:

```xml
<AbsoluteLayout>
    <Label BackgroundColor="Blue" AbsoluteLayout.LayoutBounds="x, y, width, height"></Label>
</AbsoluteLayout>
```

Platziere ein blaues Rechteck im unteren viertel auf dem Bildschirm. Starte die App und rotiere den Screen so dass er Querformat ist. Was passiert? Das Verhalten beschreibt eines der Probleme welche in Frage 3 gefragt werden.

Frage 4: 
Warum muss via `AbsoluteLayout.LayoutBounds` die Grösse und Position definiert werden und nicht einfach direkt `LayoutBounds="x, y, width, height"`.


## Aufgabe 4
Wir haben nun schon einige Pages erstellt. Als Grundlage wurde immer ContentPage verwendet. Wir wollen nun alle unsere erstellten Pages mit Tabs auf einem Screen anzeigen.

Eigene Pages zu referenzieren ist per code ein bisschen einfacher als in XAML.

* Erstelle hierzu eine neue Page (nicht XAML sondern `Forms Page`. Auf Mac: `Forms ContentPage`). Wir nennen diese `ExerciseSwitcherPage`.
* Die Klasse vererbt von `ContentPage`. Ändere dies auf `TabbedPage`
* Die `TabbedPage` besitzt kein `Content` Property -> entfernen
* Via dem `Children` Property können nun unsere Pages hinzugefügt werden (`Children.Add(...)`)
* Vergiss im App.xaml.cs nicht die PageSwitzer Klasse zu instanzieren und zuzuweisen.
* Starte die App

Die Tabs haben noch keinen Titel. Um den einzelnen Pages einen Titel zu geben muss in XAML ganz oben auf der Page das `Title` property gesetzt werden. Dies kann natürlich auch in C# gemacht werden.

* Setze auf allen Pages einen Titel und starte die App nochmal.

Neue Pages können nun einfach beim PageSwitcher hinzugefügt werden so dass nicht immer App.xaml.cs verändert werden muss.

## Aufgabe 5: Trinkgeld berechner
Das Ziel ist eine kleine App welche das Trinkgeld berechnet. Der Benutzer muss hierzu einen Betrag + in Prozent wiviel Trinkgeld er geben will eingeben. Nach einem Klick auf "Berechnen" soll der Wert angezeigt werden.

Damit  im Code auf UI Elemente zugegriffen werden kann muss via dem Property `x:Name="xxxx"` dem Element ein Name gegeben werden. z.B. `<Button x:Name="mybutton" Text="Click me" />`. Im Code (natürlich nur auf der entsprechenden Page) kann dann via `this.myButton` auf den `Button` zugegriffen werden.

Hilfe:
* Erstelle eine neue Page (XAML), zum Beispiel: TipCalculatorPage.
  * Füge die erstellte `TipCalculatorPagePage` als Tab im `ExerciseSwitcherPage` hinzu.
* Füge 2 Eingabefelder hinzu, benutze hierzu ein Layout deiner Wahl, siehe [Dokumentation](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/layouts/)
  * Neugierige können sich an das `GridLayout` wagen. Unsicherere können auch mit dem verschachtelten `StackLayout`s gute Ergebnisse erzielen.
* Es gibt 2 Eingabefelder: Betrag & Prozent für das Trinkgeld
  * Als Eingabefelder sollte `Entry` verwendet werden.
  * Versuche das Keyboard so anzupassen dass nur Zahlen eingegeben werden können [Dokumentation](https://developer.xamarin.com/guides/xamarin-forms/user-interface/text/entry/)
* Füge ein weiteres Label hinzu, welches den folgenden Text beinhalten Soll: "Trinkgeld: x.xx CHF"
* Füge ein Button hinzu "Trinkgeld Berechnen"

### Aufgabe 6b
Ersetze die Textbox mit einem Slider.