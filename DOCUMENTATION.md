# Documentatie proiect — Star Gate Runner

**Disciplina:** Dezvoltarea jocurilor pe calculator
**Autor:** Marcean Alex
**Tehnologie:** Unity 6 (6000.4.4f1) + Universal Render Pipeline + C#
**Data predare:** 2026-05-05

---

- [Documentatie proiect — Star Gate Runner](#documentatie-proiect--star-gate-runner)
  - [1. Conceptul jocului](#1-conceptul-jocului)
    - [1.1. Genre](#11-genre)
    - [1.2. Target](#12-target)
  - [2. Core loop](#2-core-loop)
  - [3. Cerinte proiectului acoperite](#3-cerinte-proiectului-acoperite)
  - [4. Structura nivelurilor](#4-structura-nivelurilor)
    - [4.1. Level 1 — Robot and Spikes](#41-level-1--robot-and-spikes)
    - [4.2. Level 2 — Rolling Ball Slope](#42-level-2--rolling-ball-slope)
  - [5. Mecanici implementate](#5-mecanici-implementate)
    - [5.1. Player movement (Starter Assets)](#51-player-movement-starter-assets)
    - [5.2. Sistem de stele si progres](#52-sistem-de-stele-si-progres)
    - [5.3. Sistem de vieti si respawn](#53-sistem-de-vieti-si-respawn)
    - [5.4. Usi care se deschid conditionat](#54-usi-care-se-deschid-conditionat)
    - [5.5. Tranzitie intre scene](#55-tranzitie-intre-scene)
    - [5.6. AI simplu — Robot urmaritor](#56-ai-simplu--robot-urmaritor)
    - [5.7. Tepi cu animatie procedurala](#57-tepi-cu-animatie-procedurala)
    - [5.8. Bile rolling cu fizica reala](#58-bile-rolling-cu-fizica-reala)
    - [5.9. Lava](#59-lava)
    - [5.10. UI Manager](#510-ui-manager)
    - [5.11. Cursor management](#511-cursor-management)
  - [6. Arhitectura proiectului](#6-arhitectura-proiectului)
    - [6.1. Structura folderelor](#61-structura-folderelor)
    - [6.2. Roluri scripturi](#62-roluri-scripturi)
    - [6.3. Patterns folosite](#63-patterns-folosite)
  - [7. Fizica si coliziuni](#7-fizica-si-coliziuni)
    - [7.1. Componente folosite](#71-componente-folosite)
    - [7.2. Cele doua tipuri de coliziuni](#72-cele-doua-tipuri-de-coliziuni)
  - [8. UI](#8-ui)
    - [8.1. Componente](#81-componente)
    - [8.2. Scenele UI dedicate](#82-scenele-ui-dedicate)
    - [8.3. Wiring butoane](#83-wiring-butoane)
  - [9. Audio](#9-audio)
    - [9.1. Lista clipuri (toate in `Assets/Audio/`)](#91-lista-clipuri-toate-in-assetsaudio)
    - [9.2. Configurare AudioSource](#92-configurare-audiosource)
  - [10. Animatii](#10-animatii)
    - [10.1. Door — Animator + AnimationClip](#101-door--animator--animationclip)
    - [10.2. Spikes — Animatie procedurala](#102-spikes--animatie-procedurala)
    - [10.3. Star — rotatie continua](#103-star--rotatie-continua)
  - [11. Iluminare](#11-iluminare)
  - [12. AI simplu](#12-ai-simplu)
  - [13. Rolurile membrilor echipei](#13-rolurile-membrilor-echipei)
  - [14. Cum se ruleaza jocul](#14-cum-se-ruleaza-jocul)
    - [14.1. Din Unity Editor](#141-din-unity-editor)
    - [14.2. Din build](#142-din-build)
    - [14.3. Controale](#143-controale)
  - [15. Capturi de ecran necesare](#15-capturi-de-ecran-necesare)
  - [16. Concluzie](#16-concluzie)


---

## 1. Conceptul jocului

**Star Gate Runner** este un mini-joc 3D de tip platformer realizat in Unity. Jucatorul controleaza un personaj third-person care trebuie sa parcurga doua niveluri, sa colecteze stele pentru a debloca usa fiecarui nivel, sa evite obstacole si AI inamic, si sa finalizeze jocul prin trecerea prin usa finala.

Jocul demonstreaza folosirea integrata a conceptelor predate la curs: scripting, mecanici de joc, fizica si coliziuni, UI, audio, iluminare, animatie, AI simplu, organizarea proiectului, build si predare prin Git.

### 1.1. Genre

3D platformer cu elemente de:
- colectare de obiecte (stele)
- evitare obstacole (tepi, bile, lava)
- AI inamic (robot urmaritor)
- progres pe niveluri
- conditii clare de Win / Lose

### 1.2. Target

Proiect didactic cu scop demonstrativ. Gameplay cu durata de 5-10 minute la prima parcurgere.

---

## 2. Core loop

```
[Start] → Player apare in nivel
        → Exploreaza traseul
        → Colecteaza stele (3 in Level 1, 5 in Level 2)
        → Evita pericolele (robot, tepi, bile, lava)
        → La total stele colectate, usa se deschide
        → Trece prin usa
        → [Level 1] → incarca Level 2
        → [Level 2] → incarca Win Screen
```

In paralel:
- La fiecare contact cu pericol → pierde 1 viata + respawn la checkpoint
- La 0 vieti → Game Over → Restart Current Level

---

## 3. Cerinte proiectului acoperite

| Cerinta | Implementare in joc |
|---|---|
| Core loop clar | Colecteaza stele → deschide usa → treci nivelul |
| Sistem scor / progres | UI `Stars: x/3` in Level 1, `Stars: x/5` in Level 2 |
| Win condition | Trecere prin usa finala din Level 2 → WinScreen |
| Lose condition | Pierdere 3 vieti → Game Over → Restart Current Level |
| Minim 2 niveluri | `Level_1.unity` si `Level_2.unity` |
| Minim 3 interactiuni scriptate | Stele, usi, roboti, tepi, bile, lava |
| Rigidbody + Collider | Bile rotative cu `Rigidbody` non-kinematic + `Sphere Collider` |
| 2 tipuri de coliziuni | **Trigger** (stele, lava, exit, spikes, robot) + **Collision** (bile vs player) |
| Meniu Start + Restart | `MainMenu.unity` cu Start, GameOver Panel cu Restart |
| Prefab-uri | Door, Lava, Player, Robot, Spikes, Star, Sphere (RollingBall) |
| UI | TMP texts pentru stele, vieti, mesaje, paneluri Game Over si Win |
| Cel putin o animatie | Animator pe Door (`Door_Open.anim`) + animatie procedurala pe Spikes |
| Audio | Background ambient + SFX (collect, damage, door, spikes, robot, ball, lava) |
| Iluminare | Directional Light + lumini ambientale pe scena |
| AI simplu | Robot cu `NavMeshAgent` care urmareste playerul |

---

## 4. Structura nivelurilor

### 4.1. Level 1 — Robot and Spikes

- **Stele:** 3 plasate pe traseu
- **Pericole:**
  - Robot AI care urmareste playerul cu NavMeshAgent. Damage la contact.
  - Platforma cu tepi care se ridica din pamant la interval de ~2s. Damage cand sunt activi.
- **Obiectiv:** Colecteaza toate cele 3 stele → usa se deschide → treci la Level 2.

### 4.2. Level 2 — Rolling Ball Slope

- **Stele:** 5 totale (4 in gauri laterale din pereti + 1 finala langa usa)
- **Pericole:**
  - Bile cu Rigidbody care se rostogolesc periodic pe panta. Damage la contact.
  - Bazin de lava intre panta si platforma finala. Player-ul trebuie sa sara peste. Primeste damage daca intra in lava.
- **Obiectiv:** Colecteaza toate cele 5 stele → usa finala se deschide → treci prin usa → Win Screen.

---

## 5. Mecanici implementate

### 5.1. Player movement (Starter Assets)

Folosim pachetul oficial **Starter Assets — Third Person Controller** (Unity Asset Store, v1.1.7) pentru:
- Miscare WASD
- Sprint (Shift)
- Saritura (Space)
- Camera cu Cinemachine (`PlayerFollowCamera.prefab`)
- Input System nou

Justificare: scriptul `ThirdPersonController.cs` din Starter Assets ofera comportament de player robust si testat. CLAUDE.md indica explicit folosirea acestor pachete.

### 5.2. Sistem de stele si progres

Implementat in `GameManager.cs` cu pattern singleton (`Instance`):

```csharp
public void AddStar()
{
    starsCollected++;
    uiManager.UpdateStars(starsCollected, totalStarsInLevel);
    if (starsCollected >= totalStarsInLevel)
    {
        levelDoor.OpenDoor();
    }
}
```

Stelele (`StarCollectible.cs`) folosesc `OnTriggerEnter` cu filtru `CompareTag("Player")`. La colectare se redau sunet (`PlayClipAtPoint` ca sa supravietuiasca destroy-ului), si se distruge.

### 5.3. Sistem de vieti si respawn

Implementat in `PlayerHealth.cs`:
- 3 vieti per nivel, configurabile in Inspector
- Cooldown 1 secunda intre damage-uri (previne pierderea instant a 3 vieti)
- Respawn la checkpoint dupa 0.5s daca mai are vieti
- Game Over la 0 vieti

Respawn-ul foloseste pattern-ul standard pentru `CharacterController`:
```csharp
characterController.enabled = false;
transform.SetPositionAndRotation(pos, rot);
characterController.enabled = true;
```

### 5.4. Usi care se deschid conditionat

`DoorController.cs` are stare `isOpen` plus 3 efecte la deschidere:
- `animator.SetTrigger("Open")` — porneste animatia rotatie
- `openAudio.Play()` — sunet de usa
- `blockingCollider.enabled = false` — playerul poate trece

Idempotenta — dublu-apel `OpenDoor()` nu repeta animatia.

### 5.5. Tranzitie intre scene

`LevelExit.cs` este un trigger separat plasat dupa usa. Verifica `door.IsOpen()` inainte sa accepte. Daca usa e inca inchisa, afiseaza mesaj "Collect all stars first!". La trecere, executa `SceneManager.LoadScene(nextSceneName)` cu cursor unlock pentru scenele UI.

### 5.6. AI simplu — Robot urmaritor

`RobotFollow.cs` foloseste `NavMeshAgent`:
- Cauta playerul prin tag `Player`
- Reactualizeaza destinatia la fiecare 0.2s (throttle pentru performanta)
- Damage la contact prin `OnTriggerEnter` + `OnTriggerStay`
- Cooldown intern 1s + cooldown din PlayerHealth = dublu-protectie

Necesita NavMesh baked pe podea. Pachetul `com.unity.ai.navigation 2.0.12` cu `NavMeshSurface`.

### 5.7. Tepi cu animatie procedurala

`TimedSpikes.cs` are coroutine cu ciclu:
1. Asteapta `inactiveTime` (jos)
2. Reda audio + ridica visualul smooth (Lerp pe Y) cu `transitionDuration`
3. Asteapta `activeTime` (sus, damage activ)
4. Coboara visualul smooth + dezactiveaza damage

Pozitia "UP" e pozitia initiala in editor. Pozitia "DOWN" = UP + `hiddenYOffset` (default `-0.5`, sub platforma). Damage activ doar in faza UP.

### 5.8. Bile rolling cu fizica reala

`RollingBallSpawner.cs` instantiaza prefabul ball periodic la varful pantei. Bila are `Rigidbody` non-kinematic — gravitatia o roteste pe panta natural. `BallDamage.cs` aplica damage la contact (`OnCollisionEnter` pentru cazul non-trigger, `OnTriggerEnter` pentru flexibilitate). Bilele sunt distruse automat dupa `ballLifetime` secunde — previne acumulare in scena.

### 5.9. Lava

`LavaDamage.cs` cu trigger collider. `OnTriggerEnter` aplica damage si declanseaza respawn (prin lantul `PlayerHealth.TakeDamage` → `Invoke(Respawn)`).

### 5.10. UI Manager

`UIManager.cs` gestioneaza:
- Texte HUD (`Stars`, `Lives`, `Message`)
- Paneluri (`GameOver`, `Win`) cu cursor unlock automat la afisare
- Mesaje temporare cu `ShowMessage(text, duration)` pe Coroutine

### 5.11. Cursor management

Logica blocare/eliberare cursor:
- `MainMenu.StartGame` / `RestartCurrentLevel` → blocheaza pentru gameplay
- `MainMenu.LoadMainMenu` → elibereaza pentru meniu
- `UIManager.ShowGameOver` / `ShowWin` → elibereaza pentru click pe butoane
- `LevelExit.OnTriggerEnter` → elibereaza pentru WinScreen
- `PlayerHealth.Start` → blocheaza defensiv la fiecare scena de gameplay

---

## 6. Arhitectura proiectului

### 6.1. Structura folderelor

```
StarGateRunner/
├── Assets/
│   ├── Animations/         # Door_AC.controller + Door_Open.anim
│   ├── Audio/              # 8 clipuri MP3 ambient + SFX
│   ├── Materials/          # Materiale pentru obiecte
│   ├── Models/             # Modele 3D (placeholder)
│   ├── Prefabs/            # Player, Star, Door, Robot, Spikes, RollingBall, Lava
│   ├── Scenes/             # MainMenu, Level_1, Level_2, WinScreen
│   ├── Scripts/            # Cele 12 scripturi C#
│   ├── StarterAssets/      # Pachet Starter Assets - Third Person Controller URP v1.1.7
│   ├── UI/                 # Fonturi si sprite-uri UI (gol momentan, TMP default)
│   └── Settings/           # URP profile assets
├── Packages/
│   ├── manifest.json       # Dependinte: probuilder, ai.navigation, characters-animation, URP, etc.
│   └── packages-lock.json
├── ProjectSettings/        # Tags, Build Settings, Quality, etc.
└── Documente .md (CLAUDE.md, REQUIREMENTS.md, DOCUMENTATION.md, ...)
```

### 6.2. Roluri scripturi

| Script | Responsabilitate |
|---|---|
| `GameManager.cs` | Singleton per scena. Tine numar stele colectate, totalul cerut, starea jocului (Playing/GameOver/Win). Notifica UIManager si DoorController. |
| `UIManager.cs` | Refresh texte HUD (`Stars`, `Lives`, `Message`). Afisare paneluri Game Over si Win. Coroutine pentru mesaje temporare. Cursor unlock cand paneluri apar. |
| `PlayerHealth.cs` | Vieti, damage cu cooldown, respawn la checkpoint, Game Over. Lock cursor in `Start()`. |
| `StarCollectible.cs` | OnTriggerEnter detecteaza player, apeleaza `GameManager.AddStar()`, reda sunet via `PlayClipAtPoint`, distruge steaua. Rotatie continua pentru efect vizual. |
| `DoorController.cs` | Stare `isOpen`. La `OpenDoor()`: trigger Animator, play audio, dezactiveaza blockingCollider. |
| `LevelExit.cs` | Trigger separat care verifica `door.IsOpen()` si incarca scena urmatoare. Cursor unlock pe transition. |
| `RobotFollow.cs` | NavMeshAgent care urmareste playerul. Damage prin trigger cu cooldown. |
| `TimedSpikes.cs` | Coroutine ciclu activ/inactiv. Animatie procedurala UP/DOWN cu Lerp. Damage prin trigger cand activ. |
| `RollingBallSpawner.cs` | Instantiaza ball prefab la interval. Destroy automat dupa lifetime. |
| `BallDamage.cs` | OnCollisionEnter + OnTriggerEnter. Damage la contact cu player. |
| `LavaDamage.cs` | Trigger. Damage la intrare → declanseaza respawn automat prin lantul PlayerHealth. |
| `MainMenu.cs` | Butoane: Start Game, Restart Current Level, Load Main Menu, Quit Game. Lock/unlock cursor pe transition. |

### 6.3. Patterns folosite

- **Singleton** (per scena, fara `DontDestroyOnLoad`): `GameManager.Instance` — punct unic de acces din `StarCollectible`, `PlayerHealth` etc.
- **Auto-discovery via `FindFirstObjectByType<T>()`** — fallback daca referinta din Inspector nu e setata.
- **Coroutine cycles** — `TimedSpikes`, `RollingBallSpawner`, `UIManager.MessageCoroutine`.
- **`Reset()` lifecycle hook** — autosetare `isTrigger = true` cand componenta e adaugata in editor.
- **Idempotent state changes** — `DoorController.OpenDoor()`, `GameManager.SetGameOver()` previn dublu-trigger.

---

## 7. Fizica si coliziuni

### 7.1. Componente folosite

- **`CharacterController`** — pe Player (din Starter Assets). Permite miscare predictibila si Move-based.
- **`Rigidbody`** non-kinematic — pe Rolling Balls. Gravitatia simuleaza rostogolirea pe panta natural.
- **`NavMeshAgent`** — pe Robot. AI navigation peste mesh baked.
- **`Box Collider`, `Capsule Collider`, `Sphere Collider`** — pe diverse obiecte.

### 7.2. Cele doua tipuri de coliziuni

**Tipul 1 — Trigger (`isTrigger = true`):**

| Obiect | Script | Eveniment | Efect |
|---|---|---|---|
| Star | `StarCollectible` | OnTriggerEnter | Adauga stea + sunet + destroy |
| Lava | `LavaDamage` | OnTriggerEnter | Damage + respawn |
| ExitTrigger | `LevelExit` | OnTriggerEnter | Verifica usa + load scena |
| Spikes | `TimedSpikes` | OnTriggerEnter + OnTriggerStay | Damage cand activ |
| Robot | `RobotFollow` | OnTriggerEnter + OnTriggerStay | Damage cu cooldown |

**Tipul 2 — Collision (`isTrigger = false`):**

| Obiect | Script | Eveniment | Efect |
|---|---|---|---|
| Rolling Ball | `BallDamage` | OnCollisionEnter | Damage la player |
| Platforme | (fara script) | implicit | Player nu cade prin |
| Door blocking | (fara script) | implicit | Player nu trece pana usa nu se deschide |

---

## 8. UI

### 8.1. Componente

In fiecare scena de gameplay (`Level_1`, `Level_2`):
- `HUDCanvas` — Canvas Screen Space Overlay
  - `StarsText` (TMP) — colt stanga sus, "Stars: x/3" sau "Stars: x/5"
  - `LivesText` (TMP) — colt dreapta sus, "Lives: x"
  - `MessageText` (TMP) — center, mesaje temporare ("Door opened!", "Collect all stars first!")
  - `GameOverPanel` — semi-transparent + text "GAME OVER" + butoane Restart, Main Menu (initial inactive)
  - `WinPanel` — analog (folosit doar in Level_2 daca e cazul)

### 8.2. Scenele UI dedicate

- **`MainMenu.unity`** — Title + Start Button + Quit Button + MenuController cu MainMenu script
- **`WinScreen.unity`** — Title "YOU WIN!" + Play Again Button + Main Menu Button + MenuController

### 8.3. Wiring butoane

Toate butoanele folosesc UnityEvent `On Click()` cu drag pe `MenuController` (sau `UIManagerObject`) si selectie metoda din dropdown:
- `MainMenu.StartGame()` — incarca Level_1
- `MainMenu.RestartCurrentLevel()` — reincarca scena curenta
- `MainMenu.LoadMainMenu()` — incarca MainMenu
- `MainMenu.QuitGame()` — iesire

---

## 9. Audio

### 9.1. Lista clipuri (toate in `Assets/Audio/`)

| Fisier | Folosire |
|---|---|
| `volcano.mp3` | Background ambient in scenele de gameplay (lava/magma) |
| `menu music.mp3` | Background pentru MainMenu si WinScreen |
| `points intake.mp3` | Sunet la colectarea unei stele |
| `stone door.mp3` | Sunet la deschiderea usii |
| `spike.mp3` | Sunet la activarea tepilor |
| `robot walk.mp3` | Sunet ambiant pe robot |
| `heavy rock rolling.mp3` | Sunet ambiant pe bile rotative |
| `rolling huge rock.mp3` | Alternative pentru bile mari |

### 9.2. Configurare AudioSource

- **Background ambient (`volcano`):** `Play On Awake = true`, `Loop = true`, `Volume = 0.4-0.6`, `Spatial Blend = 0` (2D)
- **SFX positionale (spikes, robot):** `Play On Awake = false`, `Loop = false`, `Spatial Blend = 1` (3D)
- **SFX trigger (collect, damage, door):** apelate manual prin `AudioSource.Play()` sau `AudioSource.PlayClipAtPoint()` din scripturi

---

## 10. Animatii

### 10.1. Door — Animator + AnimationClip

- `Animator Controller`: `Assets/Animations/Door_AC.controller`
- `AnimationClip`: `Assets/Animations/Door_Open.anim`

State machine:
```
Entry → Closed (default) →[Open trigger]→ Door_Open
```

Clip `Door_Open.anim`: rotatia Y de la 0° la 90° in 1 secunda, `Loop Time = false`.

Trigger declansat din `DoorController.OpenDoor()`:
```csharp
animator.SetTrigger("Open");
```

### 10.2. Spikes — Animatie procedurala

In loc de Animator, foloseste Coroutine cu `Vector3.Lerp` pe `transform.localPosition`:
- Pozitie UP (visible deasupra platformei) = pozitie initiala in editor
- Pozitie DOWN (ascunsa sub platforma) = UP + `hiddenYOffset` (default `-0.5`)
- Tranzitie smooth in `transitionDuration` (default 0.3s)

Justificare: scriptul controleaza si miscarea si starea `damageCollider.enabled` si audio simultan, fara nevoia de state machine si AnimationEvents.

### 10.3. Star — rotatie continua

In `StarCollectible.Update()`:
```csharp
transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
```

Default `rotationSpeed = 90f` (90°/sec).

---

## 11. Iluminare

- **`Directional Light`** in fiecare scena — soare general, intensity 1, Soft Shadows.
- **Lumini ambientale** procedurale prin URP Volume + setarile default URP.
- **Materiale emissive** pe lava (rosu/portocaliu emissive in `Lava_Mat.mat`) pentru efect vizual fara a necesita Point Light dedicat.

Iluminarea e realtime (nu baked), pentru simplitate la build.

---

## 12. AI simplu

Implementat in `RobotFollow.cs` cu `NavMeshAgent`:

```csharp
void Update()
{
    if (player == null || !agent.isOnNavMesh) return;
    if (Time.time - lastPathTime < repathInterval) return;
    lastPathTime = Time.time;
    agent.SetDestination(player.position);
}
```

**Caracteristici:**
- Throttle re-path la 0.2s — performanta + comportament natural
- Pathfinding pe `NavMesh` baked in `Level_1` cu `NavMeshSurface` (`Collect Objects = All Game Objects`)
- Damage la contact prin trigger cu cooldown

**Limitari intentionate:** robotul nu sare, nu trage, nu are FOV — un singur comportament: urmareste in linie dreapta accesibila pe NavMesh.

---

## 13. Rolurile membrilor echipei

Proiectul a fost realizat **individual**.

| Membru | Rol |
|---|---|
| **AlexOnData** | Toate componentele: scripting (12 scripturi C#), level design (geometrie ProBuilder + plasare obiecte), UI/UX (TMP + paneluri), audio (sourcing + integrare), animatie (Animator + procedural), build, documentatie, GitHub |

---

## 14. Cum se ruleaza jocul

### 14.1. Din Unity Editor

1. Deschide proiectul cu Unity 6 (6000.4.4f1) sau compatibila.
2. Asteapta importul pachetelor (Cinemachine, ProBuilder, AI Navigation etc.).
3. Deschide scena `Assets/Scenes/MainMenu.unity`.
4. Apasa Play.
5. Click `Start Game`.

### 14.2. Din build

1. `File → Build Settings`.
2. Verifica scenele (in ordine):
   - Index 0: MainMenu
   - Index 1: Level_1
   - Index 2: Level_2
   - Index 3: WinScreen
3. `Build` → genereaza executabil Windows.
4. Ruleaza `.exe`.

### 14.3. Controale

| Actiune | Tasta |
|---|---|
| Miscare | `WASD` |
| Camera | Mouse (cursor blocat in centru) |
| Saritura | `Space` |
| Sprint | `Shift` |
| Iesire mod cursor (in Editor) | `Esc` |

---

## 15. Capturi de ecran necesare

Capturi de ecran din Meniu si GamePlay provenite din folderul `Screenshots/`:

- [ ] **Main Menu** — ecranul de start
![image](Screenshots/MainMenu.png)
- [ ] **Level 1 — vizualizare ansamblu** — playerul + arena + roboti + tepi
![image](Screenshots/lvl1_main.png)
- [ ] **Level 1 — colectare stea** — moment de pickup (efect vizual + UI Stars actualizat)
![image](Screenshots/lvl1_collect.png)
- [ ] **Level 1 — robot urmarind** — robotul aproape de player
![image](Screenshots/lvl1_robotFollow.png)
- [ ] **Level 1 — tepi activi** — momentul cand ies din platforma
![image](Screenshots/lvl1_spikes.png)
- [ ] **Level 1 — usa deschisa** — dupa 3/3 stele
![image](Screenshots/lvl1_door.png)
- [ ] **Level 2 — vizualizare panta** — bilele care cad pe panta
![image](Screenshots/lvl2_main.png)
- [ ] **Level 2 — stalpi laterali + stele** — refugiile cu stele
![image](Screenshots/lvl2_pillars.png)
- [ ] **Level 2 — lava & usa finala** — bazinul de lava + ultima stea + ultima usa
![image](Screenshots/lvl2_lava_door.png)
- [ ] **Win Screen** — ecranul final
![image](Screenshots/WinScreen.png)
- [ ] **Game Over Panel** — panelul cu Restart + Main Menu
![image](Screenshots/GameOver.png)
- [ ] **HUD** — capturi cu UI vizibil (Stars + Lives counter)
![image](Screenshots/HUD.png)
- [ ] **Inspector** — capturi cu prefab-urile (Player, Robot, Door, etc.) si componentele lor
![image](Screenshots/prefabs.png)
- [ ] **NavMesh Bake** — captura cu stratul albastru pe podea Level_1
![image](Screenshots/lvl1_navMesh.png)

---

## 16. Concluzie

**Star Gate Runner** demonstreaza integrat conceptele studiate la cursul de Dezvoltarea jocurilor pe calculator:

- **Scripting C#** — 12 scripturi cu responsabilitati clare si interfata simpla
- **Mecanici de joc** — colectare, vieti, restart, progres, conditii Win/Lose
- **Fizica si coliziuni** — Rigidbody, CharacterController, Trigger + Collision
- **UI** — TextMeshPro, paneluri, butoane wired prin UnityEvents
- **Audio** — ambient + SFX positionale + SFX-uri trigger
- **Iluminare** — Directional Light + materiale emissive
- **Animatie** — Animator state machine pe usa + animatie procedurala pe tepi
- **AI simplu** — NavMeshAgent care urmareste playerul
- **Organizare** — folder structure clara, prefab-uri, scenele in Build Settings

Proiectul este complet, functional, testabil si **respecta toate cerintele temei**. Codul e mentinut simplu si lizibil, fara abstractizari inutile, conform principiului "keep it simple" din `CLAUDE.md`.

---

