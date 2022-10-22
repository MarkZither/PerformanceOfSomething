# PerformanceOfSomething

## Create the Solution and Projects

``` c#
dotnet new sln
dotnet new classlib -f net7.0 -o src/PerformanceOfSomething.Lib
dotnet new xunit -f net7.0 -o tests/PerformanceOfSomething.Tests
```

## Add Analyser packages

Add common packages to help improve code quality and avoid common pitfalls.
* [learn.microsoft.com](https://learn.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2022)
* [awesome-analyzers](https://github.com/Cybermaxs/awesome-analyzers)

### Lib

``` console
dotnet add package Microsoft.CodeAnalysis.NetAnalyzers --version 6.0.0
dotnet add package Microsoft.CodeAnalysis.PublicApiAnalyzers --version 3.3.4-beta1.22464.1
```

### Tests

``` console
dotnet add package xunit.analyzers --version 1.0.0
dotnet add package Microsoft.CodeAnalysis.NetAnalyzers --version 6.0.0
```

Turn on warnings as errors in the csproj

``` xml
<TreatWarningsAsErrors>True</TreatWarningsAsErrors>
```

## Move Package versions to props
As a solution grows it can be useful to manage package versions centrally.

## Add common packages globally
Analyzers can be relevant across all projects so can be added  in a props file.

## Add .editorconfig
Using .editorconfig helps bring consistency to coding style.

# Configure External Tools

## Sonarqube
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=MarkZither_PerformanceOfSomething&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=MarkZither_PerformanceOfSomething)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=MarkZither_PerformanceOfSomething&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=MarkZither_PerformanceOfSomething)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=MarkZither_PerformanceOfSomething&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=MarkZither_PerformanceOfSomething)

## GitHub Actions
[![continuous](https://github.com/MarkZither/PerformanceOfSomething/actions/workflows/continuous.yml/badge.svg)](https://github.com/MarkZither/PerformanceOfSomething/actions/workflows/continuous.yml)