using Exiled.API.Features;
using System;
using Exiled.Events.Handlers;
using Map = Exiled.Events.Handlers.Map;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

public class Plugin : Plugin<Configs>
{
    public override Version RequiredExiledVersion { get; } = new Version(6, 2, 0);
    public override string Name { get; } = "Daylight Utils";
    public override string Author { get; } = "Tiliboyy";
    public override Version Version { get; } = new Version(1, 1, 0);
    public Eventhandlers EventHandlers { get; private set; }
    public static Plugin Instance;
    public override void OnEnabled()
    {
        Instance = this;
        EventHandlers = new Eventhandlers(this);
        Player.UsedItem += Eventhandlers.OnUsingItem;
        Server.RespawningTeam += Eventhandlers.OnRespawningTeam;
        Player.UsingRadioBattery += Eventhandlers.UsingRadioBatter;
        Server.RoundEnded += Eventhandlers.OnRoundEnd;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Server.RespawningTeam -= Eventhandlers.OnRespawningTeam;
        Player.UsedItem -= Eventhandlers.OnUsingItem;
        Player.UsingRadioBattery -= Eventhandlers.UsingRadioBatter;
        Server.RoundEnded -= Eventhandlers.OnRoundEnd;
        EventHandlers = null;
        Instance = null;
        base.OnDisabled();
    }
}
