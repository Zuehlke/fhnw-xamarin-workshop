# Xamarin Installation

> **Ziel:** Hello World Applikation läuft so dass das Notebook bereit ist für die nächsten Lektionen.

## Mac

* XCode aus AppStore installieren
* Xamarin Studio installieren: http://www.xamarin.com/download
* Xamarin Installationsdokumentation: https://developer.xamarin.com/guides/android/getting_started/installation/mac/
* Xamarin Studio Starten: Tools -> SDK Manager -> API 24 Komponenten installieren
* Ein neues Hello World Projekt erstellen: File -> New Solution -> Multiplatofrm -> App -> Single View App
* Hello World App versuchen zu Starten
* Wenns nicht geht: Tools -> Google Emulator Manager -> Dort entweder eine neue Konfiguration erstellen oder die API vom existierenden auf API 24 ändern.

## Windows

Für iOS wird ein OS X benötigt. Darum wird auf Windows nur Android installiert. Ich werde in der Vorlesung jedoch noch zeigen wie man auf Windows (mithilfe eines Macs) sogar iOS Applikationen starten kann.


Grundsätzlich beinhaltet dies folgende Punkte
* Visual Studio installieren. Wichtig: Dabei die Xamarin Cross Platform Tools auswählen im Dialog wo man die einzelnen Funktionen auswählen kann.
* Neues Android Projekt erstellen. SDK installieren falls nicht vorhanden. Ausprobieren obs startet
* Sicherstellen das JDK 1.8 installiert ist (allenfalls unter Tools => Options => Xamarin => Android Options) ändern

Installationsdokumentation von Xamarin mit Visual Studio 2015:
https://developer.xamarin.com/guides/android/getting_started/installation/windows/
Hilfestellung: https://msdn.microsoft.com/en-us/library/mt613162.aspx

Oder Visual Studio 2017 RC:
https://www.visualstudio.com/de/vs/visual-studio-2017-rc/
