module Tests

open Common

//Usually just uncomment the test you are working on
let underDevelopment () =
  //actions.all()
  //assertions.all()
  //elementz.all()
  Misc.all()

let all =
  [
    Actions,    Smoke, Actions.smoke
    Assertions, Smoke, Assertions.smoke
    Elements,   Smoke, Elementz.smoke
    Misc,       Smoke, Misc.smoke

    Actions,    Full, Actions.full
    Assertions, Full, Assertions.full
    Elements,   Full, Elementz.full
    Misc,       Full, Misc.full
  ]

let register tag testType =
  let exec predicate =
    all
    |> List.filter predicate
    |> List.iter (fun (_,_,func) -> func())

  match tag, testType with
  | (_, UnderDevelopment) -> underDevelopment()
  | (Tag.All, All)        -> exec (fun _ -> true)
  | (Tag.All, testType)   -> exec (fun (_, testType', _) -> testType' = testType)
  | (tag, All)            -> exec (fun (tag', _, _) -> tag' = tag)
  | (tag, testType)       -> exec (fun (tag', testType', _) -> tag' = tag && testType' = testType)
