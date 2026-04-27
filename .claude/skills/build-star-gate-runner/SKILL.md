---
name: build-star-gate-runner
description: Skill pentru construirea mini-jocului 3D Unity Star Gate Runner, un platformer simplu cu 2 niveluri, stele, usi, vieti, robot AI, tepi, bile pe panta si lava.
---

# Build Star Gate Runner Skill

Foloseste acest skill cand lucrezi la jocul Unity "Star Gate Runner".

## 1. Read Context First

Inainte de orice modificare, citeste:

- CLAUDE.md
- REQUIREMENTS.md
- GAME_DESIGN.md
- IMPLEMENTATION_PLAN.md
- UNITY_SETUP.md
- PROJECT_STRUCTURE.md
- TESTING_CHECKLIST.md

Nu incepe implementarea pana nu intelegi scopul si limitele proiectului.

## 2. Main Objective

Construieste un mini-joc 3D in Unity care respecta cerintele proiectului de facultate.

Jocul trebuie sa aiba:

- 2 niveluri
- 3 vieti per nivel
- stele colectabile
- usi care se deschid dupa colectarea stelelor
- restart la nivelul curent daca playerul moare
- UI pentru vieti si stele
- minimum 3 interactiuni scriptate
- fizica si coliziuni
- prefab-uri
- audio
- iluminare
- animatie
- AI simplu

## 3. Game Rules To Preserve

Nu schimba aceste reguli fara sa intrebi:

### Level 1

- 3 stele de colectat.
- Robotul urmareste playerul.
- Robotul da damage daca atinge playerul.
- Exista tepi activi/inactivi pe o platforma.
- Daca playerul este prins de tepi cand sunt activi, pierde o viata.
- Dupa 3/3 stele, usa se deschide.
- Usa duce la Level_2.

### Level 2

- 5 stele de colectat.
- Nivelul este o panta.
- Bilele cad/spawneaza periodic si se rostogolesc pe panta.
- 4 stele sunt in 4 gauri/refugii din pereti.
- 1 stea este la final, inainte de usa.
- Exista lava sub/langa ultima stea.
- Daca playerul este lovit de bila sau cade in lava, pierde o viata.
- Dupa 5/5 stele, usa finala se deschide.
- Usa finala duce la WinScreen.

### Lives / Lose

- Playerul are 3 vieti per nivel.
- Daca pierde o viata, respawn la checkpoint.
- Daca ajunge la 0 vieti, Game Over.
- Restart dupa Game Over reincarca nivelul curent, nu Level_1 automat.

## 4. Use Existing Unity Systems

Foloseste sisteme existente Unity:

- Starter Assets Third Person Controller pentru player.
- ProBuilder pentru geometrie si niveluri.
- TextMeshPro pentru UI.
- NavMeshAgent pentru robot.
- Rigidbody + Collider pentru bile si fizica.
- Animator pentru usa si/sau tepi.
- AudioSource pentru sunete.

Nu construi movement controller de la zero daca Starter Assets este disponibil.

## 5. Keep It Simple

Evita:
- mecanici extra care nu sunt cerute
- cod foarte abstract
- sisteme complexe de state machine
- AI avansat
- inventory
- combat
- multiplayer
- asset-uri greu de importat
- dependinte externe inutile

## 6. Work Incrementally

Lucreaza in etape:

1. Creeaza structura de scripturi.
2. Implementeaza sistemul de stele.
3. Implementeaza sistemul de vieti.
4. Implementeaza usile si tranzitia intre scene.
5. Implementeaza Level 1: robot + tepi.
6. Implementeaza Level 2: bile + lava.
7. Adauga UI.
8. Adauga audio.
9. Adauga animatie.
10. Pregateste documentatia si checklist-ul.

Dupa fiecare etapa, spune:
- ce fisiere ai modificat
- ce trebuie setat manual in Unity
- cum trebuie testata etapa

## 7. Required Scripts

Creeaza sau mentine aceste scripturi:

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

## 8. Unity Inspector Instructions

Cand scrii cod care depinde de referinte din Inspector, explica exact:

- pe ce GameObject se pune scriptul
- ce campuri trebuie completate
- ce tag-uri trebuie folosite
- ce collider trebuie sa fie trigger
- ce prefab trebuie asignat
- ce scena trebuie trecuta in Build Settings

## 9. Testing Priority

Testeaza in aceasta ordine:

1. Player movement.
2. UI lives/stars.
3. Star collection.
4. Door unlock.
5. Level transition.
6. Player damage.
7. Game Over + restart current level.
8. Robot follow.
9. Timed spikes.
10. Rolling balls.
11. Lava.
12. Win condition.

## 10. Definition of Done

Jocul este gata cand:

- MainMenu incarca Level_1.
- Level_1 poate fi finalizat.
- Level_2 poate fi finalizat.
- Playerul are 3 vieti per nivel.
- Game Over reincarca nivelul curent.
- Stelele sunt colectabile.
- Usile se deschid corect.
- Robotul urmareste playerul.
- Tepii functioneaza.
- Bilele se rostogolesc pe panta.
- Lava produce damage.
- UI-ul functioneaza.
- Exista cel putin 3 sunete.
- Exista cel putin o animatie.
- Exista prefab-uri.
- Nu exista erori in Console.
- Proiectul poate fi build-uit.
