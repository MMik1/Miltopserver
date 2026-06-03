# Functional Design Document (FDD)

## General description
Een rebranding van de pagina "'t Bundertje", waarbij we een simulatie toevoegen voor kinderen over hoe het grondwater werkt, en een game op de website plaatsen die door gamedevelopers wordt ontwikkeld.

## Functional requirements
#### Website
* Je ziet in real-time de grondwaterstand via de API;
* "Wat gebeurt er?" simulatie door middel de gekozen:
  * Seizoen (ook visueel);
  * Temperatuur;
  * Hoeveelheid regen.
* De website is responsive.

#### Game
* Volledig bestuurbaar met muis/touchscreen;
* 3 levels met verschillende obstakels:
  * Te veel water: sleep pompen in de pomp vakken om het water te minderen;
  * Te weinig water: sleep infiltratievelden naar de velden op het gras;
  * Vervuiling: sleep zuiverings pompen naar de pomp slots om vervuild water te zuiveren;
  * Mogelijk: 4de level met combinaties van hiervoor benoemde obstakels.
* Pop-ups met weetjes -> start van het level;
* Scoreboard;
* Een bewegend waterpijl meter.

## Non-functional requirements
#### Website
* Er is een seizoensindicator;
* "Wist je dat?" sectie;
* De website design/gebruik is gericht op de doelgroep van 6-12.

#### Game
* Kind-vriendelijk UI (6-12);
* Kleine storyline over de game.
* Polishing in geluid/visuals om succes aan te duiden.