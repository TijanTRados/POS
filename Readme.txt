POS - simulacija blagajne implementirana prema uputstvima DZ1

Za pokretanje pokrenuti POS.sln datoteku pomo�u programa Visual Studio.
Alternativno - unutar direktorija POS/bin/debug/ pokrenuti POS.exe datoteku.

Unutar POS/bin/debug/ direktorija nalaze se tekstualne datoteke klju�ne za rad aplikacije:
	artikli.txt
	racuni.txt
	login.txt

Ukoliko nedostaje ijedan od navedenih tekstualnih datoteka aplikacija nije u mogu�nosti funkcionirati ispravno.

Savjetuje se ne mijenjati stavke navedenih datoteka kako se ne bi dogodilo da ih je nemogu�e u�itati.


Opcije podr�ane unutar aplikacije:
	1. login u sustav: ponu�eni korisnici (admin, blagajnik, x (izlazak iz aplikacije)) - lozinka za svaki je ista kao i korisni�ko ime
	2. kreiranje ra�una
		1. dodavanje stavke (u�itava stavke iz artikli.txt i pretvara ih u instance razreda Artikl)
		2. izmjena stavke (izmjena stavke koja postoji. Ukoliko ne postoji, ne�e se ni�ta promijeniti)
		3. proknji�avanje (unos ra�una u bazu podataka (racuni.txt) i ispis ra�una na konzolu)
	3. x - izvje��e: ispis ukupnog prometa za dana�nji dan i popis svih ra�una napravljenih danas
	4. izvje��e po artiklima: ispis ukupnog prometa od po�etka vremena pa do sada. Artikli su poredani po vrijednosti prodaje (artikal s najve�im ukupnim iznosom nalazi se na prvom mjestu). Dodatno, ukupna vrijednost maloprodaje
	5. dodavanje artikla: unos novog artikla u odre�enom formatu. Mjere opreza navedene u aplikaciji, kako se baza podataka (artikli.txt) ne bi pokvarila
	6. storno ra�una: brisanje ra�una po broju ra�una. Ukoliko ra�un s brojem ne postoji - aplikacija �e ispisati obavijest
	7. logout

Ukoliko neka od funkcionalnosti ne radi kako treba, javiti se proizvo�a�u:
@	tijan.tomislav@gmail.com
@	tr46286@fer.hr
@	TijanTomislav.Rados@fer.hr
t	098/198 5934