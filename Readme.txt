POS - simulacija blagajne implementirana prema uputstvima DZ1

Za pokretanje pokrenuti POS.sln datoteku pomoæu programa Visual Studio.
Alternativno - unutar direktorija POS/bin/debug/ pokrenuti POS.exe datoteku.

Unutar POS/bin/debug/ direktorija nalaze se tekstualne datoteke kljuène za rad aplikacije:
	artikli.txt
	racuni.txt
	login.txt

Ukoliko nedostaje ijedan od navedenih tekstualnih datoteka aplikacija nije u moguænosti funkcionirati ispravno.

Savjetuje se ne mijenjati stavke navedenih datoteka kako se ne bi dogodilo da ih je nemoguæe uèitati.


Opcije podržane unutar aplikacije:
	1. login u sustav: ponuðeni korisnici (admin, blagajnik, x (izlazak iz aplikacije)) - lozinka za svaki je ista kao i korisnièko ime
	2. kreiranje raèuna
		1. dodavanje stavke (uèitava stavke iz artikli.txt i pretvara ih u instance razreda Artikl)
		2. izmjena stavke (izmjena stavke koja postoji. Ukoliko ne postoji, neæe se ništa promijeniti)
		3. proknjižavanje (unos raèuna u bazu podataka (racuni.txt) i ispis raèuna na konzolu)
	3. x - izvješæe: ispis ukupnog prometa za današnji dan i popis svih raèuna napravljenih danas
	4. izvješæe po artiklima: ispis ukupnog prometa od poèetka vremena pa do sada. Artikli su poredani po vrijednosti prodaje (artikal s najveæim ukupnim iznosom nalazi se na prvom mjestu). Dodatno, ukupna vrijednost maloprodaje
	5. dodavanje artikla: unos novog artikla u odreðenom formatu. Mjere opreza navedene u aplikaciji, kako se baza podataka (artikli.txt) ne bi pokvarila
	6. storno raèuna: brisanje raèuna po broju raèuna. Ukoliko raèun s brojem ne postoji - aplikacija æe ispisati obavijest
	7. logout

Ukoliko neka od funkcionalnosti ne radi kako treba, javiti se proizvoðaèu:
@	tijan.tomislav@gmail.com
@	tr46286@fer.hr
@	TijanTomislav.Rados@fer.hr
t	098/198 5934