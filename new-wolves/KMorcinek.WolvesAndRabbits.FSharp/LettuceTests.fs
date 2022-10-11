// module LettuceTests
//
// open Lettuce
// open Xunit
// open Xunit.Should
// open FsTypes
//
//     let anyPosition = 1
//     let growHalfFood () = 0.5
//
//     [<Fact>]
//         let ``Create basic lettuce field with 9 fields``() = 
//             let positions = createLettuceField
//
//             Assert.Equal(9, positions.Length)
//             
//     [<Fact>]
//         let ``NextTurn() for Lettuce``() = 
//             let lettuces = [new Rabbit(anyPosition, 1.)]
//
//             let nextTurn = NextTurn growHalfFood lettuces
//
//             Assert.Equal(2.5, nextTurn.Head.Food)
//             
//     [<Fact>]
//         let ``NextTurn() for Lettuce cannot grow more than max``() = 
//             let lettuces = [new Rabbit(anyPosition, 99.)]
//
//             let nextTurn = NextTurn growHalfFood lettuces
//
//             Assert.Equal(100., nextTurn.Head.Food)
//             
//
//
//
