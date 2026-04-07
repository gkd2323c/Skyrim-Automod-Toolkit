# nif-tool

A Rust CLI for rewriting texture paths and string table entries in Skyrim SE NIF files. Byte-perfect roundtrip guaranteed — only the data you target is modified.

## Installation

Build from source (requires Rust 1.70+):

```bash
cd E:\Projects\nif-tool
cargo build --release
```

Binary: `target\release\nif-tool.exe`

## Commands

### list — List texture paths

```bash
nif-tool list <path>
```

Lists all non-empty texture paths in a NIF file or folder (recursive). Shows block index, block type, texture slot, and the path string.

```bash
# Single file
nif-tool list "D:\mods\MyMod\meshes\head.nif"

# Entire folder
nif-tool list "D:\mods\MyMod\meshes"
```

### replace — Replace texture path substrings

```bash
nif-tool replace <path> --old <string> --new <string> [--dry-run] [--backup]
```

Case-insensitive substring replacement across all `BSShaderTextureSet` blocks.

| Flag | Default | Description |
|------|---------|-------------|
| `--old` | required | Substring to find (case-insensitive) |
| `--new` | required | Replacement string |
| `--dry-run` | `false` | Preview changes without writing files |
| `--backup` | `true` | Create `.nif.bak` before overwriting |

```bash
# Replace texture path prefix across a folder
nif-tool replace "D:\mods\MyMod\meshes" --old "OldFolder\Textures" --new "NewFolder\Textures"

# Preview first
nif-tool replace "D:\mods\MyMod\meshes" --old "OldPrefix" --new "NewPrefix" --dry-run
```

### strings — List string table entries

```bash
nif-tool strings <path>
```

Lists all non-empty entries in the NIF header string table (node names, block names, etc.).

```bash
nif-tool strings "D:\mods\MyMod\meshes\head.nif"
```

### rename — Rename string table entries

```bash
nif-tool rename <path> --old <string> --new <string> [--dry-run] [--backup]
```

Case-insensitive substring replacement in the NIF string table. Same flags as `replace`. Automatically updates `max_string_len` in the header.

```bash
# Rename node/block names
nif-tool rename "D:\mods\MyMod\meshes" --old "OldNPC_Hair" --new "NewNPC_Hair"
```

### verify — Verify byte-perfect roundtrip

```bash
nif-tool verify <path>
```

Parses and re-serializes each NIF, comparing output byte-for-byte. Reports `OK` or `FAIL` with the first differing byte offset. Use this to confirm the parser handles your NIFs without data loss.

```bash
nif-tool verify "D:\mods\MyMod\meshes"
```

### shader-info — Show shader flags

```bash
nif-tool shader-info <path>
```

Inspects all `BSLightingShaderProperty` blocks in NIF file(s) and displays their shader flags. Flags any blocks with `SLSF1_Eye_Environment_Mapping` set (the flag that causes ghosted eyes in Skyrim SE).

```bash
# Check a single NIF
nif-tool shader-info "D:\mods\MyMod\meshes\head.nif"

# Scan an entire FaceGen folder
nif-tool shader-info "D:\mods\MyMod\meshes\actors\character\FaceGenData"
```

Output shows each BSLightingShaderProperty block with SF1/SF2 flags in hex and human-readable names. Blocks with the eye bug are marked `*** EYE_ENV_MAP ***`. The summary line reports how many files have the flag.

### fix-eyes — Fix eye shader flags

```bash
nif-tool fix-eyes <path> [--dry-run] [--backup true|false]
```

Batch-fixes the eye ghosting bug in FaceGen NIFs. For every `BSLightingShaderProperty` block that has `SLSF1_Eye_Environment_Mapping` (bit 17), the fix:

- **SF1:** Clears `Eye_Environment_Mapping`, sets `Environment_Mapping` (bit 7). Also ensures `Specular`, `Skinned`, `Receive_Shadows`, `Cast_Shadows`, `Own_Emit`, `Remappable_Textures`, `ZBuffer_Test`.
- **SF2:** Ensures `ZBuffer_Write`, `Double_Sided`, `Assume_Shadowmask`, `EnvMap_Light_Fade`, `Soft_Lighting`.

| Flag | Default | Description |
|------|---------|-------------|
| `--dry-run` | `false` | Preview changes without writing files |
| `--backup` | `true` | Create `.nif.bak` before overwriting |

```bash
# Preview what would change
nif-tool fix-eyes "D:\mods\MyMod\meshes" --dry-run

# Fix all NIFs in a folder (no backups)
nif-tool fix-eyes "D:\mods\MyMod\meshes" --backup false

# Fix with backups (default)
nif-tool fix-eyes "D:\mods\MyMod\meshes"
```

### restore — Restore from backups

```bash
nif-tool restore <path>
```

Finds all `.nif.bak` files recursively, copies each back to its original `.nif`, then deletes the backup.

```bash
nif-tool restore "D:\mods\MyMod\meshes"
```

## Safety

- **Byte-perfect roundtrip** — NIF blocks are stored as raw bytes; only targeted data (texture paths or string table entries) is modified
- **Validation before write** — serialized output is re-parsed and verified before saving; if validation fails, the file is not touched
- **Backups by default** — `.nif.bak` created automatically before any modification
- **Dry-run available** — preview all changes before committing
- **SSE only** — requires NIF version `20.2.0.7` with BS version >= 83

## Bash Escaping

On Windows bash, backslashes in NIF paths need care. Use single quotes:

```bash
nif-tool replace "D:\path" --old 'VNPCs\'"$name"'\hair' --new 'Foundation\'"$name"'\hair'
```

## Why nif-tool instead of PyFFI?

PyFFI fails on SSE FaceGen NIFs with a version mismatch error. nif-tool handles SSE head NIFs correctly because it stores blocks as raw bytes rather than trying to interpret every block type.
