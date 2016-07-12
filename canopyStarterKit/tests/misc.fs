module Misc

open canopy

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
