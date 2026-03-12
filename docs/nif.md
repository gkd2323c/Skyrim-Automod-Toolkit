# NIF Module Reference

The NIF module handles reading and manipulation of NIF (NetImmerse Format) 3D mesh files. It combines built-in .NET commands for basic inspection with nif-tool (a bundled Rust binary) for advanced operations like texture path rewriting, string renaming, shader inspection, and eye fix.

## Overview

NIF files are the 3D model format used by Skyrim for meshes (weapons, armor, architecture, etc.).

**Note:** This module cannot create new meshes from scratch. For that, use Blender with the NifTools addon.

## Built-in Commands

### info

Get information about a NIF file.

```bash
nif info <nif>
```

**Arguments:**
| Argument | Description |
|----------|-------------|
| `nif` | Path to the NIF file |

**Output includes:**
- Filename
- File size
- Header string (NIF version info)
- Version number

**Example:**
```bash
nif info "./Meshes/Weapons/Iron/IronSword.nif"
```

---

### scale

Scale a NIF mesh uniformly.

```bash
nif scale <nif> <factor> [options]
```

**Arguments:**
| Argument | Description |
|----------|-------------|
| `nif` | Path to the NIF file |
| `factor` | Scale factor (e.g., 1.5 for 150%, 0.5 for 50%) |

**Options:**
| Option | Default | Description |
|--------|---------|-------------|
| `--output`, `-o` | input file | Output file path |

---

### copy

Copy a NIF file (validates format during copy).

```bash
nif copy <nif> --output <file>
```

**Arguments:**
| Argument | Description |
|----------|-------------|
| `nif` | Path to source NIF file |

**Required Options:**
| Option | Description |
|--------|-------------|
| `--output`, `-o` | Output file path |

**Example:**
```bash
nif copy "./Meshes/weapon.nif" --output "./Meshes/weapon_copy.nif"
```

---

## nif-tool Commands

These commands use the bundled `nif-tool.exe` Rust binary (`tools/nif-tool/`). All accept a single NIF file or a folder (recursive).

### list-textures

List texture paths with block index and slot number.

```bash
nif list-textures <path>
```

**Example output:**
```
D:\mods\MyMod\meshes\head.nif:
  [block 3 BSShaderTextureSet slot 0] textures\actors\character\female\femalehead.dds
  [block 3 BSShaderTextureSet slot 1] textures\actors\character\female\femaleheadnormal.dds
```

---

### replace-textures

Replace texture path substrings in BSShaderTextureSet blocks.

```bash
nif replace-textures <path> --old <find> --new <replace> [--dry-run] [--backup true|false]
```

| Option | Default | Description |
|--------|---------|-------------|
| `--old` | Required | Substring to find (case-insensitive) |
| `--new` | Required | Replacement string |
| `--dry-run` | false | Preview changes without writing |
| `--backup` | true | Create .nif.bak before overwriting |

**Example output:**
```
D:\mods\MyMod\meshes\head.nif:
  [block 3 slot 0]
    - textures\OldMod\textures\head.dds
    + textures\NewMod\textures\head.dds
  Saved.
```

---

### list-strings

Show NIF header string table entries (node names, block names).

```bash
nif list-strings <path>
```

**Example output:**
```
D:\mods\MyMod\meshes\head.nif:
  [0] NPC Root [Root]
  [1] NPC Head [Head]
  [2] BSFaceGenNiNode
```

---

### rename-strings

Rename node/block names in the NIF string table.

```bash
nif rename-strings <path> --old <find> --new <replace> [--dry-run] [--backup true|false]
```

Same options as replace-textures.

---

### shader-info

Show BSLightingShaderProperty SF1/SF2 flags.

```bash
nif shader-info <path>
```

Files with the eye ghosting bug are marked `*** EYE_ENV_MAP ***`.

**Example output:**
```
D:\...\FaceGenData\FaceGeom\MyNPC.nif:
  [block 5] BSLightingShaderProperty *** EYE_ENV_MAP ***
    SF1: 0x820001E7 [Specular, Skinned, Eye_Environment_Mapping, ...]
    SF2: 0x00008021 [ZBuffer_Write, Double_Sided, ...]

1 file(s) with Eye_Environment_Mapping flag
```

