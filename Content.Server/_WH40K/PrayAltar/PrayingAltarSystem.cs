using Content.Shared.DoAfter;
using Content.Shared.Humanoid;
using Content.Shared.Popups;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;
using Content.Shared.WH40k.PrayAltar;
using Content.Shared.Movement.Systems;
using Content.Shared.Movement.Components;

namespace Content.Server.WH40K.PrayAltar;

public sealed class PrayAltarSystem : SharedPrayAltarSystem
{

    [Dependency] private readonly IPrototypeManager _proto = default!;
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;

    [Dependency] private readonly SharedPopupSystem _popup = default!;
    [Dependency] private readonly MovementSpeedModifierSystem _speed = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<PrayAltarComponent, PrayAltarDoAfterEvent>(OnDoAfter);
    }

    private void OnDoAfter(Entity<PrayAltarComponent> ent, ref PrayAltarDoAfterEvent args)
    {
        ent.Comp.SacrificeStream = _audio.Stop(ent.Comp.SacrificeStream);
        ent.Comp.DoAfter = null;

        if (args.Cancelled || args.Handled)
            return;

    }

    protected override void AttemptPray(Entity<PrayAltarComponent> ent, EntityUid user)
    {
        if (ent.Comp.DoAfter != null)
            return;

        if (!HasComp<HumanoidAppearanceComponent>(user))
        {
            _popup.PopupEntity(Loc.GetString("Вы не гуманоид"), ent, user, PopupType.SmallCaution);
            return;
        }

        _popup.PopupEntity(Loc.GetString("Вы молитесь"), ent, PopupType.SmallCaution);

        ent.Comp.SacrificeStream = _audio.PlayPvs(ent.Comp.PraySound, ent)?.Entity;

        var ev = new PrayAltarDoAfterEvent();
        var args = new DoAfterArgs(EntityManager, user, ent.Comp.PrayTime, ev, target: ent, eventTarget: ent)
        {
            BreakOnDamage = true,
            BreakOnMove = true,
            BreakOnWeightlessMove = true,
            NeedHand = true
        };
        DoAfter.TryStartDoAfter(args, out ent.Comp.DoAfter);
    }
}