# TESTING_CHECKLIST.md

## General Testing

- [ ] Jocul porneste din MainMenu.
- [ ] Butonul Start Game incarca Level_1.
- [ ] Playerul se poate misca.
- [ ] Playerul poate sari.
- [ ] Camera urmareste playerul corect.
- [ ] UI-ul afiseaza vietile.
- [ ] UI-ul afiseaza stelele colectate.
- [ ] Exista muzica/sunet de fundal.

## Level 1 Testing

- [ ] Level_1 are 3 stele.
- [ ] Fiecare stea poate fi colectata o singura data.
- [ ] UI-ul ajunge de la Stars 0/3 la Stars 3/3.
- [ ] Usa ramane inchisa daca nu ai toate cele 3 stele.
- [ ] Usa se deschide dupa 3/3 stele.
- [ ] Trecerea prin usa incarca Level_2.
- [ ] Robotul urmareste playerul.
- [ ] Robotul produce damage la contact.
- [ ] Damage-ul robotului scade o singura viata, nu toate instant.
- [ ] Tepii se activeaza si dezactiveaza.
- [ ] Tepii produc damage doar cand sunt activi.
- [ ] La pierderea unei vieti, playerul este respawnat.
- [ ] La 0 vieti, apare Game Over.
- [ ] Restart Current Level reincarca Level_1.

## Level 2 Testing

- [ ] Level_2 are 5 stele.
- [ ] 4 stele sunt in gaurile/refugiile din pereti.
- [ ] A cincea stea este la final, inainte de usa.
- [ ] UI-ul ajunge de la Stars 0/5 la Stars 5/5.
- [ ] Usa finala ramane inchisa daca nu ai toate cele 5 stele.
- [ ] Usa finala se deschide dupa 5/5 stele.
- [ ] Trecerea prin usa finala incarca WinScreen.
- [ ] Bila se spawneaza periodic.
- [ ] Bila se rostogoleste pe panta.
- [ ] Bila produce damage la contact.
- [ ] Bilele sunt distruse dupa un timp.
- [ ] Playerul se poate ascunde in gaurile din pereti.
- [ ] Lava produce damage cand playerul cade in ea.
- [ ] La 0 vieti, apare Game Over.
- [ ] Restart Current Level reincarca Level_2.

## UI Testing

- [ ] MainMenu are Start Game.
- [ ] MainMenu are Quit, optional.
- [ ] GameOver panel are Restart Current Level.
- [ ] GameOver panel are Main Menu.
- [ ] WinScreen are Play Again / Main Menu.
- [ ] Mesajul "Door opened" apare cand se deschide usa, optional.
- [ ] Mesajul "Collect all stars first" apare daca playerul incearca usa prea devreme, optional.

## Audio Testing

- [ ] Exista muzica de fundal.
- [ ] Se aude sunet la colectarea stelei.
- [ ] Se aude sunet la damage.
- [ ] Se aude sunet la deschiderea usii, optional dar recomandat.

## Animation Testing

- [ ] Usa are animatie de deschidere.
- [ ] Animatia usii porneste doar cand toate stelele sunt colectate.
- [ ] Stelele se pot roti, optional.
- [ ] Tepii se pot misca, optional.

## Build Testing

- [ ] Scenele sunt adaugate in Build Settings.
- [ ] Build-ul executabil porneste.
- [ ] Nu exista erori rosii in Console.
- [ ] Jocul poate fi terminat de la inceput pana la WinScreen.
