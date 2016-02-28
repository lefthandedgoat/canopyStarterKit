namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("canopyStarterKit")>]
[<assembly: AssemblyProductAttribute("canopyStarterKit")>]
[<assembly: AssemblyDescriptionAttribute("Starter kit for UI automation with canopy")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
