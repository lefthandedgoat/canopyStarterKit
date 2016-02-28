module common

open Microsoft.FSharp.Reflection

//helper funcs
let fromString<'a> s =
  match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    | [|case|] -> FSharpValue.MakeUnion(case,[||]) :?> 'a
    | _ -> failwith <| sprintf "Can't convert %s to DU" s

//types
type Tag =
  | Page1
  | Page2
  | Page3

type Arguments =
  {
    Browser : canopy.types.BrowserStartMode
    Tags : Tag list
  }
