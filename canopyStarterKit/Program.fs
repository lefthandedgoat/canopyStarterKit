module Program

open canopy
open runner

[<EntryPoint>]
let main argv =
 let args = args.parse argv
 printfn "%A" args

 0
