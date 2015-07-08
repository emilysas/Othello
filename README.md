# Othello
Creating an in-browser version of the traditional [othello / reversi](https://en.wikipedia.org/wiki/Reversi) game

##Tools Used
* C#
* ASP.NET
* NUnit


## Domain Model / CRC

[Othello/Reversi Rules as per wikipedia](https://en.wikipedia.org/wiki/Reversi) 


Collaborations
--------------

Board                   | Collaborators
------------------------|-------------------
Contains Counters       | Counter


Game                                            | Collaborators
------------------------------------------------|-------------------
Has players                                     | Player
Allows counters to be placed according to rules | Player, Counter, Board
Turns counters according to placement and rules | Counter, Board


Player                  | Collaborators
------------------------|--------------------
Plays colour            | Counters, Game
Places counters         | Counters, Board
Wins/Loses              | Board, Game
  
Counter                 | Collaborators
------------------------|--------------------
Colour                  |	



Classes
-------

* Game
* Board - this is the 'Grid' class from my [Game of Life](https://github.com/emilysas/GameOfLife) repo
* Counter
* Player

___________________________

##Issues faced
