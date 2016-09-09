using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XConceptTwo
{
    public partial class MainPage : ContentPage
    {
        private ExchangeRates exchangeRates;
        private ExchangesDolartoday exchangesRatesDolartoday;
        public MainPage()
        {
            InitializeComponent();
            Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),
                new Thickness(10),
                new Thickness(10));

            LoadPickers();
            LoadRates();

            convertButton.Clicked += ConvertButton_Clicked;
     
        }

        private async void ConvertButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(amountEntry.Text))
            {
                await DisplayAlert("Error", "Debes ingresar la cantidad a convertir", "Aceptar");
                return;
            }
            if (sourcePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Debes seleccionar la moneda origen", "Aceptar");
                return;
            }
            if (targetPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Debes seleccionar la moneda destino", "Aceptar");
                return;
            }
            decimal amount = decimal.Parse(amountEntry.Text);
            var sourceRate = GetRate(sourcePicker.SelectedIndex);
            var targetRate = GetRate(targetPicker.SelectedIndex);
            var amountConverted = amount / (decimal)sourceRate * (decimal)targetRate;

            convertedLabel.Text = string.Format("{0:N2} {1} = {2:N2} {3}", amount, sourcePicker.Items[sourcePicker.SelectedIndex],
                amountConverted, targetPicker.Items[targetPicker.SelectedIndex]);

        }

        private double GetRate(int index)
        {
            switch (index)
            {

                case 0: return exchangeRates.rates.AED;
                case 1: return exchangeRates.rates.AFN;
                case 2: return exchangeRates.rates.ALL;
                case 3: return exchangeRates.rates.AMD;
                case 4: return exchangeRates.rates.ANG;
                case 5: return exchangeRates.rates.AOA;
                case 6: return exchangeRates.rates.ARS;
                case 7: return exchangeRates.rates.AUD;
                case 8: return exchangeRates.rates.AWG;
                case 9: return exchangeRates.rates.AZN;
                case 10: return exchangeRates.rates.BAM;
                case 11: return exchangeRates.rates.BBD;
                case 12: return exchangeRates.rates.BDT;
                case 13: return exchangeRates.rates.BGN;
                case 14: return exchangeRates.rates.BHD;
                case 15: return exchangeRates.rates.BIF;
                case 16: return exchangeRates.rates.BMD;
                case 17: return exchangeRates.rates.BND;
                case 18: return exchangeRates.rates.BOB;
                case 19: return exchangeRates.rates.BRL;
                case 20: return exchangeRates.rates.BSD;
                case 21: return exchangeRates.rates.BTC;
                case 22: return exchangeRates.rates.BTN;
                case 23: return exchangeRates.rates.BWP;
                case 24: return exchangeRates.rates.BYN;
                case 25: return exchangeRates.rates.BYR;
                case 26: return exchangeRates.rates.BZD;
                case 27: return exchangeRates.rates.CAD;
                case 28: return exchangeRates.rates.CDF;
                case 29: return exchangeRates.rates.CHF;
                case 30: return exchangeRates.rates.CLF;
                case 31: return exchangeRates.rates.CLP;
                case 32: return exchangeRates.rates.CNY;
                case 33: return exchangeRates.rates.COP;
                case 34: return exchangeRates.rates.CRC;
                case 35: return exchangeRates.rates.CUC;
                case 36: return exchangeRates.rates.CUP;
                case 37: return exchangeRates.rates.CVE;
                case 38: return exchangeRates.rates.CZK;
                case 39: return exchangeRates.rates.DJF;
                case 40: return exchangeRates.rates.DKK;
                case 41: return exchangeRates.rates.DOP;
                case 42: return exchangeRates.rates.DZD;
                case 43: return exchangeRates.rates.EEK;
                case 44: return exchangeRates.rates.EGP;
                case 45: return exchangeRates.rates.ERN;
                case 46: return exchangeRates.rates.ETB;
                case 47: return exchangeRates.rates.EUR;
                case 48: return exchangeRates.rates.FJD;
                case 49: return exchangeRates.rates.FKP;
                case 50: return exchangeRates.rates.GBP;
                case 51: return exchangeRates.rates.GEL;
                case 52: return exchangeRates.rates.GGP;
                case 53: return exchangeRates.rates.GHS;
                case 54: return exchangeRates.rates.GIP;
                case 55: return exchangeRates.rates.GMD;
                case 56: return exchangeRates.rates.GNF;
                case 57: return exchangeRates.rates.GTQ;
                case 58: return exchangeRates.rates.GYD;
                case 59: return exchangeRates.rates.HKD;
                case 60: return exchangeRates.rates.HNL;
                case 61: return exchangeRates.rates.HRK;
                case 62: return exchangeRates.rates.HTG;
                case 63: return exchangeRates.rates.HUF;
                case 64: return exchangeRates.rates.IDR;
                case 65: return exchangeRates.rates.ILS;
                case 66: return exchangeRates.rates.IMP;
                case 67: return exchangeRates.rates.INR;
                case 68: return exchangeRates.rates.IQD;
                case 69: return exchangeRates.rates.IRR;
                case 70: return exchangeRates.rates.ISK;
                case 71: return exchangeRates.rates.JEP;
                case 72: return exchangeRates.rates.JMD;
                case 73: return exchangeRates.rates.JOD;
                case 74: return exchangeRates.rates.JPY;
                case 75: return exchangeRates.rates.KES;
                case 76: return exchangeRates.rates.KGS;
                case 77: return exchangeRates.rates.KHR;
                case 78: return exchangeRates.rates.KMF;
                case 79: return exchangeRates.rates.KPW;
                case 80: return exchangeRates.rates.KRW;
                case 81: return exchangeRates.rates.KWD;
                case 82: return exchangeRates.rates.KYD;
                case 83: return exchangeRates.rates.KZT;
                case 84: return exchangeRates.rates.LAK;
                case 85: return exchangeRates.rates.LBP;
                case 86: return exchangeRates.rates.LKR;
                case 87: return exchangeRates.rates.LRD;
                case 88: return exchangeRates.rates.LSL;
                case 89: return exchangeRates.rates.LTL;
                case 90: return exchangeRates.rates.LVL;
                case 91: return exchangeRates.rates.LYD;
                case 92: return exchangeRates.rates.MAD;
                case 93: return exchangeRates.rates.MDL;
                case 94: return exchangeRates.rates.MGA;
                case 95: return exchangeRates.rates.MKD;
                case 96: return exchangeRates.rates.MMK;
                case 97: return exchangeRates.rates.MNT;
                case 98: return exchangeRates.rates.MOP;
                case 99: return exchangeRates.rates.MRO;
                case 100: return exchangeRates.rates.MTL;
                case 101: return exchangeRates.rates.MUR;
                case 102: return exchangeRates.rates.MVR;
                case 103: return exchangeRates.rates.MWK;
                case 104: return exchangeRates.rates.MXN;
                case 105: return exchangeRates.rates.MYR;
                case 106: return exchangeRates.rates.MZN;
                case 107: return exchangeRates.rates.NAD;
                case 108: return exchangeRates.rates.NGN;
                case 109: return exchangeRates.rates.NIO;
                case 110: return exchangeRates.rates.NOK;
                case 111: return exchangeRates.rates.NPR;
                case 112: return exchangeRates.rates.NZD;
                case 113: return exchangeRates.rates.OMR;
                case 114: return exchangeRates.rates.PAB;
                case 115: return exchangeRates.rates.PEN;
                case 116: return exchangeRates.rates.PGK;
                case 117: return exchangeRates.rates.PHP;
                case 118: return exchangeRates.rates.PKR;
                case 119: return exchangeRates.rates.PLN;
                case 120: return exchangeRates.rates.PYG;
                case 121: return exchangeRates.rates.QAR;
                case 122: return exchangeRates.rates.RON;
                case 123: return exchangeRates.rates.RSD;
                case 124: return exchangeRates.rates.RUB;
                case 125: return exchangeRates.rates.RWF;
                case 126: return exchangeRates.rates.SAR;
                case 127: return exchangeRates.rates.SBD;
                case 128: return exchangeRates.rates.SCR;
                case 129: return exchangeRates.rates.SDG;
                case 130: return exchangeRates.rates.SEK;
                case 131: return exchangeRates.rates.SGD;
                case 132: return exchangeRates.rates.SHP;
                case 133: return exchangeRates.rates.SLL;
                case 134: return exchangeRates.rates.SOS;
                case 135: return exchangeRates.rates.SRD;
                case 136: return exchangeRates.rates.STD;
                case 137: return exchangeRates.rates.SVC;
                case 138: return exchangeRates.rates.SYP;
                case 139: return exchangeRates.rates.SZL;
                case 140: return exchangeRates.rates.THB;
                case 141: return exchangeRates.rates.TJS;
                case 142: return exchangeRates.rates.TMT;
                case 143: return exchangeRates.rates.TND;
                case 144: return exchangeRates.rates.TOP;
                case 145: return exchangeRates.rates.TRY;
                case 146: return exchangeRates.rates.TTD;
                case 147: return exchangeRates.rates.TWD;
                case 148: return exchangeRates.rates.TZS;
                case 149: return exchangeRates.rates.UAH;
                case 150: return exchangeRates.rates.UGX;
                case 151: return exchangeRates.rates.USD;
                case 152: return exchangeRates.rates.UYU;
                case 153: return exchangeRates.rates.UZS;
                case 154: return exchangeRates.rates.VEF;
                case 155: return exchangeRates.rates.VND;
                case 156: return exchangeRates.rates.VUV;
                case 157: return exchangeRates.rates.WST;
                case 158: return exchangeRates.rates.XAF;
                case 159: return exchangeRates.rates.XAG;
                case 160: return exchangeRates.rates.XAU;
                case 161: return exchangeRates.rates.XCD;
                case 162: return exchangeRates.rates.XDR;
                case 163: return exchangeRates.rates.XOF;
                case 164: return exchangeRates.rates.XPD;
                case 165: return exchangeRates.rates.XPF;
                case 166: return exchangeRates.rates.XPT;
                case 167: return exchangeRates.rates.YER;
                case 168: return exchangeRates.rates.ZAR;
                case 169: return exchangeRates.rates.ZMK;
                case 170: return exchangeRates.rates.ZMW;
                case 171: return exchangeRates.rates.ZWL;

                case 172: return exchangesRatesDolartoday.USD.transferencia;
                case 173: return exchangesRatesDolartoday.USD.transfer_cucuta;
                case 174: return exchangesRatesDolartoday.USD.efectivo;
                case 175: return exchangesRatesDolartoday.USD.efectivo_real;
                case 176: return exchangesRatesDolartoday.USD.efectivo_cucuta;
                case 177: return exchangesRatesDolartoday.USD.promedio;
                case 178: return exchangesRatesDolartoday.USD.promedio_real;
                case 179: return exchangesRatesDolartoday.USD.cencoex;
                case 180: return exchangesRatesDolartoday.USD.sicad1;
                case 181: return exchangesRatesDolartoday.USD.sicad2;
                case 182: return exchangesRatesDolartoday.USD.dolartoday;

                case 183: return exchangesRatesDolartoday.EUR.transferencia;
                case 184: return exchangesRatesDolartoday.EUR.transfer_cucuta;
                case 185: return exchangesRatesDolartoday.EUR.efectivo;
                case 186: return exchangesRatesDolartoday.EUR.efectivo_real;
                case 187: return exchangesRatesDolartoday.EUR.efectivo_cucuta;
                case 188: return exchangesRatesDolartoday.EUR.promedio;
                case 189: return exchangesRatesDolartoday.EUR.promedio_real;
                case 190: return exchangesRatesDolartoday.EUR.cencoex;
                case 191: return exchangesRatesDolartoday.EUR.sicad1;
                case 192: return exchangesRatesDolartoday.EUR.sicad2;
                case 193: return exchangesRatesDolartoday.EUR.dolartoday;

                case 194: return exchangesRatesDolartoday.COL.efectivo;
                case 195: return exchangesRatesDolartoday.COL.transfer;
                case 196: return exchangesRatesDolartoday.COL.compra;
                case 197: return exchangesRatesDolartoday.COL.venta;

                default: return 1;
            }
        }

        private async void LoadRates()
        {
            waitActivityIndicator.IsRunning = true;
            //Consumir el servicio
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://openexchangerates.org");
                var url = "/api/latest.json?app_id=c5ad6fcb983f45448075f48c7cfc32f0";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", response.StatusCode.ToString(), "Aceptar");
                    waitActivityIndicator.IsRunning = false;
                    convertButton.IsEnabled = false;
                    return;
                }
                var result = await response.Content.ReadAsStringAsync();
                exchangeRates = JsonConvert.DeserializeObject<ExchangeRates>(result);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
                waitActivityIndicator.IsRunning = false;
                convertButton.IsEnabled = false;
                return;
            }


            waitActivityIndicator.IsRunning = false;
            convertButton.IsEnabled = true;


            //Dolartoday

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://s3.amazonaws.com/dolartoday/data.json");
                var url = "https://s3.amazonaws.com/dolartoday/data.json";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Error", response.StatusCode.ToString(), "Aceptar");
                    waitActivityIndicator.IsRunning = false;
                    convertButton.IsEnabled = false;
                    return;
                }
                var result = await response.Content.ReadAsStringAsync();
                exchangesRatesDolartoday = JsonConvert.DeserializeObject<ExchangesDolartoday>(result);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
                waitActivityIndicator.IsRunning = false;
                convertButton.IsEnabled = false;
                return;
            }


            waitActivityIndicator.IsRunning = false;
            convertButton.IsEnabled = true;
        }

        private void LoadPickers()
        {
            LoadPicker(sourcePicker);
            LoadPicker(targetPicker);

        }

        private void LoadPicker(Picker picker)
        {



            picker.Items.Add("AED");
            picker.Items.Add("AFN");
            picker.Items.Add("ALL");
            picker.Items.Add("AMD");
            picker.Items.Add("ANG");
            picker.Items.Add("AOA");
            picker.Items.Add("ARS");
            picker.Items.Add("AUD");
            picker.Items.Add("AWG");
            picker.Items.Add("AZN");
            picker.Items.Add("BAM");
            picker.Items.Add("BBD");
            picker.Items.Add("BDT");
            picker.Items.Add("BGN");
            picker.Items.Add("BHD");
            picker.Items.Add("BIF");
            picker.Items.Add("BMD");
            picker.Items.Add("BND");
            picker.Items.Add("BOB");
            picker.Items.Add("BRL");
            picker.Items.Add("BSD");
            picker.Items.Add("BTC");
            picker.Items.Add("BTN");
            picker.Items.Add("BWP");
            picker.Items.Add("BYN");
            picker.Items.Add("BYR");
            picker.Items.Add("BZD");
            picker.Items.Add("CAD");
            picker.Items.Add("CDF");
            picker.Items.Add("CHF");
            picker.Items.Add("CLF");
            picker.Items.Add("CLP");
            picker.Items.Add("CNY");
            picker.Items.Add("COP");
            picker.Items.Add("CRC");
            picker.Items.Add("CUC");
            picker.Items.Add("CUP");
            picker.Items.Add("CVE");
            picker.Items.Add("CZK");
            picker.Items.Add("DJF");
            picker.Items.Add("DKK");
            picker.Items.Add("DOP");
            picker.Items.Add("DZD");
            picker.Items.Add("EEK");
            picker.Items.Add("EGP");
            picker.Items.Add("ERN");
            picker.Items.Add("ETB");
            picker.Items.Add("EUR");
            picker.Items.Add("FJD");
            picker.Items.Add("FKP");
            picker.Items.Add("GBP");
            picker.Items.Add("GEL");
            picker.Items.Add("GGP");
            picker.Items.Add("GHS");
            picker.Items.Add("GIP");
            picker.Items.Add("GMD");
            picker.Items.Add("GNF");
            picker.Items.Add("GTQ");
            picker.Items.Add("GYD");
            picker.Items.Add("HKD");
            picker.Items.Add("HNL");
            picker.Items.Add("HRK");
            picker.Items.Add("HTG");
            picker.Items.Add("HUF");
            picker.Items.Add("IDR");
            picker.Items.Add("ILS");
            picker.Items.Add("IMP");
            picker.Items.Add("INR");
            picker.Items.Add("IQD");
            picker.Items.Add("IRR");
            picker.Items.Add("ISK");
            picker.Items.Add("JEP");
            picker.Items.Add("JMD");
            picker.Items.Add("JOD");
            picker.Items.Add("JPY");
            picker.Items.Add("KES");
            picker.Items.Add("KGS");
            picker.Items.Add("KHR");
            picker.Items.Add("KMF");
            picker.Items.Add("KPW");
            picker.Items.Add("KRW");
            picker.Items.Add("KWD");
            picker.Items.Add("KYD");
            picker.Items.Add("KZT");
            picker.Items.Add("LAK");
            picker.Items.Add("LBP");
            picker.Items.Add("LKR");
            picker.Items.Add("LRD");
            picker.Items.Add("LSL");
            picker.Items.Add("LTL");
            picker.Items.Add("LVL");
            picker.Items.Add("LYD");
            picker.Items.Add("MAD");
            picker.Items.Add("MDL");
            picker.Items.Add("MGA");
            picker.Items.Add("MKD");
            picker.Items.Add("MMK");
            picker.Items.Add("MNT");
            picker.Items.Add("MOP");
            picker.Items.Add("MRO");
            picker.Items.Add("MTL");
            picker.Items.Add("MUR");
            picker.Items.Add("MVR");
            picker.Items.Add("MWK");
            picker.Items.Add("MXN");
            picker.Items.Add("MYR");
            picker.Items.Add("MZN");
            picker.Items.Add("NAD");
            picker.Items.Add("NGN");
            picker.Items.Add("NIO");
            picker.Items.Add("NOK");
            picker.Items.Add("NPR");
            picker.Items.Add("NZD");
            picker.Items.Add("OMR");
            picker.Items.Add("PAB");
            picker.Items.Add("PEN");
            picker.Items.Add("PGK");
            picker.Items.Add("PHP");
            picker.Items.Add("PKR");
            picker.Items.Add("PLN");
            picker.Items.Add("PYG");
            picker.Items.Add("QAR");
            picker.Items.Add("RON");
            picker.Items.Add("RSD");
            picker.Items.Add("RUB");
            picker.Items.Add("RWF");
            picker.Items.Add("SAR");
            picker.Items.Add("SBD");
            picker.Items.Add("SCR");
            picker.Items.Add("SDG");
            picker.Items.Add("SEK");
            picker.Items.Add("SGD");
            picker.Items.Add("SHP");
            picker.Items.Add("SLL");
            picker.Items.Add("SOS");
            picker.Items.Add("SRD");
            picker.Items.Add("STD");
            picker.Items.Add("SVC");
            picker.Items.Add("SYP");
            picker.Items.Add("SZL");
            picker.Items.Add("THB");
            picker.Items.Add("TJS");
            picker.Items.Add("TMT");
            picker.Items.Add("TND");
            picker.Items.Add("TOP");
            picker.Items.Add("TRY");
            picker.Items.Add("TTD");
            picker.Items.Add("TWD");
            picker.Items.Add("TZS");
            picker.Items.Add("UAH");
            picker.Items.Add("UGX");
            picker.Items.Add("USD");
            picker.Items.Add("UYU");
            picker.Items.Add("UZS");
            picker.Items.Add("VEF");
            picker.Items.Add("VND");
            picker.Items.Add("VUV");
            picker.Items.Add("WST");
            picker.Items.Add("XAF");
            picker.Items.Add("XAG");
            picker.Items.Add("XAU");
            picker.Items.Add("XCD");
            picker.Items.Add("XDR");
            picker.Items.Add("XOF");
            picker.Items.Add("XPD");
            picker.Items.Add("XPF");
            picker.Items.Add("XPT");
            picker.Items.Add("YER");
            picker.Items.Add("ZAR");
            picker.Items.Add("ZMK");
            picker.Items.Add("ZMW");
            picker.Items.Add("ZWL");
            
            //Dolar
            picker.Items.Add("USDtransferencia");
            picker.Items.Add("USDtransfer_cucuta");
            picker.Items.Add("USDefectivo");
            picker.Items.Add("USDefectivo_real");
            picker.Items.Add("USDefectivo_cucuta");
            picker.Items.Add("USDpromedio");
            picker.Items.Add("USDpromedio_real");
            picker.Items.Add("USDcencoex");
            picker.Items.Add("USDsicad1");
            picker.Items.Add("USDsicad2");
            picker.Items.Add("USDdolartoday");

            //Euros
            picker.Items.Add("EURtransferencia");
            picker.Items.Add("EURtransfer_cucuta");
            picker.Items.Add("EURefectivo");
            picker.Items.Add("EURefectivo_real");
            picker.Items.Add("EURefectivo_cucuta");
            picker.Items.Add("EURpromedio");
            picker.Items.Add("EURpromedio_real");
            picker.Items.Add("EURcencoex");
            picker.Items.Add("EURsicad1");
            picker.Items.Add("EURsicad2");
            picker.Items.Add("EURdolartoday");

            //Pesos
            picker.Items.Add("PESOSefectivo");
            picker.Items.Add("PESOStransfer");
            picker.Items.Add("PESOScompra");
            picker.Items.Add("PESOSventa");
            
         }
    }
}
