using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CrystalSoftware.ERP.Shared.Resources
{
    public class MessageResource : IMessageResource
    {
        private readonly IStringLocalizer _localizer;

        public MessageResource(IStringLocalizerFactory factory)
        {
            var type = typeof(Messages);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Messages", assemblyName.Name);
        }

        private static MessageResource _instance = null;
        public static MessageResource Instance
        {
            get
            {
                if (_instance is null)
                {
                    var options = Options.Create(new LocalizationOptions { ResourcesPath = "Resources" });
                    var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
                    _instance = new MessageResource(factory);
                }

                return _instance;
            }
        }
    }
}