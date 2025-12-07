using System;
using Exiled.API.Features;
using events = Exiled.Events.Handlers;

namespace EscapeManager
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override string Author => "Morkamo";
        public override string Name => nameof(EscapeManager);
        public override string Prefix => Name;
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 1, 0);

        public Handler Handler;
        
        public override void OnEnabled()
        {
            Instance = this;
            Handler = Config.Handler;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Handler = null;
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            events.Player.Escaping += Handler.OnEscapingFromFacility;
        }

        private void UnregisterEvents()
        {
            events.Player.Escaping -= Handler.OnEscapingFromFacility;
        }
    }
}