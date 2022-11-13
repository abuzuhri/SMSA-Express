namespace SMSAExpressServiceRequest
{
    public class SMSAExpressPackageDetail
    {
        public string ReferenceNo { get; set; }
        public SMSAExpressShipType ShipType { get; set; }
        public int NoOfPieces { get; set; }
        public int CarriageValue { get; set; }
        public string CarriageCurrency { get; set; }
        public int CashOnDeliveryAmount { get; set; }
        public string Weight { get; set; }
        public string CustomsValue { get; set; }
        public string CustomsCurrency { get; set; }
        public string InsuranceValue { get; set; }
        public string InsuranceCurrency { get; set; }
        public string ItemDescription { get; set; }
        public string VatValue { get; set; }
        public string HarmonizedCode { get; set; }

    }
}
