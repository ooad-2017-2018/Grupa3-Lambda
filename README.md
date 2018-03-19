# Ambasada - Vize
###### Team Lambda

1. Ali Dlakić
1. Džemil Džigal
1. Midhat Hodo

## Opis Teme


Ova aplikacija omogućava efikasnije i jednostavnije upravljanje postupka 
prijave, potvrde i izdavanja viza u ambasadi države Elektrotehne. Proces je automatizovan tako
što se prijave vrše preko internet stranice ambasade, potvrđivanje zahtijeva
vrše uposlenici ambasade. Nakon potvrde prijave idu u tombolu gdje se metodom
slučajnog izbora bira predodređen broj odobrenih viza. Kroz čitav proces uposlenicima
će biti dostupni izvještaji.

## Proces

Osoba podnosi zahtjev na zvaničnoj stranici ambasade sa svim potrebnim informacijama.
Ta osoba dobija email potvrde da je njihov zahtjev u procesu obrade.

Uposlenici imaju listu zahtijeva na čekanju sa koje potvrđuju prijave koje su isprave i saglasne sa pravilnikom ambasade.

Nakon isteka roka prijave vršit ce se tombola u kojoj će se dodijeliti viza
najsretnijim prijavama. 

Administrator dodaje i briše račune uposlenih u ambasadi. Također ima pristup zapisu svih dešavanja (log).

## Funkcionalnosti

- Podnošenje prijave preko web stranice (bez pravljenja računa)
- Zabrana duplih prijava (isti email, isti JMBG)
- Obaviještavanje podnosioca o prijemu prijave putem emaila
- Potvrđivanje ili odbijanje zahtijeva preko aplikacije (uposlenici ambasade)
- Obaviještavanje podnosioca o potvrdi prijave
- Pokretanje tomobole (nakon isteka roka i procesiranja svih prijava)
- Obavještavanje podnosioca o rezultatu tombole
- Uposlenik može poslati email podnosiocima prijava radi dodatnih informacija ili obavijesti
- Print vize samo ako je dodijeljenja osobi
- Administrator dodaje/briše račune uposlenika
- Administrator mijenja sadržaj templatea emaila.
