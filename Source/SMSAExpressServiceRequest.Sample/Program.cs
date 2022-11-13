// See https://aka.ms/new-console-template for more information
using SMSAExpressServiceRequest;

Console.WriteLine("Hello, World!");


SMSAExpressShipmentRequest smsaExpressShipmentRequest = new
    SMSAExpressShipmentRequest("http://track.smsaexpress.com/SECOM/SMSAwebServiceIntl.asmx", "Testing2");

//var dd = await smsaExpressShipmentRequest.GetStatusAsync("999");

var data = await smsaExpressShipmentRequest.AddShipment(
    new SMSAExpressShipmentSimple
    {
        Customer = new SMSAExpressCustomer
        {
            Name = "Wejdan Hassan",
            Country = Countries.SA,
            City = "As Salamah, Jeddah, Makkah",
            Mobile = "+9665539200000",
            AddressLine1 = "As salamh",
            AddressLine2 = "Nahdt ash sharq Building 8, Floor 5, apartment 170"

        },
        PackageDetail = new SMSAExpressPackageDetail
        {
            ReferenceNo = "402-0000-000000000-3",
            Weight = 0.50M,
            VatValue = 0,
            CustomsValue = 175.00M,
            Currency = CurrencyCodes.SAR,
            NoOfPieces = 1,
            ItemDescription = "Kerastase Densifique Bain Densite",
            InsuranceValue = 0,
        }
    });

var data2 = await smsaExpressShipmentRequest.GetPDFAsync(data);
Console.WriteLine(data.ToString());