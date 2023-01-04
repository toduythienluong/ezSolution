using System;
namespace ezApiStrategy.Message
{
    public class TaxReturn : ModelBase
    {
        public int TaxReturnId { get; set; }
        public string TaxReturnName { get; set; }
        public string TaxYear { get; set; }
    }

    public class TurboTaxDataFile : ModelBase
    {
        public string TurboTaxDataFileId { get; set; }
        public Dictionary<string, string> DataFields { get; set; }
    }
    public class CloneTaxReturnResponse
    {
        public int ClonedTaxReturnId { get; set; }
    }

    public class CloneTaxReturnRequest
    {
        public int TaxReturnIdToClone { get; set; }
        public int TurboTaxDataFileDataId { get; set; }
        public string TaxYear { get; set; }
        public Dictionary<string, string> Options { get; set; }
    }

    public class StartTaxReturnRequest
    {
        public int UserId { get; set; }
        public int TaxYear { get; set; }
    }

    public class StartTaxReturnResponse
    {
        public int StartedTaxReturnId { get; set; }
    }
}

