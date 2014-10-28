namespace Types

type Rabbit =
    struct 
       val Position : int
       val Food : double
       new(position, food) = { Position = position; Food = food}
    end

