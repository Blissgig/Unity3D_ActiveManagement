# Unity3D_ActiveManagement
Minimize the number of objects active in a scene

There are a few products available that do an exellent job of allowing developers to make larger scenes, however some of these need a lot of setup before and/or during development.    This code is a very simple method to minimize the number of objects that are in a scene based on the distance to the player.

Here are the steps to setting up Active Management:
1) Add the ActiveMgmt script to your player object.
2) Within the Inspector you can add items to the list.  Each item consists of a "Object Tag" and a "Min Distance".  The tags must be tags that exist in your game.  At run-time the ActiveMgmt code will loop through the items, find objects in your game that match those tags and create a list of objects and the minimum allowed distance to the player.  Objects outside that distance are disabled.

The ActiveMgmt script has two other properties
* Timer Interval.   This allows the script to run at a rate that suits the needs of your game.
* Timer Start.   This is in case you need to allow some time for other actions to occur prior to starting the timer.
