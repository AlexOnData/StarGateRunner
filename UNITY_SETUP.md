# UNITY_SETUP.md

## Recommended Unity Setup

Foloseste o versiune Unity recenta pe care o ai deja instalata si care functioneaza stabil pe calculatorul tau.

Template recomandat:
- 3D Core sau URP 3D

Daca folosesti Starter Assets URP, URP poate fi mai potrivit. Daca vrei simplitate maxima, poti folosi 3D Core si adaptezi materialele daca este nevoie.

## Packages / Assets To Use

### 1. Starter Assets - Third Person Controller

Rol:
- player movement
- jump
- camera
- input handling

Motiv:
- nu trebuie sa construiesti de la zero miscarea playerului.

### 2. ProBuilder

Rol:
- platforme
- panta
- pereti
- gauri/refugii
- niveluri rapide

Motiv:
- construiesti level design rapid cu forme simple.

### 3. TextMeshPro

Rol:
- UI text pentru stele, vieti, mesaje.

Motiv:
- text clar si usor de modificat.

### 4. AI Navigation / NavMeshAgent

Rol:
- robot care urmareste playerul.

Motiv:
- AI simplu fara sistem complicat.

### 5. Built-in Unity Components

Foloseste:
- Rigidbody
- Collider
- Trigger Collider
- Animator
- AudioSource
- SceneManager
- Directional Light
- Point Light

## Recommended Scene Names

Foloseste exact aceste nume pentru consistenta:

```text
MainMenu
Level_1
Level_2
WinScreen
```

Daca adaugi GameOver separat:

```text
GameOverScreen
```

Dar recomandarea este sa folosesti Game Over ca UI panel in Level_1 si Level_2.

## Build Settings

Adauga scenele in Build Settings in aceasta ordine:

1. MainMenu
2. Level_1
3. Level_2
4. WinScreen

## Tags

Creeaza / foloseste aceste tag-uri:

```text
Player
Star
Enemy
Hazard
Door
Ball
```

Important:
- Playerul trebuie sa aiba tag-ul `Player`.
- Robotul poate avea tag `Enemy`.
- Lava/tepii pot avea tag `Hazard`.
- Bila poate avea tag `Ball`.

## Layers

Optional, dar util:

```text
Player
Enemy
Hazard
Collectible
Environment
```

Nu este obligatoriu daca vrei sa pastrezi proiectul simplu.

## Physics Setup

### Player

- Character Controller sau Rigidbody, in functie de Starter Assets folosit.
- Collider existent din Starter Assets.
- Tag: Player.
- PlayerHealth.cs atasat pe player.

### Stars

- Collider cu `Is Trigger = true`.
- StarCollectible.cs.
- Optional: rotatie continua.

### Door

- Collider normal sau trigger separat pentru zona de intrare.
- DoorController.cs.
- LevelExit.cs pe trigger-ul de iesire.
- Animator pentru Door_Open.

### Robot

- NavMeshAgent.
- Collider.
- RobotFollow.cs.
- Daca atinge playerul, da damage.

### Spikes

- Collider trigger pentru zona de damage.
- TimedSpikes.cs.
- Activeaza/dezactiveaza colliderul la interval.

### Ball

- Sphere Collider.
- Rigidbody.
- BallDamage.cs.
- Prefab spawneat de RollingBallSpawner.cs.

### Lava

- Box Collider cu `Is Trigger = true`.
- LavaDamage.cs.
- Material rosu/orange, optional emissive.

## Suggested Values

### Player

- Lives: 3
- Respawn delay: 0.5 - 1 secunda
- Damage cooldown: 1 secunda

### Robot

- Speed: 2 - 3
- Stopping Distance: 1
- Damage cooldown: 1 secunda

### Spikes

- Active time: 2 secunde
- Inactive time: 2 secunde

### Ball Spawner

- Spawn interval: 4 - 6 secunde
- Ball lifetime: 8 - 12 secunde

## Important Unity Manual Steps

Claude poate crea scripturi si ghida setup-ul, dar verifica manual in Unity:

- scenele sunt in Build Settings
- tag-urile sunt corecte
- referintele din Inspector sunt setate
- prefab-urile au componentele potrivite
- NavMesh-ul este baked pentru robot
- butoanele UI au OnClick setat corect
- Animator-ul usii are trigger-ul corect
- AudioSource-urile au clipurile asignate
