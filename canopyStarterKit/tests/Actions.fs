module Actions

open canopy
open PageIndex

let smoke () =
  context "smoke actions"
  before (fun _ -> url PageIndex.uri)

  "clearing #firstName sets text to new empty string" &&& fun _ ->
    clear firstName
    firstName == ""

  "writing to #lastName sets text to Smith" &&& fun _ ->
    clear lastName
    lastName << "Smith"
    lastName == "Smith"

  "writing to .lastName sets text to new Smith in both boxes" &&& fun _ ->
    clear lastName
    lastNameClass << "Smith"
    lastName == "Smith"
    lastName2 == "Smith"

  "writing to #lastName sets text to new Smith (implicit clear in write)" &&& fun _ ->
    lastName << "Smith"
    lastName == "Smith"

let full () =
  context "full actions"
  before (fun _ -> url PageIndex.uri)

  "clearing #firstName sets text to new empty string via IWebElement" &&& fun _ ->
    element firstName |> clear
    firstName == ""

  "writing to #lastName (as element) sets text to John" &&& fun _ ->
    let lastname = element lastName
    clear lastname
    lastname << "John"
    lastName == "John"

  "writing to .lastName sets text to new Smith in both boxes, xpath test" &&& fun _ ->
    clear lastName
    lastNameXpath << "Smith"
    lastName == "Smith"
    lastName2 == "Smith"

let all () =
  smoke()
  full()
