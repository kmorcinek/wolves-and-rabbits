module Runner

open Types
open Rabbit

let Create =
    let lettuces = Lettuce.createLettuceFieldFromSize 10
    let rabbits = [new Rabbit(1, 52.);
                    new Rabbit(0, 10.);
                    new Rabbit(1, 10.);
                    new Rabbit(2, 10.);
                    new Rabbit(3, 10.);
                    new Rabbit(5, 10.);
                    new Rabbit(0, 9.);
                    new Rabbit(-5, 9.);
                    new Rabbit(-6, 9.);
                    new Rabbit(-9, 9.);
                    new Rabbit(-28, 9.);
                    new Rabbit(-27, 9.);
                    new Rabbit(-26, 9.);
                    new Rabbit(-25, 9.);
                    new Rabbit(-20, 9.);
                    new Rabbit(-33, 9.);
                    new Rabbit(-66, 9.);
                    new Rabbit(-29, 9.);
                    new Rabbit(-44, 9.);
                    new Rabbit(11, 9.);
                    new Rabbit(-49, 9.);
                    new Rabbit(11, 9.);
                    new Rabbit(13, 9.);
                    new Rabbit(19, 9.);
                    new Rabbit(26, 9.);
                    new Rabbit(29, 9.);
                    new Rabbit(33, 9.);
                    new Rabbit(38, 9.);
                    new Rabbit(49, 9.);
                    new Rabbit(55, 9.);
                    new Rabbit(88, 9.);
                    new Rabbit(81, 9.);
                    new Rabbit(82, 9.);
                    new Rabbit(85, 9.);
                    new Rabbit(66, 9.);
                    new Rabbit(60, 9.);
                    new Rabbit(88, 9.);
                    new Rabbit(87, 9.);
                    new Rabbit(86, 9.);
                    new Rabbit(85, 9.);
                    new Rabbit(84, 9.)]
    let wolves = [new Rabbit(8, 52.);
                    new Rabbit(66, 60.); 
                    new Rabbit(99, 60.); 
                    new Rabbit(-13, 60.); 
                    new Rabbit(-19, 60.); 
                    new Rabbit(-45, 60.); 
                    new Rabbit(37, 60.); 
                    new Rabbit(54, 60.); 
                    new Rabbit(-54, 60.); 
                    new Rabbit(-50, 60.)]
    (lettuces, rabbits, wolves)