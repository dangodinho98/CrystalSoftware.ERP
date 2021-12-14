using System;

namespace CrystalSoftware.ERP.Border.Dto.Account
{
    public class GetAccountFiltersRequest
    {
        public DateTime? CreationDateStart { get; set; }
        public DateTime? CreationDateEnd { get; set; }
    }
}
