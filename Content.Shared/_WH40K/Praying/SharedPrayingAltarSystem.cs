using System.Linq;
using Content.Shared.Buckle.Components;
using Content.Shared.DoAfter;
using Content.Shared.Examine;
using Content.Shared.Verbs;
using Content.Shared.WH40k.PrayAltar;
using Content.Shared.Mind;
using Content.Shared.Humanoid;

namespace Content.Shared.WH40k.PrayAltar;

public abstract partial class SharedPrayAltarSystem : EntitySystem
{
    [Dependency] protected readonly SharedDoAfterSystem DoAfter = default!;

    public override void Initialize()
    {
        base.Initialize();

        // SubscribeLocalEvent<PrayAltarComponent, ExaminedEvent>(OnExamined);
        SubscribeLocalEvent<PrayAltarComponent, GetVerbsEvent<AlternativeVerb>>(OnGetVerbs);
    }

    // private void OnExamined(Entity<PrayAltarComponent> ent, ref ExaminedEvent args)
    // {
    //     args.PushMarkup(Loc.GetString("altar-examine"));
    // }

    private void OnGetVerbs(Entity<PrayAltarComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract)
            // || GetFirstBuckled(strap) is not { } target)
            return;

        var user = args.User;
        args.Verbs.Add(new AlternativeVerb()
        {
            Act = () => AttemptPray(ent, user),
            Text = Loc.GetString("WH40K-Молиться"),
            Priority = 1
        });
    }

    protected virtual void AttemptPray(Entity<PrayAltarComponent> ent, EntityUid user) { }
}
