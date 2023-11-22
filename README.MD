![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/ConcreteEcho/FluentStructures/nuget.yml)
![GitHub issues](https://img.shields.io/github/issues/ConcreteEcho/FluentStructures)
![Nuget](https://img.shields.io/nuget/v/Fluent.Structures.Model)

# Wrappers for the Tekla API with a Fluent interface

A set of classes for convenient interaction with the Tekla API.

> At the moment, the library is intended only for Tekla 2022.

Classes from the following libraries are currently implemented:

- Tekla.Structures.Model — Beam, RebarGroup, Polygon, Plate;

# Motivation

The original Tekla API provides a small set of overloads for methods, moreover, these overloads contain non-recommended
classes (such as ArrayList). The construction of a complex object can take hundreds of lines.   
The purpose of this library is to simplify the creation of objects by providing a Fluent interface and implement more
reliable checks of the necessary attributes.

# How do i build this?

You must have installed .NET SDK 7.0. Then cd to the root directory and

```shell
dotnet build
```