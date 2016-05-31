using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KlotskiPhone
{
    public partial class Person : PhoneApplicationPage
    {
        public Person(String name, String imageUrl)
        {
            this.InitializeComponent();
            this.name = name;
            this.imageURL = imageUrl;
            changeBack(imageUrl);
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private String name;
        private String imageURL;
        private Driection direction;
        private Point startP;
        private Point endP;
        private Posotion positon;
        private int width, height;
        private bool isTryMove = false;


        public bool MOVE
        {
            get { return isTryMove; }
            set { isTryMove = value; }
        }

 


        public int WIDTH
        {
            get { return width; }
            set { width = value; }
        }

        public int HEIGHT
        {
            get { return height; }
            set { height = value; }
        }

        public Posotion Position
        {
            set
            {
                if (value != positon) { positon = value; }
            }
            get
            {
                return positon;
            }
        }

        public String ImageUrl
        {
            set { if (value != imageURL) imageURL = value; }
            get { return this.imageURL; }
        }


        public Driection Direction
        {
            set { if (value != this.direction) this.direction = value; }
            get { return this.direction; }
        }

        public Point SPoint
        {
            set { if (value != startP) startP = value; }
            get { return startP; }
        }

        public Point EPoint
        {
            set { if (value != endP) endP = value; }
            get { return endP; }
        }

        private void changeBack(String url)
        {
            ImageBrush imageBrushScroll = new ImageBrush();
            imageBrushScroll.ImageSource = new BitmapImage(new Uri(Languages.ImagePath+"/" + url + ".JPG", UriKind.RelativeOrAbsolute));
            personbackground.Background = imageBrushScroll;
        }
    }
}