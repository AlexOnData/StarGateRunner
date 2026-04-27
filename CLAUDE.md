# CLAUDE.md

## Project Context

Acest proiect este pentru disciplina "Dezvoltarea jocurilor pe calculator" si are ca scop construirea unui mini-joc 3D functional in Unity.

Jocul trebuie sa fie simplu, clar, realizabil rapid si sa respecte cerintele proiectului:
- scripting
- mecanici de joc
- fizica si coliziuni
- UI
- audio
- iluminare
- animatie
- AI simplu
- minimum 2 niveluri
- sistem de progres
- conditie de Win si Lose
- repository GitHub, build si documentatie

## Game Title

Titlu de lucru: **Star Gate Runner**

## High-Level Game Idea

Jocul este un 3D platformer simplu. Playerul trebuie sa colecteze stele pentru a deschide usa fiecarui nivel.

Jocul are 2 niveluri:
1. Level 1: playerul colecteaza 3 stele, evita un robot care il urmareste si o platforma cu tepi activi/inactivi.
2. Level 2: playerul urca o panta, evita bile care se rostogolesc periodic, se ascunde in gauri din pereti, colecteaza 5 stele si sare peste lava inainte de usa finala.

## Important Gameplay Rules

- Playerul are maximum 3 vieti per nivel.
- Cand playerul pierde o viata, este respawnat la checkpoint-ul nivelului curent.
- Daca playerul ajunge la 0 vieti, apare Game Over.
- Restart-ul dupa Game Over reincarca nivelul curent, nu tot jocul de la inceput.
- In Level 1 trebuie colectate 3 stele.
- In Level 2 trebuie colectate 5 stele.
- Usa se deschide doar dupa colectarea tuturor stelelor din nivel.
- Dupa usa din Level 1 se incarca Level 2.
- Dupa usa din Level 2 se afiseaza Win Screen.

## Use Existing Unity Packages

Nu construi totul de la zero. Foloseste pachete si componente existente din Unity unde este posibil:

- Starter Assets - Third Person Controller pentru player movement si camera.
- ProBuilder pentru constructia rapida a nivelurilor, platformelor, pantei si peretilor.
- TextMeshPro pentru UI.
- NavMeshAgent / AI Navigation pentru robotul care urmareste playerul.
- Rigidbody si Collider pentru fizica.
- Animator pentru usa si/sau tepi.
- AudioSource pentru sunete.

## Simplicity Rules

Pastreaza jocul simplu.

Evita:
- sisteme complexe de inventar
- combat system
- skill tree
- multiplayer
- procedural generation
- asset-uri externe inutile
- cod exagerat de abstract
- mecanici care nu sunt cerute

## Coding Style

- Scrie cod C# simplu si usor de explicat.
- Organizeaza codul in componente separate.
- Foloseste nume clare pentru clase, metode si variabile.
- Comenteaza doar acolo unde clarifica logica.
- Evita dependinte inutile.
- Nu modifica mecanica de baza fara sa mentionezi motivul.
- Nu sterge fisiere fara confirmare.

## Preferred Script Components

Scripturi recomandate:

- GameManager.cs
- UIManager.cs
- PlayerHealth.cs
- StarCollectible.cs
- DoorController.cs
- LevelExit.cs
- RobotFollow.cs
- TimedSpikes.cs
- RollingBallSpawner.cs
- BallDamage.cs
- LavaDamage.cs
- MainMenu.cs

## Working Style With Claude

Inainte sa implementezi:
1. Citeste toate fisierele `.md` din radacina proiectului.
2. Citeste skill-ul din `.claude/skills/build-star-gate-runner/SKILL.md`.
3. Propune un plan pe etape.
4. Nu incerca sa construiesti tot jocul dintr-un singur pas.
5. Lucreaza incremental.
6. Dupa fiecare etapa, spune ce fisiere ai creat/modificat si ce trebuie verificat in Unity.

## Final Deliverables

La final proiectul trebuie sa includa:

- Unity project functional
- 2 niveluri
- Main Menu
- Game Over / Restart current level
- Win Screen
- UI pentru stele si vieti
- Player cu miscare si saritura
- Stele colectabile
- Usi care se deschid dupa colectarea stelelor
- Robot AI care urmareste playerul
- Tepi activi/inactivi
- Bile care cad periodic pe panta
- Lava
- Audio minim: muzica, colectare, damage/interactiune
- Iluminare
- Cel putin o animatie
- Prefab-uri
- Documentatie
