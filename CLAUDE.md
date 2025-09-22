# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET Standard 2.0 library called `Crews.Extensions.Primitives` that provides extension methods for primitive types, particularly string utilities. The project is published as a NuGet package.

## Project Structure

- `Crews.Extensions.Primitives/` - Main library project targeting .NET Standard 2.0
- `Crews.Extensions.Primitives.Tests/` - xUnit test project targeting .NET 9.0
- `Crews.Extensions.Primitives.sln` - Visual Studio solution file

## Build and Test Commands

**Build the library:**
```bash
dotnet build Crews.Extensions.Primitives --configuration Release
```

**Run tests:**
```bash
dotnet test Crews.Extensions.Primitives.Tests --configuration Release
```

**Build entire solution:**
```bash
dotnet build --configuration Release
```

**Pack for NuGet (with version):**
```bash
dotnet pack Crews.Extensions.Primitives --configuration Release /p:Version=1.0.0 --no-build --output .
```

## Code Architecture

The library follows a simple extension method pattern:
- All extension methods are in the `Crews.Extensions.Primitives` namespace
- `StringExtensions` class contains string manipulation utilities including:
  - `TrimStart(string)` / `TrimEnd(string)` - Remove specific strings from start/end
  - `Base64Encode(Encoding)` - Base64 encoding with configurable encoding
  - `ToPascalCase(char[])` - Convert to PascalCase with custom delimiters
  - `Split(string, StringSplitOptions)` - Split by string delimiter

## Testing Framework

Uses xUnit for testing with:
- Theory/InlineData for parameterized tests
- Comprehensive test coverage for all extension methods
- Tests follow naming pattern: `MethodName_Scenario`

## CI/CD

- **CI Pipeline**: Runs on PRs to master, builds and tests with .NET 9
- **Release Pipeline**: Triggered on git tags, publishes to NuGet
- Both pipelines use Ubuntu runners and .NET 9.0.x

## Development Notes

- Library targets .NET Standard 2.0 for broad compatibility
- Tests use .NET 9.0 and nullable reference types enabled
- Package metadata includes GPL-3.0-or-later license
- XML documentation is generated for all public APIs