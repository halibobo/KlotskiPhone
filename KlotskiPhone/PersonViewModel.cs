using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace KlotskiPhone
{
    class PersonViewModel
    {
        private List<Person> people;
        private Canvas mainCanvas;
        private int personSmallWidth = 110;
        public static int pass = 1;
        private int[][] passes;
        private int[] initPersonList;
        private MainPage mvp;
        private TextBlock textStep;
        private TextBlock textPass;
        private Step step;
        public static Boolean istry;
        private int stepsRecord = 0;
        //private TextBlock textPassRecord;

       

        public PersonViewModel(MainPage mvp)
        {
            this.mvp = mvp;
            this.mainCanvas = mvp.getMainCanvas();
            textStep = mvp.getTextStep();
            textPass = mvp.getTextPass();
            init();
            addPersons();
            setPeopleSize();            
        }

        public int SSStep
        {
            get
            {
                return step.SStep;
            }
        }

        private void init()
        {
            stepsRecord = PassData.passList[pass - 1].Step;
            passes = PassData.passList[pass - 1].PassList;
            initPersonList = PassData.getPeopleList(pass);
            textPass.Text = Languages.TheDi + pass + Languages.Passes;
        }

        public void addPersons()
        {
            if (people != null)
            {
                people.Clear();
            }
            people = new List<Person>();


            for (int i = 0; i < initPersonList.Length; i++)
            {
                if (initPersonList[i] == 1)
                {
                    switch (i + 1)
                    {
                        case 1:
                            people.Add(new Person("张飞竖", "zhangfei_s"));
                            break;
                        case 2:
                            people.Add(new Person("张飞", "zhangfei_h"));
                            break;
                        case 3:
                            people.Add(new Person("曹操", "caocao"));
                            break;
                        case 4:
                            people.Add(new Person("赵云竖", "zhaoyun_s"));
                            break;
                        case 5:
                            people.Add(new Person("赵云", "zhaoyun_h"));
                            break;
                        case 6:
                            people.Add(new Person("马超竖", "machao_s"));
                            break;
                        case 7:
                            people.Add(new Person("马超", "machao_h"));
                            break;
                        case 8:
                            people.Add(new Person("关羽竖", "guanyu_s"));
                            break;
                        case 9:
                            people.Add(new Person("关羽", "guanyu"));
                            break;
                        case 10:
                            people.Add(new Person("黄忠竖", "huangzhong_s"));
                            break;
                        case 11:
                            people.Add(new Person("黄忠", "huangzhong_h"));
                            break;
                        case 12:
                            people.Add(new Person("士兵", "bing"));
                            break;
                    }
                }
                else if (initPersonList[i] != 0)
                {
                    for (int j = 0; j < initPersonList[i]; j++)
                    {
                        people.Add(new Person("士兵", "bing"));
                    }
                }
            }
        }

        /*****/
        public void setPeopleSize()
        {
            PassData.initRect();
            initPeopleInfo();
        }

        private void initPeopleInfo()
        {
            clearPeople();
            for (int i = 0; i < people.Count; i++)
            {
                switch (people[i].Name)
                {
                    case "曹操":
                        people[i].Width = personSmallWidth * 2;
                        people[i].Height = personSmallWidth * 2;
                        people[i].WIDTH = 2;
                        people[i].HEIGHT = 2;
                        break;
                    case "关羽":
                    case "马超":
                    case "张飞":
                    case "赵云":
                    case "黄忠":
                        people[i].Width = personSmallWidth * 2;
                        people[i].Height = personSmallWidth;
                        people[i].WIDTH = 2;
                        people[i].HEIGHT = 1;
                        break;
                    case "张飞竖":
                    case "赵云竖":
                    case "马超竖":
                    case "关羽竖":
                    case "黄忠竖":
                        people[i].Width = personSmallWidth;
                        people[i].Height = personSmallWidth * 2;
                        people[i].WIDTH = 1;
                        people[i].HEIGHT = 2;
                        break;
                    case "士兵":
                        people[i].Width = personSmallWidth;
                        people[i].Height = personSmallWidth;
                        people[i].WIDTH = 1;
                        people[i].HEIGHT = 1;
                        break;
                }
                if (istry)
                {
                    passes = PassData.getPass(pass);
                    stepsRecord = 0;
                }
                people[i].Position = new Posotion(passes[i][0], passes[i][1]);
                int personX = people[i].Position.getXPosition();
                int personY = people[i].Position.getYPosition();
                Canvas.SetLeft(people[i], personX * personSmallWidth);
                Canvas.SetTop(people[i], personY * personSmallWidth);
                mainCanvas.Children.Add(people[i]);
                for (int x = personX; x < personX + people[i].WIDTH; x++)
                {
                    for (int y = personY; y < personY + people[i].HEIGHT; y++)
                    {
                        PassData.setRectBool(x, y, false);
                    }
                }
                people[i].ManipulationStarted += PersonViewModel_ManipulationStarted;
                people[i].ManipulationCompleted += PersonViewModel_ManipulationCompleted;
                step = new Step(pass)
                {
                    SStep = stepsRecord
                };
                textStep.Text =Languages.Steps+" :"+ step.SStep.ToString();
            }
        }

        void PersonViewModel_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            Person p = sender as Person;

            if (p.MOVE)
            {
                p.MOVE = false;
                e.Handled = true;
                return;
            }

            p.EPoint = new Point(e.ManipulationOrigin.X,e.ManipulationOrigin.Y);
            double x = p.EPoint.X - p.SPoint.X;
            double y = p.EPoint.Y - p.SPoint.Y;
            if (getTrueValue(x) >= getTrueValue(y))
            {
                if (x > 0)
                {
                    p.Direction = Driection.right;
                }
                else
                {
                    p.Direction = Driection.left;
                }
            }
            else
            {
                if (y > 0)
                {
                    p.Direction = Driection.down;
                }
                else
                {
                    p.Direction = Driection.up;
                }
            }

            if (checkDir(p))
            {
                move(p);
            }

            //for (int i = 0; i < PassData.rectangleUsing.Length; i++)
            //{
            //    Debug.WriteLine(PassData.rectangleUsing[i].ToString());
            //}
        }

        private void PersonViewModel_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            Person p = sender as Person;
            int count = 0;
            p.MOVE = false;
            Driection dir= Driection.now;
            if (checkDir(p, Driection.up))
            {
                count++;
                dir = Driection.up;
            }
            if (checkDir(p, Driection.down))
            {
                count++;
                dir = Driection.down;
            }
            if (checkDir(p, Driection.left))
            {
                count++;
                dir = Driection.left;
            }
            if (checkDir(p, Driection.right))
            {
                count++;
                dir = Driection.right;
            }
            if (count == 1)
            {
                p.Direction = dir;
                move(p);
                p.MOVE = true;
            }
            else if (count == 0)
            {
                p.MOVE = true;
            }
            else
            {
                p.SPoint = new Point(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
                e.Handled = true;
                Debug.WriteLine("x =" + p.Position.getXPosition() + " y =" + p.Position.getYPosition());
            }
        }

        private void clearPeople()
        {
            for (int i = 0; i < people.Count; i++)
            {
                people[i].ManipulationStarted -= PersonViewModel_ManipulationStarted;
                people[i].ManipulationCompleted -= PersonViewModel_ManipulationCompleted;
            }
            mainCanvas.Children.Clear();
        }

        public void goToNextStep()
        {
            if (pass < PassData.passes)
            {
                int[][] passes = new int[10][];
                for (int i = 0; i < people.Count; i++)
                {
                    passes[i] = new int[2] { people[i].Position.getXPosition(), people[i].Position.getYPosition() };
                }
                PassData.setPssses(passes, pass - 1, step.SStep);
                pass++;
                init();
                addPersons();
                setPeopleSize();
                IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
                localSettings["currentpass"] = PersonViewModel.pass;
            }
            else
            {
               // MainPage.addToastContent("已经是最后一关了");
            }
        }

        public void goLastStep()
        {
            if (pass > 1)
            {
                int[][] passes = new int[10][];
                for (int i = 0; i < people.Count; i++)
                {
                    passes[i] = new int[2] { people[i].Position.getXPosition(), people[i].Position.getYPosition() };
                }
                PassData.setPssses(passes, pass - 1, step.SStep);
                pass--;
                init();
                addPersons();
                setPeopleSize();
                IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
                localSettings["currentpass"] = PersonViewModel.pass;
            }
            else
            {
               // MainPage.addToastContent("已经是第一关了");
            }
        }


        public void move(Person p)
        {
            int xPos = p.Position.getXPosition();
            int yPos = p.Position.getYPosition();
            switch (p.Direction)
            {
                case Driection.up:
                    if (p.WIDTH == 1)
                    {
                        Canvas.SetTop(p, Canvas.GetTop(p) - personSmallWidth);
                        step.SStep++;
                        p.Position.setYPosition(p.Position.getYPosition() - 1);
                        PassData.setRectBool(xPos, yPos-1,false);
                        PassData.setRectBool(xPos, yPos+p.HEIGHT - 1, true);
                    }
                    else
                    {
                        Canvas.SetTop(p, Canvas.GetTop(p) - personSmallWidth);
                        step.SStep++;
                        p.Position.setYPosition(p.Position.getYPosition() - 1);
                        PassData.setRectBool(xPos, yPos - 1, false);
                        PassData.setRectBool(xPos + 1, yPos - 1, false);
                        PassData.setRectBool(xPos, yPos + p.HEIGHT - 1, true);
                        PassData.setRectBool(xPos + 1, yPos + p.HEIGHT - 1, true);
                    }
                    break;
                case Driection.down:
                    if (p.WIDTH == 1)
                    {
                        Canvas.SetTop(p, Canvas.GetTop(p) + personSmallWidth);
                        step.SStep++;
                        p.Position.setYPosition(p.Position.getYPosition() + 1);
                        PassData.setRectBool(xPos, yPos + p.HEIGHT, false);
                        PassData.setRectBool(xPos, yPos , true);
                    }
                    else
                    {
                        Canvas.SetTop(p, Canvas.GetTop(p) + personSmallWidth);
                        p.Position.setYPosition(p.Position.getYPosition() + 1);
                        step.SStep++;
                        PassData.setRectBool(xPos, yPos + p.HEIGHT, false);
                        PassData.setRectBool(xPos + 1, yPos + p.HEIGHT, false);
                        PassData.setRectBool(xPos, yPos , true);
                        PassData.setRectBool(xPos + 1, yPos, true);
                    }
                    break;
                case Driection.left:
                    //if (Canvas.GetLeft(p) > 0)
                    //{
                    //    Canvas.SetLeft(p, Canvas.GetLeft(p) - personSmallWidth);
                    //    p.Position.setXPosition(xPos - 1);
                    //    step.SStep++;
                    //}
                    if (p.HEIGHT == 1)
                    {
                        Canvas.SetLeft(p, Canvas.GetLeft(p) - personSmallWidth);
                        p.Position.setXPosition(xPos - 1);
                        step.SStep++;
                        PassData.setRectBool(xPos - 1, yPos, false);
                        PassData.setRectBool(xPos + p.WIDTH - 1, yPos, true);
                    }
                    else
                    {
                        Canvas.SetLeft(p, Canvas.GetLeft(p) - personSmallWidth);
                        p.Position.setXPosition(xPos - 1);
                        step.SStep++;
                        PassData.setRectBool(xPos - 1, yPos, false);
                        PassData.setRectBool(xPos - 1, yPos+1, false);
                        PassData.setRectBool(xPos + p.WIDTH - 1, yPos, true);
                        PassData.setRectBool(xPos + p.WIDTH - 1, yPos+1, true);
                    }

                    break;
                case Driection.right:
                    //if (Canvas.GetLeft(p) + p.Width < mainCanvas.Width)
                    //{
                    //    Canvas.SetLeft(p, Canvas.GetLeft(p) + personSmallWidth);
                    //    p.Position.setXPosition(xPos + 1);
                    //    step.SStep++;
                    //}
                    if (p.HEIGHT == 1)
                    {
                        Canvas.SetLeft(p, Canvas.GetLeft(p) + personSmallWidth);
                        p.Position.setXPosition(xPos + 1);
                        step.SStep++;
                        PassData.setRectBool(xPos + p.WIDTH, yPos, false);
                        PassData.setRectBool(xPos, yPos, true);
                    }
                    else
                    {
                        Canvas.SetLeft(p, Canvas.GetLeft(p) + personSmallWidth);
                        p.Position.setXPosition(xPos + 1);
                        step.SStep++;
                        PassData.setRectBool(xPos + p.WIDTH, yPos, false);
                        PassData.setRectBool(xPos + p.WIDTH, yPos + 1, false);
                        PassData.setRectBool(xPos, yPos, true);
                        PassData.setRectBool(xPos, yPos+1, true);
                    }
                    break;
            }

            textStep.Text = Languages.Steps+"：" + step.SStep.ToString();

            if (p.Name == "曹操" && p.Position.getXPosition() == 1 && p.Position.getYPosition() == 3)
            {
                //String str = textPassRecord.Text;
                // String storestr = "\n第 " + pass + " 关：  " + step.SStep + " 步";
                IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
                if (localSettings.Contains("passover" + pass))
                {
                    int leastValue = (int)localSettings["passover" + pass];
                    localSettings["passover" + pass] = step.SStep < leastValue ? step.SStep : leastValue;
                }
                else
                {
                    localSettings["passover" + pass] = step.SStep;
                }

                //textPassRecord.Text = str + "\n第 " + pass + " 关：  " + step.SStep + " 步";
                //MessageBox.Show("恭喜过关");

                SHowToast(Languages.congratulations,"您通过了第"+pass+Languages.Passes+"；"+Languages.Steps+"："+step.SStep);
                setPeopleSize();
                /*MessageBoxResult msgRst = MessageBox.Show("恭喜过关", "提示", MessageBoxButton.OK);
                if (msgRst == MessageBoxResult.Cancel)
                {
                }
                else
                {
                   setPeopleSize();
                }*/
            }

            if (!mvp.isAdObvious &&!mvp.isRequrest && step.SStep > 1)
            {
                if ((PassData.MoveAllCount / 40) % 2 == 0)
                {
                    mvp.startAD();
                }
                else
                {
                 //   mvp.hideAD();
                }
                mvp.isRequrest = true;
            }
        }


        public bool checkDir(Person p)
        {
            int xPos = p.Position.getXPosition();
            int yPos = p.Position.getYPosition();
            Driection dir = p.Direction;
            switch (dir)
            {
                case Driection.up:
                    if (yPos <= 0)
                    {
                        return false;
                    }
                    if (p.WIDTH == 1)
                    {
                        if (PassData.getRectBool(xPos, yPos-1))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos, yPos - 1) && PassData.getRectBool(xPos + 1, yPos - 1))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.down:
                     if (yPos+p.HEIGHT >= 5)
                    {
                        return false;
                    }
                    if (p.WIDTH == 1)
                    {
                        if (PassData.getRectBool(xPos, yPos + p.HEIGHT))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos, yPos + p.HEIGHT) && PassData.getRectBool(xPos + 1, yPos + p.HEIGHT))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.left:
                     if (xPos <= 0)
                    {
                        return false;
                    }

                    if (p.HEIGHT == 1)
                    {
                        if (PassData.getRectBool(xPos - 1, yPos))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos - 1, yPos) && PassData.getRectBool(xPos - 1, yPos+1))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.right:
                    if (xPos+p.WIDTH >= 4)
                    {
                        return false;
                    }
                    if (p.HEIGHT == 1)
                    {
                        if (PassData.getRectBool(xPos + p.WIDTH, yPos))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos + p.WIDTH, yPos) && PassData.getRectBool(xPos + p.WIDTH, yPos + 1))
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }

        public bool checkDir(Person p,Driection dir)
        {
            int xPos = p.Position.getXPosition();
            int yPos = p.Position.getYPosition();
            switch (dir)
            {
                case Driection.up:
                    if (yPos <= 0)
                    {
                        return false;
                    }
                    if (p.WIDTH == 1)
                    {
                        if (PassData.getRectBool(xPos, yPos - 1))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos, yPos - 1) && PassData.getRectBool(xPos + 1, yPos - 1))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.down:
                    if (yPos + p.HEIGHT >= 5)
                    {
                        return false;
                    }
                    if (p.WIDTH == 1)
                    {
                        if (PassData.getRectBool(xPos, yPos + p.HEIGHT))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos, yPos + p.HEIGHT) && PassData.getRectBool(xPos + 1, yPos + p.HEIGHT))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.left:
                    if (xPos <= 0)
                    {
                        return false;
                    }

                    if (p.HEIGHT == 1)
                    {
                        if (PassData.getRectBool(xPos - 1, yPos))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos - 1, yPos) && PassData.getRectBool(xPos - 1, yPos + 1))
                        {
                            return true;
                        }
                    }
                    break;
                case Driection.right:
                    if (xPos + p.WIDTH >= 4)
                    {
                        return false;
                    }
                    if (p.HEIGHT == 1)
                    {
                        if (PassData.getRectBool(xPos + p.WIDTH, yPos))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (PassData.getRectBool(xPos + p.WIDTH, yPos) && PassData.getRectBool(xPos + p.WIDTH, yPos + 1))
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }


        private double getTrueValue(double d)
        {
            if (d < 0)
            {
                d = -d;
            }
            return d;
        }


        private void SHowToast(string title,string cont)
        {
            var toast = new ToastPrompt
            {
                Title = title,
                Message = cont,
            };
            toast.Show();
        }
    }

    
}
