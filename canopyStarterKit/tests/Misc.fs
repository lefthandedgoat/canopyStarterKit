module Misc

open canopy.runner.classic
open canopy.classic

let smoke () =
  context "smoke tests for misc canopy features"
  before (fun _ -> url PageIndex.uri)

  "intentionally skipped shows blue in LiveHtmlReport" &&! skipped

  "Apostrophes don't break anything" &&& fun _ ->
    count "I've got an apostrophe" 1

let full () =
  context "full tests for misc canopy features"
  before (fun _ -> url PageIndex.uri)

  ntest "find by label, following field" (fun _ ->
    "Test Field 1" == "test value 1")

  test (fun _ ->
    describe "find by label, for attribute"
    "Test Field 2" == "test value 2")

let all () =
  smoke()
  full()
  
let pmTest () =
  context "testing pm site"
  before (fun _ ->  
    url "https://en.parimatch.com"
    // click "Log in"
    // // css "select[data-id=\"list\"]" << "Account Number"
    // css "input[name=\"phone\"]" << "+380(63)2925608"
    // css "input[name=\"password\"]" << "foo"
    // sleep 5
    // // click "Log in"
    // let idSelector = "//*[@id=\"root\"]/div[2]/div[1]/div[2]/div/form/div[1]/div[2]/div/select"
    // idSelector << "Account Number"
    // "Phone Number" << "123"
  )

  let firstEvent() = first "a[data-id=\"event-card-main-info-button\"]"
  let openTopEvent() = click (firstEvent ())
  let placeBet() = 
    // let totalHeader = parent  (parent  (parent <| element "div[data-id=\"market-expansion-panel-header-Total\"]"))

    let ``Total over 2.5`` = 
       totalHeader 
        |> elementsWithin "div" 
        |> Seq.last
        |> elementsWithin "div"
        |> Seq.find (fun e -> e |> elementsWithin "div" |> List.exists (fun ie -> ie.Text = "2"))
        |> elementsWithin "div"
        |> Seq.item 1

    // click ``Total over 2.5``
   
    click "1.29"
    click "button[data-id=\"heading-bar-go-back\"]"
 
  "should place a bet" &&&& fun _ ->
    click "Football"
    click "1H"
    openTopEvent()
    placeBet()


    "div[data-id=\"animated-odds-value\"] span" == "1.29"






