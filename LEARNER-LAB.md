# Learner lab: constrain, modernize, verify

Work in pairs. Use the [prompt library](PROMPTS.md) and the [instructor timing](INSTRUCTOR.md). The exercises occupy 35 + 35 minutes in session 1 and 40 + 40 + 20 minutes in session 2; discussion/demo blocks supply additional guidance.

**This is a neutral practice option, not a Nix/NextCall specification.** Only lab A ships as an executable project. Labs B-D provide synthetic source excerpts for hands-on review, rewriting and test design. They are not a connected application, runnable EF integration, or installed Windows service. With approved customer fixtures, replace excerpts and run the actual checks; otherwise label those outcomes **source-reviewed / proposed / not integration-tested**.

Keep a record in your normal worksheet or scratch editor: original prompt, revised prompt, source facts, assumptions, proposed change, actual checks/output, rejected suggestion and unanswered questions.

## Setup and baseline

Prerequisites: approved Copilot IDE, .NET 10 SDK for the neutral fixture, and a disposable workspace. No packages, database or service installation are required for lab A.

From the workshop directory in PowerShell, copy the fixture to a new location. Stop if the destination already exists; choose a different name rather than overwriting work.

```powershell
$source = Join-Path (Get-Location) 'practice'
$destination = Join-Path $env:TEMP 'copilot-neutral-practice'
if (Test-Path -LiteralPath $destination) { throw 'Choose a new disposable destination.' }
Copy-Item -LiteralPath $source -Destination $destination -Recurse
Set-Location -LiteralPath $destination
dotnet --list-sdks
dotnet run --project .\NeutralPractice.csproj
if ($LASTEXITCODE -ne 0) { throw 'Baseline failed; stop and diagnose before editing.' }
```

Expected baseline: `PASS: 8 characterization checks.` The program throws and exits unsuccessfully on a failed check. It uses ordinal comparisons and literal CRLF, so output must not change with OS newline conventions. It has no test-runner dependency; **use `dotnet run`, not `dotnet test`, to execute its checks**.

The fixture's .NET 10 target is not a recommendation to upgrade your application. If that SDK is unavailable, use an approved compatible customer fixture or pair with an equipped learner; record the limitation.

## Lab A - C# characterization and a bounded refactor (35 minutes)

1. **Inspect (5 min):** Attach/select [LegacyFormatter.cs](practice/LegacyFormatter.cs) and [Program.cs](practice/Program.cs). Use P0-P1. Identify contract facts and gaps.
2. **Characterize (10 min):** Use P2 to add at least two deterministic cases with literal expected values. Do not compute expected output with the same algorithm being tested. Suggested edges: ten values (numbering past 9), embedded CRLF, or a null element between two non-null elements. Preserve all original checks.
3. **Refactor (10 min):** Use P3 to replace repeated concatenation with a suitable small implementation. Do not change the public signature, whitespace, delimiter, numbering, empty-array behavior or null-array exception/parameter name.
4. **Verify (5 min):** Run `dotnet run --project .\NeutralPractice.csproj`. Introduce one temporary deliberate mutation, such as changing the delimiter; confirm a failed exit, then undo **only your mutation** and rerun successfully.
5. **Review (5 min):** Inspect the diff. Explain one rejected suggestion and whether improved readability is evidenced. Do not call it faster without measurement.

### Neutral contract

| Input | Required observable result |
| --- | --- |
| Empty array | Exactly `(empty)` |
| One `"alpha"` value | Exactly `1: alpha\r\n` |
| Null element | Empty value after the numbered prefix, not a skipped row |
| Whitespace / embedded newline | Preserved verbatim |
| Several values | Input order, 1-based numbering and CRLF after every row |
| Null array | `ArgumentNullException` with parameter name `values` |

These are synthetic fixture rules. Do not generalize them to real business logic.

**Acceptance:** baseline and added checks pass; the deliberate mutation fails; output/error contract is preserved; only relevant files changed; no unsupported performance claim.

## Lab B - Razor Pages quality review and patch proposal (35 minutes)

Neutral excerpt, intentionally incomplete: `Input` is bound, the page posts a text value, and `StoreAsync` is an unspecified persistence seam. No validation, authorization, length limit, save-success contract, DI configuration or anti-forgery configuration is established by this excerpt.

```csharp
[BindProperty]
public EntryInput Input { get; set; } = new();

public sealed class EntryInput
{
    public string? Text { get; set; }
}

public async Task<IActionResult> OnPostAsync()
{
    await StoreAsync(Input.Text);
    return RedirectToPage();
}
```

```html
<form method="post">
    <input asp-for="Input.Text" />
    <button type="submit">Save</button>
</form>
```

1. **Trace (5 min):** Use P4 with both excerpts. Mark missing base class/imports and configuration as missing evidence, not defects proven by omission.
2. **Review (10 min):** Produce a table of model binding, ModelState, encoding, anti-forgery and authorization questions. Do not invent roles or validation attributes.
3. **Propose (10 min):** For this exercise only, assume a synthetic requirement: **if ModelState is invalid, return Page without calling StoreAsync**. Propose that minimal handler guard and validation feedback markup. Do not claim this is a confirmed customer requirement.
4. **Check design (10 min):** Specify checks for invalid ModelState/no store call, valid input/existing redirect, and validation message rendering. Include anti-forgery integration and authorization checks only once actual configuration/requirements are supplied.

