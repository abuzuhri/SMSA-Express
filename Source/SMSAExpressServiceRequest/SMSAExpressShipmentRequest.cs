using SMSAExpressServiceReference;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SMSAExpressServiceRequest
{
    interface ISMSAExpressShipmentRequest
    {
        Task<string> AddShipment(SMSAExpressShipmentSimple request);
        Task<string> AddShipment(SMSAExpressShipmentFullDetail request);
        Task<string> GetPDFAsync(string AWB);
    }
    public class SMSAExpressShipmentRequest : ISMSAExpressShipmentRequest
    {
        const string decimalFormate = "0.##";
        SMSAWebServiceIntlSoapClient client;
        string _passKey;
        public SMSAExpressShipmentRequest(string remoteAddres, string passKey)
        {
            _passKey = passKey;
            client = new SMSAWebServiceIntlSoapClient(SMSAWebServiceIntlSoapClient.EndpointConfiguration.SMSAWebServiceIntlSoap, remoteAddres);
        }
        public async Task<string> AddShipment(SMSAExpressShipmentSimple request)
        {
            request.IsValidRequest();

            return ValidateRequest(await client.addShipmentAsync(
                passKey: _passKey,
                    refNo: request.PackageDetail.ReferenceNo,
                    sentDate: DateTime.Now.ToShortDateString(),
                    idNo: request.PackageDetail.ReferenceNo,
                    cName: request.Customer.Name,
                    cntry: GetDescription(request.Customer.Country),
                    cCity: request.Customer.City,
                    cZip: request.Customer.Zip ?? String.Empty,
                    cPOBox: request.Customer.POBox ?? String.Empty,
                    cMobile: request.Customer.Mobile,
                    cTel1: request.Customer.Tel1 ?? String.Empty,
                    cTel2: request.Customer.Tel2 ?? String.Empty,
                    cAddr1: request.Customer.AddressLine1,
                    cAddr2: request.Customer.AddressLine2,
                    shipType: request.PackageDetail.ShipType.ToString(),
                    PCs: request.PackageDetail.NoOfPieces,
                    cEmail: request.Customer.Email ?? String.Empty,
                    carrValue: request.PackageDetail.CarriageValue.ToString(),
                    carrCurr: request.PackageDetail.Currency.ToString(),
                    codAmt: request.PackageDetail.CashOnDeliveryAmount.ToString(),
                    weight: request.PackageDetail.Weight.ToString(decimalFormate),
                    custVal: request.PackageDetail.CustomsValue.ToString(decimalFormate),
                    custCurr: request.PackageDetail.Currency.ToString(),
                    insrAmt: request.PackageDetail.InsuranceValue?.ToString(decimalFormate),
                    insrCurr: request.PackageDetail.Currency.ToString(),
                    itemDesc: request.PackageDetail.ItemDescription,
                    vatValue: request.PackageDetail.VatValue.ToString(decimalFormate),
                    harmCode: request.PackageDetail.HarmonizedCode ?? String.Empty
                ));
        }
        public async Task<string> AddShipment(SMSAExpressShipmentFullDetail request)
        {
            return "";
        }

        public async Task<string> GetPDFAsync(string AWB)
        {
            var path = Path.GetTempFileName().Replace(".tmp", ".pdf");
            var pdfByte = await client.getPDFAsync(AWB, _passKey);
            SaveByteArrayToFile(pdfByte.getPDFResult, path);
            return path;
        }
        public async Task<string> GetStatusAsync(string AWB)
        {
            return await client.getStatusAsync(AWB, _passKey);
        }
        private void SaveByteArrayToFile(byte[] data, string filePath) => File.WriteAllBytes(filePath, data);
        private string ValidateRequest(string response)
        {
            var errorMessage = "Failed :: ";
            if (response != null)
            {
                if (response.Contains(errorMessage))
                {
                    throw new SMSAExpressException(response);
                }
                else return response;
            }
            return null;
        }
        private static string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }
    }
}
