# Unity3D_ActiveManagement
Minimize the number of objects active in a scene

There are a few products available that do an exellent job of allowing developers to make larger scenes, however some of these need a lot of setup before and/or during development.    This code is a very simple method to minimize the number of objects that are in a scene based on the distance to the player.

Here are the steps to setting up Active Management:
1) Add the ActiveMgmt script to your player object.
2) Within the Inspector you can add items to the list.  Each item consists of a "Object Tag" and a "Min Distance".  The tags must be tags that exist in your game.  At run-time the ActiveMgmt code will loop through the items, find objects in your game that match those tags and create a list of objects and the minimum allowed distance to the player.  Objects outside that distance are disabled.

The ActiveMgmt script has two other properties
* Timer Interval.   This allows the script to run at a rate that suits the needs of your game.
* Timer Start.   This is in case you need to allow some time for other actions to occur prior to starting the timer.

Notes:
* The ActiveSetting class can be added specifically to tagged object at design time in case some objects within a tag-group are to have unique settings.  There is some commented code within ActiveMgmt that show the usage under that scenario.  Be aware that if ActiveSettings is used in this manner that it will need to be inherited from MonoBehaviour
* ActiveSettings has an enum ObjectType.  I used this to note a specific type, obviously, and affect that in a different manner.   In this case, for example, in the Update() function I gathered all buildings in a secondary list that another script could access.
* The ActiveSettings class also has a "postion" property, this is in cases where the transform's position is not the position you wish to track.  For example I am using Easy Roads 3D (awesome road system btw) and it's position is at the beginning of the road and I wanted the center point.   Having a different position property allowed me this feature.