**Acceptance:** a bounded patch proposal and explicit test matrix; no invented field limit or customer access rule. Without a real page/test host, mark execution **not run** rather than pasting imaginary passing tests.

## Lab C - EF/SQL equivalence before optimization (40 minutes)

Synthetic query excerpt: a context has `Messages` with non-null integer `Id` and nullable string `Text`. Assume **for this exercise only** that `Id` is unique, `minimumId` is an integer parameter, the caller reads the returned entities without updating them, and ascending `Id` order is required. This is not a customer schema. EF version/provider and database compatibility remain inputs to confirm.

```csharp
var rows = context.Messages.ToList();
var result = rows
    .Where(row => row.Id >= minimumId)
    .OrderBy(row => row.Id)
    .Take(20)
    .ToList();
```

1. **Inspect (5 min):** Use P5 to locate the premature materialization boundary. List missing package/provider/mapping facts.
2. **Rewrite (10 min):** Move the filter, order and limit before materialization in a proposed patch. Preserve membership/order and entity shape. Discuss tracking, but do not assume `AsNoTracking` is always safe for a real caller. Do not change to a DTO without approval.
3. **SQL (10 min):** Use P6 to propose a parameterized SQL Server equivalent with explicit columns and stable order, not `SELECT *`. State schema/parameter assumptions. No production execution or DDL.
4. **Equivalence matrix (10 min):** Cover zero matches, fewer/exactly/more than 20 matches, the boundary `Id`, nullable text, and unsorted input. Expected output must be ascending and at most 20 rows. Duplicated IDs violate this fixture's stated assumption; flag rather than silently choose ties.
5. **Evidence (5 min):** If an approved real provider/database is available, compare actual result rows and emitted SQL, then record plan/reads/timing under comparable conditions. Otherwise save the patch, SQL and test plan as **unexecuted proposals**.

**Acceptance:** semantic equivalence reasoning with cases and explicit provider assumptions. No claim that LINQ-to-Objects or EF's in-memory provider proves SQL Server translation/performance. Async/cancellation changes need confirmed supported APIs and callers.

## Lab D - Windows service lifecycle modernization (40 minutes)

Synthetic excerpt only; it is **not** a working service host. `ProcessOnce` is an unspecified operation. Start/stop adapters, logging, scheduling and side effects are not supplied.

```csharp
public void Run(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        ProcessOnce();
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}
```

For this exercise only, propose an awaitable loop with a cancellation-aware delay after each completed iteration, no overlapping calls, and no swallowed unexpected exceptions. Do not infer business retry/recovery semantics.

1. **Inspect (5 min):** Use P7. Identify that cancellation is observed between iterations but sleep is not interruptible, and that stopping during `ProcessOnce` depends on that missing operation.
2. **Plan (10 min):** Specify an asynchronous operation accepting cancellation, an awaitable delay, and how the host observes completion/failure. List what must change at callers. No `async void` or fire-and-forget task.
3. **Patch proposal (10 min):** Draft a narrowly scoped loop. Distinguish expected shutdown cancellation from unrelated cancellation/failure using the actual host's policy; do not add a blanket catch or automatic retry.
4. **Check design (10 min):** Cover stop during delay, stop during work, work failure, no overlap, resource disposal and repeated start/stop if supported. Propose fake operation/delay seams to avoid a five-second real wait in each unit check.
5. **Host boundary (5 min):** List SCM adapter/startup/account/permissions/stop-timeout checks requiring an actual disposable Windows service. Do not install a service or migrate ServiceBase to BackgroundService during this lab.

**Acceptance:** patch/test design with visible failure behavior, an identified host boundary and no invented delivery guarantees. Without the host and operation, mark lifecycle execution **not run**.

## Peer review and Azure DevOps handoff (20 minutes)

Use P8-P9 on your actual local diff or proposed patch. For Git repositories, inspect `git diff --check` and `git diff` in the disposable workspace if initialized; do not run reset/checkout over someone else's changes. For TFVC, use the team's workspace/shelveset review equivalents.

Submit:

- One vague prompt and its improved, constrained version.
- C# baseline, added checks, deliberate failure and final successful result.
- Razor patch/test matrix, EF query/SQL equivalence matrix, and service patch/lifecycle matrix.
- Clear labels: **executed**, **source-reviewed**, **proposed**, **not run**.
- A human-review description: intent, preserved/changed behavior, validation, risks, rollback and open questions.
- Explicit note that native on-premises Azure DevOps Copilot PR review remains unverified until the exact Server release/update is supplied.

### Completion rubric

| Criterion | Complete when |
| --- | --- |
| Prompt quality | Includes actual context, goal, invariants, bounded scope and measurable checks |
| C# behavior | Original + at least two new checks pass; a deliberate mutation demonstrably fails |
| Cross-stack reasoning | Each stack has a specific change/test proposal, assumptions and truthful execution status |
| Quality judgment | At least one unsupported or incorrect AI suggestion is rejected with evidence |
| Review readiness | Human reviewer can distinguish verified changes from unexecuted proposals |

Do not award integration/performance/SCM completion for a source-only exercise. Those outcomes need approved runnable samples and real execution.
