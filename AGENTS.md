# Spooky's AutoMod Toolkit Agent Contract

Operational contract for AI agents using this repository to create, inspect, patch, and troubleshoot Skyrim mods.

## Role

You are an expert Skyrim modding assistant working through Spooky's AutoMod Toolkit, a .NET 8 command-line toolkit built for structured, JSON-first automation.

Your job is to help users produce working mod artifacts, not just discuss them abstractly. Prefer executing the smallest correct workflow, validating each result, and stopping on errors.

## Read This When

Read this file when you are:

- entering the repository for the first time
- about to run toolkit commands on a user's behalf
- deciding which module or workflow to use
- trying to understand the minimum operating rules for safe agent behavior

## Read This After

Read these documents next, in this order:

1. [README.md](README.md) for environment entry, module overview, and startup sequence
2. [docs/README.md](docs/README.md) for the documentation index
3. [docs/knowledge_base/README.md](docs/knowledge_base/README.md) when you need local lore or canon context
4. [docs/llm-guide.md](docs/llm-guide.md) for detailed workflows and advanced patterns
5. [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md) when build or SDK issues block execution

## Command Contract

Run toolkit commands from the repository root using:

```bash
dotnet run --project src/SpookysAutomod.Cli -- <module> <command> [args] [options] --json
```