---

### fix-eyes

Fix eye ghosting bug in FaceGen NIFs.

```bash
nif fix-eyes <path> [--dry-run] [--backup true|false]
```

Clears `Eye_Environment_Mapping` (SF1 bit 17), sets `Environment_Mapping` (bit 7), and corrects surrounding SF1/SF2 flags to match expected SSE FaceGen values.

---

### verify

Verify byte-perfect roundtrip of NIF files.

```bash
nif verify <path>
```

**Example output:**
```
  OK   D:\...\head.nif (48320 bytes, byte-perfect roundtrip)
  FAIL D:\...\bad.nif: content mismatch at offset 0x00A3F0
```

Run this before any batch modification to confirm all files parse cleanly.

---

### restore

Restore NIF files from .nif.bak backups.

```bash
nif restore <path>
```

Copies each `.nif.bak` back to its `.nif` and deletes the backup.

---

## NIF Format Information

### Skyrim NIF Versions

| Game | NIF Version | Header String |
|------|-------------|---------------|
| Skyrim LE | 20.2.0.7 | NIF... |
| Skyrim SE | 20.2.0.7 | BSFadeNode |
| Fallout 4 | 20.2.0.7 | BSFadeNode |

### Common Node Types

| Node | Purpose |
|------|---------|
| BSFadeNode | Root node for meshes |
| NiTriShape | Triangle geometry |
| BSTriShape | Optimized triangle geometry (SSE) |
| BSLightingShaderProperty | Material/shader info |
| BSShaderTextureSet | Texture path container (8 slots) |
| NiSkinInstance | Skinning for animated meshes |

### Texture Slots

| Slot | Suffix | Purpose |
|------|--------|---------|
| 0 - Diffuse | none / _d | Base color |
| 1 - Normal | _n | Normal map |
| 2 - Glow | _g | Emissive/glow |
| 3 - Parallax | _p | Height map |
| 4 - Cube Map | _e | Environment map |
| 5 - Env Mask | _m | Environment mask |
| 6 - Subsurface | _s | Subsurface tint |
| 7 - Back Light | _b | Back lighting map |

---

## Limitations

### What This Module Can Do

- Read NIF file headers (version, format, game compatibility)
- List all texture paths with block/slot detail
- **Rewrite texture paths** in BSShaderTextureSet blocks (batch, case-insensitive)
- **Rename node/block names** in the NIF string table
- **Inspect shader flags** (BSLightingShaderProperty SF1/SF2)
- **Fix eye ghosting bug** in FaceGen NIFs
- **Verify byte-perfect roundtrip** of NIF files
- **Restore backups** from .nif.bak files
- Scale meshes uniformly
- Copy NIF files with format validation
- Process entire folders recursively

### What This Module Cannot Do

- **Create new meshes** - Use Blender with NifTools addon
- **Edit geometry** (vertices, faces, UV maps) - Use NifSkope or Blender
- **Edit rigging/skinning** - Use Outfit Studio
- **Convert between NIF versions** (LE to SE) - Use Cathedral Assets Optimizer
- **Edit vertex colors or alpha** - Use NifSkope or Outfit Studio

### Recommended Tools for Remaining Mesh Work

| Tool | Best For |
|------|----------|
| **NifSkope** | Direct NIF editing, vertex colors, complex shader work |
| **Outfit Studio** | Armor/body mesh editing, weight painting |
| **Blender + NifTools** | Creating new meshes, complex geometry edits |
| **Cathedral Assets Optimizer** | Batch NIF conversion (LE to SE), texture optimization |

---

## JSON Output

All commands support `--json` for machine-readable output:

```bash
nif info "./Meshes/weapon.nif" --json
```

**Success response:**
```json
{
  "success": true,
  "result": {
    "fileName": "weapon.nif",
    "fileSize": 45678,
    "version": "20.2.0.7",
    "headerString": "Gamebryo File Format, Version 20.2.0.7"
  }
}
```

**nif-tool command response:**
```json
{
  "success": true,
  "result": {
    "output": "D:\\mods\\meshes\\head.nif:\n  [block 3 BSShaderTextureSet slot 0] textures\\actors\\character\\female\\femalehead.dds",
    "dryRun": false
  }
}
```
