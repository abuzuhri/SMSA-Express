using SMSAExpressServiceReference;
using System;
using System.Threading.Tasks;

namespace SMSAExpressServiceRequest
{
    interface ISMSAExpressShipmentRequest
    {
        Task<string> AddShipment(SMSAExpressShipmentSimple request);
        Task<string> AddShipment(SMSAExpressShipmentFullDetail request);
    }
    public class SMSAExpressShipmentRequest : ISMSAExpressShipmentRequest
    {
        SMSAWebServiceIntlSoapClient client;
        string _passKey;
        public SMSAExpressShipmentRequest(string remoteAddres, string passKey)
        {
            _passKey = passKey;
            client = new SMSAWebServiceIntlSoapClient(SMSAWebServiceIntlSoapClient.EndpointConfiguration.SMSAWebServiceIntlSoap, remoteAddres);
        }
        public async Task<string> AddShipment(SMSAExpressShipmentSimple request)
        {
            return await client.addShipmentAsync(
                passKey: _passKey,
                    refNo: request.PackageDetail.ReferenceNo,
                    sentDate: DateTime.Now.ToShortDateString(),
                    idNo: request.PackageDetail.ReferenceNo,
                    cName: request.Customer.Name,
                    cntry: request.Customer.Country,
                    cCity: request.Customer.City,
                    cZip: request.Customer.Zip,
                    cPOBox: request.Customer.POBox,
                    cMobile: request.Customer.Mobile,
                    cTel1: request.Customer.Tel1,
                    cTel2: request.Customer.Tel2,
                    cAddr1: request.Customer.AddressLine1,
                    cAddr2: request.Customer.AddressLine2,
                    shipType: request.PackageDetail.ShipType.ToString(),
                    PCs: request.PackageDetail.NoOfPieces,
                    cEmail: request.Customer.Email,
                    carrValue: request.PackageDetail.CarriageValue.ToString(),
                    carrCurr: request.PackageDetail.CarriageCurrency,
                    codAmt: request.PackageDetail.CashOnDeliveryAmount.ToString(),
                    weight: request.PackageDetail.Weight,
                    custVal: request.PackageDetail.CustomsValue,
                    custCurr: request.PackageDetail.CustomsCurrency,
                    insrAmt: request.PackageDetail.InsuranceValue,
                    insrCurr: request.PackageDetail.InsuranceCurrency,
                    itemDesc: request.PackageDetail.ItemDescription,
                    vatValue: request.PackageDetail.VatValue,
                    harmCode: request.PackageDetail.HarmonizedCode
                );
        }
        public async Task<string> AddShipment(SMSAExpressShipmentFullDetail request)
        {
            return "";
        }
        public async Task<string> GetStatusAsync(string AWB)
        {
            return await client.getStatusAsync(AWB, _passKey);
        }
    }
}
