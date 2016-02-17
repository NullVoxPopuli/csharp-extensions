# csharp-extensions
[![Build Status](https://travis-ci.org/NullVoxPopuli/csharp-extensions.svg)](https://travis-ci.org/NullVoxPopuli/csharp-extensions) [![NuGet version](https://badge.fury.io/nu/csharp-extensions.svg)](http://badge.fury.io/nu/csharp-extensions)

Because csharp needs some help.

## Target Framworks

- DNX 5.0
- DNX 4.6
- .NET 4.6

## Extensions

### `Object`

| Method | Description | Example|
| ----- | ----- | ----- |
| `#Send` | calls a property or method | `obj.Send("MethodName")`
| `#Send=` | Sets a field or property | `obj.Send("PropertyName=", value)` |
| `#RespondsTo` | has property or method? | `obj.RespondsTo("MethodName")` |
| `#IsA` | checks class, superclass, and interfaces | `obj.IsA("IEnumerable")` |
| `#CallableInfo` | returns the Member's Info object | `obj.CallableInfo("propertyOrFieldOrMethod")` |
| `#IsIterable` | checks if the object can be iterated over | `obj.IsIterable()` |
| `#GetInstanceFields` | returns a list of fields for the instance | `obj.GetInstanceFields()` |
| `#IsPrimitive` | returns true if the object is a primitive type, string, or decimal | `obj.IsPrimitive()` |
| `#IsSameTypeAs` | compares the objects type to a passed in object | `obj.IsSameTypeAs(otherObj)` |
| `#HasFieldMatching` | checks instance fields if the passed in field matches name and type | `obj.HasFieldMatching(otherField)` |


### `IEnumerable`
| Method | Description | Example|
| ----- | ----- | ----- |
| `#FirstOrDefault` | configurable default | `list.FirstOrDefault(i => i.IsTrue, defaultValue)`|
| `#Flatten` | recusively reduces nested lists to a single dimension | `list.Flatten()` |
| `#AddRange` | adds an at-runtime defined `List<object>` or `List<dynamic>` to a statically typed list | `list.AddRange(otherList)` as long as all lists have the item type |
| `#Subset` | returns a subset of the enumerable, given a start and end index | `list.Subset(1, 4)` |
| `#Join` | joins an enumerable of strings | `list.Join("-")` |
| `#Zip` | zips two IEnumerables together for easier looping over both simultaneously | `list.Zip(otherList)` |

### `Type`
| Method | Description | Example|
| ----- | ----- | ----- |
| `#GrepProperties` | List of properties matching regex | |
| `#ImplementsType` | Returns whether or not a type Implements an Interface | `typeof(List<int>).ImplementsType(typeof(IEnumerable))` |
| `#HasGenericType` | Returns whether or not a type has a given generic type | `typeof(Dictionary<int, string>).HasGenericType(typeof(string))` |
### `string`
| Method | Description | Example|
| ----- | ----- | ----- |
| `#Gsub` | Replaces the matching pattern with the given text| `"hello".Gsub("\A..l", "")` |

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
