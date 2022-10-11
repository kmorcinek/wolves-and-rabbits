# Wolves & rabbits (year 2014)

Main purpose is learning.

## Short description

Lettuce (sałata) grown on field. Rabbits eat lettuce. Wolves eat rabbits. Animals are moving a board to eat best food possible. Animals also grow, breed and finally starve (when run out of food).

## C# version

It is my first approach to write C# code using only Functional programming (not perfect, but for my current knowledge). Immutability and no dealing with state (no side effects). Yes, **writing in functional style is possible in C#/.NET** (starting with LINQ in .NET 3.5)

The case of [Cellular automaton] I guess is less efficient in functional approach than object oriented (not sure). So yes, my code can be inefficient.

Todos:

- Some implementations from FieldBase (*AddNewBorns()*, *GetAlive()*, ...) should be probably moved to other class as static methods easy for testability. Not sure yet how to deal with inheritance.
- Interface method *IFood Create(Position position, double food);* should be moved to a factory.
- *NeighborhoodGenerator* should use Dictionary<Position, Positions[]>

## F# version

Later rewritten whole app to F#.

## Demo

(Currently rewriting to .NET Core and Azure)

[Cellular automaton]:http://en.wikipedia.org/wiki/Cellular_automaton
