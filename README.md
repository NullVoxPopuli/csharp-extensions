# csharp-extensions
[![Build Status](https://travis-ci.org/NullVoxPopuli/csharp-extensions.svg)](https://travis-ci.org/NullVoxPopuli/csharp-extensions) [![NuGet version](https://badge.fury.io/nu/csharp-extensions.svg)](http://badge.fury.io/nu/csharp-extensions)

Because csharp needs some help.

## Target Framworks

Currently just DNX 5.0
Pre 5.0 will not be supported because it's too much of a hassle to deploy nugets for multiple frameworks...

## Extensions

 - `Object`
   - `#NewInstance` - creates an empty instance
   - `#Send` - calls a property or method
   - `#RespondsTo` - has property or method?
   - `#IsA` - checks class, superclass, and interfaces
 - `IEnumerable`
   - `#FirstOrDefault` - configurable default
   - `#Flatten` - reduces nested lists to a single dimension
 - `Type`
   - `#GrepProperties` - List of properties matching regex

## Additional Classes

There are no additional classes / data structures at this time.

## Development Notes

[Reference](https://github.com/aspnet/Home/wiki/DNX-utility)

### Refresh Dependencies

Dependencies are defined in project.json

They can be installed/updated via `dnu restore`

### Building

`dnu build`

### Running Tests

`dnx test`

### Packaging for Nuget

`NuGet pack`

### Publish Nuget

`NuGet Push csharp-extensions.x.y.z.nupkg`