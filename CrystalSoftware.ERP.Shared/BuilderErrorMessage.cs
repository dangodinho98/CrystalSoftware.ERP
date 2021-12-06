using CrystalSoftware.ERP.Border.Shared;
using System.Linq;

namespace CrystalSoftware.ERP.Shared
{
    public static class BuilderErrorMessage
    {
        public static ErrorMessage Build(string message)
        {
            var structureMessage = message.Split('|').ToList();

            if (structureMessage.Count < 2)
                structureMessage.Insert(0, "000");

            var errorCode = structureMessage[0].Trim();
            var errorMessage = structureMessage[1].Trim();

            return new ErrorMessage
            {
                Code = errorCode,
                Message = errorMessage
            };
        }
    }
}
