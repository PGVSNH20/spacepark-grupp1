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

Vi diskuterade ang�ende databas l�sningen och kom fram till att vi ska anv�nda docker och MSSQLserver lokalt p� varsin dator.
#### Docker kommandot (windows powershell) att k�nna till:

* H�mtar MSSQL container
```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```
* K�r MSSQL lokalt
```
docker run -d -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=My!P@ssw0rd1" -p 1433:1433 --name SpaceParkDb mcr.microsoft.com/mssql/server - latest
```
#### VS Package Manager Console komandot att k�nna till:
* Skapar ett ny "migration" fil
```
add-migration DbUpdate
```
* Updater databasmodell enligt senaste migration filen
```
update-database
```

#### K�llkoden
* Vi skapade projekt SpaceParkApi som ska inneh�lla application data hantering
* Vi la p� f�ljadne NuGet paket:
  * Microsoft.EntityFrameworkCore.SqlServe
  * Microsoft.EntityFrameworkCore.Design
  * Microsoft.EntityFrameworkCore.Tools
* Vi skapade DdContextModel klasser samt konfigurerade DbContext klassen som ansvar f�r databas modellens uppbyggnad.
* Vi skapada initiala migrerigs filen och uppdaterad databasen, det funkade f�r resten av oss att uppdatera lokalal databaser enligt denna fil
