# IMPLEMENTATION_PLAN.md

## Implementation Philosophy

Construieste jocul incremental. Nu incerca sa faci totul intr-un singur pas.

Prioritatea este:
1. Functionalitate.
2. Respectarea cerintelor.
3. Simplitate.
4. Aspect vizual decent.

## Phase 0 - Unity Project Setup

### Tasks

- Creeaza proiect Unity 3D.
- Instaleaza/importa pachetele necesare:
  - Starter Assets - Third Person Controller
  - ProBuilder
  - TextMeshPro
  - AI Navigation/NavMesh daca este necesar
- Creeaza structura folderelor.
- Creeaza scenele:
  - MainMenu
  - Level_1
  - Level_2
  - WinScreen

### Done When

- Proiectul porneste.
- Scenele exista.
- Playerul din Starter Assets poate fi folosit.

## Phase 1 - Folder Structure

Creeaza structura:

```text
Assets/
  Animations/
  Audio/
  Materials/
  Models/
  Prefabs/
  Scenes/
  Scripts/
  UI/
```

### Done When

- Folder structure exista in Unity project.
- Scripturile noi vor fi puse in `Assets/Scripts`.

## Phase 2 - Core Managers

### Scripts

- GameManager.cs
- UIManager.cs
- PlayerHealth.cs
- MainMenu.cs

### Functionality

- GameManager tine numarul de stele si totalul necesar.
- UIManager actualizeaza textul pentru stele si vieti.
- PlayerHealth gestioneaza damage, vieti, respawn si game over.
- MainMenu gestioneaza Start, Restart si Quit.

### Done When

- UI afiseaza Stars si Lives.
- Playerul are 3 vieti.
- Damage scade vieti.
- La 0 vieti se poate restarta nivelul curent.

## Phase 3 - Collectibles and Doors

### Scripts

- StarCollectible.cs
- DoorController.cs
- LevelExit.cs

### Functionality

- Stelele pot fi colectate cu trigger collider.
- UI-ul se actualizeaza.
- La toate stelele colectate, usa se deschide.
- Usa Level 1 incarca Level_2.
- Usa Level 2 incarca WinScreen.

### Done When

- Level 1: 3 stele deschid usa.
- Level 2: 5 stele deschid usa.
- Usa nu permite trecerea daca nu ai toate stelele.

## Phase 4 - Level 1

### Build

Creeaza nivel simplu cu ProBuilder:
- platforme
- zona de start
- zona robot
- platforma cu tepi
- zona usa

### Scripts

- RobotFollow.cs
- TimedSpikes.cs

### Functionality

- Robotul urmareste playerul.
- Robotul da damage la contact.
- Tepii alterneaza activ/inactiv.
- Tepii dau damage doar cand sunt activi.

### Done When

- Level 1 poate fi terminat.
- Cele 3 stele pot fi colectate.
- Robotul si tepii pot lua vieti.
- Usa se deschide corect.

## Phase 5 - Level 2

### Build

Creeaza nivel simplu cu ProBuilder:
- panta lunga
- pereti laterali
- 4 gauri/refugii in pereti
- zona finala cu lava
- usa finala

### Scripts

- RollingBallSpawner.cs
- BallDamage.cs
- LavaDamage.cs

### Functionality

- Bilele apar periodic in partea de sus.
- Bilele se rostogolesc pe panta.
- Bilele dau damage la contact cu playerul.
- Lava da damage daca playerul cade in ea.
- 4 stele sunt in gaurile din pereti.
- Ultima stea este langa usa finala, inainte de lava/dupa saritura.

### Done When

- Playerul poate urca panta.
- Playerul se poate ascunde in gauri.
- Bilele pot fi evitate.
- 5 stele deschid usa finala.
- Trecerea prin usa finala afiseaza Win Screen.

## Phase 6 - Audio, Animation, Lighting

### Audio

Adauga:
- background music
- star collect sound
- damage sound
- door open sound

### Animation

Adauga cel putin:
- Door_Open

Optional:
- Star rotation
- Spikes up/down

### Lighting

Adauga:
- Directional Light
- lumini locale langa usi/lava/zone importante

### Done When

- Exista minimum 3 tipuri de sunete.
- Exista cel putin o animatie.
- Scenele sunt iluminate corect.

## Phase 7 - Prefabs

Creeaza prefab-uri pentru:

- Player
- Star
- Door
- Robot
- Spikes
- RollingBall
- Lava
- UI Canvas, optional

### Done When

- Obiectele reutilizabile sunt prefab-uri.
- Nivelurile nu contin multe obiecte duplicate neorganizate.

## Phase 8 - Testing

Testeaza:

- Level 1 poate fi castigat.
- Level 2 poate fi castigat.
- Daca pierzi 3 vieti in Level 1, restart la Level 1.
- Daca pierzi 3 vieti in Level 2, restart la Level 2.
- Stelele nu se pot colecta de doua ori.
- Usa nu se deschide prea devreme.
- Robotul nu ramane blocat.
- Bilele nu se aduna infinit in scena.
- Lava si tepii dau damage corect.
- UI-ul afiseaza valorile corecte.

## Phase 9 - Documentation

Creeaza documentatia pentru predare:

- concept joc
- mecanici implementate
- arhitectura proiectului
- rolurile membrilor echipei
- capturi de ecran
- cum se ruleaza jocul
