# Velocity Redux Modding Tool
 This is a development kit for modders of Velocity Redux. This ReadMe currently contains only the information that hasn't been added to the wiki yet. Check the wiki (at the top of this page) for the information that is no longer here!
 
 ![image](https://github.com/SuperCatGaming/Velocity-Redux-Mod-Creator/assets/16313202/1921f0b1-d7e7-4af8-b32f-7e4aa2b10ceb)

# Table of contents
* [Adding a horn](#adding-a-horn)
* [Adding a boost theme](#adding-a-boost-theme)
* [Adding a game theme](#adding-a-game-theme)
* [Adding a music track](#adding-a-music-track)
* [Adding a world](#adding-a-world)
* [Building mods for distribution/testing](#building-mods-for-distributiontesting)

  
## Adding a horn
  If you are following the recommended file structure for mods, horns are located under \[Sounds/Horns]. It is recommended to create a new folder for each horn you add.
  To create a horn, access the menu \[Assets > Create > Mods > Horn]. Name the created object. Notice that horns can have multiple audio clips added. When the player uses
  the horn, it will pick a random clip from the list, so this is often used to create slight variance each use. In the inspector, name the horn. Then, import into Unity any sound(s) you want to
  use for the horn. Then drag them from the project explorer into the "Audio Clips" list. If you want the Horn to always be available without an unlock, check the box for "Bypass Unlock"

## Adding a boost theme
  If you are following the recommended file structure for mods, boost themes are located under \[BoostThemes].
  To create a boost theme, access the menu \[Assets > Create > Mods > Boost Theme]. Name the created object. In the inspector, you will see everything you need to create a boost theme.
  
  * Theme Name: the name of the theme
  * Ui Color: not actually sure
  * Boost Gradient: a gradient to determine how the boost looks in game. The left side of the gradient is the front of the flame (the side that faces the exhaust)
## Adding a game theme
  If you are following the recommended file structure for mods, game themes are located under \[GameThemes].
  To create a game theme, access the menu \[Assets > Create > Mods > Game Theme]. Name the created object. In the inspector, you will see everything you need to create a game theme.

  * Theme Name: the name of the theme 
  * Normal Color: the color of the UI by default
  * Highlighted Color: the color of UI elements when the mouse hovers over them
  * Pressed Color: the color of UI elements when the mouse is pressed down on them
  * Selected Color: the color of UI elements when the element is selected (usually after a click)
  * Disabled Color: the color of UI elements when they are disabled
  * Color Multiplier: How bright the UI appears. Due to a bug in Unity, the actual default is 0, which makes some UI elements not appear at all.
    To fix this, move the slider anywhere and then back to 1
  * Fade Duration: How long it takes for the UI elements to transition between colors; recommended default is 0.1

  **Tip**: When selecting a color, be sure to set the Alpha value higher than 0. The recommended default for disabled is 128, and the recommended default for the rest is 230
  
## Adding a music track
  If you are following the recommended file structure for mods, music is located under \[Sounds/Music]. It is recommended to create a new folder for each music track you add.
  To create a music track, access the menu \[Assets > Create > Mods > Music Track]. Make sure to name the created object. Then, in the inspector, you will notice
  a few options. 
  
  If the track is for the main menu, check the "Is Main Menu Theme" box. Then, give the track a name. Notice that music tracks have two parts to them: an intro and a loop.
  The intro is played before the loop. For some tracks, you might just have a loop. Whatever the case may be for you, import the audio file(s) into Unity.
  Then add the imported audio files to the correct options ("Intro" or "Loop") by dragging and dropping. If you want the track to loop, check the "Loops" box (if the box is left unchecked,
  the "Loop" clip will never play, so be sure your file is in the "Intro" clip slot). Usually, main menu themes should loop.

  **Tip**: It is recommended that your audio files are in the ".ogg" format, especially if it loops. ".mp3" files almost always have some silence at the beginning and end
  due to the format specification, which means they will not seamlessly loop.

## Adding a world
  Adding worlds can be a complex task. There are many necessary parts that go into each world. Here are some that you will need:
  
  * Scene
  * Scene info
  * Game mode info
  * ... todo
 
  A scene is a game object in Unity which we use to load worlds. Due to technical limitations, these *must* be placed in a folder separate from *every* other part of your mod.
  This folder is generally in your base mod folder: \[Assets/(ModName)/Scenes]. This folder must only contain scenes, nothing else. Your mod will fail to build if scenes are in your "Mod" folder,
  or assets other than scenes are in your "Scenes" folder.
  
  TODO: Lorem ipsum dolor sit amet
  
# Building mods for distribution/testing
  Once your mod is in a state that you want to distribute it or test it to make sure it works, all you have to do is access the assets menu and click [Build Mods].
  Unity will then start creating your mod file that you can test or distribute. This file will be created in the Unity project under Assets/Mods/{YourModNameHere}.vrx
