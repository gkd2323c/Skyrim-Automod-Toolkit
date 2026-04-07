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
| [environment-troubleshooting.md](environment-troubleshooting.md) | Environment recovery | `.NET`, restore, build, or external tool setup is blocking execution |
| Module references in this folder | Capability reference | You already know the module and need command-level details |

## Reading Order

### For AI Agents

1. [../README.md](../README.md)
2. [../AGENTS.md](../AGENTS.md)
3. This file
4. The relevant module reference
5. [llm-guide.md](llm-guide.md) when the task becomes multi-step or unusual

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

## Task-to-Doc Map

| Task | Start Here |
| --- | --- |
| Create a new simple mod | [../README.md](../README.md) then [esp.md](esp.md) |
| Build a scripted quest | [../AGENTS.md](../AGENTS.md) then [papyrus.md](papyrus.md) and [llm-guide.md](llm-guide.md) |
| Patch an existing plugin | [llm-guide.md](llm-guide.md) then [esp.md](esp.md) |
| Extract or edit a BSA/BA2 | [archive.md](archive.md) |
| Debug a broken mod | [llm-guide.md](llm-guide.md) then the relevant module docs |
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
- `docs/llm-guide.md` shows the full workflows
