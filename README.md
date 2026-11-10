# GitHub Copilot workshop for an on-premises Azure DevOps C# team

**Status: proposed for sponsor review, not a confirmed delivery booking.**

Two three-hour sessions focus on advanced prompting, code quality, and incremental modernization of C#, Razor Pages, Entity Framework (EF), SQL, and Windows services. Work stays in an approved local checkout and follows the team's existing Azure DevOps workflow. Moving repositories to GitHub is not a prerequisite.

## Scheduling correction

- **10:00-12:00 on November 10 and November 12, 2026 totals four hours, not six.** It is two two-hour slots.
- **The November 10 slot has elapsed in the supplied scheduling brief.** Do not reuse it as a future invitation. This is a brief-provided status, not a timezone-based determination; the timezone is still unconfirmed.
- Replacement dates and timezone are **TBD**. Reserve **two new 180-minute slots**. Extending only the remaining two-hour slot by one hour does not recover the elapsed session.
- The agendas below use relative time, not invented calendar bookings. Six hours means **360 scheduled minutes**, including two ten-minute breaks: 340 facilitated minutes. If six hours of instruction excluding breaks is required, book 380 minutes.
- If only four hours can be secured, obtain approval for a reduced-scope workshop; do not describe it as this six-hour package.

## Outcomes

Learners will:

1. Build evidence-based prompts with explicit context, invariants, scope, output shape, and verification.
2. Characterize legacy C# behavior before making a small, reversible change.
3. Review Razor Pages handlers and binding, EF translation and tracking, SQL semantics and plans, and service lifecycle behavior.
4. Validate suggestions with deterministic checks and distinguish verified results from hypotheses.
5. Prepare a human-reviewed Azure DevOps change without relying on a hosted coding agent.

## Workshop pack

| Resource | Purpose |
| --- | --- |
| [Instructor agendas](INSTRUCTOR.md) | Two 180-minute runbooks, facilitation cues, evidence and fallback paths |
| [Sponsor review](SPONSOR-REVIEW.md) | Proposed demos, sample approval questions, scope and delivery gates |
| [Reusable prompts](PROMPTS.md) | Copyable, IDE-neutral prompts for each technology and review stage |
| [Learner lab](LEARNER-LAB.md) | Runnable neutral C# exercise plus cross-stack review/refactoring exercises |
| [Setup and support verification](SETUP-AND-SUPPORT.md) | On-premises verification gate, capability distinctions and first-party sources |
| [Neutral practice project](practice/NeutralPractice.csproj) | Dependency-free regression harness; no customer business model |

## Delivery boundaries

- **IDE Copilot is the focus:** explanation, context selection, bounded edits, tests, and local review. Optional IDE agent mode is supervised and subject to tool permissions.
- **GitHub-hosted/cloud coding agents are not the demo focus.** An agent launched from an IDE can still execute in the cloud; check execution location rather than the UI label.
- IDE use does not mean an offline or on-premises AI model. Apply organizational policies before sending code or context to Copilot.
- Native Copilot review on an Azure DevOps pull request is a separate capability from asking Copilot to review a local diff. **Exact on-premises Server version is unknown; verification remains blocked.** See the [support gate](SETUP-AND-SUPPORT.md#exact-version-verification-gate).
- **Nix/NextCall details are unconfirmed.** No domain rules, architecture, data model, workflow, defect, or integration is asserted here. Every customer demo remains a proposal until its owner approves the sample and expected behavior.
- The neutral practice fixture is synthetic. It neither models Nix/NextCall nor justifies changing production behavior. Cross-stack excerpts are review exercises, not a deployable application.

## Before delivery

The sponsor must confirm replacement dates/timezone, audience IDE/runtime mix, exact Azure DevOps Server release/update, repository type (Git or TFVC), approved code/data, build access, and demo acceptance criteria. The user has confirmed these are currently unknown, so the pack uses relative agendas and neutral practice only.

Use the [setup checklist](SETUP-AND-SUPPORT.md) before the event. Do not upgrade a legacy application framework or install services/database changes merely to make a demonstration work.
