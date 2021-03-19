# Documentation
### Mob programmnging schema
|   |  1 |  2 | 3  |  4 |
|---|---|---|---|---|
| driver  | edgar  | elsa  | cecilia  |  anton |
| cd  |  elsa |  edgar |  anton |  cecilia |
| timer  | cecilia  | anton  | edgar  | elsa  |
| spy  | anton  | cecilia  | elsa  |  edgar |

## Dagbok
### 2021-03-18
Vi diskuterade arbetss�tt och uppl�gg vi ska k�ra p�.
Vi ska f�rs�ka h�lla oss till MOB programmeringsarbetss�tt.

Applikation ska bli p� engelska, det ska bli konsolapplikation, man anv�nder tangentbord, menyer kommer som text i konsolen

* Vad beh�ver vi databasm�ssigt?
  * anv�ndares namn
  * bostadsplanet
  * parkerings starttid
  * parkerings sluttid
  * vilken spaceship
  * kostnad
  * betalt eller inte
  * parkeringsplats (storlek (length), position, id, ledig/upptagen)

* Klasser/Tabeller
  * User
  * ParkingSpot
  * ParkingRegistration
  * Spaceship (bara klass)

Hur ser fl�det ut?
* anv�ndare ange namn
* finns aktiv parkering?
* vill avsluta, starta �ndra parkering
* starta (om det finns lediga platser, annars meddela fullt)
	* ange spaceship
	* visa lediga platser
	* ange sluttid
	* meddela parkering startad, position och f�rv�ntad kostnad
* avsluta
	* ange spaceship
	* meddela slutpris
	* meddela fakturaadress
	* meddela betaldatum
* �ndra
	* ange spaceship
	* ange ny sluttid
	* meddela parkering startad, position och f�rv�ntad kostnad

### 2021-03-19

Vi diskuterade ang�enda databas l�sningen och kom fram till att vi ska anv�nda docker och MSSQLserver lokalt p� varsin dator