IS-PRG2000: OBLIGATORISK DELOPPGAVE 1/3
"BRICKS IN SPACE"

29.02.2016
Marius Haugan
hauganmarius@outlook.com

DOKUMENTASJON
Kontroller:
* Bevege romskip til venstre: 'A'
* Bevege romskip til h�yre: 'D'
* Skyte missil: 'K'

Om spillet:
* Spiller m� f�rst velge navn, deretter starte spillet - via spillets meny.
* Spilleren m� man�vrere romskipet for � unng� fiendene, og samtidig fors�ke skyte dem ned.
* Poengsummen beregnes ut i fra hvor raskt fienden beveger seg, samt fiendens st�rrelse.
* Jo vanskeligere det er � treffe fienden, jo mer poeng f�r spilleren.
* N�r det er 1 minutt igjen p� klokka, dobler hyppigheten til fienden seg,
  s� spillet blir vanskeligere.
* Spillet avsluttes etter to minutter, hvilket synliggj�res av nedtelleren i h�yre topphj�rne.
* Spillerens navn og poengsum holdes oppdatert i venstre topphj�rne.
* Poengsum og navn kan lagres til en .txt fil, som holdes automatisk sortert. 
* Fil med poengsum og navn kan lagres og �pnes via spillets meny.

Om programmeringa:
* Prinsippet om innkapsling holdes hellig, s� langt det lar seg gj�re.
  Metoder og klassefelt er ikke "public" eller "static" med mindre det er strengt n�dvendig.
  C# Properties er flittig brukt.
* For � unng� "flickering" ved oppdatering av Paint-event 
  tegnes grafikkobjektene p� en PictureBox.
  Refresh() metoden kalles i MainTimer med en intervall p� 18 millisekunder.
* En Random nummergenerator forer parameterverdier til konstrukt�ren for SpriteWorker-klassen.
  Det gj�r at bakgrunns- og fiendeobjekter f�r tilfeldig genererte st�rrelser, hastigheter,
  posisjoner og farger.
* Det er fors�kt � holde koden enkel og lesbar.
  7 iterasjoner av utviklinga er utf�rt,
  for � forenkle designet og utvikle egen forst�else
  av OOP prinsipper og software design.

Spillets hovedklasse MainWindow.cs tar for seg..
* det visuelle oppsettet av hovedvinduet, text labels og spillomr�det.
* alle events: timer ticks, key press, menu item clicks og graphics painting.
* all spillogikk (inkl. teste om missil treffer fiende, eller fiende treffer spiller).
* beregning av poeng. 
* kall til konstrukt�ren i SpriteWorker.cs.

Spillets grafikkobjekt-klasse SpriteWorker.cs tar for seg..
* generering av grafikkobjekter for spiller, fiender-, missil- og bakgrunnsobjekter.
* oppdatering av grafikkobjektenes bevegelse i henhold til x og y-posisjoner.
* retur av rektangelobjekter for hit detection i hovedklassen.

Spillets lydspiller-klasse SoundPlayer.cs tar for seg..
* lydavspilling ved missilskudd, treff p� fiende, og musikkavspilling ved "Game Over".

Spillets poengsum-klasse ScoreLogger.cs tar for seg..
* Lagring, oppdatering, sortering og fil-skriving av poengsum og spillernavn.

Bugs:
* En uoppdaget feil i algoritmen til metoden for sortering av poengsum og skriving til fil,
  gj�r at verdiene lagres dobbelt. Sorteringen kan bli feil pga dette.
* Noen fiendeobjekter lar seg ikke skyte,
  s�rlig etter "dobbel-hastighet" n�r vanskelighetsgraden p� spillet �ker.