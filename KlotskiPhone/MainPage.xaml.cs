using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;
using MSNADSDK.AD;

namespace KlotskiPhone
{
    public partial class MainPage : PhoneApplicationPage
    {

        private PersonViewModel pvw;
        public bool isAdObvious = false;
        public bool isRequrest = false;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            Languages.CurrentLang = Languages.currentLanguage.zh;
            PassData.init();
            IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
            
            //for (int i = 0; i < 18; i++)
            //{
            //    if (localSettings.Contains("passover" + (i + 1)))
            //    {
            //        String str = textRecord.Text;
            //        textRecord.Text = str + "\n第 " + (i + 1) + " 关：  " + localSettings["passover" + (i + 1)] + " 步";
            //        // "\n第 " + pass + " 关：  " + step.SStep + " 步"
            //    }
            //}

            if (localSettings.Contains("currentpass"))
            {
                PersonViewModel.pass = (int)localSettings["currentpass"];
            }

            pvw = new PersonViewModel(this);
        }


        public TextBlock getTextStep()
        {
            return textStep;
        }

        public TextBlock getTextPass()
        {
            return textPass;
        }


        public Canvas getMainCanvas()
        {
            return mainCanvas;
        }
         protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)  
        {

            if (pvw.SSStep > 0)
            {

                if (MessageBox.Show(Languages.SureQuit, Languages.SavePass, MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;//操作取消
                }
                else
                {
                    while (NavigationService.BackStack.Any())
                        NavigationService.RemoveBackEntry();
                    this.IsHitTestVisible = this.IsEnabled = false;
                    if (this.ApplicationBar != null)
                    {
                        foreach (var item in this.ApplicationBar.Buttons.OfType<ApplicationBarIconButton>())
                        {
                            item.IsEnabled = false;
                        }
                    }
                }
            }
        }

        private void back_click(object sender, EventArgs e)
        {
            pvw.goLastStep();
        }

        private void refresh_click(object sender, EventArgs e)
        {
            PersonViewModel.istry = true;
            pvw.setPeopleSize();
            PersonViewModel.istry = false;
        }

        private void next_click(object sender, EventArgs e)
        {
            pvw.goToNextStep();
        }

        private void record(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Record_Information.xaml", UriKind.Relative));
        }



        private void ad_AdRequestSuccessEvent(object sender, MSNADSDK.AD.AdRequestStatesEventArgs args)
        {

        }

        private void ad_AdRequestErrorEvent(object sender, MSNADSDK.AD.AdRequestStatesEventArgs args)
        {

        }

        private void AdView_Loaded(object sender, RoutedEventArgs e)
        {

        }



      /*  string defaultAppid = "143244";
        string defaultAdId = "147904";
        string defaultIntersitialAdId = "100004";
        string defaultSerectKey = "a5706d385b5540699b195aa4d39a6872";*/

        string defaultAppid = "143284";
        string defaultAdId = "147940";
       // string defaultIntersitialAdId = "100004";
        string defaultSerectKey = "2bef3c27eb39419f95c9de73862bbd1b";


        public  void startAD()
        {
            AdView adView = new AdView();

            adView.Appid = defaultAppid;
            adView.SecretKey = defaultSerectKey;

           /* if (btn.Name == "requestbtn2")
            {
                adView.SizeForAd = AdSize.Small;
                adView.Adid = defaultAdId;
            }*/
                adView.SizeForAd = AdSize.Large;
                adView.Adid = defaultAdId;
            /*else
            {

                adView.SizeForAd = AdSize.Large;
                adView.IsInterstitial = true;
                adView.Adid = defaultIntersitialAdId;
            }*/



            adView.TelCapability = true;

            adArea.Children.Clear();
            adArea.Children.Add(adView);


            adView.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            adView.LogOutput += adView_LogOutput;
            adView.AdRequestSuccessEvent += adView_AdRequestSuccessEvent;
            adView.AdRequestErrorEvent += adView_AdRequestErrorEvent;
            adView.AdSdkExceptionEvent += adView_AdSdkExceptionEvent;

        }

        void adView_AdSdkExceptionEvent(object sender, ADExceptionEventArgs e)
        {
            //txt.Text = "广告请求异常, " + e.SDKDescription;
            isRequrest = false;
        }

        void adView_LogOutput(object sender, EventArgs e)
        {
            LogEventArgs logArgs = e as LogEventArgs;

           // txt.Text = logArgs.Log;
        }

        void adView_AdRequestErrorEvent(object sender, AdRequestStatesEventArgs args)
        {
            string msg = args.Msg;
          //  txt.Text = "广告请求失败, " + msg;
            isRequrest = false;
        }

        void adView_AdRequestSuccessEvent(object sender, AdRequestStatesEventArgs args)
        {
           // txt.Text = "广告请求成功";
            isAdObvious = true;
        }
    }
}