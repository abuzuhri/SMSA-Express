# SMSA Express API C#  [![.NET](https://github.com/abuzuhri/SMSA-Express/actions/workflows/dotnet.yml/badge.svg)](https://github.com/abuzuhri/SMSA-Express/actions/workflows/dotnet.yml) [![NuGet](https://img.shields.io/nuget/v/SMSA-Express-Service.svg)](https://www.nuget.org/packages/SMSA-Express-Service/)


---
## Installation [![NuGet](https://img.shields.io/nuget/v/SMSA-Express-Service.svg)](https://www.nuget.org/packages/SMSA-Express-Service/)

```powershell
Install-Package SMSA-Express-Service
```


### Configuration
```CSharp

SMSAExpressShipmentRequest smsaExpressShipmentRequest = new
    SMSAExpressShipmentRequest("http://track.smsaexpress.com/SECOM/SMSAwebServiceIntl.asmx", "Testing2");

```

### Sample how to create new shipment
```CSharp
var data = await smsaExpressShipmentRequest.AddShipment(
    new SMSAExpressShipmentSimple
    {
        Customer = new SMSAExpressCustomer
        {
            Name = "Wejdan Hassan",
            Country = Countries.SA,
            City = "XXXXX",
            Mobile = "+9999999999999",
            AddressLine1 = "Line  1",
            AddressLine2 = "Line 2"

        },
        PackageDetail = new SMSAExpressPackageDetail
        {
            ReferenceNo = "402-0000-000000000-3",
            Weight = 0.50M,
            VatValue = 0,
            CustomsValue = 175.00M,
            Currency = CurrencyCodes.SAR,
            NoOfPieces = 1,
            ItemDescription = "ABC with BAC",
            InsuranceValue = 0,
        }
    });

```




