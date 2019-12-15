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






this is a test.



## The Factory Design Pattern


this is a test.

