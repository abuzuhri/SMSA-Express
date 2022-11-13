namespace SMSAExpressServiceRequest
{
    public class SMSAExpressShipmentSimple
    {
        public SMSAExpressCustomer Customer { get; set; }
        public SMSAExpressPackageDetail PackageDetail { get; set; }

        public bool IsValidRequest()
        {
            if (Customer == null)
                throw new SMSAExpressException("Customer can't be empity");

            if (PackageDetail == null)
                throw new SMSAExpressException("PackageDetail can't be empity");

            Customer.IsValid();
            PackageDetail.IsValid();

            return true;
        }
    }
}
