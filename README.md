# Final Project : Design Pattern - Monopoly Game in C#
### _Justine LAGRANGE & Yann KERVELLA_

## **SUMMARY**

- [Project Overview](#project-overview)
- [What Monopoly's functionalities we've implemented](#what-monopoly-functionalities-we-have-implemented)
- [The Decorator Design Pattern](#the-decorator-design-pattern)
- [The Factory Design Pattern](#the-factory-design-pattern)
- [The Singleton Design Pattern](#the-singleton-design-pattern)


## Project Overview

![image](https://user-images.githubusercontent.com/57563656/70870121-d4407580-1f8f-11ea-9f98-d92a7f6c6706.png)

We have decided to create multiple classes (you also see abstract classes on the image above) for our solution to the project.

Here is a brief explanation of each : 

- *Board.cs* : This is our singleton design pattern class, it will instantiate a unique board for our game, with all the properties and cards and jail !

- *Card.cs* : This is an the product of our factory pattern, cards have different types of actions : give or take money, move players...

- *CardFactory* : The Factory for the product Cards, we'll just have to give a position in the future to create one for the board

- *Game.cs* : The "big" class, that monitors the game in terms of UI, create a board, called from the very beginning to the very end.

- *Player.cs* : This class enables us to monitor player's ressources (money, properties, jail or not) and his position very easily after instanciation

- *Program.cs" : Contains our main function, very simple & basic but we wanted it to be clear (create a game)!

- *Property.cs* : As we know, Monopoly's Board is not only about getting cards, but also properties. This class enables us to manipulate property, reading their values, names, etc...

- *PropertyDecorator.cs* : This contains the decorator pattern that we wanted to implement, we use it when a property changes its state : bought / player has bought a house / player has bought a hotel : we'll discuss this more in-depth later.

- *Square* : Our board is made of Squares that can be properties, cards, taxes or jail ! But all these share the same instance : a position !

- *SquareFactory* : Part of the factory pattern !

## What Monopoly functionalities we have implemented

- 2-6 players

![image](https://user-images.githubusercontent.com/57563656/70870343-73ff0300-1f92-11ea-889c-9fe2baa61b64.png)

- Random Dice Rolling

![image](https://user-images.githubusercontent.com/57563656/70870349-88430000-1f92-11ea-856c-09c84cd9cc0c.png)

- 40 Square Board

- All properties implemented with options to buy, add house and add hotels to increase future revenues

![image](https://user-images.githubusercontent.com/57563656/70870386-08696580-1f93-11ea-941f-ae1f5f604d1a.png)

- Chances Cards and Community_Chest Cards implemented with random events : earn money, pay taxes, move backwards or forwards...

![image](https://user-images.githubusercontent.com/57563656/70870352-9db82a00-1f92-11ea-8211-a0e2af944a1c.png)

- Jail option added

![image](https://user-images.githubusercontent.com/57563656/70870390-1ae39f00-1f93-11ea-826d-a85fc591834d.png)
![image](https://user-images.githubusercontent.com/57563656/70870396-2e8f0580-1f93-11ea-8606-81b4bbbbcb87.png)

- Players win when their opponents gave up or lost all their money

- Players earn money each tour they make.

- Players have to pay taxes if they are on another's one property

![image](https://user-images.githubusercontent.com/57563656/70870415-6ac26600-1f93-11ea-9954-b1b56302b078.png)

- Dashboard option to see our information

![image](https://user-images.githubusercontent.com/57563656/70870382-f4bdff00-1f92-11ea-8dcb-c1926101f244.png)

- Game Status Option

![image](https://user-images.githubusercontent.com/57563656/70870373-c7715100-1f92-11ea-8334-be2b3bd0e922.png)


## The Decorator Design Pattern

We chose to use this pattern in order for our properties to be evolving during the course of the game. First, their situation : bought or not. Then, if a player chose to buy a house or a hotel for this property, the taxes should be changing as well. At first, we had the ambition to use it as well to group properties (Streets so the tax rise up and we build up to 5 houses) like other Monopoly Games, but it turned out that it was way more complicated than wr thought it would be. So here it is : 

![image](https://user-images.githubusercontent.com/57563656/70870791-f211d880-1f97-11ea-9e42-e724f9fe2225.png)

![image](https://user-images.githubusercontent.com/57563656/70870794-035ae500-1f98-11ea-96c9-732425bb07cd.png)


## The Factory Design Pattern

We chose to use this pattern in order to create Square cards more efficiently in our Monopoly Board. Unlike properties, cards are a like a dynamic object in this project whereas there isn't two similar properties on the board. Each time a player falls on a card square on the board (Chance Card or Community Chest), a random number is generated. Each number have a different action. 

- UML Diagram

![image](https://user-images.githubusercontent.com/57563656/70870761-86c80680-1f97-11ea-8f34-39536de11b98.png)

- Code : 

![image](https://user-images.githubusercontent.com/57563656/70870651-34d2b100-1f96-11ea-872d-38b841d6b2d7.png)

![image](https://user-images.githubusercontent.com/57563656/70870631-f3420600-1f95-11ea-9d43-fa474e2e4030.png)

![image](https://user-images.githubusercontent.com/57563656/70870637-06ed6c80-1f96-11ea-8f34-230eab84ef94.png)

![image](https://user-images.githubusercontent.com/57563656/70870645-1d93c380-1f96-11ea-8a24-cf6d54c7ecf1.png)

This Factory Pattern enables us to instantiate Square very easily afterwards :

![image](https://user-images.githubusercontent.com/57563656/70870773-ae1ed380-1f97-11ea-9bdc-4b11a343ae1f.png)

![image](https://user-images.githubusercontent.com/57563656/70870782-becf4980-1f97-11ea-8ce3-95847ea29fa2.png)

## The Singleton Design Pattern

The choice of using a Singleton Pattern here ensures at any given point of time only one instance of the board is alive.

![image](https://user-images.githubusercontent.com/57563656/70870565-246e0680-1f95-11ea-95fc-4d4dc3950a1a.png)

In this portion of code, the thread is locked (function lock) on a shared object and checks whether an instance has been created or not.
Thanks to this code, we will take care of memory barrier issues and ensure that only one thread will create an instance.

