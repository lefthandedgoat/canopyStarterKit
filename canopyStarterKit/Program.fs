module Program

open canopy
open runner

[<EntryPoint>]
let main argv =
 let args = args.parse argv

 start args.Browser

 System.Console.ReadKey() |> ignore

 quit ()

 0
