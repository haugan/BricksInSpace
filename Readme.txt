IS-PRG2000: OBLIGATORISK DELOPPGAVE 1/3
"BRICKS IN SPACE"

29.02.2016
Marius Haugan
hauganmarius@outlook.com

DOKUMENTASJON
Kontroller:
* Bevege romskip til venstre: 'A'
* Bevege romskip til høyre: 'D'
* Skyte missil: 'K'

Om spillet:
* Spiller må først velge navn, deretter starte spillet - via spillets meny.
* Spilleren må manøvrere romskipet for å unngå fiendene, og samtidig forsøke skyte dem ned.
* Poengsummen beregnes ut i fra hvor raskt fienden beveger seg, samt fiendens størrelse.
* Jo vanskeligere det er å treffe fienden, jo mer poeng får spilleren.
* Når det er 1 minutt igjen på klokka, dobler hyppigheten til fienden seg,
  så spillet blir vanskeligere.
* Spillet avsluttes etter to minutter, hvilket synliggjøres av nedtelleren i høyre topphjørne.
* Spillerens navn og poengsum holdes oppdatert i venstre topphjørne.
* Poengsum og navn kan lagres til en .txt fil, som holdes automatisk sortert. 
* Fil med poengsum og navn kan lagres og åpnes via spillets meny.

Om programmeringa:
* Prinsippet om innkapsling holdes hellig, så langt det lar seg gjøre.
  Metoder og klassefelt er ikke "public" eller "static" med mindre det er strengt nødvendig.
  C# Properties er flittig brukt.
* For å unngå "flickering" ved oppdatering av Paint-event 
  tegnes grafikkobjektene på en PictureBox.
  Refresh() metoden kalles i MainTimer med en intervall på 18 millisekunder.
* En Random nummergenerator forer parameterverdier til konstruktøren for SpriteWorker-klassen.
  Det gjør at bakgrunns- og fiendeobjekter får tilfeldig genererte størrelser, hastigheter,
  posisjoner og farger.
* Det er forsøkt å holde koden enkel og lesbar.
  7 iterasjoner av utviklinga er utført,
  for å forenkle designet og utvikle egen forståelse
  av OOP prinsipper og software design.

Spillets hovedklasse MainWindow.cs tar for seg..
* det visuelle oppsettet av hovedvinduet, text labels og spillområdet.
* alle events: timer ticks, key press, menu item clicks og graphics painting.
* all spillogikk (inkl. teste om missil treffer fiende, eller fiende treffer spiller).
* beregning av poeng. 
* kall til konstruktøren i SpriteWorker.cs.

Spillets grafikkobjekt-klasse SpriteWorker.cs tar for seg..
* generering av grafikkobjekter for spiller, fiender-, missil- og bakgrunnsobjekter.
* oppdatering av grafikkobjektenes bevegelse i henhold til x og y-posisjoner.
* retur av rektangelobjekter for hit detection i hovedklassen.

Spillets lydspiller-klasse SoundPlayer.cs tar for seg..
* lydavspilling ved missilskudd, treff på fiende, og musikkavspilling ved "Game Over".

Spillets poengsum-klasse ScoreLogger.cs tar for seg..
* Lagring, oppdatering, sortering og fil-skriving av poengsum og spillernavn.

Bugs:
* En uoppdaget feil i algoritmen til metoden for sortering av poengsum og skriving til fil,
  gjør at verdiene lagres dobbelt. Sorteringen kan bli feil pga dette.
* Noen fiendeobjekter lar seg ikke skyte,
  særlig etter "dobbel-hastighet" når vanskelighetsgraden på spillet øker.