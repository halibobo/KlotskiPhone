using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace KlotskiPhone
{
    public partial class Record_Information : PhoneApplicationPage
    {
        public Record_Information()
        {
            InitializeComponent();
            PassRecord.Text = Languages.PassRecord;
            IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
            for (int i = 0; i < 18; i++)
            {
                if (localSettings.Contains("passover" + (i + 1)))
                {
                    if (Languages.CurrentLang == Languages.currentLanguage.zh)
                    {
                        string str = textStep.Text;
                        textStep.Text = str + "\n第 " + (i + 1) + " 关：  " + localSettings["passover" + (i + 1)] + " 步";
                        // "\n第 " + pass + " 关：  " + step.SStep + " 步"
                    }
                    else
                    {
                        string str = textStep.Text;
                        string lastStr = "th";
                        string pass = (i + 1 == 1 ? "passes" : "pass");
                        switch (i + 1)
                        {
                            case 1:
                                lastStr = "st";
                                break;
                            case 2:
                                lastStr = "nd";
                                break;
                            case 3:
                                lastStr = "rd";
                                break;
                        }
                        textStep.Text = str + "\n The " + (i + 1) + lastStr + " Pass：  " + localSettings["passover" + (i + 1)] + " " + pass;
                    }
                }
            }
        }
    }
}