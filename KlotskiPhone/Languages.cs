using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlotskiPhone
{
    class Languages
    {

        private static string ZhImagePath = "Imageszh";
        private static string EnImagePath = "Images";

        public enum currentLanguage { zh, en };
        public static currentLanguage CurrentLang = currentLanguage.zh;

        public static string ImagePath
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return ZhImagePath;
                }
                return EnImagePath;
            }
        }

        public static string SureQuit
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "确认退出吗？";
                }
                return "Confirm Quit?";
            }
        }

        public static string SavePass
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "当前进度没保存";
                }
                return "Current pass Is't save";
            }
        }

        public static string TheDi
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "第";
                }
                return "";
            }
        }

        public static string Passes
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "关";
                }
                return "Level";
            }
        }

        public static string Steps
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "步数";
                }
                return "Steps";
            }
        }

        public static string congratulations
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "恭喜！";
                }
                return "Congratulations！";
            }
        }

        public static string Youvpass
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "您通过了第！";
                }
                return "You have pass the";
            }
        }

        public static string PassRecord
        {
            get
            {
                if (CurrentLang == currentLanguage.zh)
                {
                    return "通关记录！";
                }
                return "Passes";
            }
        }
    }
}
