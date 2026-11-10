# Reusable IDE Copilot prompts

Use in the team's approved IDE. Attach/select the relevant files using that IDE's supported controls; do not assume a particular slash command or participant exists. Replace placeholders before sending. Never attach restricted source, secrets or production data.

## P0 - Context and guardrails

```text
Work only with these approved files: <paths>.
Stack: <C# / framework / Razor Pages / EF6 or EF Core + provider /
SQL Server version and compatibility / service host versions>.
Goal: <one measurable outcome>.
Observed behavior and evidence: <tests, caller contracts, sample outputs>.
Preserve: <inputs, outputs, nulls, whitespace, ordering, errors, side effects>.
Allowed edits: <scope>. Non-goals: <scope>.
Do not invent Nix/NextCall or other business rules. Treat missing facts as
questions. Separate source-backed observations from assumptions.
First return a brief plan, affected files, risks, and proposed checks.
Do not edit or execute commands until I approve that plan.
```

## P1 - Understand a legacy slice

```text
Using the selected method, callers and tests, explain the observable contract.
Return a table: behavior | source reference | supporting test | uncertainty.
Trace input through outputs, database calls and side effects.
List unknowns that block a safe refactor. Do not infer business intent from
names or comments alone. Do not change code.
```

## P2 - Characterization and adversarial examples

```text
Propose characterization tests before refactoring <method>.
Derive expected results from approved behavior evidence, not from a guessed
new design. Cover normal, empty, null, boundary, duplicate/order and failure
cases where applicable. Name behavior that is currently unspecified.
Use <existing test framework or neutral console harness>; no new packages.
Return test name | input | exact expected result | evidence.
Suggest one mutation that should fail a check. Do not weaken existing checks.
```

## P3 - Small behavior-preserving C# modernization

```text
Approved plan: <plan>. Refactor only <method/file> to improve <specific issue>.
Keep signatures, target framework, outputs and exception behavior unchanged.
Use APIs available in the existing runtime. No framework/package upgrade,
new business rules or wholesale rewrite.
For the neutral formatter preserve literal CRLF, null elements as empty
values, input whitespace, 1-based numbering and "(empty)" for an empty array.
Keep null-array ArgumentNullException and parameter name unchanged.
Show the bounded change and list validation commands. Run only approved
commands; report exact results and anything not run. No speed claim without
a representative benchmark and baseline.
```

## P4 - Razor Pages review and bounded fix

```text
Review this approved .cshtml and PageModel together.
Trace model binding, validation, handler selection and response paths.
Check over-posting, output encoding, anti-forgery expectations and
authorization boundaries against the actual configuration.
Do not invent roles, permissions, field limits or successful-save behavior.
Return issue | evidence/location | observable risk | proposed focused check.
Distinguish confirmed defects from configuration-dependent questions.
Then propose one minimal change using existing patterns, preserving the
confirmed request/response contract. No MVC/Blazor conversion.
```

## P5 - Entity Framework query modernization

```text
Versions/provider: <confirmed values>. Approved query and mapping: <files>.
Identify materialization boundaries, SQL-translatable operations, tracking,
N+1 risk and cancellation points. Separate EF6 from EF Core API assumptions.
Propose filter/projection changes without altering result membership,
ordering, null semantics, transactions or required tracking behavior.
Do not blindly add AsNoTracking or async. Request missing callers/schema.
Return before/after query, semantic risks, expected emitted SQL to verify,
and provider-backed equivalence checks. Do not claim tests ran.
```

## P6 - SQL correctness before performance

```text
Use the approved schema, query, parameters and representative test data.
SQL Server version/compatibility: <confirmed>.
First state result semantics, including NULL, duplicates, collation, ties,
ordering and parameter types. Identify missing schema/index facts.
Propose a parameterized query change and equivalence test cases.
Provide a read-only measurement plan using emitted SQL, execution plan,
logical reads and timings under comparable conditions.
No DDL, production execution, new indexes or claimed speedup without approval
and measured evidence. Keep unexecuted SQL explicitly labeled unverified.
```

## P7 - Windows service reliability

```text
Approved host/runtime: <ServiceBase or worker + versions>.
Observed lifecycle/scheduling/retry/overlap/side-effect contract: <evidence>.
Trace start, work, stop, cancellation, disposal and failures.
Propose the smallest testable seam; do not migrate the host or invent retry,
idempotency, delivery guarantees or business recovery rules.
Never use async void, fire-and-forget work, broad swallowed exceptions or a
catch that turns failure into success.
Return patch plan and checks for stop during work, failure visibility,
resource cleanup and overlap. Treat expected cancellation separately from
unexpected cancellation/failure; use the repository's error policy.
Flag SCM behavior that cannot be verified without a real test adapter.
```

## P8 - Local diff review (not native Azure DevOps PR review)

```text
Review only this approved local diff plus necessary surrounding context.
Return a table: finding | file/line | evidence | impact | focused validation.
Prioritize high-confidence correctness, maintainability and regression risks.
Separate confirmed issues from questions. Do not imply you posted comments
to Azure DevOps or performed a native PR review.
Do not approve or edit automatically. For each accepted fix, identify the
smallest regression check; do not change unrelated code.
```

## P9 - Evidence-based handoff

```text
Draft a human-reviewed Azure DevOps change description from this diff and
actual command output.
Sections: intent; confirmed preserved behavior; changed behavior (approval
required); validation commands/results; not-run checks and why; risk and
rollback; reviewer questions.
Do not invent passing tests, benchmark results, customer acceptance or
on-premises Copilot PR-review support. Call out unknown Server version.
Use existing branch/reviewer/build policy; do not request bypasses.
```

## Iterating when the answer is wrong

```text
This proposal violates <specific invariant>. Evidence: <source/test/output>.
Revise only <scope>, preserving all other approved constraints.
Explain the correction briefly and give the smallest check that distinguishes
the incorrect and corrected versions. Stop if requirements still conflict.
```
