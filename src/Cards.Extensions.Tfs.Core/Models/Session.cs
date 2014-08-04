using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Models
{
    public class Session
    {
        public string DisplayName { get; set; }
        public string WindowsIdentityName { get; set; }

        public ITFSProvider TFSProvider { get; protected set; }

        public Session(ITFSProvider tfsProvider)
        {
            TFSProvider = tfsProvider;
        }

        public Session()
            : this(new TFSProvider())
        { }

        public Session CreateSession(string windowsIdentityName)
        {
            return new Session(this.TFSProvider)
            {
                WindowsIdentityName = windowsIdentityName,
                DisplayName = getTFSDisplayName(windowsIdentityName)
            };
        }

        private string getTFSDisplayName(string windowsIdentityName)
        {
            return TFSProvider.GetTFSDisplayName(windowsIdentityName);
        }
    }
}
