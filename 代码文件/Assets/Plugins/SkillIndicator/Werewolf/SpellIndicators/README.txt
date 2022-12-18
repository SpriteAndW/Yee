?Werewolf Games Studio 2016 - Unity Asset Store
________________________________________________________________________________________________________________________

daily assets update for try.

U should buy the asset from home store if u use it in your project!

# Spell Indicators

Thankyou for purchasing Spell Indicators!
________________________________________________________________________________________________________________________

# Contents
A.  How to quickly add Spell Indicators to your Game
A.1 Troubleshooting

B. How to create a custom Spell Indicator
1. Create the Image
2. Create the Material
3. Create the Projector
4. Apply Splat to Scene
5. Write the Code. 

Other Settings
C. Hiding the Mouse Cursor
D. Adding or Changing Indicator Types
E. Changing the size of your Splat
F. Changing the color of your Splat
G. Masking the splat when rendering over a Character
H. Extending the SplatManager so that it can handle a large array of Indicator Types (per spell, etc)

________________________________________________________________________________________________________________________

# How to quickly add Spell Indicators to your Game
________________________________________________________________________________________________________________________

Open the demo in Werewolf/SpellIndicators/Demo.

Expand the "Character" gameobject and copy the SplatManager gameobject.

Open the desired scene and paste it onto your character in the manner that is shown in the demo.

Make sure its transform is centered on the Character so that the rotation will revolve around it.

Create a property on your Character,

    public SplatManager Splats { get; set; }

In your character Start() method add,

    Splats = GetComponentInChildren<SplatManager>();

Or simply refer to the Character script that is in the demo.

Code away!

Example Update Method:
    void Update() {
      // Hide Splat if Left Mouse Click
      if (Input.GetMouseButton(0))
        Splats.Cancel();

      if (Input.GetKeyDown(KeyCode.Q)) {
        Splats.Direction.Select();
        Splats.Direction.Scale = 5f;
      }

      if (Input.GetKeyDown(KeyCode.W)) {
        Splats.Cone.Select();
        Splats.Cone.Scale = 5f;
      }

      if (Input.GetKeyDown(KeyCode.E)) {
        Splats.Point.Select();
        Splats.Point.Scale = 5f;
        Splats.Point.Range = 5f;
      }

      if (Input.GetKeyDown(KeyCode.A)) {
        Splats.Direction.Select();
        Splats.Direction.Scale = 8f;
      }

      if (Input.GetKeyDown(KeyCode.S)) {
        Splats.Cone.Select();
        Splats.Cone.Scale = 8f;
      }

      if (Input.GetKeyDown(KeyCode.D)) {
        Splats.Point.Select();
        Splats.Point.Scale = 8f;
        Splats.Point.Range = 8f;
      }
    }
________________________________________________________________________________________________________________________

# Troubleshooting
________________________________________________________________________________________________________________________

Due to the dynamic nature of the custom editor, prefab attributes will be applied back onto intances when the game starts. 
If you want instances to have separate attribute values, make sure to unlink from the prefab and proceed as normal.

________________________________________________________________________________________________________________________

# How to create a custom Spell Indicator
________________________________________________________________________________________________________________________

#### 1: Create the Image

First you will need an image to use as your Spell Splat.

Requirements
- Use White color only, to allow customization of color in game.
- The image must be square, non-square images will look deformed.

Import the image into Unity. In the image settings set "Wrap Mode" to Clamped.


#### 2: Create the Material

Create a new Material with, Right-Click -> Create -> Material

In the new material select the Image that you want to use for your Splat.

Set the Falloff using the falloff image provided in the package in the Images folder.


#### 3: Create the Projector

Drag the SpellSplatBase provided in the Prefabs folder in the Package onto the scene. 

Unlink the prefab and create a new prefab for it.

Set the Material to your newly created Material.

Specify the settings as needed for the Splat. If you want it only rotate and face the mouse, such as a cone splat, choose "Facing". If you want it to follow the Mouse Cursor, choose "Moving".


#### 4: Apply Splat to Scene