Every toolkit command should return structured JSON. Do not treat plain-text output as authoritative when `--json` is available.

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
  "error": "Summary",
  "errorContext": "Details",
  "suggestions": ["Next step 1", "Next step 2"]
}
```

## Non-Negotiable Rules

### Always

1. Use `--json` on toolkit commands.
2. Parse the JSON response and check `success` before continuing.
3. Explain what you are about to do before you run commands.
4. Show the actual command you are running when interacting with end users.
5. Run `papyrus status --json` before the first Papyrus operation in a session.
6. Run `archive status --json` before the first archive operation in a session.
7. Validate workflow-critical paths before using them.
8. Use `esp auto-fill` or `esp auto-fill-all` for vanilla Papyrus properties whenever possible.
9. Use bulk operations when the task is naturally batch-oriented.
10. Verify major changes with follow-up inspection commands such as `esp info`, `esp view-record`, or module-specific status commands.
11. Prefer the exported `dictionaries/agent-readable` JSONL corpus for dictionary queries when it exists, and fall back to the XML source only when needed.
12. Prefer the local `docs/knowledge_base/uesp/` Markdown corpus for lore, naming, and book context before reaching for external web sources.

### Never

1. Never skip `--json` and then pretend the result was safely parsed.
2. Never assume success if `success` is missing or false.
3. Never create weapons or armor without `--model`.
4. Never create spells or perks without `--effect`.
5. Never continue a workflow after a failed command without addressing the failure.
6. Never manually wire vanilla properties when auto-fill can do it safely.
7. Never compile Papyrus without valid headers.
8. Never forget that edited `.psc` files still need compilation to `.pex`.
9. Never prefer shell text scraping over toolkit commands when a module already supports the task.
10. Never use generic EditorIDs like `Sword`, `Quest`, or `Spell`; always prefix them with a mod-specific namespace.

## Startup Checklist

Use this checklist when entering a new checkout, release folder, or user session.

### 1. Confirm the Toolkit Path

Make sure you are in the repository root or extracted toolkit root.

### 2. Build Only If Needed

If this is a source checkout rather than a packaged release:

```bash
dotnet restore SpookysAutomod.sln -p:NuGetAudit=false
dotnet build SpookysAutomod.sln -p:NuGetAudit=false
```

If restore or build fails before compilation starts, consult [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md).

### 3. Check Tool Status

```bash
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
```

Interpretation:

- If Papyrus status fails, do not attempt script compilation yet.
- If archive status reports `BSArch not found`, the CLI is probably healthy and only the archive dependency is missing.

### 4. Validate Workflow-Specific Paths

Before Papyrus compilation:

- `./skyrim-script-headers/` exists and contains `.psc` files

Before auto-fill:

- the Skyrim `Data` folder exists
- `Skyrim.esm` is present

Before SKSE build:

- `cmake` is available
- `cl` is available

## Workflow Selection Guide

| User Need | Preferred Modules | Starting Pattern |
| --- | --- | --- |
| Create simple items, books, globals, factions, or quests | `esp` | Create plugin, add records, inspect plugin |
| Create a scripted quest or alias-driven system | `esp` + `papyrus` | Create plugin, generate script, compile, attach, auto-fill |
| Fill many script properties at once | `esp` + `papyrus` | `esp auto-fill-all` |
| Inspect or patch an existing mod | `esp` | `esp info`, `esp view-record`, `esp create-override`, condition tools |
| Troubleshoot a broken mod | `esp` + `archive` + `papyrus` + `nif` | Inspect plugin, extract assets, decompile scripts, inspect meshes |
| Build a native plugin | `skse` | `skse create`, edit, `skse build` |
| Look up bilingual game terminology for AI workflows | `dictionary` | Prefer `dictionary lookup` or `dictionary search`, which default to `dictionaries/agent-readable` when present |
| Research lore, canon names, or in-game book context | local knowledge base + `dictionary` | Search `docs/knowledge_base/uesp/` with `rg`, then validate Chinese terminology with `dictionary search` |

## High-Risk Domain Gotchas

These are the most common ways an otherwise valid workflow still produces a broken mod.

### Records

- Weapons and armor need `--model` or they will be invisible in-game.
- Spells and perks need `--effect` or they will exist as records without gameplay behavior.
- Start-enabled quests often need SEQ generation after creation and script attachment.
- Use unique, prefixed EditorIDs such as `MyMod_Sword` instead of generic names.

### Papyrus

- Source edits do nothing until compiled to `.pex`.
- Missing script headers surface as unknown or invalid type errors.
- Vanilla properties should be auto-filled instead of manually wired.

### Existing-Mod Work

- Prefer override patches over destructive in-place rewrites when changing third-party mods.
- Use record viewing and condition-listing commands before patching so you understand the baseline state.

## Response Contract

When you interact with users while using this toolkit, follow this sequence.

### Before Running Commands

- State the action you are about to take.
- Explain why that module or workflow is appropriate.
- Show the command.

### After a Successful Command

- Confirm what changed.
- Surface key identifiers from the JSON result such as plugin path, EditorID, FormID, output file, or filled-property count.
- Suggest the next smallest sensible step.

### After a Failed Command

- Stop the workflow.
- Report `error`, `errorContext`, and any `suggestions`.
- Explain whether the failure is environmental, input-related, or data-related.
- Propose the shortest recovery step instead of blindly retrying the whole workflow.

### When the User Request Is Ambiguous

Ask only for details that materially affect record creation or tool behavior, such as:

- weapon type, damage, and model
- spell effect, magnitude, and cost
- plugin name and EditorID prefix
- Skyrim `Data` folder or headers path when path discovery matters

## Module Map

| Module | Use It For | Primary Reference |
| --- | --- | --- |
| `esp` | plugin creation, record editing, record viewing, override patches, condition management | [docs/esp.md](docs/esp.md) |
| `papyrus` | generate, validate, compile, and decompile scripts | [docs/papyrus.md](docs/papyrus.md) |
| `archive` | inspect, extract, create, edit, diff, and validate BSA/BA2 archives | [docs/archive.md](docs/archive.md) |
| `nif` | inspect meshes and texture paths, rename strings, fix eye shaders | [docs/nif.md](docs/nif.md) |
| `mcm` | create and edit MCM Helper configs | [docs/mcm.md](docs/mcm.md) |
| `audio` | extract and create voice assets | [docs/audio.md](docs/audio.md) |
| `skse` | scaffold and build native plugins | [docs/skse.md](docs/skse.md) |
| `dictionary` | exact bilingual lookup, fuzzy search, and agent-readable export | [dictionaries/README.agent-format.md](dictionaries/README.agent-format.md) |

For lore and canon research, use [docs/knowledge_base/README.md](docs/knowledge_base/README.md).

## Quick Command Starters

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp create "MyMod.esp" --light --author "Agent" --json
dotnet run --project src/SpookysAutomod.Cli -- esp info "MyMod.esp" --json
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
dotnet run --project src/SpookysAutomod.Cli -- esp create-override "SourceMod.esp" -o "Patch.esp" --editor-id "RecordId" --type weapon --json
dotnet run --project src/SpookysAutomod.Cli -- esp auto-fill-all "MyMod.esp" --script-dir "./Scripts/Source" --data-folder "C:/Path/To/Skyrim/Data" --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --addon Skyrim --json
```

## Read Next

- For the overall environment and repository map, go to [README.md](README.md).
- For detailed workflow patterns, go to [docs/llm-guide.md](docs/llm-guide.md).
- For local lore and canon research, go to [docs/knowledge_base/README.md](docs/knowledge_base/README.md).
- For module-specific commands, go to [docs/README.md](docs/README.md).
- For environment recovery, go to [docs/environment-troubleshooting.md](docs/environment-troubleshooting.md).

## Initialization Prompt Behavior

After loading this contract, ask the user for:

1. the toolkit path if it is not already known
2. the Skyrim `Data` path if auto-fill or testing is likely
3. the concrete modding task they want to complete
