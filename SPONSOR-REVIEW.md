# Demo topics for sponsor review

**All customer demos are proposed, not approved.** Nix/NextCall names do not establish application behavior. The neutral examples are synthetic teaching aids only.

## Proposed demonstrations

| ID / session | Topic and proposed flow | Required sample confirmation | Evidence / decision |
| --- | --- | --- | --- |
| D1 / 1 | C# legacy logic: explain, characterize, refactor one method, challenge the diff | Approved method and callers, runtime, edge cases, exception/output contract, existing tests | Passing characterization checks, bounded diff, rejected behavior drift. Neutral formatter available. |
| D2 / 1 | Razor Pages quality: follow view binding into handler, propose focused validation and tests | Actual page and PageModel, framework version, input/response contract, authorization ownership, test host | Handler/view findings with references and test plan; executable checks only if a runnable page is approved. Neutral excerpt available. |
| D3 / 2 | EF and SQL: find early materialization, compare a server-side filter/projection, inspect SQL | EF6 or EF Core version, provider, schema, SQL Server version/compatibility, representative sanitized data and expected results | Result-equivalence evidence; emitted SQL and plan/logical-read measurements only with an approved database. Neutral query available. |
| D4 / 2 | Windows service reliability: isolate logic, propose explicit cancellation and error handling | ServiceBase/worker implementation, target framework, install/stop model, schedule, retry/overlap/side-effect contracts, disposable test host | Failure/stop matrix and a small patch; SCM verification only with approved host. Neutral loop excerpt available. |
| D5 / 2 | Code quality and Azure DevOps handoff: IDE diff review, validate findings, prepare PR notes | Exact Server update, Git vs TFVC, branch/build/reviewer policies, IDE/entitlements | Local diff review and human-review package. Native Copilot PR review is blocked pending exact-version verification. |

No hosted GitHub coding-agent issue assignment, autonomous cloud PR creation, or GitHub repository migration is required. Any optional local IDE agent use must have a bounded scope and approved tools.

## Decisions required before invitations and rehearsal

| Decision | Current status | Owner / required action |
| --- | --- | --- |
| Replacement dates, timezone, two 180-minute bookings | **TBD** | Sponsor: Nov 10/12 10:00-12:00 was four hours total; the Nov 10 slot is elapsed per brief. Confirm new bookings. |
| Audience and skill level | C# team; IDE/runtime mix unknown | Team lead: confirm Visual Studio/VS Code versions, .NET Framework/.NET versions, EF6/EF Core, Razor Pages vs other Razor technologies. |
| Azure DevOps installation | On-premises; exact version/update unknown | Server administrator: provide About/build number, repository type and applicable support evidence using the [support gate](SETUP-AND-SUPPORT.md#exact-version-verification-gate). |
| Copilot entitlement, network, code-sharing policy | Unconfirmed | IT/security: authorize Copilot use and permitted context before any upload. No production data or secrets. |
| Nix/NextCall samples and behavior | **Not confirmed** | Application owners: supply sanitized paths, expected behavior, test results and disclosure permission. Do not infer rules from application names. |
| Data and Windows service test environments | Unconfirmed | Owners: provide disposable sandboxes or explicitly approve source-only exercises. Never use production as a fallback. |
| Demo acceptance | **Pending sponsor approval** | Sponsor: approve each topic and fixture, or retain the neutral exercise with its stated limits. |

## Sample intake template

Complete once per approved customer demo:

```text
Demo ID / sample owner:
Approved checkout and exact files:
Allowed data/context to send to Copilot:
Application/framework/EF/provider/SQL versions:
Observed behavior and source of truth:
Invariants (including nulls, errors, ordering, side effects):
Known defect or desired change, if any:
Baseline build/test command and result:
Allowed edits / explicit non-goals:
Expected measurable outcome:
Sandbox, reset procedure and reviewer:
Approval / date:
```

Source comments and generated explanations alone are not authoritative business requirements. Confirm disagreements with the owner before changing behavior.

## Approval response

For each D1-D5, record **approve topic / revise topic / defer**, approved fixture, owner and required proof. Topic approval alone does not confirm customer behavior. Keep the fixture neutral until sample approval is explicit.

Suggested exclusions: framework-wide upgrades, database migrations, service installation, new business features, unverified performance promises, and integrations unavailable on the exact Server release.
