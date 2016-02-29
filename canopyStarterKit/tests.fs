module tests

open common

//Usually just uncomment the test you are working on
let underDevelopment () =
  //actions.all()
  //assertions.all()
  //elementz.all()
  misc.all()

let all =
  [
    Actions,    Smoke, actions.smoke
    Assertions, Smoke, assertions.smoke
    Elements,   Smoke, elementz.smoke
    Misc,       Smoke, misc.smoke

    Actions,    Full, actions.full
    Assertions, Full, assertions.full
    Elements,   Full, elementz.full
    Misc,       Full, misc.full
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
