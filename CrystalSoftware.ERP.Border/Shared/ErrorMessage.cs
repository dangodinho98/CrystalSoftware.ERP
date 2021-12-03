namespace CrystalSoftware.ERP.Border.Shared
{
    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ErrorMessage()
        {
            Code = string.Empty;
            Message = string.Empty;
        }

        public ErrorMessage(string code)
        {
            Code = code;
            Message = string.Empty;
        }

        public ErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
