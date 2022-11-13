namespace SMSAExpressServiceRequest
{
    public class SMSAExpressShipmentFullDetail
    {
        public SMSAExpressCustomer Customer { get; set; }
        public SMSAExpressShipper Shipper { get; set; }
        public SMSAExpressPackageDetail PackageDetail { get; set; }
        public SMSAExpressDeliveryDetail DeliveryDetail { get; set; }

    }
}
