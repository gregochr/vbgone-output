# VBGone Output

Generated C# code from [VBGone](https://vbgone.online) — AI-assisted migration from legacy VB.NET to modern, tested C#.

## What This Repo Is

This is the **output repository** for VBGone. Every migration produces three files — a C# interface, an NUnit test suite, and a stub or full implementation — committed to a feature branch via Pull Request. The quality pipeline runs automatically on every PR.

VBGone does not push directly to `main`. Every migration lands as a PR, reviewed by a human, validated by CI, and merged only when green.

## Repository Structure

```
vbgone-output/
├── generated/
│   ├── ArithmeticOperations/
│   │   ├── ArithmeticOperations.sln
│   │   ├── ArithmeticOperations/
│   │   │   ├── ArithmeticOperations.csproj
│   │   │   ├── IArithmeticOperations.cs
│   │   │   └── ArithmeticOperations.cs
│   │   └── ArithmeticOperations.Tests/
│   │       ├── ArithmeticOperations.Tests.csproj
│   │       └── ArithmeticOperationsTests.cs
│   └── <NextClass>/
│       └── ...
├── .github/workflows/
│   ├── ci.yml            ← build, test, coverage, CodeQL, CVE scan
│   └── mutation.yml      ← Stryker.NET nightly mutation testing
└── docs/decisions/
    ├── 001-nunit-over-xunit.md
    ├── 002-strangler-fig-pattern.md
    └── 003-stryker-nightly.md
```

## Quality Pipeline

Every PR triggers the full CI pipeline:

| Check | Tool | Purpose |
|---|---|---|
| Build | `dotnet build` | Compilation with warnings as errors |
| Test | `dotnet test` + NUnit | Behavioural correctness |
| Coverage | Coverlet + Codecov | Line and branch coverage reporting |
| Test Report | dorny/test-reporter | Test results visible directly on the PR |
| Security | CodeQL | Static analysis for security vulnerabilities |
| CVE Scan | `dotnet list package --vulnerable` | Known vulnerability detection in dependencies |

### Nightly Mutation Testing

[Stryker.NET](https://stryker-mutator.io/docs/stryker-net/introduction/) runs on a nightly schedule against `main`. It introduces deliberate mutations (flipping operators, removing statements, changing constants) and verifies the test suite catches them. This measures **test quality**, not just coverage percentage.

## How VBGone Works

1. **Upload** — a `.vb` source file or `.zip` archive
2. **Analysis** — Claude identifies classes, methods, dependencies, and migration order
3. **Interface** — a C# interface is generated, defining the contract
4. **Tests** — a comprehensive NUnit test suite is generated against the interface
5. **Red Build** — a stub implementation is created; all tests fail (expected)
6. **Implementation** — Claude generates a full implementation, or the developer implements manually
7. **Green Build** — tests pass
8. **PR** — interface, implementation, and tests are committed here via the GitHub API

## Target Framework

All projects target **.NET 10.0** (`net10.0`).

## Local Development

```bash
cd generated/ArithmeticOperations
dotnet test
```
