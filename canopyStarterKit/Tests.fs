module Tests

open Common

//The default argument passed from the console in the starter kit is UnderDevelopment
//This lets you simply comment/uncomment the test context/suite that you are working on
//As you add more tests for different pages, add an entry here
let underDevelopment () =
  //Actions.all()
  //Assertions.all()
  //Elementz.all()
  Misc.pmTest()

//This is a list of all tests, which is useful when running in a CI environment where you want to
//run all tests, or a specific type of test like Full/Smoke, or tests for a specific
//page or set of functionality
//Its is a list of a tuple of 3 things, a Tag, TestType, and a the function that wraps your actual tests
//As you add more tests for different pages, add an entry/entries here
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
  
//Code below does not need to be changed in most cases, it simply takes all of the tests and removes ones that dont
//meet the tags provided from arguments
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
