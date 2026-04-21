# Documentation Index

Central index for the toolkit documentation set.

## Role

Use this file to decide which document to read next. It is intentionally an index, not a duplicate of the full command reference or workflow guide.

## Read This When

Read this file when you are:

- new to the repository and need the shortest reading path
- looking for the right module reference
- deciding whether a question belongs in README, AGENTS, the workflow guide, or a module doc

## Read This After

Start with these first:

1. [../README.md](../README.md) for environment setup, startup sequence, and repository overview
2. [../AGENTS.md](../AGENTS.md) for the AI-agent execution contract

## Documentation Roles

| Document | Role | Read It When |
| --- | --- | --- |
| [../README.md](../README.md) | Entry point | You need setup, module overview, startup sequence, or environment checklist |
| [../AGENTS.md](../AGENTS.md) | Agent contract | You need execution rules, command discipline, and workflow selection guidance |
| [llm-guide.md](llm-guide.md) | Detailed workflow guide | You need full end-to-end examples, patching patterns, or advanced AI workflows |
| [esp-translation.md](esp-translation.md) | ESP translation workflow | You need to translate player-facing plugin text while staying consistent with vanilla terminology |
| [human-name-translation.md](human-name-translation.md) | Human-name translation guide | You are translating NPC names, surnames, titles, epithets, or historical figures |
| [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md) | Dictionary guide | You need bilingual Skyrim terms for direct lookup or retrieval-friendly export |
| [knowledge_base/README.md](knowledge_base/README.md) | Knowledge base guide | You need local UESP lore and canon context without leaving the repository |
| [environment-troubleshooting.md](environment-troubleshooting.md) | Environment recovery | `.NET`, restore, build, or external tool setup is blocking execution |
| Module references in this folder | Capability reference | You already know the module and need command-level details |

## Reading Order

### For AI Agents

1. [../README.md](../README.md)
2. [../AGENTS.md](../AGENTS.md)
3. This file
4. The relevant module reference
5. [llm-guide.md](llm-guide.md) when the task becomes multi-step or unusual
6. [esp-translation.md](esp-translation.md) when you are translating player-facing ESP text
7. [human-name-translation.md](human-name-translation.md) when the translation surface is dominated by people names and titles
8. [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md) when you need dictionary lookup or agent-readable translation corpora
9. [knowledge_base/README.md](knowledge_base/README.md) when you need local lore, book context, or canon naming guidance

### For Human Operators

1. [../README.md](../README.md)
2. [environment-troubleshooting.md](environment-troubleshooting.md) if setup fails
3. The module docs that match the operation you want to perform

## Shared Operating Conventions

These conventions apply across the documentation set:

1. Toolkit commands should use `--json`.
2. Agents should parse JSON and check `success` before proceeding.
3. Agents should run `papyrus status --json` before first Papyrus use.
4. Agents should run `archive status --json` before first archive use.
5. Weapons and armor require `--model`.
6. Spells and perks require `--effect`.
7. Vanilla Papyrus properties should prefer auto-fill over manual wiring.
8. Prefer `dictionary lookup` or `dictionary search` for direct bilingual queries, and let those commands use `dictionaries/agent-readable` by default when it exists.
9. For ESP translation work, inspect the record first and treat dictionary evidence as part of the workflow rather than an optional afterthought.
10. For lore-heavy naming or translation work, use the local UESP knowledge base for context and the dictionary for final terminology validation.

## Module References

| Module | Use It For | Read |
| --- | --- | --- |
| ESP | Create and edit `.esp/.esl` plugins, inspect records, create patches, manage conditions | [esp.md](esp.md) |
| Papyrus | Generate, validate, compile, and decompile scripts | [papyrus.md](papyrus.md) |
| Archive | Inspect, extract, create, edit, diff, and validate BSA/BA2 archives | [archive.md](archive.md) |
| MCM | Generate and validate MCM Helper configs | [mcm.md](mcm.md) |
| NIF | Inspect meshes, textures, strings, shader flags, and roundtrip integrity | [nif.md](nif.md) |
| Audio | Work with FUZ, XWM, WAV, and related voice assets | [audio.md](audio.md) |
| SKSE | Scaffold and build native SKSE plugins | [skse.md](skse.md) |
| Dictionary | Query bilingual XML dictionaries and export them into JSONL shards and EDID-grouped records for AI retrieval | [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md) |
| ESP Translation | Translate player-facing plugin text with dictionary-backed terminology discipline | [esp-translation.md](esp-translation.md) |
| Human Name Translation | Translate NPC names, surnames, titles, and epithets against shipped Skyrim naming patterns | [human-name-translation.md](human-name-translation.md) |
| Knowledge Base | Research lore, books, canon naming, and contextual background from the local UESP Markdown mirror | [knowledge_base/README.md](knowledge_base/README.md) |

## Task-to-Doc Map

| Task | Start Here |
| --- | --- |
| Create a new simple mod | [../README.md](../README.md) then [esp.md](esp.md) |
| Build a scripted quest | [../AGENTS.md](../AGENTS.md) then [papyrus.md](papyrus.md) and [llm-guide.md](llm-guide.md) |
| Patch an existing plugin | [llm-guide.md](llm-guide.md) then [esp.md](esp.md) |
| Translate an ESP while keeping vanilla terminology consistent | [esp-translation.md](esp-translation.md) |
| Translate NPC and historical names against base-game Chinese naming | [human-name-translation.md](human-name-translation.md) |
| Research lore, canon naming, or in-game book context | [knowledge_base/README.md](knowledge_base/README.md) |
| Extract or edit a BSA/BA2 | [archive.md](archive.md) |
| Debug a broken mod | [llm-guide.md](llm-guide.md) then the relevant module docs |
| Query bilingual dictionary data or prepare it for an AI agent | [../README.md](../README.md) then [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md) |
| Fix build or SDK issues | [environment-troubleshooting.md](environment-troubleshooting.md) |
| Extend the toolkit itself | [../README.md](../README.md), [../CLAUDE.md](../CLAUDE.md), then the source modules |

## External Tool Notes

| Tool | Used By | Notes |
| --- | --- | --- |
| `papyrus-compiler` | Papyrus | Managed by the toolkit |
| `Champollion` | Papyrus | Managed by the toolkit |
| `BSArch` | Archive | Not bundled; often the missing dependency in archive workflows |
| `nif-tool` | NIF | Bundled in `tools/` |
| `cmake` and `cl` | SKSE | Required for native plugin builds |

## Summary

If you only remember one rule, remember this split:

- `README.md` tells you how to enter the project
- `AGENTS.md` tells an AI agent how to behave
- `docs/README.md` tells you where to go next
- `docs/esp-translation.md` tells an agent how to translate plugin text without drifting from vanilla terms
- `docs/human-name-translation.md` tells an agent how to translate people names against shipped Skyrim naming patterns
- `dictionaries/README.agent-format.md` tells you how to export bilingual terms for retrieval
- `docs/knowledge_base/README.md` tells an agent how to mine the local UESP lore corpus safely
- `docs/llm-guide.md` shows the full workflows
