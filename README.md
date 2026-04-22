# Spooky's AutoMod Toolkit

AI-first command-line toolkit for creating, inspecting, patching, and troubleshooting Skyrim mods on Windows.

This repository exists to make Skyrim modding accessible to AI agents. Instead of relying on the Creation Kit GUI, agents can use structured CLI commands with JSON responses to create plugin records, compile Papyrus scripts, inspect archives, work with meshes, build MCM configs, process voice assets, scaffold SKSE plugins, and convert bilingual game dictionaries into retrieval-friendly data.

## Role

This is the entry point for the whole documentation set. Use it for environment setup, repository overview, startup sequence, and the first pass at choosing a module or workflow.

## Read This When

Read this file when you are:

- opening the repository for the first time
- trying to understand what the toolkit covers
- checking build, toolchain, or environment prerequisites
- deciding where to go next in the docs

## Read This After

If you are an AI agent, continue with:

1. [AGENTS.md](AGENTS.md)
2. [docs/README.md](docs/README.md)
3. [docs/knowledge_base/README.md](docs/knowledge_base/README.md) when the task needs lore or canon context
4. [docs/llm-guide.md](docs/llm-guide.md) when the task becomes multi-step
5. [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md) when execution is blocked by the environment

## Start Here If You Are an AI Agent

Treat this repository as an execution environment, not just a codebase to read.

### Core Command Format

```bash
dotnet run --project src/SpookysAutomod.Cli -- <module> <command> [args] [options] --json
```

### Non-Negotiable Rules

1. Always use `--json` on toolkit commands.
2. Parse the JSON response and check `success` before continuing.
3. Run `papyrus status --json` before the first Papyrus operation.
4. Run `archive status --json` before the first archive operation.
5. Validate paths before using them, especially `--headers`, `--data-folder`, and archive paths.
6. Use `esp auto-fill` or `esp auto-fill-all` for vanilla Papyrus properties instead of manually wiring Skyrim records.
7. Never create weapons or armor without `--model`.
8. Never create spells or perks without `--effect`.
9. Stop on failures and surface `error`, `errorContext`, and `suggestions`.
10. Prefer toolkit commands over ad hoc shell parsing when a module already supports the task.
11. For lore and naming research, prefer the local `docs/knowledge_base/uesp/` corpus before browsing elsewhere.

### JSON Contract

Typical success shape:

```json
{
  "success": true,
  "result": { }
}
```

Typical error shape:

```json
{
  "success": false,
  "error": "Human-readable summary",
  "errorContext": "Detailed context",
  "suggestions": ["Suggested next step 1", "Suggested next step 2"]
}
```

### Canonical Agent Docs

| Document | Role | Read It When |
| --- | --- | --- |
| [AGENTS.md](AGENTS.md) | Agent contract | You need execution rules, workflow selection, and command discipline |
| [docs/README.md](docs/README.md) | Documentation index | You need to choose the right module or guide |
| [docs/knowledge_base/README.md](docs/knowledge_base/README.md) | Knowledge base guide | You need local lore and canon context from the bundled UESP mirror |
| [docs/llm-guide.md](docs/llm-guide.md) | Detailed workflow guide | You need multi-step examples or advanced patterns |
| [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md) | Environment recovery | Build, restore, or tool setup is failing |

## What This Toolkit Covers

| Module | What Agents Can Do | Key Notes |
| --- | --- | --- |
| `esp` | Create and edit `.esp/.esl` plugins, add records, inspect records, create override patches, manage conditions | Built on Mutagen; core mod-authoring module |
| `papyrus` | Generate, validate, compile, and decompile scripts | Requires script headers for compilation |
| `archive` | Inspect, extract, diff, validate, merge, and edit BSA/BA2 archives | Requires `BSArch` for full archive workflows |
| `nif` | Inspect meshes, list and replace texture paths, rename strings, fix eye shaders, verify roundtrip safety | Uses bundled `nif-tool` |
| `mcm` | Generate MCM Helper config files | Useful for mod configuration UIs |
| `audio` | Work with FUZ/XWM/WAV assets | Useful for voice workflows |
| `skse` | Scaffold and build SKSE C++ plugins | Requires CMake and MSVC build tools |
| `dictionary` | Query bilingual translation dictionaries and convert them into agent-readable JSONL shards and EDID-grouped records | Query commands prefer exported JSONL when available |
| `setup` | Bootstrap a modding environment through a Windows setup wizard | Human-friendly entry point |

## Recommended Agent Startup Sequence

Use this sequence when entering an unfamiliar checkout or release folder.

### 1. Confirm the Toolkit Path

