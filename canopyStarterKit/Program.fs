module Program

open canopy
open reporters
open Common

[<EntryPoint>]
let main argv =
  let args = Args.parse argv

  configuration.chromeDir <- executingDir()
  reporter <- new LiveHtmlReporter(Chrome, configuration.chromeDir) :> IReporter
  reporter.setEnvironment "canopy test page"

  start args.Browser

  Tests.register args.Tag args.TestType
  run()

  System.Console.ReadKey() |> ignore
  quit ()

  //return code
  canopy.runner.failedCount
