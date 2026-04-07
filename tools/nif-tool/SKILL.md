---
name: nif-tool
description: Use when working with Skyrim SE NIF files — rewriting texture paths, renaming node/block names, inspecting or fixing eye shader flags, verifying roundtrip safety, or restoring backups. Trigger on mentions of NIF texture paths, BSShaderTextureSet, BSLightingShaderProperty, eye ghosting bug, FaceGen NIFs, or any task involving batch NIF modification.
---

# nif-tool

A CLI for rewriting texture paths, string table entries, and shader flags in Skyrim SE NIF files. Byte-perfect roundtrip guaranteed — only the data you target is modified.

**Binary:** Provided separately. Either add it to your PATH as `nif-tool` or invoke it with the full path. All examples below use `nif-tool`.

**SSE only:** Requires NIF version `20.2.0.7` with BS version ≥ 83.

---

## Commands at a Glance

| Command | What it touches | Use when |
|---|---|---|
| `list` | Texture paths | Inspect what `.dds` paths are in a NIF |
| `replace` | Texture paths | Change `.dds` file paths in `BSShaderTextureSet` blocks |
| `strings` | String table | Inspect node/block names in a NIF |
| `rename` | String table | Change node or block names |
| `shader-info` | Shader flags | Inspect `BSLightingShaderProperty` SF1/SF2 flags |
| `fix-eyes` | Shader flags | Fix eye ghosting bug (`Eye_Environment_Mapping`) |
| `verify` | Whole file | Confirm a NIF can be parsed/re-serialized without data loss |
| `restore` | Backups | Roll back `.nif.bak` files |

All commands accept a single `.nif` file or a folder (recursive).

---

## `replace` vs `rename` — Which One?

| You want to change... | Command |
|---|---|
| Texture image paths (`.dds` files) | `replace` |
| Node names, block names (e.g. `NPC Head`) | `rename` |

`replace` targets `BSShaderTextureSet` blocks. `rename` targets the NIF header string table.

---

## Texture Slot Reference

`list` and `replace` output shows `slot N`. Slot mapping:

| Slot | Texture type |
|---|---|
| 0 | Diffuse (albedo) |
| 1 | Normal map |
| 2 | Glow / emissive |
| 3 | Parallax / height |
| 4 | Environment / cube map |
| 5 | Environment mask |
| 6 | Subsurface tint |
| 7 | Back lighting map |

---

## Shared Flags (replace, rename, fix-eyes)

| Flag | Default | Effect |
|---|---|---|
| `--dry-run` | `false` | Preview changes, no files written |
| `--backup` | `true` | Write `.nif.bak` before overwriting |

Always use `--dry-run` first on a folder you haven't processed before.

---

## Command Reference

### list
```bash
nif-tool list "D:\mods\MyMod\meshes\head.nif"
nif-tool list "D:\mods\MyMod\meshes"
```
Output:
```
D:\mods\MyMod\meshes\head.nif:
  [block 3 BSShaderTextureSet slot 0] textures\actors\character\female\femalehead.dds
  [block 3 BSShaderTextureSet slot 1] textures\actors\character\female\femaleheadnormal.dds
```

### replace
```bash
nif-tool replace "D:\mods\MyMod\meshes" --old "OldMod\textures" --new "NewMod\textures" --dry-run
nif-tool replace "D:\mods\MyMod\meshes" --old "OldMod\textures" --new "NewMod\textures"
```
Output per changed file:
```
D:\mods\MyMod\meshes\head.nif:
  [block 3 slot 0]
    - textures\OldMod\textures\head.dds
    + textures\NewMod\textures\head.dds
  Saved.
```

### strings
```bash
nif-tool strings "D:\mods\MyMod\meshes\head.nif"
```
Output:
```
D:\mods\MyMod\meshes\head.nif:
  [0] NPC Root [Root]
  [1] NPC Head [Head]
  [2] BSFaceGenNiNode
```

### rename
```bash
nif-tool rename "D:\mods\MyMod\meshes" --old "OldNPC" --new "NewNPC" --dry-run
nif-tool rename "D:\mods\MyMod\meshes" --old "OldNPC" --new "NewNPC"
```

### shader-info
```bash
nif-tool shader-info "D:\mods\MyMod\meshes\actors\character\FaceGenData"
```
Output:
```
D:\...\FaceGenData\FaceGeom\MyNPC.nif:
  [block 5] BSLightingShaderProperty *** EYE_ENV_MAP ***
    SF1: 0x820001E7 [Specular, Skinned, Eye_Environment_Mapping, ...]
    SF2: 0x00008021 [ZBuffer_Write, Double_Sided, ...]

1 file(s) with Eye_Environment_Mapping flag
```
Files marked `*** EYE_ENV_MAP ***` have the eye ghosting bug.

### fix-eyes
```bash
nif-tool fix-eyes "D:\mods\MyMod\meshes" --dry-run
nif-tool fix-eyes "D:\mods\MyMod\meshes"
nif-tool fix-eyes "D:\mods\MyMod\meshes" --backup false
```
Clears `Eye_Environment_Mapping` (SF1 bit 17), sets `Environment_Mapping` (bit 7), and corrects surrounding SF1/SF2 flags to match expected SSE FaceGen values.

### verify
```bash
nif-tool verify "D:\mods\MyMod\meshes"
```
Output:
```
  OK   D:\...\head.nif (48320 bytes, byte-perfect roundtrip)
  FAIL D:\...\bad.nif: content mismatch at offset 0x00A3F0
```
Run `verify` on any folder before batch-modifying it to confirm all files parse cleanly.

### restore
```bash
nif-tool restore "D:\mods\MyMod\meshes"
```
Copies each `.nif.bak` back to its `.nif` and deletes the backup.

---

## Safety Model

1. After any modification, the output is re-parsed and block count is checked before writing.
2. If validation fails: `VALIDATION FAILED — not saving` — the original file is untouched.
3. Backups (`.nif.bak`) are created before overwriting by default.
4. NIF blocks are stored as raw bytes — only the specific targeted data changes.

If you see `VALIDATION FAILED`, the file was not modified. The NIF may be malformed or an unsupported variant. Skip it and report the path.

---

## Recommended Workflow for Batch Texture Retextures

```bash
# 1. Verify all NIFs parse cleanly first
nif-tool verify "D:\mods\MyMod\meshes"

# 2. Check what paths exist
nif-tool list "D:\mods\MyMod\meshes"

# 3. Dry run the replacement
nif-tool replace "D:\mods\MyMod\meshes" --old "OldPath" --new "NewPath" --dry-run

# 4. Apply
nif-tool replace "D:\mods\MyMod\meshes" --old "OldPath" --new "NewPath"

# 5. Roll back if needed
nif-tool restore "D:\mods\MyMod\meshes"
```

---

## Bash Escaping (Windows)

Backslashes in path arguments need single quotes in bash:

```bash
nif-tool replace "D:\mods" --old 'OldFolder\'"$name"'\textures' --new 'NewFolder\'"$name"'\textures'
```

---

## Why Not PyFFI?

PyFFI fails on SSE FaceGen NIFs with a version mismatch error. nif-tool handles SSE head NIFs correctly because it stores NIF blocks as raw bytes rather than trying to interpret every block type.
