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
Vi diskuterade arbetssätt och upplägg vi ska köra på.
Vi ska försöka hålla oss till MOB programmeringsarbetssätt.

Applikation ska bli på engelska, det ska bli konsolapplikation, man använder tangentbord, menyer kommer som text i konsolen

* Vad behöver vi databasmässigt?
  * användares namn
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

Hur ser flödet ut?
* användare ange namn
* finns aktiv parkering?
* vill avsluta, starta ändra parkering
* starta (om det finns lediga platser, annars meddela fullt)
	* ange spaceship
	* visa lediga platser
	* ange sluttid
	* meddela parkering startad, position och förväntad kostnad
* avsluta
	* ange spaceship
	* meddela slutpris
	* meddela fakturaadress
	* meddela betaldatum
* ändra
	* ange spaceship
	* ange ny sluttid
	* meddela parkering startad, position och förväntad kostnad

### 2021-03-19

Vi diskuterade angående databas lösningen och kom fram till att vi ska använda docker och MSSQLserver lokalt på varsin dator.
#### Docker kommando (windows power-shell) att känna till:

* Hämtar MSSQL container
```
docker pull mcr.microsoft.com/mssql/server
```
* Kör MSSQL lokalt
```
docker run -d -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=My!P@ssw0rd1" -p 1433:1433 --name SpaceParkDb mcr.microsoft.com/mssql/server
```
#### VS Package Manager Console kommando att känna till:
* Skapar ett ny "migration" fil
```
add-migration DbUpdate
```
* Updater databasmodell enligt senaste migration filen
```
update-database
```

#### Källkoden
* Vi skapade projekt SpaceParkApi som ska innehålla application data hantering
* Vi la på följande NuGet paket:
  * Microsoft.EntityFrameworkCore.SqlServe
  * Microsoft.EntityFrameworkCore.Design
  * Microsoft.EntityFrameworkCore.Tools
* Vi skapade DdContextModel klasser samt konfigurerade DbContext klassen som ansvar för databas modellens uppbyggnad.
* Vi skapade initiala migreringsfilen och uppdaterad databasen, det funkade för resten av oss att uppdatera lokalal databaser enligt denna fil

### 2021-03-22
#### Källkoden
* Vi skapade namespace klass SWApi som ska hantera anrop till awapi.dev/api. Vi skapade följande metoder för klassen SWApi:
  * GetAllUsers()
  * GetAllStarShips()
  * GetUserById(int user)

### 2021-03-24
* Implementerade AddParkingRegistration.
* Testade lägga till en ParkingRegistration i databasen.
* Upptäckte att samma användare får olika UserID:n i ParkingRegistration-tabellen.
* Implementerat flöde som låter användaren välja SpaceShip.
