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
Second Aproach : The Process Will be fired , once a Client Request an Order,
This Order will be allocaded on a BUS, and Dispached once the Dispacher is free.

The order for example a Bycicle, 
then the Dispacher will Disamble each necesary part of the Bycicle.
each Part its allocated in Diferent Stations/Lockers.

the Dispacher will Create the Best Suited Route with  Threads for each Robot Travel,
This Robots will Start from The Parking Stand to the Pointed Station pick the Material and then Bring it to a 
Delivery Stand.Once the Operator, Realease the Robot, this will bring the Material to the Station.

The Best Scenario its to Create the Most Optimal Route.
When The Robots Return the Material, they could see if there is Something else requiered Close to him , 
so in that case the Robot doesnt return Empty.

again,robots Notify their activity.


