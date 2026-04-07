# Environment Troubleshooting

Practical notes for recovering the toolkit when the local .NET or build environment is unhealthy.

## Case Study: Broken .NET 8 SDK on Windows

This repository hit a Windows-specific environment failure where:

- `dotnet build` failed immediately with `0` errors and `0` warnings
- `dotnet run --project src/SpookysAutomod.Cli -- ...` also failed before the CLI started
- MSBuild diagnostics showed SDK resolution failures around workload locator imports

### Symptoms

Typical commands that failed:

```powershell
dotnet build SpookysAutomod.sln
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
```

Common diagnostic clues:

- `MSB4276` mentioning `Microsoft.NET.SDK.WorkloadAutoImportPropsLocator`
- `MSB4276` mentioning `Microsoft.NET.SDK.WorkloadManifestTargetsLocator`
- failure during restore graph generation instead of during C# compilation

### Root Causes

The failure turned out to be environmental, not a source-code compile error.

1. The system-installed `.NET SDK 8.0.419` under `C:\Program Files\dotnet` was incomplete for this machine's MSBuild behavior.
2. System repair was blocked by damaged installer cache entries and a missing original bootstrapper source path.
3. The repository does not use .NET workloads, but workload resolver imports were still being evaluated and causing SDK lookup failures.
4. In restricted or offline environments, NuGet vulnerability audit warnings can add noise during restore.

## What Worked

### 1. Install a clean user-local SDK

Instead of continuing to repair the broken machine-wide SDK, install a clean SDK into a user-owned directory:

```powershell
Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile '.\dotnet-install.ps1'
.\dotnet-install.ps1 -Version '8.0.419' -Architecture 'x64' -InstallDir "$env:USERPROFILE\.dotnet-8.0.419-fixed"
```

### 2. Prefer the clean SDK in the user environment

Persist these user environment variables:

```powershell
[Environment]::SetEnvironmentVariable('DOTNET_ROOT', "$env:USERPROFILE\.dotnet-8.0.419-fixed", 'User')
[Environment]::SetEnvironmentVariable('DOTNET_MULTILEVEL_LOOKUP', '0', 'User')
```

Add the same directory to the front of the user `Path`.

After updating environment variables, open a new terminal.

### 3. Disable workload resolver for this repository

This repository does not rely on .NET workloads, so disabling the workload resolver avoids broken locator imports on affected machines.

`[Directory.Build.props](../Directory.Build.props)` now contains:

```xml
<MSBuildEnableWorkloadResolver>false</MSBuildEnableWorkloadResolver>
```

## Validation Commands

Once the fixed SDK is active, these commands should work again:

```powershell
dotnet restore SpookysAutomod.sln -p:NuGetAudit=false -v minimal
dotnet build src/SpookysAutomod.Cli/SpookysAutomod.Cli.csproj --no-restore -v minimal
dotnet run --project src/SpookysAutomod.Cli -- papyrus status --json
dotnet run --project src/SpookysAutomod.Cli -- archive status --json
```

Expected outcome:

- `restore` completes
- `build` succeeds with normal project outputs
- CLI commands return JSON from the toolkit itself

If `archive status` reports `BSArch not found`, that means the .NET environment is fixed and the remaining issue is only the archive tool dependency.

## What Did Not Work Reliably

These paths were investigated but were not sufficient on their own:

- repairing the broken machine-wide SDK from `C:\Program Files\dotnet`
- relying on MSI-only repair for the SDK payload
- using the repository in a sandbox to prove the final host-machine result

System repair logs showed:

- installer cache hash mismatch
- missing original bootstrapper source path
- MSI maintenance blocked by system policy in some repair attempts

## Recommended Triage Order

When `dotnet build` fails before compilation starts:

1. Run `dotnet --info` and `dotnet --list-sdks`
2. Capture a diagnostic build log with `dotnet build -v diag`
3. Check whether the failure happens in restore, SDK resolution, or compilation
4. If workload locator errors appear, disable workload resolver for the repo
5. If the system SDK still looks unhealthy, install a clean user-local SDK
6. Re-test outside any sandbox before concluding the machine is fixed

## Lessons Learned

- A failed `.NET build` is not automatically a code problem.
- Repair logs are often more useful than build logs when the SDK itself is damaged.
- A user-local SDK is a practical recovery path when machine-wide SDK repair is blocked.
- Sandbox behavior can differ from the real host environment, so final verification should happen on the real system.
- Separate infrastructure failures from toolkit-level tool status. Once the CLI returns JSON again, remaining failures are usually normal application-level setup issues.
