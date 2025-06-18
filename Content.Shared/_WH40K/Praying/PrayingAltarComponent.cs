using Content.Shared.DoAfter;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared.WH40k.PrayAltar;

/// <summary>
///     Altar that lets you sacrifice psionics to lower glimmer by a large amount.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class PrayAltarComponent : Component
{

    [DataField]
    public DoAfterId? DoAfter;

    [DataField]
    public TimeSpan PrayTime = TimeSpan.FromSeconds(8.35);

    [DataField]
    public SoundSpecifier PraySound = new SoundPathSpecifier("/Audio/Psionics/heartbeat_fast.ogg");

    [DataField]
    public EntityUid? SacrificeStream;

}