Create a "Splat Manager" if you haven't already, by creating a new GameObject and applying the SplatManager script. The Splat Manager contains references to all the Spell Splats.

Drag the new Spell Splat object you have created onto the Splat Manager, so that the Splat's parent is the Splat Manager. This is not necessary, but nice if you want to keep everything organised.

Drag the new Spell Splat object into one of the slots in the Splat Manager. You can adjust these slots as necessary in the Splat Manager code.

Make sure the SplatManager is sitting at the center just above the base of your character (or where ever you want the splat to show). This will make sure the Splats rotate around the character. If you need an example please have a look at the Demo provided.


#### 5: Write the Code

Create a GameObject script and apply this code in your Update() method.

  if (Input.GetKeyDown(KeyCode.Space))
    Splats.Direction.Select();

Replace Splats.Direction with the slot you have used. For example if you applied to the Cone slot, use Splats.Cone instead.

Congrats! You have now made a Spell Indicator!

Run the scene and press Spacebar, you should see the splat rotating around your character!

________________________________________________________________________________________________________________________

# Other Settings
________________________________________________________________________________________________________________________


#### C: Hiding the Mouse Cursor

You can specify whether you want the mouse cursor to hide when a Splat is rendered in the SplatManager, by checking the "Hide Cursor" option.

The "HideCursor" variable and "Update()" method in SplatManager may be deleted if you do not need the functionality, it is only there for example purposes.


#### D: Adding or Changing Indicator Types

In order to add new or change existing indicator types you will need to edit the SplatManager script.

The two lines of code you will need to edit are:

The public variable,

    public Splat Direction, Cone, Point;

And the Splat Array initializer in the Start() method,

   Splats = new Splat[] { Direction, Cone, Point };


If you want to add a new Splat, for example Circle, you will add the variable "Circle" to both these lines, as follows;

    public Splat Direction, Cone, Point, Circle;

And

   Splats = new Splat[] { Direction, Cone, Point, Circle };

Basically, make sure that any changes in the variables are mirrored in the initializer so that the Manager knows about them.

After adding the new Splat type, you should see an extra "Circle" slot in the inspector window. 

Create a new Splat using the tutorial above and add it to the slot.


#### E: Changing the size of your Splat

You can change the size of your splat by adjusting the "Orthographic Size" field. You can narrow and widen the splat by adjusting the "Aspect Ratio" field.


#### F: Changing the color of your Splat

You can change the color of your splat by adjusting the color field in the Material you created for the Splat.


#### G: Masking the splat when rendering over a Character

If you would like to have the splat not render over a Character or any object, make sure that the object is in a separate layer and you specify that layer in "Ignore Layers" in the Projector.


#### H: Extending the SplatManager so that it can handle a large array of Indicator Types (per spell, etc)

The current setup is designed to handle a small amount of splats in a simple manner, this should be fine for most games. The code is oriented around being as simple as possible to be easy to use.

However manually adding splats to the splat manager when the nature is very dynamic in your project may be a bit time consuming with the current setup.

If you want to handle Splats Per Spell for example, it would be better to add the Splat reference to the Spell instead of the Splat manager.

In your Splat Manager, instead of having a fixed array, use a variable list.

When you assign/de-assign a spell to the character, this should update your splat manager list, and it should also set the reference to the SplatManager for the Spell Splat.

When you cast the spell, selecting the Splat from the Spell rather than the Manager should allow it to appear, and the Splat manager will make sure to hide the other spell splats.

In summary
  FireballSpell has reference to a Splat
  Assign FireballSpell to Character, 
   - FireballSpellSplat is added to SplatManager List<Splats>
   - Maps the SplatManager to FireballSpell.Splat
  When Character casts Fireball, Fireball.Spell.Splat.Select() is called
  Manager handles the rendering and hiding of other Splats

This means you don't have to manually add all the Spell Splats to the SplatManager in the beginning and can be handled dynamically. 

________________________________________________________________________________________________________________________


Feel free to send an email to WerewolfGameStudio@gmail.com if you have any questions.

Thanks for reading and I hope you enjoy the new package!