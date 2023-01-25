using System.ComponentModel;
using Exiled.API.Interfaces;
[Serializable]
public class Configs : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
    [Description("Adrenalin Speedboost")]
    public bool AdrenalinSpeedboost = true;
    public float SpeedDuration { get; set; } = 5;
    public byte SpeedIntensity = 50;
    [Description("Chaos Announcement")]
    public bool ChaosAnnouncement = true;
    public string ChaosSpawnMessage { get; set; } = "CHAOSINSURGENCY WAS DETECTED OUTSIDE THE FACILITY";
    [Description("Auto FriendlyFire Toggle")]
    public bool AutoFriendlyFireToggle { get; set; } = true;

    [Description("Infinite Radio")] public bool InfiniteRadio { get; set; } = false;

}