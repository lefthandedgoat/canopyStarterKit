module common

type Tag =
  | Page1
  | Page2
  | Page3

type Arguments =
  {
    Browser : canopy.types.BrowserStartMode
    Tags : Tag list
  }
