# Documentation Update Instructions

This document provides comprehensive instructions for updating project documentation when new features are added or existing features are modified.

## Overview

This project maintains documentation for **two distinct audiences**:
1. **Human users** - README.md, docs/*.md files
2. **AI assistants** - CLAUDE.md, docs/llm-*.md, .claude/skills/*.md

Both must be kept in sync when features change.

---

## When to Update Documentation

Update documentation when:
- **New features added** (new commands, package types, tools)
- **Feature behavior changes** (command syntax, parameters, workflows)
- **Breaking changes** (removed features, changed behavior)
- **Major bug fixes** (that affect documented workflows)
- **Architecture changes** (new modules, changed patterns)

**Do NOT update documentation for:**
- Minor refactoring (internal code changes)
- Small bug fixes (that don't affect usage)
- Development/test code changes

---

## Documentation Files to Update

### Core Documentation (Always Check These)

| File | Purpose | Audience | Update Frequency |
|------|---------|----------|------------------|
| `README.md` | Main project documentation | Humans | Every feature |
| `CLAUDE.md` | AI assistant project guide | AI | Every feature |
| `CHANGELOG.md` | Version history | Both | Every release |
| `docs/llm-guide.md` | Comprehensive AI workflows | AI | Major features |
| `docs/llm-init-prompt.md` | Quick AI onboarding | AI | Major features |
| `.claude/skills/skyrim-esp/skill.md` | ESP command reference for AI | AI | ESP features |

### Conditional Documentation (Update If Relevant)

| File | Update When... |
|------|----------------|
| `.claude/skills/skyrim-papyrus/skill.md` | Papyrus features change |
| `.claude/skills/skyrim-archive/skill.md` | Archive features change |
| `.claude/skills/skyrim-nif/skill.md` | NIF features change |
| `.claude/skills/skyrim-mcm/skill.md` | MCM features change |
| `.claude/skills/skyrim-audio/skill.md` | Audio features change |
| `.claude/skills/skyrim-skse/skill.md` | SKSE features change |
| `docs/esp.md` | Detailed ESP reference changes |

---

## Update Process - Step by Step

### Step 1: Identify Changes

Before starting, create a list of what changed:
- **New commands added**
- **New package types added**
- **New options/parameters added**
- **Changed command syntax**
- **Removed features**
- **New workflows enabled**

### Step 2: Update README.md

**Location:** Root directory

**Sections to update:**

1. **Features Section** - Add bullet points for new capabilities
2. **Quick Start / Installation** - Update if setup changed
3. **Command Reference** - Add/update command examples
4. **Package Types** (if ESP changes) - Update the package type list

**Guidelines:**
- Keep examples concise and practical
- Use real-world use cases
- Maintain consistent formatting
- Keep version-agnostic (no "v1.2.3" references except in installation)

**Example Update Pattern:**
```markdown
## Features

### ESP Plugin Manipulation
- Create and modify Skyrim plugins (.esp/.esl)
- Add records: weapons, armor, spells, perks, books, NPCs, factions
- **NEW:** Complete NPC AI package support (36 package types)
- Auto-fill script properties from .psc files
```

### Step 3: Update CHANGELOG.md

**Location:** Root directory

**When to update:**
- Always update for releases
- Group changes by type (Added, Changed, Fixed, Removed)
- Use present tense ("Add" not "Added")
- Be specific about what changed

**Template:**
```markdown
## [Unreleased]

### Added
- Complete NPC AI package support with 36 package types
- Commands: `esp add-package`, `esp attach-package`
- Package types: Sandbox, Travel, Sleep, Eat, Follow, Guard, Patrol, UseItemAt, Sit, UseIdleMarker, Flee, Accompany, CastMagic, Dialogue, Find, Ambush, Wander, Wait, Activate, Relax, ForceGreet, Greet, UseWeapon, UseMagic, LockDoors, UnlockDoors, Dismount, Acquire, Escort, Say, Shout, FollowTo, HoldPosition, KeepAnEyeOn, Hover, Orbit

### Changed
- Updated ESP module with comprehensive package builder

### Fixed
- (List any bugs fixed)

## [1.8.0] - 2024-XX-XX

### Added
- Archive editing features
```

**Version Guidelines:**
- Use semantic versioning (MAJOR.MINOR.PATCH)
- MAJOR: Breaking changes
- MINOR: New features (backwards compatible)
- PATCH: Bug fixes
- Keep [Unreleased] section at top
- Move to versioned section on release

### Step 4: Update CLAUDE.md

**Location:** Root directory

**This is the AI assistant's primary reference - keep it accurate!**

**Sections to update:**

1. **Project Architecture** - If new modules added
2. **Critical Domain Knowledge** - If new concepts introduced
3. **File Locations** - If new file types added
4. **Key Dependencies** - If dependencies added/changed

**Guidelines:**
- Focus on *what AI needs to know* to work on the project
- Include gotchas and critical patterns
- Keep concise - this file was trimmed from 818 lines
- Reference detailed docs (don't duplicate llm-guide.md)

**Example Update:**
```markdown
## Critical Domain Knowledge

### NPC AI Packages
- **Package Records:** Define NPC behavior (sleep, eat, work, patrol)
- **36 Package Types:** Complete coverage of Skyrim's AI system
- **Package.Data Dictionary:** Uses `Dictionary<sbyte, APackageData>` for configuration
- **ProcedureTree:** `List<PackageBranch>` defines behavior procedures
- **FormKey Format:** Must be "FORMID:MODNAME" (e.g., "000007:Skyrim.esm")
```

### Step 5: Update docs/llm-init-prompt.md

**Location:** `docs/llm-init-prompt.md`

**Purpose:** Quick onboarding for AI assistants starting a new session

**Sections to update:**

1. **What This Toolkit Does** - High-level capabilities
2. **Key Commands** - Most important commands only
3. **Common Workflows** - Update if new workflows enabled

**Guidelines:**
- Keep extremely concise (AI reads this first)
- Focus on the 20% of features used 80% of the time
- Include 1-2 sentence examples

**Example Update:**
```markdown
## Key Commands

**ESP Module** (Plugin manipulation):
- `esp create <plugin>` - Create new plugin
- `esp add-npc <plugin> <editorId>` - Add NPC
- `esp add-package <plugin> <editorId> --type <type>` - Create AI package (36 types supported)
- `esp attach-package <plugin> --npc <npc> --package <pkg>` - Attach behavior to NPC
```

### Step 6: Update docs/llm-guide.md

**Location:** `docs/llm-guide.md`

**Purpose:** Comprehensive workflow guide for AI assistants

**This is the detailed reference - be thorough!**

**Sections to update:**

1. **Module Capabilities** - Add new features to relevant module section
2. **Common Workflows** - Add new workflow examples
3. **Command Reference** - Add detailed command examples
4. **Troubleshooting** - Add common issues/solutions

**Guidelines:**
- Provide complete, copy-paste-ready examples
- Show realistic workflows (not toy examples)
- Include expected output
- Explain the "why" not just the "how"

**Example Update:**
```markdown
### NPC AI Packages - Complete Behavior System

Packages control NPC behavior (sleep, work, patrol, combat). The toolkit supports all 36 Skyrim package types.

#### Creating Packages

**Sandbox Package** (wandering/idling):
```bash
esp add-package "MyMod.esp" "InnSandbox" \
  --type sandbox \
  --radius 500 \
  --location "InnLocationMarker"
```

**Sleep Package** (scheduled sleep):
```bash
esp add-package "MyMod.esp" "NightSleep" \
  --type sleep \
  --bed "InnkeeperBed" \
  --start-hour 22 \
  --duration 8
```

[Continue with all 36 types...]

#### Complete Workflow: Quest NPC

This workflow creates a quest NPC with complex behavior:

```bash
# 1. Create NPC
esp add-npc "QuestMod.esp" "QuestGiver" --name "The Mysterious Stranger" --level 15

# 2. Create packages
esp add-package "QuestMod.esp" "QG_DaySandbox" --type sandbox --radius 300
esp add-package "QuestMod.esp" "QG_NightSleep" --type sleep --bed "BedRef" --start-hour 22 --duration 8
esp add-package "QuestMod.esp" "QG_ForceGreet" --type forcegreet --target "PlayerRef"

# 3. Attach packages (order matters - evaluated top to bottom)
esp attach-package "QuestMod.esp" --npc "QuestGiver" --package "QG_ForceGreet"
esp attach-package "QuestMod.esp" --npc "QuestGiver" --package "QG_NightSleep"
esp attach-package "QuestMod.esp" --npc "QuestGiver" --package "QG_DaySandbox"
```
```

### Step 7: Update .claude/skills/skyrim-esp/skill.md

**Location:** `.claude/skills/skyrim-esp/skill.md`

**Purpose:** ESP-specific command reference that Claude uses when invoked with /esp or when working on ESP tasks

**Sections to update:**

1. **What This Skill Does** - Capabilities overview
2. **Available Commands** - Command list
3. **Common Patterns** - Workflow examples

**Guidelines:**
- Focus on commands and syntax
- Provide quick-reference examples
- Include JSON flag usage
- Show error handling patterns

**Example Update:**
```markdown
## Available Commands

### NPC AI Packages

Create AI behavior packages for NPCs.

**Create Package:**
```bash
esp add-package <plugin> <editorId> --type <type> [options]
```

**Package Types (36 total):**
- Basic: sandbox, travel, sleep, eat, follow, guard, patrol
- Actions: useitemat, activate, sit, useidlemarker
- Combat: flee, ambush, useweapon, usemagic, shout
- Social: dialogue, forcegreet, greet, say
- Advanced: acquire, escort, followto, holdposition, keepaneyeon
- Flying: hover, orbit
- Utility: castmagic, find, accompany, wander, wait, relax, lockdoors, unlockdoors, dismount

**Common Options:**
- `--marker <FormKey>` - Location marker reference
- `--target <FormKey>` - Target actor reference
- `--radius <units>` - Area radius (default: 500)
- `--start-hour <0-23>` - Schedule start time
- `--duration <hours>` - Duration in hours

**Examples:**
```bash
# Create sandbox package
esp add-package "MyMod.esp" "HomeSandbox" --type sandbox --radius 500

# Create sleep package with schedule
esp add-package "MyMod.esp" "NightSleep" --type sleep --bed "000801:Skyrim.esm" --start-hour 22 --duration 8

# Attach package to NPC
esp attach-package "MyMod.esp" --npc "MyNPC" --package "HomeSandbox"
```
```

### Step 8: Check Other Skills

**Review these skills and update if relevant:**

| Skill | Update When |
|-------|-------------|
| `skyrim-papyrus/skill.md` | Papyrus compilation or script features change |
| `skyrim-archive/skill.md` | BSA/BA2 archive features change |
| `skyrim-nif/skill.md` | NIF mesh features change |
| `skyrim-mcm/skill.md` | MCM menu features change |
| `skyrim-audio/skill.md` | Audio features change |
| `skyrim-skse/skill.md` | SKSE plugin features change |

**Only update skills that are directly affected by the changes.**

---

## Documentation Standards

### Writing Style

**For Human Documentation (README.md):**
- Professional but approachable tone
- Use second person ("you can create...")
- Provide context for why features matter
- Include real-world examples

**For AI Documentation (CLAUDE.md, llm-*.md):**
- Direct and technical
- Use imperative mood ("Create packages with...")
- Focus on facts and mechanics
- Include edge cases and gotchas

### Formatting Standards

**Command Examples:**
```bash
# Always include comments explaining what the command does
esp add-package "MyMod.esp" "PackageName" \
  --type sandbox \          # Use line continuations for readability
  --radius 500              # Explain non-obvious parameters
```

**Code Blocks:**
- Use appropriate language tags (bash, csharp, json)
- Keep examples copy-paste ready
- Show expected output when helpful

**Lists:**
- Use bullets for unordered items
- Use numbers for sequential steps
- Keep items parallel in structure

### Version Policy

**Version-Agnostic** (most files):
- Don't mention specific versions in documentation
- Use "current version" or "latest version"
- Focus on features, not version numbers

**Version-Specific** (CHANGELOG.md only):
- Use semantic versioning
- Include release dates
- Link to GitHub releases if applicable

---

## Common Mistakes to Avoid

### ❌ DON'T:
1. Update only human docs and forget AI docs
2. Add features to README without updating CLAUDE.md
3. Forget to update CHANGELOG.md
4. Make examples too simple (toy examples)
5. Include version numbers outside CHANGELOG.md
6. Copy-paste between docs without adapting to audience
7. Update only the skill without updating llm-guide.md

### ✅ DO:
1. Update ALL relevant documentation files
2. Keep human and AI docs in sync
3. Provide realistic, practical examples
4. Test command examples before documenting
5. Keep CHANGELOG.md current
6. Adapt content to each document's audience
7. Cross-reference related documentation

---

## Testing Documentation Updates

Before committing documentation changes:

1. **Verify command examples work:**
   ```bash
   # Run each example command to ensure accuracy
   esp add-package "Test.esp" "TestPkg" --type sandbox --radius 500
   ```

2. **Check formatting:**
   - View README.md in GitHub's markdown preview
   - Ensure code blocks render correctly
   - Check that links work

3. **Verify completeness:**
   - All new features documented?
   - All changed features updated?
   - CHANGELOG.md updated?

4. **AI perspective check:**
   - Would an AI assistant understand how to use this feature?
   - Are there enough examples?
   - Are edge cases documented?

---

## Quick Checklist for Documentation Updates

When adding a new feature, use this checklist:

- [ ] Identify all files that need updates (see "Documentation Files to Update")
- [ ] Update README.md with new feature capabilities
- [ ] Update CHANGELOG.md in [Unreleased] section
- [ ] Update CLAUDE.md if architectural changes or critical concepts
- [ ] Update docs/llm-init-prompt.md if commonly-used feature
- [ ] Update docs/llm-guide.md with detailed workflows
- [ ] Update relevant .claude/skills/*.md files
- [ ] Test all command examples
- [ ] Verify formatting in markdown preview
- [ ] Check that AI docs and human docs are in sync

---

## Example: Complete Documentation Update Flow

**Scenario:** Added complete NPC AI package support (36 package types)

**Files Updated:**
1. ✅ README.md - Added "NPC AI Packages" to features, added command examples
2. ✅ CHANGELOG.md - Added to [Unreleased] > Added section
3. ✅ CLAUDE.md - Added NPC AI Packages section to "Critical Domain Knowledge"
4. ✅ docs/llm-init-prompt.md - Added `esp add-package` to key commands
5. ✅ docs/llm-guide.md - Added comprehensive package workflows and all 36 types
6. ✅ .claude/skills/skyrim-esp/skill.md - Added package commands and examples

**Files NOT Updated:**
- ❌ skyrim-papyrus/skill.md - No Papyrus changes
- ❌ skyrim-archive/skill.md - No archive changes
- ❌ Other skills - Not relevant to ESP packages

---

## Maintenance

**Quarterly Review:**
- Review all documentation for accuracy
- Remove outdated information
- Update examples to use current best practices
- Check that new contributors can follow docs

**After Major Releases:**
- Move [Unreleased] to versioned section in CHANGELOG.md
- Review all docs for version-specific content
- Update any outdated screenshots or examples

---

## Questions?

If unsure about documentation updates:
1. Check this guide first
2. Look at previous updates in git history
3. Follow the patterns used in existing docs
4. When in doubt, be more thorough rather than less

**Key Principle:** Documentation is for both humans and AI assistants. Always update both perspectives when features change.
