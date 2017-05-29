[![Build status](https://ci.appveyor.com/api/projects/status/b98onv6m5cb39mly?svg=true)](https://ci.appveyor.com/project/protobufel/multikeymapcsharp)
[![NuGet](https://img.shields.io/nuget/v/multikeymap.svg?style=plastic)](https://www.nuget.org/packages/multikeymap/)

<!--- ([![NuGet Pre Release](https://img.shields.io/nuget/vpre/multikeymap.svg?style=plastic)](https://www.nuget.org/packages/multikeymap/)) --->

# MultiKeyMap C# Implementation #

C# implementation of the multi-key map.  It behaves like a regular generic IDictionary with the additional ability of getting its values by any combination of partial keys. For example, one can add any value with the complex key {"Hello", "the", "wonderful", "World!"} , and then query by any sequence of subkeys like {"wonderful", "Hello"}.  
