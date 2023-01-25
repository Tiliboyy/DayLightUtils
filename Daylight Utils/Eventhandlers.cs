using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using GameCore;
using PlayerRoles;
using Respawning;
using UnityEngine;
using Cassie = Exiled.API.Features.Cassie;
using Log = Exiled.API.Features.Log;
using Map = Exiled.API.Features.Map;
using Player = Exiled.API.Features.Player;
using Server = Exiled.API.Features.Server;

public class Eventhandlers
{
    private readonly Plugin plugin;

    public Eventhandlers(Plugin plugin)
    {
        this.plugin = plugin;
    }
    public static void OnUsingItem(UsedItemEventArgs ev)
    {
        if (ev.Item.Type != ItemType.Adrenaline && Plugin.Instance.Config.AdrenalinSpeedboost) return;
        ev.Player.ChangeEffectIntensity<MovementBoost>(Plugin.Instance.Config.SpeedIntensity, Plugin.Instance.Config.SpeedDuration);
    }
    public static void OnRespawningTeam(RespawningTeamEventArgs ev)
    {
        
        if(ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency && Plugin.Instance.Config.ChaosAnnouncement)
            Cassie.Message(Plugin.Instance.Config.ChaosSpawnMessage);
    }
    public static void UsingRadioBatter(UsingRadioBatteryEventArgs ev)
    {
        if(Plugin.Instance.Config.InfiniteRadio)
            ev.IsAllowed = false;
    }
    public static void OnRoundEnd(RoundEndedEventArgs ev)
    {
        if(!Plugin.Instance.Config.AutoFriendlyFireToggle) return;
        var roles = new List<RoleTypeId>()
        {
            RoleTypeId.Scientist,
            RoleTypeId.Tutorial,
            RoleTypeId.ChaosConscript,
            RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor,
            RoleTypeId.ChaosRifleman,
            RoleTypeId.ChaosConscript,
            RoleTypeId.ClassD,
            RoleTypeId.NtfCaptain,
            RoleTypeId.NtfPrivate,
            RoleTypeId.NtfSergeant,
            RoleTypeId.NtfSpecialist,
        };
        foreach (var player in Player.List)
        {
            foreach (var role in roles)
            {
                player.TryAddFriendlyFire(role, 1);
            }
        }


    }
}