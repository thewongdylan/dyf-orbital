# Oslo's Odyssey
Welcome to our game development log/README.
<br /> Click [here](https://play.unity.com/p/oslo-s-odyssey-ms3/edit) for a working prototye of our game!
<br /> MS2 working prototype can be found [here](https://tinyurl.com/OslosOdyssey)

## Table of Contents
README
* Level of Achievement
* Motivation
* Game Ideation
* Tech Stack
* Milestone 1
* Game Ideation
* DevLog
* Software Engineering Practices
* Testing
* Gameplay
* Save feature



## README

**Level of Achievement**
Apollo

**Motivation**
As lovers of 2D pixel-art games as well as traditional platformer style games, making our own game that combines these 2 elements has always been on our bucket list.

(We want players to experience a retro-style looking game that has the smooth and sharp mechanics of modern platformers (e.g Metroid Dread and Ori franchise). We also wanted players to experience a game that is unique: offering special mechanics and a playstyle that is not restricted to a certain linear flow.)

**Game Ideation**
We took inspiration from Metroidvania games for their non-linearity game progression as well as classic 2D pixel-art games for their retro style graphics.

![](https://www.gamepur.com/wp-content/uploads/2021/10/11132505/grapple-beam.jpg?w=1200)
*In Metroid Dread, obstacles that require power ups not yet acquired such as Grapple Beam (as shown above) are introduced in the game early on, requiring players to go back to previous locations once acquiring certain abilities*

![Todas as vezes que Mario entrou no Guiness Book - GameHall](https://gamehall.com.br/wp-content/uploads/2022/06/443244_661579.jpg)
*classic 2D pixel artstyle we took inspiration from*
## Art
Oslo was intentionally designed to look plain as his source of power doesn't come from within himself but the orbs he possesses.
![](https://art.pixilart.com/sr20c18a77f3fab.gif)
*Oslo Milestone 1 design*

Orbs grant Oslo his power and are meant to contrast Oslo with flashy visuals and colours
![](https://art.pixilart.com/sr227c5b278632c.gif)
*fireball; a spell available once Oslo obtains the Fire Orb (Milestone 1 mockup)*


## Tech Stack

 - Unity
	 - the game engine used to create our game
- C#
	- language used in coding scripts in Unity
- Pixilart
	- used to design sprites and animation

## Milestone 1
**Technical proof of concept**

We have created a basic prototype game which includes Oslo basic movement and animation, as well as Oslo's Fireball skill.

A Health system has been implemented for Oslo as well as for enemies. This allows them to have a starting health value and take damage as they come into contact with enemy projectiles, and eventually die when they lose all their health.

Screens have been implemented to allow players to navigate through the game. 
- Start Screen: To start the game, level select (future milestones)
- Game Over Screen: When the player dies
- End Screen: When the player finishes the game






# Game Ideation
## Story
The story starts in NoWay, Oslo's hometown. Oslo is part of a long running lineage of monks in NoWay who maintains the balance of the world. Right before Oslo is about to succeed his father as head monk, portals spawned all over the world, causing monsters to be unleashed across the worlds! Oslo must travel the world to acquire the elemental orbs that are essential to the balance of the world and use them to seal the portals once and for all.



## Abilities
Oslo harnesses the power of the elemental orbs for combat with his enemy. He starts off with the Air orb he claims from the monastery and gains Air-related powers such as double jump and air strike (a normal melee attack).

## Mechanics (MS2 and MS3)
(work in progress)
We intend to make Oslo's abilities interactive with his environment. 

**Fire**: Fireball is used as a basic combat ability


**Air**: Float ability allows Oslo to levitate for a certain period of time, dictated by an ability bar. Once ability bar runs out, Oslo cannot use the ability until it fully recharges.

**Water**: Ability to dive into waterbodies and move freely for a certain period of time similar to Air ability. However, once the bar runs out, Oslo starts running out of breath and takes damage.

## Naming Conventions
**PascalCase**: Classes, Scripts, Animations

**camelCase**: Variables



## DevLog

The number of hours spent and task allocation can be seen in the project log below.
[https://docs.google.com/document/d/1XT90z5Mit2AHdJE8UPNN7zeuluRcQ2i8rtYhRSdc5VQ/edit ](https://docs.google.com/document/d/1zTZmu03rmhe_ehCaYfu1JF-_lHKfzGGcvf4tMw2lR38/edit?usp=sharing)

## Software Engineering Practices

**Component pattern**
Unity GameObjects possess components that serve to add relevant functions and interactions to objects themselves.
![Screenshot 2023-06-24 at 4 36 22 PM](https://user-images.githubusercontent.com/89378503/248472888-547681f4-76d0-406c-8204-1b8b42b13921.png)

**Singleton pattern**
GameObjects that have multiple instances are referenced from a single "prefab" in Unity. For example: enemies that appear multiple times in our games are created as "prefabs". This reduces the work needed to create same enemies multiple times and ensures that they behave the same way.
![Screenshot 2023-06-24 at 4 37 51 PM](https://user-images.githubusercontent.com/89378503/248472861-da79d2fb-e078-4ba3-8e25-1223fb4bc0eb.png)
**Liskov Substitution Principle**
Classes who are subtype of another classes can be a substitute of that other class. For example: Enemy Life and Oslo Life (scripts that manage enemy and Oslo (the character player plays as) health system) have a superclass Object life.

**Version Control System**
We use GitHub to allow us to collaborate efficiently on the game and fix any merge conflicts when we make changes to the same pieces of code.


## Classes
Class inheritance was used in some cases, but for most other scripts, they are unrelated and instead are grouped by the components they are attached to in the Unity Editor.
![image](https://github.com/thewongdylan/dyf-orbital/assets/90192310/6cf070c4-2e8a-4fef-8f2b-fcd3ea630622)


# Testing
## User Testing

| User testing | Issue | Implemented solution |
| --- | ----------- |----------- |
| Fire Level too easy, just need to shoot enemies without ranged attack | Difficulty of fire level too simple, mechanics were too basic |Increased frequency of enemy and difficulty for player to navigate through the fire stage. Player has to activate levitate to get past certain obstacles |
|Air Level too simple  |Air level does not engage the user as they were just jumping past enemies.  |Make the user use the ability gained in air stage to navigate through the level |
|  Unable to keep track of multiple orbs after picking up more than 1| Orb information was not made available to the player, only to developers through the scripts | implemented a display in the Status Bar for the currently equipped orb as well as all available orbs for the player|
|Not sure what to do at the title screen, no instructions provided  | Title screen assumes users know how to move Oslo before the instructions are shown to them |To switch to a click button for the start screen before introducing WASD controls to users |
|No way to pause/quit the game  | Lack of pause menu** |To implement a pause menu that allows users to pause, resume, restart |
| Damage system too strict and simple - game over upon losing all 5 hearts is rather strict |Player health system is rudimentary and does not scale properly with damage dealt by enemies  | To implement a different health metric when players are hit, consider a HP bar for health per life, and restart the level when players lose all their HP (lose a life), then finally game over when they lose all their lives|
| Tutorial is good, but lack of purpose is given to the player, and I feel like I’m just walking around collecting stuff/attacking enemies | Lack of story element incorporated into the game, failed to sustain player interest | To incorporate some elements of Oslo’s story and background into the tutorial, consider cutscenes between levels to further the narrative|
| Fireball was damaging Oslo | Fireball is too slow, Oslo can outrun the fireball and collide with it | Increase the velocity of fireball
| Players don't know when levitation was activated | There is no stark visual cue of levitation being activated | Oslo now moves up slightly once levitation is activated|
|Levitation causes Oslo to bypass terrain | The method that moves Oslo up once activated bypassed rigidbodies | fixed levitation script


## Unit Testing
Unity offers Edit Mode and Play Mode unit tests. Edit Mode tests check for things that don't require the game to be run while Play Mode tests check for things that require the game to be run.
### Edit Mode
![Screenshot 2023-07-24 at 1 27 19 AM](https://user-images.githubusercontent.com/89378503/255421835-64cfe8e8-2bcc-445c-966c-0a316315223d.png)
Edit mode was used to make sure simple things such as animations are called at correct conditions.

### Play Mode
![Screenshot 2023-07-24 at 1 27 05 AM](https://user-images.githubusercontent.com/89378503/255421877-f98b8a63-58b6-4372-b2b7-e6264ce62ffc.png)
Play mode was used to check movement of Oslo is always working as intended (e.g jump).

# Gameplay
## Tutorial

Oslo starts off walking through the title screen.
![Screenshot 2023-06-24 at 4 10 27 PM](https://user-images.githubusercontent.com/89378503/248472843-9fe9d9c1-d3b4-4214-87bc-0a46e6d25c4b.png)
At the tutorial stages, he is greeted with text instructions that guides him on how to use the orbs that he will eventually possess.
![Screenshot 2023-06-24 at 4 30 49 PM](https://user-images.githubusercontent.com/89378503/248472899-3a245b95-f885-4684-9eb4-1d5d2f64f961.png)
Oslo encounters a ghost enemy that shoots out projectiles. Simple enemy that require minimal effort to defeat with whatever orbs that Oslo possesses.


## Enemies
### Air Stage: Wizard
![wizard preview](https://user-images.githubusercontent.com/89378503/248548091-9754b403-977e-4b66-adfc-be0b77429da7.png)
We wanted enemies of air to be floating and easy to manoeuvre about as Oslo would be starting off without a combat ability until he reaches other stages. Shoots out tornado projectiles that are relatively easy to dodge.



### Fire Stage: Devil
![devil preview](https://user-images.githubusercontent.com/89378503/248548095-77f5b324-c5a3-4992-894b-a98987f39bc8.png)
Simple enemy which damages player once colliding with it.

### Water Stage: Fish
![fish sprite](https://user-images.githubusercontent.com/89378503/255417567-6a65d579-af5e-4a6d-ac9d-c723886dcab1.png)
Water enemy that damages player once colliding with it, could have possibly more erratic movement paths.

### Metal Stage: Golem
![](https://user-images.githubusercontent.com/89378503/255417612-18bdbc9f-5382-419f-a755-b98d8e343f59.png)
Metallic enemy that shoots out projectile in a fixed direction.

## Level Design

![Screenshot 2023-06-25 at 6 45 19 PM](https://user-images.githubusercontent.com/89378503/248549269-a11307ce-78b3-492a-abf3-c7b6c5d7765c.png)
<br /> Air stage continues right off from tutorial, hence the similar design.


![Screenshot 2023-06-25 at 6 46 09 PM](https://user-images.githubusercontent.com/89378503/248549272-225b26bc-01c5-4e28-b96d-ad65c3221660.png)
<br /> Fire stage contains floor tiles (*orange lava*) which causes Oslo to take damage periodically standing on it.

![Screenshot 2023-07-24 at 12 39 48 AM](https://user-images.githubusercontent.com/89378503/255414015-7726d9ec-cb90-4add-9b07-774f0b8c7d3b.png)
<br /> Water stage contains water tiles (*water body*) that causes Oslo to take damage once he runs out of breath.

![Screenshot 2023-07-24 at 12 54 42 AM](https://user-images.githubusercontent.com/89378503/255415242-7f8cad22-722b-435d-94a3-5f661913a933.png)
<br /> Earth stage contains metal themed golems that shoot out beams.

### Heart pickups
![Screenshot 2023-07-24 at 1 49 24 AM](https://user-images.githubusercontent.com/89378503/255423182-a3bca052-2e12-4f8c-b74c-ca324ebd0c75.png)
<br /> Heart collectibles can heal Oslo when he is damaged.

## Save Feature
![login](https://user-images.githubusercontent.com/90192310/255594453-eb64993d-2c3f-4355-9b21-d47a596ff540.png)
<br /> Using the Unisave package in Unity, a basic save and load feature was implemented that allowed users to save their progress and load it.
<br /> Data was stored in ArangoDB, Unisave's database, and allowed users to use their email as a unique ID.
<br /> Potential future improvements would include multiple save states as well as the ability to load into a level directly when starting up the game.

## Pause Menu
![pause menu](https://user-images.githubusercontent.com/90192310/255594438-f6060223-4e82-46cf-bb83-0746103eb33b.png)
<br /> A pause menu was implemented in playable levels (not cutscenes) to allow players to pause, resume, save, and load their game.
