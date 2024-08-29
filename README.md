# All Tanks to You Open Source Preview
*"Game Engine Projects :)"*
## Introduction

Hello! Welcome to the Open Source preview of the upcoming Drachenblut SoftWorks game ***All Tanks To You***. This repository constitutes the first portion of development for the project. As it currently stands the game can be built and played as is with two players. I am leaving this repository public for those who want to look at my game's code and as a portfolio example.

## Table of Contents

+ [Game Guide and Screenshots](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/tree/master?tab=readme-ov-file#game-guide-and-screenshots)
+ [Technical Details](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/tree/master?tab=readme-ov-file#technical-details)
+ [Level Serialization Usage](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/tree/master?tab=readme-ov-file#level-serialization-usage)
+ [Development Roadmap](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/tree/master?tab=readme-ov-file#development-roadmap)

## Game Guide and Screenshots

![Screenshot of the All Tanks to You Menu](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/blob/master/Screenshot%202024-08-28%20210109.png)
The ***All Tanks to You*** Open Source Preview can only really be played in local multiplayer with two players. To play either run the game through unity editor or build an exe and have one or two controllers connected. Select the "Multiplayer" option on the menu. If the red and blue controllers are emitting light, it means both players are connected.
![Screenshot of the Open Source Preview Multiplayer Menu](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/blob/master/Screenshot%202024-08-28%20210132.png)

The controls are simple, you move, using tank controls with the left stick and move your reticle with the right stick. Use the left trigger to fire. If you're using mouse and keyboard the mouse controls your reticle and WASD acts as the stand in got a left-stick. Left-Click fires your weapon. First tank to get shot 3 times loses the match.
![Gameplay Screenshot](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/blob/master/Screenshot%202024-08-28%20210224.png)
![Gameplay Screenshot](https://github.com/yourespeakingtothemoon/AllTanksToYou--Unity-Project/blob/master/Screenshot%202024-08-28%20210303.png)

## Technical Details

***All Tanks to You*** is built in the Unity Game Engine utilizing C# and JSON code for its built in features. While binares are not available here, it can easily be built in a current version of the Unity Editor.

## Level Serialization Usage
In the assets folder, you can edit the level that is loaded in the demo in the testLevelData.json folder. The Json Object array inside contains a number of references to prefabs within the project. Currently implemented in the code are 5 objects
+ "rTall"
+ "tumbleweed"
+ "rLarge"
+ "Cube (1)"
+ "RicochetWall"
Use these exact names to put the objects in the level. The level loader is still using hacky prototype code and looks up the prefabs by these names. 
then put the location information like this example:
```
{"name":"RicochetWall","x":-6.596984386444092,"y":0.5,"z":-2.6705117225646974}
```

## Development Roadmap

The plans for this project are simple:

1. Finish the Multiplayer
   - 4 Player Local Multiplayer
   - Tank Loadout Customization
   - Loading more levels than just the test file
2. Finish the Level Editor
   - Complete the Level Editor UI
   - Fix the Serializing Code
3. Add Singleplayer Modes
   - Develop AI Agents
   - Build out "Campaigns"
4. Release

Because the ultimate plan for this project is to release it commercially all future development will be done on a private repository/fork. I will keep this open for anyone to use/learn from, but please be mindful that many of the assets are property of myself and other artists/creators.

 

 
