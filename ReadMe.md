<div align="center">
 <img src="SmartSelector.png" weight="250px" height="250px" />
 <h2>SmartSelector</h2>
 
 [![NuGet](https://img.shields.io/nuget/v/Kurnakov.SmartSelector.svg)](https://www.nuget.org/packages/Kurnakov.SmartSelector)
 [![NuGet download](https://img.shields.io/nuget/dt/Kurnakov.SmartSelector.svg)](https://www.nuget.org/packages/Kurnakov.SmartSelector) 
 ![Visitors](https://api.visitorbadge.io/api/visitors?path=https%3A%2F%2Fgithub.com%kurnakovv%SmartSelector&countColor=%23263759&style=flat)
  [![MIT License](https://img.shields.io/github/license/kurnakovv/SmartSelector?color=%230b0&style=flat)](https://github.com/kurnakovv/SmartSelector/blob/main/LICENSE)
 [![Build/Test](https://github.com/kurnakovv/SmartSelector/actions/workflows/build-test.yml/badge.svg)](https://github.com/kurnakovv/SmartSelector/actions/workflows/build-test.yml)

</div>

# Description
<b>SmartSelector</b> is open source library that allows you to get the specific object fields without a "Select" method.

# Idea
Code taken from https://stackoverflow.com/questions/54549506/select-only-specific-fields-with-linq-ef-core

# How is it work

```cs
public class MyTestObject
{
    public string FirstProperty { get; set; }
    public string SecondProperty { get; set; }
    public string ThirdProperty { get; set; }
}

IQueryable<MyTestObject> myTestObjects = new List<MyTestObject>() 
{
    new MyTestObject { FirstProperty = "a1", SecondProperty = "a2", ThirdProperty = "a3", },
    new MyTestObject { FirstProperty = "b1", SecondProperty = "b2", ThirdProperty = "b3", },
    new MyTestObject { FirstProperty = "c1", SecondProperty = "c2", ThirdProperty = "c3", },
}.AsQueryable();
IQueryable<MyTestObject> result = myTestObjects.SelectFields(new List<string>() { "SecondProperty", "ThirdProperty" });

// Output
FirstProperty: null (default), SecondProperty: 'a2', ThirdProperty: 'a3'
FirstProperty: null (default), SecondProperty: 'b2', ThirdProperty: 'b3'
FirstProperty: null (default), SecondProperty: 'c2', ThirdProperty: 'c3'
```

# Give a star ⭐
I hope this library is useful for you, if so please give a star for this repository, thank you :)
