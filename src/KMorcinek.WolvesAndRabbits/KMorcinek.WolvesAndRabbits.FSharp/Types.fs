namespace FsTypes

type Rabbit(position:int, food:double) =
    member x.Position = position
    member x.Food = food
    member x.WithUpdatedFood(updatedFood) = new Rabbit(position, updatedFood)