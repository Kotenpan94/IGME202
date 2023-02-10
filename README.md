# Project 1

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Gabe Goldsteen
-   Section: ## IGME 202.03-04 

## Game Design

-   Camera Orientation: _How are the art assets viewed from? (ie. topdown or side)_ Topdown
-   Camera Movement: _How does the camera move in your game? (if at all)_ Camera does not move in the game
-   Player Health: _How are you handling player health? (healthbar, lives, ?)_ Lives I am using lifebar
-   End Condition: _How does a game/round/level end?_ The game ends when the player loses all their lives
-   Scoring: _How does the player earn points in your game?_ For each enemy the player kills, +100 to score. While there are two variants they both give out the same score
as both can be threatening. Part of the appeal of my game is reaction skills, especially as time progresses. It adds to the unpredictability by having two different aliens, at varying speeds.


### Game Description

_A brief explanation of your game. Inculde what is the objective for the player. Think about what would go on the back of a game box._
An unknown threat emerges! It is unknown whether these Octopus like aliens come in peace or if they are hostile, but one thing is for sure.
They are dangerous and need to be taken care of before it is too late. Control your ship and fire at the aliens, to prevent them from reaching
both yourself, and the human population.

### Controls

-   Movement
    -   Up: W
    -   Down: S 
    -   Left: A
    -   Right: D
-   Fire: Left Mouse Button

## Player Movement

-  The player will wrap around both the top and bottom of the screen, to each other and vice versa. They will not wrap with the left side
and right side of the screen, and instead get stopped at them.

## Enemy Types
-  Green Octopus
The basic enemy type, moves at a predictable and slow speed. Minds its own business. If it's shot at, oh well
-  Red Octopus
A stronger Octopus. It moves at faster speeds, and can be a bit unpredictable. Additionally, because of its burning intense spirit,
it will wrap around the left side of the screen to the right, making it more of a nuisance if not dealt with swiftly.

## Your Additions

_List out what you added to your game to make it different for you_
For this project, I'm going to be creating all of the art assets for the game using Photoshop/Asesprite. I already enjoy making pixel art in photoshop,
so I want to use this project as a way to enhance and hone my pixel art skills. I've already included the ship asset that I've made
for the game, as well as two other assets that I've included in the images a folder, being an asteroid and a planet(tho I want to make the planet nicer looking).
Update as of Checkpoint 3: As of now, I believe I have all the art assets completely. If anything else comes up though and any revisions need to be made, I will get to work on them.


## Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_
All assets were made by myself

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_
As of now, collision has stopped working. Looking at why it no longer is functioning.

### Requirements not completed

_If you did not complete a project requirement, notate that here_
As of Checkpoint 3, I am working on a lot of fixes for small parts of my code scattered around. I still need to work on collision for the bullets and enemies, 
confused how to do that, but will be reaching out to find out how. Additionally, enemy movement needs work, as well as enemy firing.

