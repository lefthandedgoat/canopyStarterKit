module Assertions

open canopy
open PageIndex

let smoke () =
  context "smoke assertions"
  before (fun _ -> url PageIndex.uri)

  "#firstName should have John (using == infix operator)" &&& fun _ ->
    firstName == "John"

let full () =
  context "full assertions"
  before (fun _ -> url PageIndex.uri)

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
