module args

open Argu
open common

type private CLIArguments =
  | Browser of string
  | Tagz of string
  with
    interface IArgParserTemplate with
      member s.Usage =
        match s with
        | Browser _ -> "specicfy a browser (Chrome Firefox IE)."
        | Tagz _ -> "specify tags (Page1 Page2 Page3...)."

let parse cliargs =
  let parser = ArgumentParser.Create<CLIArguments>()
  let results = parser.Parse(cliargs)

  let parseTags (ts : string) = ts.Split(' ') |> Array.map fromString<Tag> |> List.ofArray

  {
    Browser = results.PostProcessResult (<@ Browser @>, fromString<canopy.types.BrowserStartMode>)
    Tags = results.PostProcessResult (<@ Tagz @>, parseTags)
  }
