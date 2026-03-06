# ADR-002: Strangler Fig Pattern for Migration

## Status

Accepted

## Context

VBGone migrates VB.NET business logic to C#. The migration must be incremental — replacing one class at a time — without requiring a big-bang rewrite or breaking the legacy system while migration is in progress.

## Decision

Use the **Strangler Fig pattern**, with a C# interface as the seam between legacy and modern code.

## Rationale

- **Incremental migration** — each class is migrated independently. The legacy VB.NET system continues running in production while C# replacements are built alongside it.
- **Interface as contract** — the generated C# interface defines the exact method signatures, parameter types, and return types. Both the legacy VB.NET code and the new C# implementation satisfy the same contract.
- **Test-first verification** — the NUnit test suite is written against the interface, not the implementation. Tests are valid regardless of who implements the class or how. When all tests pass, the behaviour is correct.
- **Safe cutover** — the legacy implementation is only retired once the C# replacement passes all tests and has been reviewed via PR. There is no flag day.
- **Confidence builds incrementally** — the suggested migration order starts with the simplest, most self-contained classes. Each successful migration builds confidence and test coverage before tackling complex, high-dependency classes.

## Consequences

- Every migration produces an interface file (`I<ClassName>.cs`) as the first artefact.
- Tests reference the interface type, not the concrete class (except for instantiation in `[SetUp]`).
- The VBGone wizard enforces this order: analyse, interface, tests, stub, implement, PR.
