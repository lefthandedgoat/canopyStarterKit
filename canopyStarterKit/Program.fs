module Program

open canopy
open configuration
open reporters
open Common
open canopy.types
open canopy.classic
open canopy.runner.classic

[<EntryPoint>]
let main argv =
  //Parse all the args into the types that we use in the rest of the code
  let args = Args.parse argv

  configuration.chromeDir <- executingDir()
  reporter <- LiveHtmlReporter(BrowserStartMode.Chrome, configuration.chromeDir) :> IReporter
  reporter.setEnvironment "canopy test page"

  //Start the browser supplied in args
  start args.Browser

  //Register the tests that you want to run (under development, a specific page, all tests, etc)
  Tests.register args.Tag args.TestType
  //Run tests
  run()

  System.Console.ReadKey() |> ignore
  //Quit all browsers
  quit ()

  //return code
  runner.classic.failedCount
