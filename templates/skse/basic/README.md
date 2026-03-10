# {{PROJECT_NAME}}

**Author:** {{AUTHOR}}
**Version:** {{VERSION_MAJOR}}.{{VERSION_MINOR}}.{{VERSION_PATCH}}
**Description:** {{DESCRIPTION}}

## Build Requirements

- **CMake 3.24+**
- **MSVC Build Tools** (Visual Studio 2022 or Build Tools package)
- **Internet connection** (first build only - CommonLibSSE-NG is downloaded automatically)

## Building

Dependencies are handled automatically via CMake FetchContent. No need to install vcpkg or manually download libraries.

### Quick Build (Windows CMD)

```cmd
build.bat

REM Clean build:
build.bat --clean

REM Debug build:
build.bat --debug
```

### Manual Build

Open an **x64 Native Tools Command Prompt for VS 2022**, then:

```cmd
cmake -B build -S .
cmake --build build --config Release
```

The first build will take a few minutes as CMake downloads CommonLibSSE-NG. Subsequent builds are fast.

## Installation

1. After building, the DLL will be in `build/Release/{{PROJECT_NAME}}.dll`
2. Copy the DLL to: `<Skyrim>\Data\SKSE\Plugins\`
3. Launch Skyrim with SKSE

## Troubleshooting

### "Cannot open include file: 'RE/Skyrim.h'"

CommonLibSSE-NG should be downloaded automatically by CMake. If this fails:
- Delete the `build/` folder and try again
- Ensure you have internet access
- Check that git is installed and accessible from the command line

### "Incomplete type error with RE::TESObjectREFR"

This template uses `#include <RE/Skyrim.h>` in PCH.h which includes ALL headers. This error should not occur. Ensure PCH is being used correctly (CMake handles this automatically via `target_precompile_headers`).

### "undefined symbol: std::literals"

This template uses C++23. Ensure CMake is using the correct standard (set in CMakeLists.txt).

### "CompatibleVersions not found"

The old SKSE API is deprecated. This template uses C++20 designated initializers for `PluginVersionData` with `.RuntimeCompatibility()`. Do NOT use the old `CompatibleVersions()` method.

### "error C2440: cannot convert NiPointer"

Use `.get()` to get the raw pointer, then use `.As<RE::Actor>()` for safe casting:
```cpp
auto target = event->target.get();
auto targetActor = target->As<RE::Actor>();
```

### PCH Issues

This template configures PCH via CMake's `target_precompile_headers()`. Do NOT manually `#include "PCH.h"` in `.cpp` files - CMake handles it automatically.

## Project Structure

```
{{PROJECT_NAME}}/
├── CMakeLists.txt      # Build configuration (FetchContent handles deps)
├── build.bat           # Quick build script
├── README.md           # This file
└── src/
    ├── PCH.h           # Precompiled header (all RE:: and SKSE:: headers)
    └── main.cpp        # Plugin entry point and implementation
```

## Modifying the Plugin

### Adding Event Handlers

See examples in `src/main.cpp`:
- `OnHitEventHandler` - Handles combat hits
- `OnEquipEventHandler` - Handles item equip/unequip

To add your own event handler:
1. Create a class that inherits from `RE::BSTEventSink<EventType>`
2. Implement `ProcessEvent()` method
3. Register it in `InitializeEventHandlers()`

### Looking Up Forms

```cpp
auto form = RE::TESForm::LookupByEditorID("IronSword"sv);
auto weapon = RE::TESForm::LookupByID<RE::TESObjectWEAP>(0x00012EB7);
```

### Accessing Player

```cpp
auto player = RE::PlayerCharacter::GetSingleton();
if (player) {
    SKSE::log::info("Player name: {}", player->GetName());
}
```

## Resources

- **CommonLibSSE-NG Docs**: https://github.com/CharmedBaryon/CommonLibSSE-NG
- **SKSE Source**: https://github.com/ianpatt/skse64
- **Example Plugins**: https://github.com/topics/commonlibsse

## License

[Add your license here]
