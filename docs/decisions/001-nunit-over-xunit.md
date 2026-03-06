# ADR-001: NUnit over xUnit

## Status

Accepted

## Context

VBGone generates C# test suites for migrated VB.NET code. We need a test framework that Claude can generate consistently and that developers migrating from VB.NET will find familiar.

## Decision

Use **NUnit 4** as the test framework for all generated test suites.

## Rationale

- **Familiarity** — most VB.NET codebases in enterprise environments already use NUnit. Developers migrating from VB.NET are more likely to recognise `[TestFixture]`, `[Test]`, and `Assert.That` than xUnit's constructor injection and `[Fact]` attributes.
- **Constraint-based assertions** — NUnit's `Assert.That(actual, Is.EqualTo(expected))` syntax reads naturally and generates well from an LLM. The constraint model is expressive enough for edge cases (tolerances, collection assertions, exception testing) without requiring extra libraries.
- **Setup/teardown** — `[SetUp]` and `[TearDown]` are explicit and visible. xUnit's constructor/dispose pattern is elegant but less obvious in generated code that needs to be readable at a glance.
- **Parameterised tests** — `[TestCase]` is simpler than xUnit's `[InlineData]` + `[Theory]` for the straightforward value-driven tests VBGone generates.

## Consequences

- All generated test projects depend on `NUnit` and `NUnit3TestAdapter`.
- Coverlet is used for coverage (framework-agnostic).
- Stryker.NET supports NUnit natively.
