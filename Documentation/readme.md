# Documentation

Use this file to fill in your documentation
### Mob programmnging schema
		1		2		3		4
driver	edgar	elsa	cecilia	anton
cd		elsa	edgar	anton	cecilia
timer	cecilia	anton	edgar	elsa
spy		anton	cecilia	elsa	edgar

## Dagbok
### 2021-03-18
Vi diskuterade arbetssätt och upplägg vi ska köra på.
Vi ska försöka hålla oss till MOB programmeringsarbetssätt.

Vad behöver vi databasmässigt?
*modell som lagrar uppgifter från användare
** data som lagras:
*** användares namn
*** bostadsplanet
*** parkerings starttid
*** parkerings sluttid
*** vilken spaceship
*** kostnad
*** betalt eller inte
*** parkeringsplats (storlek, postion, id, ledig/upptagen)

Hur ser flödet ut?
*användare ange namn
*finns aktiv parkering?
*vill avsluta, starta ändra parkering
*starta (om det finns lediga platser, annars meddela fullt)
	*ange spaceship
	*visa lediga platser
	*ange sluttid
	*meddela parkering startad, position och förväntad kostnad
*avsluta
	*ange spaceship
	*meddela slutpris
	*meddela fakturaadress
	*meddela betaldatum
*ändra
	*ange spaceship
	*ange ny sluttid