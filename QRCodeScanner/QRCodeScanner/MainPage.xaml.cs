using QRCodeScanner.QR_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRCodeScanner
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender,EventArgs e)
        {
            try
            {
                var ScannerPage = new ZXingScannerPage();
                ScannerPage.OnScanResult += (result) =>
                {
                    ScannerPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() =>
                    {

                        Navigation.PopModalAsync();
                        txtBarcode.Text = result.Text;
                    });
                };

                await Navigation.PushModalAsync(ScannerPage);
               
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void btnOpenUri_Clicked(object sender, EventArgs e)
        {
            
            Device.OpenUri(new Uri(txtBarcode.Text));
        }
    }
}
