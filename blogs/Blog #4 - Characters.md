Main Character: 

The main character was taken from Mixamo and its animations as well. The animations used for the characters are standing, running, jumping, crouch standing, crouch walking, and side walking. These animations were used for enabling the player to jump on obstacles, crouch under them, or sidewalk in tight zones. All of them were set up in the animator tab in Unity, having a boolean value for each to be able to manipulate them in the script when to be turned on/off. The transition from one animation to another is made also by setting the boolean parameters to the right values. For example, for the main character to go from the running animation to the crouching animation, we set in animator the conditions isRunning to false, isCrouching true (for the Crouching Idle animation) and also the isCrouchWalking true (for the Crouching Walking animation). All of the conditions in the animator tab were set in a similar way as the one exemplified above.  The user can interact with the character’s animation in the following matter: 

Idle animation: when no command is given, the character will be in the Standing Idle mode 

Running animation: the player runs when, for the keyboard input, the ‘W’ or forward key is pressed, and for the controller and VIA Arcade machine inputs, the joystick is moved forward 

Jumping animation: the player jumps when, for the keyboard input, the space key is pressed, and for the rest of the inputs is either the ‘A’ for the controller or the green button for the VIA Arcade machine 

Crouching animation: the player crouches when, for the keyboard input, the ‘B’ button is pressed and if it needs to walk, the commands for forward/backwards/left/right are used, and for the rest of the inputs is either the ‘X’ button for the controller or the blue button for the VIA Arcade machine and if it needs to walk, the joystick is moved in the preferred direction 

Side-walking animation: the player side-walks when, for the keyboard input, the ‘P’ button is pressed and if it needs to walk, the commands for left/right are used, the forward and backward directions are frozen, and for the rest of the inputs is either the ‘B’ button for the controller or the red button for the VIA Arcade machine and if it needs to walk, the joystick is moved left/right. 

 

To offer a better perspective for the player when the main character is performing any action (animation), the camera movement was modified to follow the character. It is placed behind the main character and even if the main character turns, for example during sidewalks, the camera follows its back.  

Enemy: 

The enemy was also taken from Mixamo, along with the animations used: walking and punching. It was built using Unity’s NavMeshAgent for basic AI navigation, in combination with NavMeshSurface to define walkable areas. Enemy behavior logic was handled using vector math for pathing and detection.  The enemy starts walking and follows the main character when it enters the chase range zone, and when it is within the punch range zone (closer to the main character), it starts punching. There is a collider added to the enemy’s hand and when it hits the main character’s collider, the health of the main character decreases, illustrated in the UI in the health bar. 
