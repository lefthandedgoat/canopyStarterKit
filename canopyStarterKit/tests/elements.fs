module Elementz

open canopy
open PageElementWithin

let smoke () =
  context "smoke elements"
  before (fun _ -> url PageElementWithin.uri)

  "element within only searching within the element" &&& fun _ ->
    count items 5
    "spanned item 4" === (element "span" |> elementWithin items).Text

let full () =
  context "full elements"
  before (fun _ -> url PageElementWithin.uri)

  "elements within only searching within element" &&& fun _ ->
    count items 5
    2 === (element "span" |> elementsWithin items |> List.length)

  "someElementWithin only searching within element" &&& fun _ ->
    count ".item" 5
    true === (element "span" |> someElementWithin specialItems).IsSome

let all () =
  smoke()
  full()
