module assertions

open canopy
open page_index

let smoke () =
  context "smoke assertions"
  before (fun _ -> url page_index.uri)

  "#firstName should have John (using == infix operator)" &&& fun _ ->
    firstName == "John"

let full () =
  context "full assertions"
  before (fun _ -> url page_index.uri)

  "id('firstName') should have John (using == infix operator), basic xpath test" &&& fun _ ->
    firstNameXpath == "John"

  "#lastName should have Doe" &&& fun _ ->
    lastName == "Doe"

  "#lastName should have Doe via read cssSelector" &&& fun _ ->
    read lastName |> is "Doe"

  "#lastName should have Doe via read IWebElements" &&& fun _ ->
    element lastName |> read |> is "Doe"

let all () =
  smoke()
  full()
