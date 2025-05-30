using Content.Shared.Chat.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Robust.Shared.Audio;

namespace Content.Server.Mobs;

/// <summary>
///     Mobs with this component will emote a deathgasp when they die.
/// </summary>
/// <see cref="DeathgaspSystem"/>
[RegisterComponent]
public sealed partial class DeathgaspComponent : Component
{
    /// <summary>
    ///     The emote prototype to use.
    /// </summary>
    [DataField(customTypeSerializer: typeof(PrototypeIdSerializer<EmotePrototype>))]
    public string Prototype = "DefaultDeathgasp";

    /// <summary>
    ///     Makes sure that the deathgasp is only displayed if the entity went critical before dying
    /// </summary>
    [DataField]
    public bool NeedsCritical = true;

    [DataField, AutoNetworkedField]
    public SoundSpecifier GaspSound = new SoundCollectionSpecifier("DefaultDeathgasp");
}
