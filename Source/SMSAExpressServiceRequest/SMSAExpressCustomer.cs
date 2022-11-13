namespace SMSAExpressServiceRequest
{
    public class SMSAExpressCustomer
    {
        public string Name { get; set; }
        public Countries Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string POBox { get; set; }
        public string Mobile { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Email { get; set; }



        public bool IsValid()
        {
            if (Name == null)
                throw new SMSAExpressException("Customer Name can't be empity");
            if (Country == Countries.NOTSET)
                throw new SMSAExpressException("Customer Country can't be empity or not set");
            if (City == null)
                throw new SMSAExpressException("Customer City can't be empity");
            if (Mobile == null)
                throw new SMSAExpressException("Customer Mobile can't be empity");
            if (Mobile.Length < 9)
                throw new SMSAExpressException("Customer Mobile Must be at least 9 digits");
            if (AddressLine1 == null)
                throw new SMSAExpressException("Customer AddressLine1 can't be empity");
            if (AddressLine2 == null)
                throw new SMSAExpressException("Customer AddressLine2 can't be empity");


            return true;
        }

    }
}
