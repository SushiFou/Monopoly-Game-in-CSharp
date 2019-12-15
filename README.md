# Final Project : Design Pattern - Monopoly Game in C#
### _Justine LAGRANGE & Yann KERVELLA_

## **SUMMARY**

- [Project Overview](#project-overview)
- [What Monopoly's functionalities we've implemented](#what-monopoly-functionalities-we-have-implemented)
- [The Decorator Design Pattern](#the-decorator-design-pattern)
- [The Factory Design Pattern](#the-factory-design-pattern)
- [The Singleton Design Pattern](#the-singleton-design-pattern)
- [The Bridge Design Pattern](the-bridge-design-pattern)


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



this is a test.






## The Decorator Design Pattern






this is a test.



## The Factory Design Pattern


this is a test.

