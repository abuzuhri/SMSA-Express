// See https://aka.ms/new-console-template for more information
using SMSAExpressServiceRequest;

Console.WriteLine("Hello, World!");


SMSAExpressShipmentRequest smsaExpressShipmentRequest = new
    SMSAExpressShipmentRequest("http://track.smsaexpress.com/SECOM/SMSAwebServiceIntl.asmx", "2222");

var dd = await smsaExpressShipmentRequest.GetStatusAsync("999");

var data = await smsaExpressShipmentRequest.AddShipment(
    new SMSAExpressShipmentSimple
    {
        Customer = new SMSAExpressCustomer
        {
            Name = "ABC",
            Country = "KSA",
            City = "ALR",
            Mobile = "00188393783944",
            AddressLine1 = "111111",
            AddressLine2 = "333333",

        },
        PackageDetail = new SMSAExpressPackageDetail
        {
            ReferenceNo = "AA",
            Weight = "0.50",
            VatValue = "0",
            CustomsValue = "1",
            CustomsCurrency = "SA",
        }
    });

