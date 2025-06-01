using Content.Shared.Damage;
using Content.Shared.Popups;
using Content.Shared.Stunnable;
using Robust.Shared.Audio.Systems;
using Content.Shared.Tag;
using Content.Shared.Damage.Prototypes;
using Robust.Shared.Prototypes;
using Content.Shared._Shitmed.Targeting;
using Content.Shared.Weapons.Ranged.Systems;

namespace Content.Server.WH40K.BigGun;

public sealed class BigGunSystem : EntitySystem
{
    [Dependency] private readonly SharedStunSystem _stun = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    [Dependency] private readonly DamageableSystem _damageable = default!;
    [Dependency] private readonly TagSystem _tag = default!;
    [Dependency] private readonly IPrototypeManager _proto = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<BigGunComponent, GunShotEvent>(OnShoot);
    }

    private void OnShoot(EntityUid uid, BigGunComponent ent, ref GunShotEvent args)
    {

        if (_tag.HasTag(args.User, "BigGunUser"))
            return;

        _damageable.TryChangeDamage(args.User, new DamageSpecifier(_proto.Index<DamageTypePrototype>("Blunt"), 35), targetPart: TargetBodyPart.Arms);

        _stun.TryParalyze(args.User, TimeSpan.FromSeconds(5), true);

        _audio.PlayPvs(ent.GunShootFailSound, args.User);

        _popup.PopupEntity(Loc.GetString("Оружие не ваших габаритов"), args.User, args.User);

    }
}
