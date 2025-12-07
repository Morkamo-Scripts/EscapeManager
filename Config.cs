using Exiled.API.Interfaces;

namespace EscapeManager
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        
        public Handler Handler { get; set; } = new Handler();
    }
}