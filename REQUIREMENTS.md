# REQUIREMENTS.md

## Cerinta proiectului

Proiectul trebuie sa fie un mini-joc 3D functional realizat in Unity.

Trebuie sa demonstreze:
- utilizarea corecta a scripting-ului
- implementarea mecanicilor de joc
- fizica si coliziuni
- animatie
- UI
- audio
- iluminare
- AI simplu
- organizarea proiectului

## Cerinte minime obligatorii si cum sunt acoperite

| Cerinta | Implementare in Star Gate Runner |
|---|---|
| Core loop clar | Colecteaza stele -> deschide usa -> treci nivelul |
| Sistem scor/progres | Stars 0/3 in Level 1 si Stars 0/5 in Level 2 |
| Win condition | Playerul trece prin usa finala din Level 2 |
| Lose condition | Playerul pierde toate cele 3 vieti in nivelul curent |
| Minimum 2 niveluri | Level_1 si Level_2 |
| Minimum 3 interactiuni scriptate | stele, usa, robot, tepi, bile, lava |
| Rigidbody si Collider | player, bile, stele, robot, lava, platforme |
| 2 tipuri de coliziuni | trigger pentru stele/lava, collision pentru platforme/bile |
| Meniu Start + Restart | MainMenu si GameOver panel/screen |
| Prefab-uri | Player, Star, Door, Robot, Spikes, Ball, Lava |
| UI | text pentru stele, vieti, mesaje |
| Cel putin o animatie | usa care se deschide si/sau tepi activi |
| Audio | muzica, colectare stea, damage, usa |
| Iluminare | Directional Light + lumini locale |
| AI simplu | robot cu NavMeshAgent care urmareste playerul |

## Functional Requirements

### General

- Jocul are 2 niveluri.
- Fiecare nivel are propriile stele si propria usa.
- Usa se deschide doar dupa ce toate stelele din nivel au fost colectate.
- Playerul are 3 vieti per nivel.
- La 0 vieti, restart la nivelul curent.
- Dupa Level 2, jocul se finalizeaza cu Win Screen.

### Level 1

- Are 3 stele de colectat.
- Include un robotel care urmareste playerul.
- Daca robotul atinge playerul, playerul pierde 1 viata.
- Include o platforma cu tepi.
- Tepii se activeaza/dezactiveaza la intervale regulate.
- Daca playerul este pe platforma cand tepii sunt activi, pierde 1 viata.
- Dupa colectarea celor 3 stele, usa se deschide.
- Cand playerul intra prin usa, se incarca Level 2.

### Level 2

- Are 5 stele de colectat.
- Nivelul este construit pe o panta.
- La intervale regulate cade/spawneaza o bila care se rostogoleste pe panta spre player.
- Daca bila atinge playerul, playerul pierde 1 viata.
- Exista 4 gauri/refugii in pereti.
- Fiecare din cele 4 gauri contine cate o stea.
- A cincea stea este la final, inainte de usa.
- Sub ultima stea sau langa ea se afla un bazin cu lava.
- Playerul trebuie sa sara peste lava.
- Daca playerul cade in lava, pierde 1 viata.
- Dupa colectarea celor 5 stele, usa finala se deschide.
- Cand playerul intra prin usa finala, jocul este castigat.

## Non-Functional Requirements

- Jocul trebuie sa fie usor de explicat.
- Codul trebuie sa fie organizat.
- Nivelurile trebuie sa fie simple.
- Trebuie folosite pachete Unity existente unde se poate.
- Nu se construieste un sistem complex inutil.
- Proiectul trebuie sa fie potrivit pentru un proiect de facultate.

## Required Scenes

- MainMenu
- Level_1
- Level_2
- WinScreen

Optional:
- GameOverScreen

Recomandare: Game Over poate fi un UI panel in fiecare nivel, ca sa fie mai simplu.

## Required UI

In nivel:
- Stars: current / total
- Lives: current
- Message text: "Collect all stars to open the door", "Door opened", "Game Over"

Main Menu:
- Start Game
- Quit

Game Over:
- Restart Current Level
- Main Menu

Win Screen:
- You Win
- Play Again
- Main Menu
