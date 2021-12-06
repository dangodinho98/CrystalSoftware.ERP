using CrystalSoftware.ERP.Shared.Exceptions;
using CrystalSoftware.ERP.Shared.Resources;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace CrystalSoftware.ERP.Shared.Configuration
{
    public class ApplicationConfig
    {
        public DataBaseConfiguration Database { get; set; }
        public ApiConfiguration PersonApi { get; set; }
        public MailSettings EmailSettings { get; set; }


        public ApplicationConfig()
        {
            Database = new DataBaseConfiguration();
            PersonApi = new ApiConfiguration();
            EmailSettings = new MailSettings();
        }

        public void Validate()
        {
            ValidationResult validationResult = new ApplicationConfigValidation().Validate(this);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(c => c.ErrorMessage).ToList();

                //Log.Error("Configuration: Contains errors: {@errors}", errors);
                throw new ErrorConfigurationException(string.Join(",", errors));
            }
        }
    }

    public class ApplicationConfigValidation : AbstractValidator<ApplicationConfig>
    {
        public ApplicationConfigValidation()
        {
            RuleFor(config => config.Database).NotEmpty().WithMessage(Messages.DatabaseConfigurationNotFound);
            RuleFor(config => config.Database.ConnectionString).NotEmpty().WithMessage(Messages.DatabaseConfigurationNotFound);
            RuleFor(config => config.Database.DatabaseName).NotEmpty().WithMessage(Messages.DatabaseConfigurationNotFound);
            RuleFor(config => config.PersonApi).NotEmpty().WithMessage("Person api was not found");
            RuleFor(config => config.PersonApi.Url).NotEmpty().WithMessage("Person api was not found");
        }
    }

    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class ApiConfiguration
    {
        public string Url { get; set; }
    }

    public class MailSettings
    {
        public string EmailFrom { get; set; }
        public string EmailFromPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
