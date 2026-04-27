# DOCUMENTATION_TEMPLATE.md

# Documentatie proiect - Star Gate Runner

## 1. Conceptul jocului

Star Gate Runner este un mini-joc 3D de tip platformer realizat in Unity. Jucatorul trebuie sa parcurga doua niveluri, sa colecteze stele si sa deschida usa de iesire din fiecare nivel.

Jocul include obstacole, AI simplu, coliziuni, UI, audio, animatii si conditii clare de win/lose.

## 2. Core Loop

Core loop-ul jocului este:

1. Playerul porneste nivelul.
2. Colecteaza stelele.
3. Evita pericolele.
4. Deschide usa.
5. Trece la nivelul urmator sau castiga jocul.

## 3. Mecanici implementate

### Colectare stele

Playerul colecteaza stele pentru a progresa. In Level 1 trebuie colectate 3 stele, iar in Level 2 trebuie colectate 5 stele.

### Usi blocate/deblocate

Usa fiecarui nivel ramane inchisa pana cand playerul colecteaza toate stelele.

### Sistem de vieti

Playerul are 3 vieti per nivel. Daca pierde toate vietile, nivelul curent este restartat.

### Robot AI

In primul nivel exista un robot care urmareste playerul. Daca robotul atinge playerul, acesta pierde o viata.

### Tepi activi

In Level 1 exista o platforma cu tepi care se activeaza si dezactiveaza periodic. Daca playerul este prins cand tepii sunt activi, pierde o viata.

### Bile pe panta

In Level 2, bilele se rostogolesc periodic pe panta. Playerul trebuie sa se ascunda in gaurile din pereti pentru a le evita.

### Lava

La finalul nivelului 2, playerul trebuie sa sara peste un bazin cu lava. Daca pica in lava, pierde o viata.

## 4. Structura nivelurilor

### Level 1 - Robot and Spikes

- 3 stele
- robot care urmareste playerul
- platforma cu tepi
- usa care se deschide dupa colectarea stelelor

### Level 2 - Rolling Ball Slope

- 5 stele
- panta
- bile care cad periodic
- 4 gauri in pereti cu stele
- ultima stea inainte de usa
- lava sub zona finala
- usa finala catre Win Screen

## 5. Arhitectura proiectului

Scripturile principale sunt:

| Script | Rol |
|---|---|
| GameManager.cs | Gestioneaza stelele, progresul si starea nivelului |
| UIManager.cs | Actualizeaza UI-ul |
| PlayerHealth.cs | Gestioneaza vietile si damage-ul |
| StarCollectible.cs | Gestioneaza colectarea stelelor |
| DoorController.cs | Controleaza deschiderea usii |
| LevelExit.cs | Incarca urmatorul nivel sau WinScreen |
| RobotFollow.cs | Controleaza robotul AI |
| TimedSpikes.cs | Controleaza tepii activi/inactivi |
| RollingBallSpawner.cs | Spawneaza bile periodic |
| BallDamage.cs | Produce damage cand bila loveste playerul |
| LavaDamage.cs | Produce damage cand playerul cade in lava |
| MainMenu.cs | Controleaza butoanele de meniu |

## 6. Fizica si coliziuni

Proiectul foloseste:
- Rigidbody
- Collider
- Trigger Collider
- Sphere Collider pentru bile
- Box Collider pentru platforme/lava/usi
- Collider pentru stele si hazard-uri

Tipuri de interactiuni:
1. Trigger pentru colectarea stelelor.
2. Trigger/Collision pentru damage de la robot, bile, tepi si lava.

## 7. UI

UI-ul afiseaza:
- numarul de stele colectate
- numarul de vieti
- Game Over
- Win Screen
- butoane de restart si meniu

## 8. Audio

Sunetele folosite:
- muzica de fundal
- sunet colectare stea
- sunet damage
- sunet usa deschisa

## 9. Animatii

Animatia principala:
- usa care se deschide dupa colectarea tuturor stelelor

Optional:
- stele rotative
- tepi care se ridica/coboara

## 10. AI simplu

AI-ul este reprezentat de robotul din Level 1. Robotul foloseste un comportament de urmarire a playerului, implementat cu NavMeshAgent sau logica simpla de deplasare catre pozitia playerului.

## 11. Rolurile membrilor echipei

Completati cu numele echipei:

| Membru | Rol |
|---|---|
| Student 1 | Gameplay scripting |
| Student 2 | Level design |
| Student 3 | UI, audio, documentatie |
| Student 4 | Testing, build, GitHub |

## 12. Capturi de ecran necesare

Adauga screenshot-uri cu:
- Main Menu
- Level 1
- colectare stele
- robot
- tepi
- usa deschisa
- Level 2
- panta cu bila
- gauri in pereti
- lava
- Win Screen

## 13. Concluzie

Star Gate Runner demonstreaza conceptele principale studiate in Unity: scripting, coliziuni, fizica, UI, audio, animatie, AI simplu si organizarea unui mini-joc 3D functional.
