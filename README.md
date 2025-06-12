# BookstoreCodeSamples
Code samples of code I wrote from the Bookstore for my portfolio. All scripts are in C#

### My role
I was responsible for implementing the escalator looping mechanic, player movement, and item collection and management. 
The scripts have been sorted into folders accordingly.

### Files
 -  MouseLook.cs: handles mouse movement and we used it to lock and unlock the cursor when necessary such as when the player dies it should unlock.
 -  FirstPersonController.cs: script that handles all player movement as well as sounds related to jumping and stepping on different materials.
 -  TapeCounter.cs: handles item collection including updating UI objectives and making the tape asset unload.
 -  TapeManager.cs: Manages tape counter.
 -  MirrorPlayer.cs: simulates a mirrored version of the player (like a reflection or view through a portal).
 -  PortalTeleporter.cs: ensuring the player Only teleports when moving the correct direction through a portal. Emerges properly aligned at the destination portal.