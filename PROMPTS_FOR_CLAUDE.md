# PROMPTS_FOR_CLAUDE.md

## Prompt 1 - Initial Analysis

Foloseste acest prompt prima data in Claude Code:

```text
Citeste toate fisierele .md din proiect, inclusiv CLAUDE.md si skill-ul din .claude/skills/build-star-gate-runner/SKILL.md.

Nu modifica nimic inca.

Vreau sa imi spui:
1. daca ai inteles conceptul jocului
2. ce fisiere/scenes/scripts trebuie create
3. ce trebuie facut manual in Unity
4. un plan incremental de implementare
```

## Prompt 2 - Create Script Skeletons

```text
Creeaza structura de scripturi pentru joc, dar nu implementa inca toata logica.

Creeaza fisierele:
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

Fiecare script trebuie sa aiba responsabilitatea lui clara si comentarii minime.
```

## Prompt 3 - Implement Core Systems

```text
Implementeaza sistemele de baza:
- GameManager pentru stele si progres
- UIManager pentru textul de stele si vieti
- PlayerHealth pentru 3 vieti, damage, respawn si restart current level
- StarCollectible pentru colectarea stelelor
- DoorController pentru usa care se deschide dupa toate stelele
- LevelExit pentru trecerea la Level_2 sau WinScreen

Pastreaza codul simplu si compatibil cu Unity.
```

## Prompt 4 - Implement Level 1 Mechanics

```text
Implementeaza mecanicile pentru Level 1:
- RobotFollow cu NavMeshAgent care urmareste playerul
- Damage la contact cu playerul
- TimedSpikes cu activare/dezactivare la interval
- Damage de la tepi doar cand sunt activi

Include instructiuni clare pentru ce componente trebuie setate in Unity Inspector.
```

## Prompt 5 - Implement Level 2 Mechanics

```text
Implementeaza mecanicile pentru Level 2:
- RollingBallSpawner care spawneaza bile periodic
- BallDamage pentru damage la contact
- distrugerea bilelor dupa un lifetime
- LavaDamage pentru damage cand playerul cade in lava

Include instructiuni clare pentru setup in Unity Inspector.
```

## Prompt 6 - Unity Setup Checklist

```text
Pe baza scripturilor create, da-mi un checklist pas cu pas pentru Unity Editor:
1. ce scene creez
2. ce GameObjects creez
3. ce componente adaug pe fiecare
4. ce valori setez in Inspector
5. ce prefab-uri creez
6. cum testez fiecare mecanica
```

## Prompt 7 - Generate Documentation

```text
Creeaza documentatia finala pentru proiect in romana, folosind DOCUMENTATION_TEMPLATE.md.

Include:
- concept joc
- mecanici
- arhitectura
- fizica si coliziuni
- UI
- audio
- AI
- rolurile echipei
- capturi de ecran necesare
```

## Prompt 8 - Debugging Prompt

```text
Am urmatoarea eroare/problema in Unity:

[paste error / explain problem]

Te rog:
1. explica de ce apare
2. spune ce script sau obiect trebuie verificat
3. da-mi pasii exacti de rezolvare
4. daca trebuie modificat codul, ofera-mi varianta corecta
```

## Prompt 9 - Do Not Overcomplicate

```text
Revizuieste implementarea curenta si spune-mi daca exista ceva prea complex pentru cerinta proiectului.

Vreau sa pastrez jocul simplu. Recomanda ce pot elimina sau simplifica fara sa pierd cerintele obligatorii.
```
