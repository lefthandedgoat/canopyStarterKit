module args

open Argu
open common

type private CLIArguments =
  | Browser of string
  | Tag of string
  | TestType of string
  with
    interface IArgParserTemplate with
      member s.Usage =
        match s with
        | Browser _ -> "specicfy a browser (Chrome Firefox IE)."
        | Tag _ -> "specify tag (All Misc etc)."
        | TestType _ -> "specify testType (All Smoke Full UnderDevelopment)."

let parse cliargs =
  let parser = ArgumentParser.Create<CLIArguments>()
  let results = parser.Parse(cliargs)

  {
    Browser = results.PostProcessResult (<@ Browser @>, fromString<canopy.types.BrowserStartMode>)
    Tag = results.PostProcessResult (<@ Tag @>, fromString<Tag>)
    TestType = results.PostProcessResult (<@ TestType @>, fromString<TestType>)
  }
