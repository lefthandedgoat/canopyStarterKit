module Common

open Microsoft.FSharp.Reflection

//helper funcs
let fromString<'a> s =
  match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    | [|case|] -> FSharpValue.MakeUnion(case,[||]) :?> 'a
    | _ -> failwith <| sprintf "Can't convert %s to DU" s

let executingDir () = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

//types
//A Tag is a description of a type of tests you may want to run, generally covering a page or set of functionality
type Tag =
  | All
  | Actions
  | Assertions
  | Elements
  | Misc

//A TestType lets you break tests up in a second way, not by functionality, but maybe by coverage, or environment
type TestType =
  | All
  | Smoke
  | Full
  | UnderDevelopment

type Arguments =
  {
    Browser : canopy.types.BrowserStartMode
    Tag : Tag
    TestType : TestType
  }