Work from the repository root or extracted release root.

### 2. Restore and Build if You Are in a Source Checkout

```bash
dotnet restore SpookysAutomod.sln -p:NuGetAudit=false
dotnet build SpookysAutomod.sln -p:NuGetAudit=false
```

If build or restore fails before compilation starts, use [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md).

### 3. Check Tool Status Before Specialized Work

```bash
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
```

Interpretation:

- If `papyrus status` fails, do not attempt compilation until the compiler toolchain is ready.
- If `archive status` reports `BSArch not found`, the .NET environment is probably fine and only the archive dependency is missing.

### 4. Validate Required Paths

Before specific workflows, confirm:

- `skyrim-script-headers/` exists and contains `.psc` files if you will compile Papyrus.
- Your Skyrim `Data` folder exists and contains `Skyrim.esm` if you will use auto-fill.
- `cmake` and `cl` are available if you will build SKSE plugins.

### 5. Pick the Smallest Workflow That Solves the User Request

- Simple item or quest record with no scripts: use `esp`
- Scripted quest or alias logic: use `esp` + `papyrus` + auto-fill
- Compatibility patch or balance fix: use `esp view-record`, `esp create-override`, and condition tooling
- Reverse engineering or bug triage: use `esp info`, `archive`, `papyrus decompile`, and `nif`
- Bilingual terminology lookup or translation support: use `dictionary lookup` or `dictionary search`
- Bilingual terminology retrieval or embedding prep: use `dictionary export-agent`
- Lore and canon research for naming or translation: use [docs/knowledge_base/README.md](docs/knowledge_base/README.md) and search `docs/knowledge_base/uesp/`

## High-Value Workflows

These are the workflows most AI agents should reach for first.

### 1. Create a Simple Plugin

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp create "MyMod.esp" --light --author "Agent" --json
dotnet run --project src/SpookysAutomod.Cli -- esp add-book "MyMod.esp" "MM_LoreBook" --name "Lore Notes" --text "Text goes here" --json
dotnet run --project src/SpookysAutomod.Cli -- esp add-weapon "MyMod.esp" "MM_Sword" --name "Frostbane" --type sword --damage 30 --model iron-sword --json
dotnet run --project src/SpookysAutomod.Cli -- esp info "MyMod.esp" --json
```

Use this when the user wants records that do not need custom script logic.

### 2. Create a Scripted Quest with Auto-Fill

```bash
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- esp create "QuestMod.esp" --light --json
dotnet run --project src/SpookysAutomod.Cli -- esp add-quest "QuestMod.esp" "QM_MainQuest" --name "Quest Mod" --start-enabled --json
dotnet run --project src/SpookysAutomod.Cli -- papyrus generate --name "QM_MainQuestScript" --extends Quest --output "./Scripts/Source" --json
dotnet run --project src/SpookysAutomod.Cli -- papyrus compile "./Scripts/Source/QM_MainQuestScript.psc" --output "./Scripts" --headers "./skyrim-script-headers" --json
dotnet run --project src/SpookysAutomod.Cli -- esp attach-script "QuestMod.esp" --quest "QM_MainQuest" --script "QM_MainQuestScript" --json
dotnet run --project src/SpookysAutomod.Cli -- esp auto-fill "QuestMod.esp" --quest "QM_MainQuest" --script "QM_MainQuestScript" --psc-file "./Scripts/Source/QM_MainQuestScript.psc" --data-folder "C:/Path/To/Skyrim/Data" --json
```

Use this for quests, aliases, or systems that reference vanilla records such as keywords, globals, factions, locations, or forms from `Skyrim.esm`.

### 3. Inspect or Patch an Existing Mod

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp info "ExistingMod.esp" --json
dotnet run --project src/SpookysAutomod.Cli -- esp view-record "ExistingMod.esp" --editor-id "SomeRecord" --type weapon --json
dotnet run --project src/SpookysAutomod.Cli -- esp create-override "ExistingMod.esp" -o "Patch.esp" --editor-id "SomeRecord" --type weapon --json
dotnet run --project src/SpookysAutomod.Cli -- esp list-conditions "ExistingMod.esp" --editor-id "SomePerk" --type perk --json
```

Use this when the user wants a compatibility patch, a balance adjustment, or an explanation of what another mod is doing.

