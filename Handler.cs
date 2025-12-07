using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace EscapeManager
{
    public class Handler
    {
        [Description("Когда игрок не связан")]
        public Dictionary<RoleTypeId, RoleTypeId> ReleasedRoles { get; set; } = new Dictionary<RoleTypeId, RoleTypeId>()
        {
            [RoleTypeId.FacilityGuard] = RoleTypeId.NtfSergeant
        };
        
        [Description("Когда игрок связан")]
        public Dictionary<RoleTypeId, RoleTypeId> DisarmedRoles { get; set; } = new Dictionary<RoleTypeId, RoleTypeId>()
        {
            [RoleTypeId.FacilityGuard] = RoleTypeId.ChaosRepressor
        };

        public void OnEscapingFromFacility(EscapingEventArgs ev)
        {
            if (ev.Player.IsCuffed && DisarmedRoles.TryGetValue(ev.Player.Role, out var role))
            {
                ev.NewRole = role;
                ev.EscapeScenario = EscapeScenario.CustomEscape;
                ev.IsAllowed = true;
            }
            else if (!ev.Player.IsCuffed && ReleasedRoles.TryGetValue(ev.Player.Role, out var role2))
            {
                ev.NewRole = role2;
                ev.EscapeScenario = EscapeScenario.CustomEscape;
                ev.IsAllowed = true;
            }
        }
    }
}