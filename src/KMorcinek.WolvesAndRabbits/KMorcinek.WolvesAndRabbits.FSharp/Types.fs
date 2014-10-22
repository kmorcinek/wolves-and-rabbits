namespace Types

type Position =
    struct 
       val X : int
       val Y : int
       val Number : int
       new(number) = { X = number%3; Y = number/3; Number = number}
    end 

type Rabbit =
    struct 
       val Position : int
       val Food : double
       new(position, food) = { Position = position; Food = food}
    end

type RabbitWithLettuces =
    struct 
       val Rabbit : Rabbit
       val Lettuces : Rabbit List
       new(lettuces, rabbit) = {Lettuces = lettuces; Rabbit = rabbit}
    end

