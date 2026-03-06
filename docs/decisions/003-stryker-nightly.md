# ADR-003: Stryker.NET Nightly Rather Than Per-PR

## Status

Accepted

## Context

Stryker.NET mutation testing validates that the test suite catches real bugs — not just that it covers lines. However, mutation testing is computationally expensive. Running Stryker on every PR would add significant time to the CI feedback loop.

## Decision

Run Stryker.NET on a **nightly schedule** against `main`, not on every Pull Request.

## Rationale

- **Speed** — mutation testing can take minutes to tens of minutes depending on the number of mutants. PR CI should complete in under two minutes for fast feedback.
- **Coverage is checked per-PR** — Coverlet reports line and branch coverage on every PR via Codecov. This catches obvious gaps immediately.
- **Mutation testing catches subtle gaps** — Stryker finds tests that cover a line but don't actually assert the correct behaviour (e.g., a test that calls `Divide` but never checks the result). These subtle issues rarely need instant feedback — overnight is sufficient.
- **Break threshold** — the nightly workflow uses `--break-at 60`, failing the run if the mutation score drops below 60%. This ensures test quality does not silently degrade.
- **Manual trigger** — the workflow also supports `workflow_dispatch` for on-demand runs when investigating specific quality concerns.

## Consequences

- The nightly workflow produces HTML and Markdown reports, uploaded as GitHub Actions artefacts.
- A mutation score below 60% fails the nightly run, signalling that test quality needs attention.
- Developers can run `dotnet stryker` locally for immediate feedback during development.
