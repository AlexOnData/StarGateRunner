# GAME_DESIGN.md

## Title

**Star Gate Runner**

## Genre

3D platformer simplu cu elemente de colectare, evitare obstacole si progres pe niveluri.

## Target

Proiect de facultate pentru Unity, gandit sa fie simplu, functional si usor de prezentat.

## Core Loop

1. Playerul porneste nivelul.
2. Exploreaza traseul.
3. Evita obstacolele/inamicii.
4. Colecteaza toate stelele.
5. Usa se deschide.
6. Playerul intra prin usa.
7. Treci la nivelul urmator sau castigi jocul.

## Player Objective

Playerul trebuie sa termine cele 2 niveluri colectand toate stelele din fiecare nivel si trecand prin usa de iesire.

## Health / Lives

- Playerul are 3 vieti per nivel.
- Cand pierde o viata, este respawnat la checkpoint-ul nivelului.
- Daca ajunge la 0 vieti, apare Game Over.
- Restart-ul reincarca nivelul curent.

## Star Progression

### Level 1

- Total stele: 3
- UI: Stars 0/3
- Usa se deschide la 3/3.

### Level 2

- Total stele: 5
- UI: Stars 0/5
- Usa se deschide la 5/5.

## Level 1 Design

### Name

**Level 1 - Robot and Spikes**

### Goal

Colecteaza 3 stele si ajungi la usa de iesire.

### Layout Simplu

1. Zona de start.
2. Prima platforma cu prima stea.
3. Zona cu robot care urmareste playerul.
4. Platforma cu tepi activi/inactivi si a doua stea.
5. Zona finala cu a treia stea.
6. Usa inchisa.
7. Usa se deschide dupa 3/3 stele.

### Obstacles

#### Robot

- Robotul urmareste playerul.
- Daca robotul atinge playerul, playerul pierde 1 viata.
- Robotul foloseste AI simplu, ideal NavMeshAgent.

#### Timed Spikes

- Tepii se activeaza si dezactiveaza periodic.
- Cand sunt activi, colliderul lor de damage este pornit.
- Cand sunt inactivi, colliderul lor de damage este oprit.
- Daca playerul este prins pe platforma cand tepii sunt activi, pierde 1 viata.

## Level 2 Design

### Name

**Level 2 - Rolling Ball Slope**

### Goal

Urca panta, evita bilele, colecteaza 5 stele si treci prin usa finala.

### Layout Simplu

1. Playerul porneste jos, la baza pantei.
2. Pe panta apar bile periodic de sus.
3. Playerul urca panta.
4. Pe laterale exista 4 gauri/refugii in pereti.
5. In fiecare gaura este cate o stea.
6. La final exista ultima stea langa usa.
7. Sub ultima stea este o zona cu lava.
8. Playerul trebuie sa sara peste lava, sa ia ultima stea si sa intre prin usa.
9. Dupa usa, apare Win Screen.

### Obstacles

#### Rolling Ball

- O bila apare/spawneaza la interval regulat in partea de sus a pantei.
- Bila are Rigidbody si Sphere Collider.
- Gravitatia o face sa se rostogoleasca pe panta.
- Daca atinge playerul, playerul pierde 1 viata.
- Bila este distrusa dupa un timp, ca sa nu incarce scena.

#### Wall Holes / Safe Zones

- Gaurile din pereti sunt refugii unde playerul se poate ascunde de bila.
- Fiecare gaura contine cate o stea.
- Playerul trebuie sa intre in fiecare gaura pentru a colecta stelele.

#### Lava Pool

- Lava este sub ultima stea sau imediat in zona finala.
- Lava are trigger collider.
- Daca playerul cade in lava, pierde 1 viata si este respawnat la checkpoint.

## Win Condition

Jucatorul castiga cand:
1. Colecteaza toate cele 5 stele din Level 2.
2. Usa finala se deschide.
3. Playerul intra prin usa finala.
4. Se afiseaza Win Screen.

## Lose Condition

Jucatorul pierde nivelul curent cand:
1. Ajunge la 0 vieti.
2. Se afiseaza Game Over.
3. Poate apasa Restart Current Level.

## Audio Design

Minim 3 sunete:

1. Background music.
2. Collect star sound.
3. Damage sound.

Recomandat si:
4. Door open sound.
5. Win sound.
6. Game over sound.

## Animation Design

Minim o animatie:

- Door_Open pentru usa.

Optional:
- Star rotation.
- Spikes up/down.
- Robot idle/walk.

## Lighting Design

- Directional Light pentru iluminare generala.
- Lumini locale langa usa, stele sau lava.
- Lava poate avea material emissive pentru efect vizual.
