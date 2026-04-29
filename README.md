Coding-Assistent
Hier sind prägnante Bullet Points, die du für deine Präsentationsfolien oder als Spickzettel nutzen kannst, um dein Projekt und die technische Umsetzung professionell zu präsentieren:

1. Projekt-Kern (Die Vision)
Zentralisierung: Aufbau eines einheitlichen Management-Systems für E-Sport und Team-Events.

Simulation-Fokus: Unterstützung verschiedener Plattformen (ACC, iRacing, LMU) in einer gemeinsamen App.

UX-Optimierung: Effiziente Planung und Kommunikation für Teammitglieder durch klare Rollenverteilung.

2. Technische Architektur 
MVVM-Pattern: Strikte Trennung von UI (View), Logik (ViewModel) und Daten (Model).

Objektorientierte Vererbung: Einsatz von Klassenhierarchien (Event -> Race -> RaceACC), um redundanten Code zu vermeiden.

Polymorphie & Dynamik: Einsatz von DataTemplates und ContentControls, um die UI automatisch an den Event-Typ anzupassen.

Schnittstellen: Dynamische Daten-Anbindung durch IValueConverter (z. B. für Simulation-spezifische Farbkodierung).

3. Highlights & Herausforderungen 
Dynamische UI-Generierung: Nutzung von DataTriggers im XAML, um komplexe Formulare (wie Livestream-URLs oder League-Links) bedarfsgerecht ein- und auszublenden.

Erweiterbarkeit: Die Architektur erlaubt das Hinzufügen neuer Events oder Sim-Typen in Minuten ohne Eingriff in die Kernlogik.

Daten-Persistenz: Polymorphe Speicherung von Objekten in JSON-Dateien, um die Typ-Hierarchie beim Laden beizubehalten.
