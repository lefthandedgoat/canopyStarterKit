module Program

open canopy
open reporters
open common

[<EntryPoint>]
let main argv =
  configuration.chromeDir <- executingDir()
  reporter <- new LiveHtmlReporter(Chrome, configuration.chromeDir) :> IReporter
  reporter.setEnvironment "canopy test page"

  let args = args.parse argv
  start args.Browser

  tests.register args.Tag args.TestType
  run()

  System.Console.ReadKey() |> ignore
  quit ()

  //return code
  canopy.runner.failedCount
