using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;

namespace SpookysAutomod.Esp.Builders;

/// <summary>
/// Fluent builder for creating Faction records.
/// </summary>
public class FactionBuilder
{
    private readonly SkyrimMod _mod;
    private readonly Faction _faction;

    public FactionBuilder(SkyrimMod mod, string editorId)
    {
        _mod = mod;
        _faction = new Faction(mod.GetNextFormKey(), SkyrimRelease.SkyrimSE);
        _faction.EditorID = editorId;
        mod.Factions.Add(_faction);
    }

    /// <summary>
    /// Sets the faction name.
    /// </summary>
    public FactionBuilder WithName(string name)
    {
        _faction.Name = name;
        return this;
    }

    /// <summary>
    /// Sets the HiddenFromPC flag (faction won't appear in player's faction list).
    /// </summary>
    public FactionBuilder HiddenFromPC()
    {
        _faction.Flags |= Faction.FactionFlag.HiddenFromPC;
        return this;
    }

    /// <summary>
    /// Sets the TrackCrime flag (faction tracks crimes against its members).
    /// </summary>
    public FactionBuilder TrackCrime()
    {
        _faction.Flags |= Faction.FactionFlag.TrackCrime;
        return this;
    }

    /// <summary>
    /// Sets the SpecialCombat flag.
    /// </summary>
    public FactionBuilder SpecialCombat()
    {
        _faction.Flags |= Faction.FactionFlag.SpecialCombat;
        return this;
    }

    /// <summary>
    /// Sets the CanBeOwner flag (faction can own items and properties).
    /// </summary>
    public FactionBuilder CanBeOwner()
    {
        _faction.Flags |= Faction.FactionFlag.CanBeOwner;
        return this;
    }

    /// <summary>
    /// Sets the Vendor flag (faction acts as vendor faction).
    /// </summary>
    public FactionBuilder AsVendor()
    {
        _faction.Flags |= Faction.FactionFlag.Vendor;
        return this;
    }

    /// <summary>
    /// Sets multiple flags at once.
    /// </summary>
    public FactionBuilder WithFlags(params Faction.FactionFlag[] flags)
    {
        foreach (var flag in flags)
        {
            _faction.Flags |= flag;
        }
        return this;
    }

    /// <summary>
    /// Builds and returns the Faction record.
    /// </summary>
    public Faction Build() => _faction;
}
