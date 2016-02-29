module elementz

open canopy
open page_elementWithin

let smoke () =
  context "smoke elements"
  before (fun _ -> url page_elementWithin.uri)

  "element within only searching within the element" &&& fun _ ->
    count items 5
    "spanned item 4" === (element "span" |> elementWithin items).Text

let full () =
  context "full elements"
  before (fun _ -> url page_elementWithin.uri)

  "elements within only searching within element" &&& fun _ ->
    count items 5
    2 === (element "span" |> elementsWithin items |> List.length)

  "someElementWithin only searching within element" &&& fun _ ->
    count ".item" 5
    true === (element "span" |> someElementWithin specialItems).IsSome

let all () =
  smoke()
  full()
