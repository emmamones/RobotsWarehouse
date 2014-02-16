RobotsWarehouse
===============

MovilityofRobots


Creates an Applications to Deliver Robots to Stations.
Basically it could be reach by 2 approaches:

Fist Aproach : Limited by the Stock on WareHouse, 
Then by the Limited Stations on the WareHouse and the freeSpace to allocate more Boxes.
as long as Exist Stock and Free Spots on the Stations
we will be Creating Threads for each Robot Travel, and Notify the activity of the robots.

--------------------
Second Approach : The Process Will be fired , once a Client Request an Order,
This Order will be allocated on a BUS, and Dispatched once the Dispatcher is free.

The order as an example could be a Bicycle, 
Then the Dispatcher Receive the Order and recognize each necessary item of the Bicycle in order to Manufactured (Sit, Tires, etc). Each Part has its own Station/Lockers.

The Dispatcher will create the Best Suited Route with Threads for each Robot Travel; 

This Robots will Start from The Parking Stand to the Pointed Station pick the Material and then bring it to a Delivery Stand. 
Once the Operator, Release the Robot, this will bring the Material to the Station.

The Best Scenario it’s to create the Most Optimal Route.
When The Robots Return the Material, they could see if there is something else required Close to him, 
so in that case the Robot doesn’t return Empty.
Again, robots notify their activity.


