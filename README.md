# GitHub Copilot workshop for an on-premises Azure DevOps C# team

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


Use the [setup checklist](SETUP-AND-SUPPORT.md) before the event. Do not upgrade a legacy application framework or install services/database changes merely to make a demonstration work.
