# Velocity Redux Modding Tool
 This is a development kit for modders of Velocity Redux. This ReadMe will tell you all you need to know about how to mod Velocity Redux
# Table of contents
  * [How to use this project](#how-to-use-this-project)
  * [Unity: How to use and basic functionality](#unity-how-to-use-and-basic-functionality)
    * [The editor](#the-editor)
    * [Prefabs](#prefabs)
    * [Importing files into Unity](#importing-files-into-unity)
  * [How to create mods](#how-to-create-mods)
    * [Adding custom textures/materials](#adding-custom-texturesmaterials)
    * [Adding a car](#adding-a-car)
      * [Placing the model](#placing-the-model)
      * [Placing the wheels](#placing-the-wheels)
      * [WheelWidthOverride](#wheelwidthoverride)
      * [Placing the lights](#placing-the-lights)
        * [Headlights](#headlights)
        * [Tail lights](#tail-lights)
        * [Boost lights](#boost-lights)
        * [Damage smoke](#damage-smoke)
      * [Placing the WeaponHandler](#placing-the-weaponhandler)
      * [Extra model parts](#extra-model-parts)
      * [Settings](#settings)
        * [Audio](#audio)
        * [Car stats](#car-stats)
      * [Skins](#skins) 
    * [Adding skins to existing cars](#adding-skins-to-existing-cars)
    * [Adding a rim](#adding-a-rim)
    * [Adding a boost theme](#adding-a-boost-theme)
    * [Adding a game theme](#adding-a-game-theme)
    * [Adding a music track](#adding-a-music-track)
    * [Building mods for distribution/testing](#building-mods-for-distributiontesting)
# How to use this project
  This repository comes as a Unity project that you will use to add content to the game. As such, you will need the Unity game engine to create a mod.
  The current Unity version that you'll need is *2021.2.7f1*

  You can download Unity [here](https://unity.com/releases/editor/whats-new/2021.2.7).

  After your download is complete, use the installer to install Unity.
  Once you have Unity, you will need to download this project. To do so, at the top of this page, click the green "Code" button, and select "Download ZIP".
  
  ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/35d8580b-c2c3-4921-bf69-ee0d3b0dd87c)

  Unzip the project wherever you want to.
  [explain how to download and use project]

# Unity: How to use and basic functionality
  Unity can be a very complex program. However, to make a mod, you don't need to know everything about how it works.
  This section will go over the basics that you need to know to continue. If you already know how to use Unity, you can skip this section.

## The editor
  When you first open Unity, you should see a screen that looks like this:

  ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/6fca924a-998d-48ce-a454-7e8051ecaaf3)
  
  **Inspector**: At the right, highlighted in green, is the inspector. This is the most important widget you need to create a mod. It shows you all the information you need
  about the selected item. If, for some reason, you do not see the inspector, you can open it by pressing \[Ctrl + 3] or through the menu at the top.
  Just go to \[Window > General > Inspector].
  
  **Project File Explorer**: At the bottom, highlighted in blue, is the project file explorer. This will show you all the files in the project. Clicking an item will show you
  all the relevent properties in the inspector and the full file path at the bottom of this widget. There are multiple ways to navigate through the folders; you can double click folders to enter them, 
  you can click a path item at the top to go back to a folder, or you can use the side bar to the left.

  **Project Hierarchy**: At the left, highlighted in yellow, is the project hierarchy. This will be used for certain mods to create a game object that will be imported into Velocity Redux.
  Clicking on an object in the list will show you its properties in the inspector. If an object has an arrow to the left, it has child objects.
  You can see the children by clicking on the arrow. If an object has an arrow to the right, that object is a prefab instance (See: [Prefabs](#prefabs)).
  The object at the very top of the hierarchy is referred to as the "root."

  **Scene**: In the middle, highlighted in red, is the scene. This will display a 3d rendering of the currently open scene, which could be a prefab. As you make changes in the project hierarchy,
  you will see the effects (as long as the effects change the appearance of the scene) here. For example, you may use this to make sure you place all the necessary objects on a car
  (such as wheels) in the correct position. Controlling the viewport in the scene may be necessary. Here are the basic controls:
  * Right click and drag: rotates the camera
  * Middle mouse and drag: pans the camera
  * Right click and hold + WASD: move the camera's position
  * Scroll wheel: zooms in and out
  
  **Menu Bar**: Finally, at the top, highlighted in purple, is the menu bar. This contains a ton of useful actions, but for Velocity Redux modders, the majority the needed actions will be in the
  "Assets" menu option.

  **Important note**: whenever you need to access the assets menu, there are two ways to do this. You can either access it from the menu bar (labeled "Assets"), or you can
  right click in the project explorer. This is often notated as \[Assets > ...]

  ## Prefabs
  Prefabs are game objects that are saved as an asset, which means they are a file in the project. Prefabs are used to create multiple independent instances of the same object.
  They can be edited in the same way as a scene: open a prefab by double clicking the file, and then edit the objects in the hierarchy and their components. To close the prefab
  editor and return to the main scene, just click the arrow next to the prefab name in the hierarchy.
  
  ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/3e8a2d6d-2e2b-4701-bb05-e70fdb4d8592)

  ## Importing files into Unity
  Importing assets into Unity is simple. Find the files you want to import on your device's file manager. Select any files you want to import, then drag and drop them into
  Unity's project explorer. This will create the assets and their related metadata for you, making the assets available to use in your mod. 
  
  **Note**: Make sure that any assets you are using in your mod are located inside your mod's folder!

# How to create mods
  To start creating a mod, go to \[Assets > Mods > Create New Mod]. Fill in the details and click "Create Mod".
  Assuming no errors occurred, a new folder will be created in the root "Assets" directory with the given name. Inside this folder will be two other folders,
  "Mod" and "Scenes". "Mod" is where the majority of your mod content should go. "Scenes" should only contain any scenes (ex. worlds) that your mod contains.
  
  **Now you should be all set to start adding content!**
## Adding custom textures/materials
  For some mods, you may want to add custom textures or materials. Fortunately, adding custom textures/materials is simple.
  
  1. Import the texture into Unity; if you want a flat color, you can skip this step
  1. Create a material through the menu [Assets > Create > Material]
   ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/bbda00fa-b853-4886-9a09-38621b03b9ed)
  1. To match the rest of the game, switch the shader of the material to Real Toon. At the top of the inspector, click the "Shader" dropdown.
     Select "Universal Render Pipeline > RealToon > Version 5 > Default > Default"
  1. Open the "Texture" Dropdown. If you imported a texture, add the texture to the box that says "None (Texture)"
   ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/cc53e827-425a-4611-b674-ef89b87d4910)  
   Otherwise, select a color by clicking the box next to "Main Color"
  1. If you would like to add gloss, open the "(Disable/Enable Features)" dropdown and check the box that says "Gloss". A new dropdown named "Gloss" will appear. Edit the settings to your liking
## Adding a car
  Cars in Velocity Redux have a lot of parts. It is strongly recommended that you create a new folder for each car.

  To add a car, you will need a model. It is recommended that the model file is a ".fbx" file. Other formats might work, but are untested. If you are new to modeling, 
  [Blender](https://www.blender.org) is a free, but powerful modeling tool. Learning how to model is out of the scope for this tutorial; you can find a ton
  of resources to help on [YouTube](https://www.youtube.com/results?search_query=blender+tutorial).

  Note: Models may have separate parts that can be swapped out per skin. For example, you may want one skin to have a different wing than another skin. An explanation of
  how this works is later in this section.

  Once you have a model, import it into Unity by dragging it into your folder. You may want to set some default materials so you can get an idea about how the car will look in-game.
  To do this, click on the model file in Unity, and select the "Materials" tab in the inspector. Then set the materials as you see fit; some common car materials can be found in
  the "Assets/Common Car Resources" folder. Adding custom textures is a [future step](#Adding-custom-textures/materials-for-cars/rims).

  The next step is to create a prefab for your car. This must be done very carefully. If you name something incorrectly, the mod may fail to load properly. For this reason, it is recommended to
  use the asset menu option under "Create > Mods > Car Prefab". **Make sure you have your model selected when you do this.** This will initialize a prefab for you with all the
  necessary parts. There is a lot you can change, but there is also a lot you shouldn't.
  
  What you shouldn't do:
  * Rename any objects
  * Delete any objects or components
  * Reorder the hierarchy
  * Add your own custom scripts to objects

  Any of the above actions will likely cause the mod to not load properly (except for some outliers which are explained later).

  What you can do:
  * Modify the values of components in the inspector
  * Add objects to the hierarchy
  * Add components to objects
  
### Placing the model
  After you create your prefab, open it in the scene by double clicking it. You may notice that everything is very small. To zoom in, just scroll up on the scene. Do this until you see your model.
  Depending on how the model was made, it may need to be scaled to fit in with the other vehicles. To check the scale, drag your prefab into the main scene hierarchy. To zoom in on it, double click
  it in the hierarchy. You should see another object there called carSize. The black box is the approximate size of an MST Suzuka, and the track is from Cliffside Realm. These are provided for you
  to scale your vehicle appropriately.
  
  Also note the rotation of the model. The (prefab) scene should have lightbulb icons that depict the location of the headlights and tail lights. If you can't see them,
  in the upper right corner of the scene is an indicator for your perspective on the scene. The car's front should be in the positive z direction (facing the same direction as the bottom of the blue cone).
### Placing the wheels
  Once you have the model placed and rotated correctly, can now place everything else. Let's start with the wheels. [todo: give a cylinder to approximate a wheel].
  There are two objects for each wheel. One is under the "Wheel Colliders" object, and the other is under the "Models > WheelWidthOverride" object. Place the colliders
  as where you want the wheels to go. Make sure they are symmetrical (if that's how the car is supposed to be). The wheel models do not have to be precise (in fact, they technically
  don't have to be placed at all). It is typical to place them in the relative area of the given wheels, and to make them symmetrical if that is intended placement for the wheels. However,
  the game will position the rim objects where the colliders are, so it isn't really that important.
### WheelWidthOverride
  Note: the "WheelWidthOverride" object is an optional object. It is there for your convienience in the case that all wheels for the vehicle should be made thinner/thicker
  (done by changing the x-scale of this object). Changing the other properties of this object is not recommended. You can leave this object in the hierarchy, but you can also delete it.
  To delete it, select all the child wheel objects and drag them out into the "Models" object. Then you can delete it.
### Placing the lights
  Now let's place the lights. This part is simple compared to the rest! Expand the "Vehicle Lights" object. You should see 4 more objects, 3 of which can be expanded.
  #### Headlights
  Under "HeadLights" you will find 2 objects. If your vehicle has one or no headlights, you can delete these as you see fit. You can also create more. To do so just right click one
  of them and select duplicate. The names do not matter. [todo: Be sure that no object that isn't a headlight is placed as a child of the HeadLights object,
  as that may cause your mod to fail to load.] may remove this.
  Now, simply place the headlights close to where they are on the model. Be sure to keep them in front of the model, or the light will not shine correctly. This doesn't have to be perfect.
#### Tail lights
  All the same applies for tail lights. This time, make sure the light is slightly behind the model. With tail lights, you also have to add each tail light to the "Tail Light Control Mod" script
  found on the "TailLights" object. All you have to do is expand the "Tail Lights" object on the script, click the "+", and then drag and drop the new tail light object.
  You may also notice that you have some options for the light brightness on that script. You can modify these if you wish.
#### Boost lights
  Boost lights are much the same as headlights. Boost lights are the flames that appear when the car is using boost. They are usually placed at the exhaust ports. For these, the rotation matters.
  The goal is to have the blue arrow on the visual effect object pointing into the exhaust. Again, this doesn't have to be perfect. You may also notice a script with a "Turbo Radius" value.
  This will modify the size of the flame; you can modify this if you wish.
#### Damage smoke
  Finally, damage smoke. Damage smoke is the smoke that appears when the car is damaged (who'd've thunk). This is often placed on the engine, but it can be placed wherever.
  This object can also be duplicated. The name *does* matter for these, though. At the very least, they must contain "DamageSmoke". This will already be done for you if
  you simply duplicate it and leave it, but if you want to rename it for any reason, just be sure the name still contains "DamageSmoke".
### Placing the WeaponHandler
  The final thing to place is the "WeaponHandler" object. This is where weapons will be placed on the car. This is normally placed on the roof or the hood. This object should sit
  slightly inside your model, but not too far.

### Extra Model Parts
Some models might have multiple parts that can be swapped out. These have to be skinned differently. To do this, add a new GameObject under the "Models" object by right clicking
on "Models" and selecting "Create Empty". It should be named something like "CarPartSkin\[Name]", where \[Name] is replaced by the name of the part. Then in the inspector,
click "Add Component" and search for the script called "Car Part Skin Mod" and add it. 

Then you need to set the values for the script. The body renderer should be set to the part associated with the game object. To do this, expand the children of the model in the hierarchy
and drag the part into the selection box for body renderer. You also need to specify whether the part has Level Of Detail (LOD). [todo: explain what this means].
If it doesn't, you need to specify the outline material (which is usually Outline10, found in the \[Common Car Resources/Materials] folder).
Then you also need to specify any objects that should only be shown with the model part you selected. This can often be left empty.
Note that this will not apply the same skin to the objects in the list; this will only toggle their visibility with body renderer you selected.

### Settings
  Now it's time for settings galore!
  #### Audio
  Let's start easy. On the "Car Audio Sources" object, you will find a script with a bunch of settings for how the car will sound. Default Sound settings
  can be listened to in the Main Scene via the "ListenToEngineSounds" object. Just select that object, then select the sound you want to hear in the inspector and click play.
  You can also change the pitch by modifying the "Pitch" slider on the "Audio Source" component.
  * Is Turbo Charger: adds charger sounds when accelerating and winddown sound when letting off the throttle.
  * Is Super Charger: only adds charger sounds when accelerating. Overridden by "Is Turbo Charger"
  * Default Engine Sound: the sound the engine makes while revving (driving)
  * Default Idle Sound: the sound the engine makes at idle (not driving)
  * Default Winddown Sound: the sound the turbo makes when it winds down (is only used if "Is Turbo Charger" is checked
  * Default Skid Sound: the sound the tires make when they skid
  * Engine Pitch Offset: Pitch offset for engine sound (this value is added to all engine pitch values)
  * Engine Pitch Scalar: Engine pitch multiplier (this value is multiplied to all engine pitch values)
  * Idle Pitch: Pitch offset for idle sound
  * Burnout Pitch: Max pitch when performing burnout
  * Burnout Pitch Increment: How quickly it should reach Burnout Pitch
  * Burnout Pitch Backoff: The amount the pitch goes down once the max pitch is reached
  * Audio Gears: The pitch of the engine as it shifts through the gears...
    * Name: Can be whatever; is usually something like "Gear 1"
    * Min Speed: Denotes what speed (of the engine; RPM not MPH) is 0 on the Pitch Curve (not used for shifting). Generally, this should be the same as the Max
      Speed of the previous gear
    * Max Speed: The speed (of the engine; RPM not MPH) when the next gear should be used
    * Pitch Offset: This value is added to all engine pitch values for this gear
    * Pitch Scalar: This value is multiplied to all engine pitch values for this gear
    * Pitch Curve: The pitch of the engine as the speed moves from Min Speed to Max Speed. Normally, this is linear (a straight line)
  #### Car Stats
  Select the base object (the one at the top of the hierarchy). In the inspector, there are a ton of stats for you to change to customize the performance of your car.
  The first thing to modify is located on the Rigidbody component; change the mass to a reasonable amount. You can think of the units as kilograms if it helps. Somewhere in the range
  of 1000 to 3000 would be fine for most cases; generally between 1200 and 2500 is reasonable.
  Then, on the Car Move Mod script, there is a ton more stats to change:
  * Car Parts To Skin: This is a list of all objects you added the CarPartSkinMod script to
  * Car Wheel Drive: this affects the car's handling, especially when drifting
  * Acceleration Curve: How quickly the car can accelerate the closer to max speed it is
  * Boost Curve: How quickly the car accelerates while boosting the closer to max boost speed it is
  * Air Boost Curve: The same as boost curve, but when the car is airborne
  * Reverse Curve: How fast the car accelerates when in reverse
  * Steer Curve: Affects how easily the car can steer at different speeds
  * Center of Mass: Changes how gravity affects the car (probably affects handling)
  * Motor Force: How much force the motor outputs; 1000-2300 is a good range
  * Brake Force: How quickly the vehicle comes to a stop; 10,000-25,000 is a good range
  * Max Steer Angle: Affects turning radius; the higher the angle, the smaller the turning radius (the car will turn sharper)
  * Max Speed: todo

  Finally, if you haven't done so already, rename the base object to the name of the car (do the same with the prefab file).

### Skins
  If you are following the recommended file structure for mods, skins for cars you added are located under \[Cars/(your car name)/Data\] and \[Cars/(your car name)/Skins\].
  Textures and materials will go in the "Skins" folder, and everything else will go in "Data".
  To add textures, see [Adding custom textures/materials](#Adding-custom-textures/materials)

  todo
## Adding skins to existing cars
  If you are following the recommended file structure for mods, skins for cars already in the game are located under \[Skins].
  It is recommended to create a folder for each car you add skins to, as well as a new folder for each skin. To create a skin for an existing car, you will need to
  know the number of parts and materials per part. Each car handles materials and skins differently; because of this, you are provided with a script that
  gives you the set of parts and materials for each car. To access these lists, in the main scene, select the object named "Data". You should see a script in the inspector called "Data Reference".
  Expand the list to find the car you want to add a skin to. The hierarchy of this list is:
  1. Cars
  1. (Car name)
  1. Skins
  1. (Car Entity Skin name)
  1. (Car Skin Data name)
  1. (Material name)

  This list can be used to help you figure out how to apply materials, and it is especially useful for knowing when a car has multiple parts to skin.
  Find the car you want to add a skin to, and expand one of the Car Entity Skin entries (under the "Skins" entry). Each of the entries under that is for a different part (there may only be one).
  So, for your skin, create a Car Skin Data object \[Assets > Create > Mods > Car Skin Data] for each sub-entry in that list. They do not have to be named the same, but be sure you know which is for which part.
  **Note**: if you see an entry named "Hide Part" on a skin, then you may not need to create an Car Skin Data object; this is a special Car Skin Data
  that hides the part associated with that element. This object is provided to you at \[Assets/Common Car Resources/Hide Part].

  For example:
  
  ![image](https://github.com/SuperCatGaming/Velocity-Redux-Modding-Tool/assets/16313202/e91180a5-c209-4460-996a-a4642a184498)
  
  Here, we have chosen Drift Tech, since it has multiple parts. By looking at the Teku skin, we see that Drift Tech has 3 parts; the body, the spoiler, and a hidden part.
  If we look at the other skins for Drift Tech, we will find what that hidden part is; it happens to be an alternative spoiler. So, for this example,
  we will only need 2 Car Skin Data objects because we don't need both spoilers.

  After you have create the Car Skin Data objects, you need to set the materials for the skin. **Note**: order matters. Look at the list; 
  you can look at the order of the materials for each skin to get an idea about what each material is generally for. You may have to tinker with the materials to get it just right.
  Once you know/have the materials you want, add them to the "Skin Materials" list of the Car Skin Data object
  for the respective part. To add custom materials, see [Custom textures/materials](#Custom-textures/materials) above.
  
  Once you have added all the materials for each part, create a Car Entity Skin Addon \[Assets > Create > Mods > Car Skin (for existing cars)\]. Select the created object and fill out the details:
  
   * Skin Name: the short name of the skin
   * Skin Long Name: the full name of the skin
   * Skin Creator: the creator of the skin
   * Skin Period: usually tells when the die-cast was produced
   * Skin Image: the icon for this skin, normally 512x512. You can [import](#Importing-files-into-Unity) an image into Unity to use here
   * Car Name: this field tells the game which car to add this skin to. This **must** match exactly. The list of cars is at the bottom of the inspector under "Name Lists (for your reference)"
   * Skin Rim Color: the default primary rim color
   * Skin Rim Secondary: the default secondary rim color
   * Skin Tire Color: the default tire color
   * Default Rim: this field tells the game which rim to default to for this skin. This alos **must** match exactly. The list of rims is found under the car list in the inspector
   * Skin Color Changeable: if checked, allows the skin's color to be changed by the player
   * Skin Color Slots: identifies the index/indices of the material(s) to change the color of. This only indexes the materials of the main body of the car, not extra parts. **Note**: the material
       is normally "Spectraflame_WhiteTemplate", located at [Assets/Common Car Resources/Materials/Spectraflame Paint/Spectraflame_WhiteTemplate]
   * Skin Color Default: the color selected by default if "Skin Color Changeable" is checked
   * Bypass Unlock: if checked, allows players to use the skin without unlocking it
   * Skin Materials: a list of Car Skin Data objects; one for each part. **Order matters**
## Adding a rim
  If you are following the recommended file structure for mods, rims are located under \[Rims]. It is recommended to create a new folder for each rim you add.
  To create a new rim, you will need a model; import the model into Unity. Be sure to set the default materials.
  A default rim material is located in \[Common Car Resources/Materials/Rims]. Then, you need to create a prefab for your rim. To do so, select the model, then access the menu
  \[Assets > Create > Mods > Rim Prefab]. This creates the rim prefab. **Note:** The name of the prefab is shown as the shorthand name of the rim.
  Double click the newly create prefab to open it in the hierarchy. Select the topmost object in the hierarchy; in the inspector, you will see some settings for the rim.

  * Full Name: Provide the full name of the rim
  * Rim Credit: Provide the (user)name of the creator of the rim
  * Wheel Picture: To add an image, first import an image into Unity. Then drag and drop the image into the box next to "Wheel Picture"
       Rim icons should be 1024x1024 pixels
  * Bypass Unlock: check this if you want players to be able to use the rim without unlocking it
  * Wheel Model: This is set for you if you used the menu item to create a rim. Otherwise, just click and drag the rim model from the hierarchy to this box
  * Supports Wheel Mats: if checked, allows players to select a rim color for this rim
  * Wheel Mat Slot: the index of the material to replace with color. If you're unsure, click on the rim in the hierarchy (usually the second object). At the bottom of the inspector,
       you should see a list of materials. The materials are in index order, starting from 0.
  * Supports Back Wheel Mats: if checked, allows players to select a secondary rim color for this rim
  * Rim Back Mat Slot: the index of the material to replace with secondary color.
  * Tire Model: If you are using a provided tire model, ignore this. Otherwise, we'll get to this
  * Supports Tire Mats: if checked, allows players to select a tire color
  
  As mentioned, some tire models are provide; however, you may also want a model for the tire. Once you have the tire model, import it into Unity. With the rim prefab open, delete the "Tire"
  object in the hierarchy; now add your tire by dragging it from the project explorer to the root object of the hierarchy. Now, select the root object and click and drag
  the newly created tire object into the "Tire Model" box in the inspector.

  Finally, to make sure the game knows this is a rim, create a Rim object \[Assets > Create > Mods > Rim]. Then add the prefab to this object in the inspector.
  
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
