
Prethoughts

Design

Maze











Collectibles
Easy:  Box recipe 3+ Ingredients
Middle:  Muffin 6+ Ingredients
Hard:  Cupcake 10+ Ingredients

Character
Character is a mixing bowl, who changes appearance during the collection of ingredients


Recipe 
Find the recipe
Receive a recipe after winning the game
Grocery list
Menue/ Cookbook to collect all recipes


Gamefunctions

Maze
Wände sind nicht durchdringbar (character stopp/ border)
Hoch genug dass man nur slightly darüber hinweg sehen kann (Kameralauf)

Collectable
Springen auf ihrem platz
Partikel/ Funken sprühen
Verschwinden wenn character damit in Berührung kommt 

Character
Läuft durch maze (constante bewegeung vor zurück rechts llinks, nicht hoch und nicht runter, kein springen)
Char veränderung bei kontakt mit collectables 
Kann nicht durch wände gehen

recipe/ menue
Anklicken möglich (durch cursor auf pixel bereich, enter wird gedrückt)
Enthält zutatenrechner, zB für 6, 12, 24 muffins (auch krumme zahlen können eingegeben werden, zB für 8 muffins, aber nur anze zahlen, keine 12,5 möglich)
Während des spiels läuft die Zeit (stoppt automatisch im Ziel)
Bei Spielende screenshot (wird im Menü abgespeichert)





Documentation

13.06.23
Object Player kann laufen, kann nicht durch wände laufen, höhe der Wände eingestellt

18.06.23
Assets heraus gesucht (Figur ist eine Rührschüssel, collectables sind zutaten..)
Assets bearbeitet

28.06.23
Object player läuft flüssiger, mit Unity eigenem KI System ausgestattet (Problem, richtungswechsel wird erst angezeigt wenn man mit dem spieler nach vorne läuft)
level 1 labyrinth erstellt.
Problem mit richtungswechsel behoben

01.07.23
Collectables poppen nacheinander, random auf der Karte auf.

Functionalities

Player control (back, forth, right, left - based on pathfinding A.I.)
Camera follows player
Collectibles spawn randomly
Collectibles appear in a determined order
Player can collect collectibles
Player changes appearance, when level completed
Collectibles float up and down/ spark for attention
