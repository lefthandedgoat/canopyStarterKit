module common

open Microsoft.FSharp.Reflection

//helper funcs
let fromString<'a> s =
  match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    | [|case|] -> FSharpValue.MakeUnion(case,[||]) :?> 'a
    | _ -> failwith <| sprintf "Can't convert %s to DU" s

let executingDir () = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

//types
type Tag =
  | All
  | Actions
  | Assertions
  | Elements
  | Misc

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
