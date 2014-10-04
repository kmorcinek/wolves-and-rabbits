Wolves & rabbits
==================

Main purpose is learning.

It is my first approach to write C# code using only Functional programming (not perfect, but for my current knowledge). Immutability and no dealing with state (no side effects). Yes, **writing in functional style is possible in C#/.NET** (starting with LINQ in .NET 3.5)

The case of [Cellular automaton] I guess is less efficient in functional approach than object oriented (not sure). So yes, my code can be inefficient.

Todos:
  - Some implementations from FieldBase (*AddNewBorns()*, *GetAlive()*, ...) should be probably moved to other class as static methods easy for testability. Not sure yet how to deal with inheritance.
  - Interface method *IFood Create(Position position, double food);* should be moved to a factory.
  - *NeighborhoodGenerator* should use Dictionary<Position, Positions[]>

Should probably use F# as soon as I learn it.

Demo
==================

[Web version of Wolves and rabbits]



[Cellular automaton]:http://en.wikipedia.org/wiki/Cellular_automaton
[Web version of Wolves and rabbits]:http://wolves-and-rabbits.krzysztofmorcinek.com/