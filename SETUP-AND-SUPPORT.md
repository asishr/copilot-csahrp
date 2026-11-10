# Setup and Copilot support verification

**Documentation checked: November 10, 2026. Recheck before delivery.**

## Distinguish the capabilities

| Capability | Execution and repository boundary | Workshop position |
| --- | --- | --- |
| IDE completions/chat and bounded edits | Work against permitted local files in supported Visual Studio/VS Code. Copilot still connects to its service; local source hosting does not mean offline inference. | Primary workflow; no GitHub repository migration required. Validate IDE, account, network and policy. |
| Supervised IDE agent mode | Can edit files/run approved tools in the selected environment. The IDE can also launch remote/cloud sessions; verify execution location and permissions. | Optional local exercise only, not an unattended workflow. |
| GitHub-hosted/cloud coding agent | Delegated execution outside the local checkout, with separate environment, repository access and governance requirements. Launching from an IDE does not make it local. | Explain the distinction; not a demo focus or prerequisite. |
| IDE/local diff review | A request for feedback on selected local code/diff, followed by human verification. Dedicated review UI varies by IDE, plan and policy; ordinary chat can be the fallback. | Default review path. Does not post a native Azure DevOps PR review automatically. |
| Native Azure Repos Copilot PR review | Microsoft Learn currently labels this **Azure DevOps Services**, **public preview**, for Git repositories; TFVC is not supported by that documented feature. It has separate admin/billing prerequisites. | Do not extrapolate cloud documentation to on-premises Server. Exact Server verification is blocked. |

Azure DevOps Services and Azure DevOps Server are different products. A self-hosted build agent, an extension, an MCP integration, GitHub connectivity, or a local IDE review does not establish native on-premises Copilot PR-review support. An on-premises repository is also not a guarantee that code stays on premises when using AI services.

## Exact-version verification gate

**Result now: BLOCKED - exact Azure DevOps Server release/update/build is unknown.** The user confirmed it is unknown. No exact-version support claim or live native PR-review demo is authorized.

The first-party page checked below documents **Services**, not a Server release. That establishes the scope of the published feature, not a verified answer for an unidentified installation. Never relabel a Services preview as a Server feature.

Administrator checklist:

1. Record product name, full release/update/build from the installation's About information, edition, Git vs TFVC, authentication and relevant extensions. Do not include credentials.
2. Consult Microsoft Learn and release notes explicitly applicable to that release/update. A `view=` URL parameter or a successful page load alone is not evidence; read the actual applicability banner and prerequisites.
3. Find explicit native Copilot PR-review support for that build. If the documentation is Services-only or unclear, record **not established for this installation** and obtain Microsoft support confirmation if needed. Do not infer support from similarly named integrations.
4. If support is explicitly established, verify entitlement/billing, admin controls, preview availability, network/data policy and repository permissions. Test only in an approved disposable PR with no sensitive code.
5. Record whether a request produced an identifiable Copilot review comment on that Azure DevOps PR, plus any limitations. Have an administrator approve the result before changing workshop scope.
6. If unsupported, unavailable or still unknown, keep IDE/local diff review and normal human Azure DevOps review. Do not install an unapproved marketplace workaround or mirror source to GitHub.

Verification record:

| Field | Current value |
| --- | --- |
| Product / full release / update / build | Unknown - administrator required |
| Git or TFVC | Unknown |
| Applicable official URL and explicit applicability text | Services-only documentation found; no exact Server evidence yet |
| Exact-build native PR-review support | Blocked / not verified |
| Entitlement, network and administrator approval | Not checked |
| Sandbox PR / observed result / date | Not run |
| Administrator decision and reviewer | Pending |
| Workshop fallback | IDE-assisted local review, human Azure DevOps PR review |

## First-party sources

1. [GitHub: Copilot in IDEs](https://docs.github.com/en/copilot/concepts/copilot-surfaces/copilot-in-ides) - distinguishes IDE assistance, agent mode and cloud sessions; available features vary by IDE.
2. [GitHub: Copilot on GitHub.com and GitHub Mobile](https://docs.github.com/en/copilot/concepts/copilot-surfaces/copilot-on-github) - describes cloud execution environments and delegated work.
3. [GitHub: Copilot code review](https://docs.github.com/en/copilot/concepts/agent-capabilities/agent-powered-workflows-and-operations/code-review) - lists review surfaces, including IDEs and Azure DevOps preview; a surface listing is not exact Server-version support.
4. [Microsoft Learn: Get started with Copilot code review for pull requests](https://learn.microsoft.com/en-us/azure/devops/repos/git/copilot-code-reviews?view=azure-devops) - applicability banner: **Azure DevOps Services**; preview; Git, not TFVC; separate administrator and billing requirements.

These are capability references, not authorization to enable a feature or a replacement for version-specific verification. Dynamic documentation can change before delivery.