### 4. Troubleshoot a Broken Mod

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp info "BrokenMod.esp" --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
dotnet run --project src/SpookysAutomod.Cli -- archive list "BrokenMod.bsa" --json
dotnet run --project src/SpookysAutomod.Cli -- archive extract "BrokenMod.bsa" --output "./Debug" --json
dotnet run --project src/SpookysAutomod.Cli -- papyrus decompile "./Debug/Scripts/BrokenScript.pex" --output "./Debug/Source" --json
dotnet run --project src/SpookysAutomod.Cli -- nif list-textures "./Debug/Meshes/SomeMesh.nif" --json
```

Use this to inspect plugins, archives, scripts, and meshes as a single debugging workflow.

### 5. Export Game Dictionaries for Agent Retrieval

Quick query examples:

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --addon Skyrim --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "鼠道" --scope chinese --group-by record --limit 5 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml "./SomeMod_english_chinese.xml" --output "./SomeMod_english_chinese.translated.xml" --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml-ai "./SomeMod_english_chinese.xml" --output "./SomeMod_english_chinese.translated.xml" --report "./SomeMod_english_chinese.report.json" --json
```

Export example:

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary export-agent --input "./dictionaries" --output "./dictionaries/agent-readable" --shard-size 5000 --json
```

When `dictionaries/agent-readable` exists, the query commands prefer that exported JSONL corpus automatically and fall back to the source XML files only when no export is available. Use the export command when the same data needs to be easier to search, embed, shard, and cite than the original XML files.

What the export produces:

- `entries/`: one translation row per JSON object for exact lookups
- `records/`: one EDID-grouped document per record for richer context
- `manifest.json`: counts, relative shard file lists, and record-type distribution before opening large shards
- `agentText`: flattened natural-language text inside each object for retrieval workflows

`dictionary translate-xml` uses the same corpus to fill `Dest` values in `SSTXMLRessources` exports. By default it only fills untranslated rows where `Dest` is empty or still matches `Source`, and it skips ambiguous matches instead of guessing.

`dictionary translate-xml-ai` runs the same dictionary-first pass, then sends the remaining untranslated rows to OpenAI for fallback translation. Set `OPENAI_API_KEY` or pass `--api-key`, and optionally tune `--model`, `--batch-size`, and `--min-confidence`.

You can also configure AI translation defaults in `settings.json`. A ready-to-edit example is included at [settings.example.json](/D:/SteamLibrary/steamapps/common/Skyrim%20Special%20Edition/Data/Skyrim-Automod-Toolkit/settings.example.json). Copy it to `settings.json`, then edit the `aiTranslation` section to set the endpoint URL, API key, model name, prompts, confidence threshold, and batch sizing once for the whole toolkit.

AI translation now supports a persistent cache file. Successful batch results are written as they arrive, and reruns reuse cached entries before calling the model again. You can set `aiTranslation.cacheFile` in `settings.json` or pass `--cache-file` on the command line.

AI fallback also deduplicates identical untranslated entries before calling the model. Matching `REC + Source` rows are translated once and then written back to every duplicate occurrence, which reduces local-model time and keeps repeated labels consistent.

### 6. Research Lore with the Local UESP Knowledge Base

Use the bundled knowledge base when you need lore context, book relationships, or canon naming support that is broader than the bilingual dictionary.

```bash
rg --files docs/knowledge_base/uesp | rg "Riften|Ratway"
rg -n "House Redoran|Redoran" docs/knowledge_base/uesp -m 20
```

Use the knowledge base for English lore context and the dictionary for final Chinese terminology. See [docs/knowledge_base/README.md](docs/knowledge_base/README.md) for the full agent workflow.

## Environment Checklist

| Requirement | Needed For | How to Verify |
| --- | --- | --- |
| Windows | All modules | Native platform target |
| .NET 8 SDK | Source checkout builds and local development | `dotnet --version` |
| Skyrim installation | Testing and auto-fill workflows | Confirm `Data/Skyrim.esm` exists |
| Papyrus script headers | Script compilation | `skyrim-script-headers/*.psc` present |
| `BSArch` | Archive create and edit workflows | `archive status --json` |
| CMake | SKSE builds | `cmake --version` |
| MSVC Build Tools (`cl`) | SKSE builds | `cl` in terminal |

### External Tool Behavior

- `papyrus-compiler` and `Champollion` are managed by the toolkit.
- `BSArch` is not bundled and may need manual installation.
- NIF workflows use the bundled `tools/nif-tool`.

## Installation

### Option A: Setup Wizard

Recommended for humans who want a guided setup.

1. Download the latest release from the GitHub Releases page.
2. Extract it into a working mod-project folder.
3. Run `SpookysAutomodSetup.exe`.
4. Let the wizard detect Skyrim, link headers, download required tools, and verify the toolkit.

### Option B: Source Checkout

```bash
git clone https://github.com/SpookyPirate/spookys-automod-toolkit.git
cd spookys-automod-toolkit
dotnet restore SpookysAutomod.sln -p:NuGetAudit=false
dotnet build SpookysAutomod.sln -p:NuGetAudit=false
```

Verify the CLI:

```bash
dotnet run --project src/SpookysAutomod.Cli -- --help
```

## Papyrus Headers

Papyrus compilation requires Bethesda script headers such as `Actor.psc`, `Quest.psc`, and `Game.psc`.

- The repository includes the `skyrim-script-headers/` directory but does not ship the copyrighted header files.
- Obtain headers from your own Creation Kit installation.
- Prefer `papyrus setup-headers --json` or place the headers into `./skyrim-script-headers/`.
- Do not commit header `.psc` files to version control.

Example:

```bash
dotnet run --project src/SpookysAutomod.Cli -- papyrus setup-headers --json
```

## SKSE Build Requirements

Native SKSE plugin development requires:

- CMake
- MSVC Build Tools with C++ workload

Example workflow:

```bash
dotnet run --project src/SpookysAutomod.Cli -- skse create "MyPlugin" --output "./" --json
dotnet run --project src/SpookysAutomod.Cli -- skse build "./MyPlugin" --config Release --json
```

## Repository Layout

```text
src/
|- SpookysAutomod.Core/       Shared result models, logging, shared types
|- SpookysAutomod.Cli/        CLI entry point and commands
|- SpookysAutomod.Esp/        Plugin and record manipulation
|- SpookysAutomod.Papyrus/    Script generation, validation, compilation, decompilation
|- SpookysAutomod.Archive/    BSA/BA2 archive workflows
|- SpookysAutomod.Nif/        Mesh inspection and editing helpers
|- SpookysAutomod.Mcm/        MCM config generation
|- SpookysAutomod.Audio/      Audio and voice-file workflows
|- SpookysAutomod.Skse/       SKSE project generation and build orchestration
|- SpookysAutomod.Dictionaries/ Dictionary parsing and agent-readable export
|- SpookysAutomod.Setup/      Windows setup wizard
docs/                        Module references and troubleshooting docs
docs/knowledge_base/        Local UESP-derived Markdown knowledge base and usage guide
dictionaries/                Source XML dictionaries and agent-readable export docs/output
tools/                       External tools and bundled helpers
.claude/skills/              Claude Code skills for module-specific behavior
AGENTS.md                    Agent initialization prompt and operating rules
```

## Limits and Handoff Points

This toolkit is strong at structured mod data and related assets, but it is not a replacement for every Skyrim authoring tool.

It does not generate:

- custom 3D models
- custom textures
- NPC facegen artistry
- full worldspace or landscape editing
- arbitrary Creation Kit GUI workflows

Use it when the task can be represented as structured records, scripts, archives, meshes, configs, audio conversions, or SKSE scaffolding.

## Documentation Map

| Need | Read |
| --- | --- |
| Agent rules and execution behavior | [AGENTS.md](AGENTS.md) |
| Module reference index | [docs/README.md](docs/README.md) |
| ESP record creation and patching | [docs/esp.md](docs/esp.md) |
| Papyrus workflows | [docs/papyrus.md](docs/papyrus.md) |
| Archive workflows | [docs/archive.md](docs/archive.md) |
| NIF workflows | [docs/nif.md](docs/nif.md) |
| Audio workflows | [docs/audio.md](docs/audio.md) |
| MCM workflows | [docs/mcm.md](docs/mcm.md) |
| SKSE workflows | [docs/skse.md](docs/skse.md) |
| ESP text translation with dictionary-backed terminology | [docs/esp-translation.md](docs/esp-translation.md) |
| Agent-readable dictionary export | [dictionaries/README.agent-format.md](dictionaries/README.agent-format.md) |
| Local UESP lore and canon research | [docs/knowledge_base/README.md](docs/knowledge_base/README.md) |
| Advanced agent patterns | [docs/llm-guide.md](docs/llm-guide.md) |
| Repairing broken .NET environments | [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md) |

## Summary

If you are an agent, the practical reading order is:

1. [AGENTS.md](AGENTS.md)
2. This README
3. [docs/README.md](docs/README.md)
4. [docs/knowledge_base/README.md](docs/knowledge_base/README.md) when the task needs lore context
5. The specific module doc you need
6. [docs/llm-guide.md](docs/llm-guide.md) when the task becomes multi-step or unusual

If you are a human operator, the shortest path is:

1. Run the setup wizard or build the source checkout
2. Verify `papyrus status --json` and `archive status --json`
3. Let your AI agent work from this repository root using the command contract above
