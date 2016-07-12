module Program

open canopy
open reporters
open Common

[<EntryPoint>]
let main argv =
  configuration.chromeDir <- executingDir()
  reporter <- new LiveHtmlReporter(Chrome, configuration.chromeDir) :> IReporter
  reporter.setEnvironment "canopy test page"

  let args = Args.parse argv
  start args.Browser

  Tests.register args.Tag args.TestType
  run()

  System.Console.ReadKey() |> ignore
  quit ()

  //return code
  canopy.runner.failedCount
