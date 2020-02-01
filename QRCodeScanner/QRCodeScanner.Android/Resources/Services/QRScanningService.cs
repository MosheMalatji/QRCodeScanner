using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QRCodeScanner.QR_Service;
using ZXing.Mobile;
using System.Threading.Tasks;

[assembly: Dependency(typeof(QRCodeScanner.Droid.Resources.Services.QRScanningService))]

namespace QRCodeScanner.Droid.Resources.Services
{
    public class QRScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
            TopText = "Scan the QR Code",
            BottomText = "Please Wait"
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}