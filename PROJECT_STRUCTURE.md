# PROJECT_STRUCTURE.md

## Target Unity Folder Structure

```text
Assets/
  Animations/
    Door_Open.anim
    Spikes_Up_Down.anim

  Audio/
    background_music.wav
    collect_star.wav
    damage.wav
    door_open.wav

  Materials/
    Platform_Mat.mat
    Wall_Mat.mat
    Star_Mat.mat
    Lava_Mat.mat
    Door_Mat.mat

  Models/
    PlaceholderModels/

  Prefabs/
    Player.prefab
    Star.prefab
    Door.prefab
    Robot.prefab
    Spikes.prefab
    RollingBall.prefab
    Lava.prefab

  Scenes/
    MainMenu.unity
    Level_1.unity
    Level_2.unity
    WinScreen.unity

  Scripts/
    GameManager.cs
    UIManager.cs
    PlayerHealth.cs
    StarCollectible.cs
    DoorController.cs
    LevelExit.cs
    RobotFollow.cs
    TimedSpikes.cs
    RollingBallSpawner.cs
    BallDamage.cs
    LavaDamage.cs
    MainMenu.cs

  UI/
    Fonts/
    Sprites/
```

## Markdown / Claude Setup Files

In radacina proiectului:

```text
CLAUDE.md
REQUIREMENTS.md
GAME_DESIGN.md
IMPLEMENTATION_PLAN.md
UNITY_SETUP.md
PROJECT_STRUCTURE.md
TESTING_CHECKLIST.md
DOCUMENTATION_TEMPLATE.md
PROMPTS_FOR_CLAUDE.md
```

In `.claude`:

```text
.claude/
  skills/
    build-star-gate-runner/
      SKILL.md
```

## Script Responsibilities

### GameManager.cs

Responsabil pentru:
- stele colectate
- total stele per nivel
- notificare catre UI
- notificare catre usa cand toate stelele sunt colectate
- stare de joc: playing, game over, win

### UIManager.cs

Responsabil pentru:
- text stele
- text vieti
- mesaje temporare
- Game Over panel
- Restart button

### PlayerHealth.cs

Responsabil pentru:
- vieti
- TakeDamage()
- damage cooldown
- respawn la checkpoint
- game over la 0 vieti
- restart current level

### StarCollectible.cs

Responsabil pentru:
- detectarea playerului
- colectarea stelei
- sunet colectare
- dezactivarea/distrugerea stelei

### DoorController.cs

Responsabil pentru:
- starea usii: locked/unlocked/open
- animatia de deschidere
- sunet usa
- activare trigger iesire

### LevelExit.cs

Responsabil pentru:
- verificarea daca usa este deschisa
- incarcarea scenei urmatoare
- WinScreen dupa Level_2

### RobotFollow.cs

Responsabil pentru:
- gasirea playerului
- urmarirea playerului cu NavMeshAgent
- damage la contact

### TimedSpikes.cs

Responsabil pentru:
- alternarea intre activ/inactiv
- activarea colliderului de damage
- optional animatie/spawn visual

### RollingBallSpawner.cs

Responsabil pentru:
- spawn periodic bila
- setarea pozitiei de spawn
- distrugerea bilei dupa lifetime

### BallDamage.cs

Responsabil pentru:
- damage la contact cu playerul
- optional distrugerea bilei dupa impact

### LavaDamage.cs

Responsabil pentru:
- damage cand playerul intra in trigger-ul de lava
- respawn player

### MainMenu.cs

Responsabil pentru:
- Start Game
- Restart Current Level
- Main Menu
- Quit Game
