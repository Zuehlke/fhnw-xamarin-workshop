# Aufgaben Tag 3
## Aufgabe 1: Navigation
* Erstelle 3 Pages
  * Start
  * Mitte
  * Ende
* Gestalte die Page so dass man diese entsprechend erkennt.
* Auf jeder Seite soll es ein Zurück und ein weiter Button haben. 
* Der Zurück Button navigiert zurück
* Der weiter Button navigiert auf die nächste Page
* Auf der letzten Page soll es ein Button haben "Zurück zum Start" welcher zum Start zurück navigiert.
  * Finde heraus, wie man dies bewerkstelligt

## Aufgabe 2: Tipping Calculator
* Erstelle ein neues leeres Xamarin Projekt: TippingCalculator
* Inkompatible Projekte können rausgelöscht werden (OS X: kein Windows Phone, Windows: keine iOS Projekte)
* Als erstes wird ein `TippingModel` benötigt welches folgende Properties beinhaltet:
  * Amount (Wieviel wurde bezahlt)
  * Tip (in %)
  * Total
* Erstelle ein UI mit `Amount` und `Tip` und dem `Total`. 
  * Alle 3 Werte sollen mit DataBinding aufs Model gebindet werden
  * Für `Amount` und `Tip` eignen sich `Entry``
  * Für `Total` ein `Label`
* Implementiere `INotifyPropertyChanged` für das TippingModel
* Füge einen Button "Berechnen" hinzu. Beim klicken auf den Button soll das Total berechnet und ins `TippingModel` geschrieben werden welches via Binding die Änderungen direkt aufs UI rendert.

## Aufgabe 3: Simple Todo App
* Erstelle ein `TodoModel` mit folgenden Properties
  * Beschreibung (string)
  * Done (bool)
* Der Kipp-Schalter heisst in Xamarin.Forms `Switch`
* Beginne mit der View und hardcodiere 3-4 Todos.