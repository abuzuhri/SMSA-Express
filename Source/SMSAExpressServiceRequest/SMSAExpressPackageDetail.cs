namespace SMSAExpressServiceRequest
{
    public class SMSAExpressPackageDetail
    {
        public string ReferenceNo { get; set; }
        public SMSAExpressShipType ShipType { get; set; }
        public int NoOfPieces { get; set; }
        public int CarriageValue { get; set; }
        public int CashOnDeliveryAmount { get; set; }
        public decimal Weight { get; set; }
        public decimal CustomsValue { get; set; }
        public CurrencyCodes Currency { get; set; }
        public decimal? InsuranceValue { get; set; }
        public string ItemDescription { get; set; }
        public decimal VatValue { get; set; }
        public string HarmonizedCode { get; set; }

        public bool IsValid()
        {
            if (NoOfPieces <= 0)
                throw new SMSAExpressException("Package NoOfPieces can't be zero or less");
            if (string.IsNullOrEmpty(ReferenceNo))
                throw new SMSAExpressException("Package ReferenceNo can't be empty");
            if (Weight <= 0)
                throw new SMSAExpressException("Package Weight can't be zero or less");
            if (VatValue < 0)
                throw new SMSAExpressException("Package VatValue can't be zero or less");
            if (CustomsValue <= 0)
                throw new SMSAExpressException("Package CustomsValue can't be zero or less");
            if (Currency == CurrencyCodes.NOTSET)
                throw new SMSAExpressException("Package CustomsCurrency can't be empty or not set");
            if (string.IsNullOrEmpty(ItemDescription))
                throw new SMSAExpressException("Package ItemDescription can't be empity");


            return true;
        }

    }
}
