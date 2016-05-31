using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KlotskiPhone
{
    class PassData
    {
        public static int passes = 18;
        public static List<Pass> passList = new List<Pass>();
        public static Boolean[] rectangleUsing = new Boolean[20];
        public static int MoveAllCount = 0;

        public static void init()
        {
            for (int i = 1; i <= passes; i++)
            {
                passList.Add(new Pass(getPass(i), i - 1, 0));
            }
            initRect();
            //passList.Where((Pass=>Pass.Index==1));
        }

        public static void initRect()
        {
            for (int i = 0; i < rectangleUsing.Length; i++)
            {
                rectangleUsing[i] = true;

            }
        }

        public static int[][] getPass(int i)
        {
            int[][] pass = null;
            switch (i)
            {
                case 1:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {1,0 }, new int[2] {3,0 }, new int[2] {0,2 }, new int[2] {1,2},
                        new int[2] {3,2 }, new int[2] {0,4 }, new int[2] {1,3 }, new int[2] {2,3 }, new int[2] {3,4 }
                     };
                    break;
                case 2:
                    pass = new int[10][]{
                        new int[2] {0,2 }, new int[2] {0,0 }, new int[2] {2,2 }, new int[2] {2,0 }, new int[2] {1,3},
                        new int[2] {3,0 }, new int[2] {0,4 }, new int[2] {0,3 }, new int[2] {3,3 }, new int[2] {3,4 }
                     };
                    break;
                case 3:
                    pass = new int[10][]{
                        new int[2] {1,2 }, new int[2] {1,0 }, new int[2] {0,0 }, new int[2] {0,2 }, new int[2] {1,3},
                        new int[2] {3,0 }, new int[2] {0,4 }, new int[2] {3,2 }, new int[2] {3,3 }, new int[2] {3,4 }
                     };
                    break;
                case 4:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {1,1 }, new int[2] {2,0 }, new int[2] {0,1 }, new int[2] {1,3},
                        new int[2] {3,1 }, new int[2] {0,4 }, new int[2] {0,3 }, new int[2] {3,3 }, new int[2] {3,4 }
                     };
                    break;

                case 5:
                    pass = new int[10][]{
                        new int[2] {0,2 }, new int[2] {1,0 }, new int[2] {1,3 }, new int[2] {2,3 }, new int[2] {1,2},
                        new int[2] {3,2 }, new int[2] {0,0 }, new int[2] {0,1 }, new int[2] {3,0 }, new int[2] {3,1 }
                     };
                    break;
                case 6:
                    pass = new int[10][]{
                        new int[2] {1,2 }, new int[2] {1,0 }, new int[2] {1,3 }, new int[2] {0,1 }, new int[2] {1,4},
                        new int[2] {3,1 }, new int[2] {0,0 }, new int[2] {0,3 }, new int[2] {3,0 }, new int[2] {3,3 }
                     };
                    break;
                case 7:
                    pass = new int[10][]{
                        new int[2] {0,1 }, new int[2] {2,0 }, new int[2] {0,2 }, new int[2] {0,4 }, new int[2] {2,2},
                        new int[2] {2,3 }, new int[2] {0,0 }, new int[2] {1,0 }, new int[2] {2,4 }, new int[2] {3,4 }
                     };
                    break;
                case 8:
                    pass = new int[10][]{
                        new int[2] {2,0 }, new int[2] {0,0 }, new int[2] {2,1 }, new int[2] {0,2 }, new int[2] {2,2},
                        new int[2] {1,2 }, new int[2] {0,4 }, new int[2] {2,3 }, new int[2] {3,3 }, new int[2] {3,4 }
                     };
                    break;

                case 9:
                    pass = new int[10][]{
                        new int[2] {0,3 }, new int[2] {0,0 }, new int[2] {2,3 }, new int[2] {0,4 }, new int[2] {2,4},
                        new int[2] {3,0 }, new int[2] {2,0 }, new int[2] {2,1 }, new int[2] {0,2 }, new int[2] {1,2 }
                     };
                    break;
                case 10:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {1,1 }, new int[2] {3,0 }, new int[2] {3,2 }, new int[2] {1,3},
                        new int[2] {0,3 }, new int[2] {1,0 }, new int[2] {2,0 }, new int[2] {0,2 }, new int[2] {3,4 }
                     };
                    break;
                case 11:
                    pass = new int[10][]{
                        new int[2] {0,2 }, new int[2] {0,0 }, new int[2] {2,2 }, new int[2] {0,3 }, new int[2] {2,3},
                        new int[2] {3,0 }, new int[2] {0,4 }, new int[2] {3,4 }, new int[2] {2,0 }, new int[2] {2,1 }
                     };
                    break;
                case 12:
                    pass = new int[10][]{
                        new int[2] {0,4 }, new int[2] {1,0 }, new int[2] {0,1 }, new int[2] {1,2 }, new int[2] {2,4},
                        new int[2] {3,1 }, new int[2] {0,0 }, new int[2] {0,3 }, new int[2] {3,0 }, new int[2] {3,3 }
                     };
                    break;


                case 13:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {1,0 }, new int[2] {3,0 }, new int[2] {0,3 }, new int[2] {1,2},
                        new int[2] {3,3 }, new int[2] {0,2 }, new int[2] {1,3 }, new int[2] {2,3 }, new int[2] {3,2 }
                     };
                    break;
                case 14:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {2,0 }, new int[2] {0,1 }, new int[2] {0,2 }, new int[2] {2,2},
                        new int[2] {0,3 }, new int[2] {1,4 }, new int[2] {2,3 }, new int[2] {0,4 }, new int[2] {3,3 }
                     };
                    break;
                case 15:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {2,0 }, new int[2] {0,1 }, new int[2] {0,2 }, new int[2] {2,2},
                        new int[2] {3,3 }, new int[2] {0,3 }, new int[2] {0,4 }, new int[2] {2,3 }, new int[2] {2,4 }
                     };
                    break;
                case 16:
                    pass = new int[10][]{
                        new int[2] {0,2 }, new int[2] {0,0 }, new int[2] {2,2 }, new int[2] {0,3 }, new int[2] {2,3},
                        new int[2] {1,4 }, new int[2] {2,0 }, new int[2] {3,0 }, new int[2] {3,1 }, new int[2] {2,1 }
                     };
                    break;

                case 17:
                    pass = new int[10][]{
                        new int[2] {1,2 }, new int[2] {1,0 }, new int[2] {0,0 }, new int[2] {0,2 }, new int[2] {1,3},
                        new int[2] {3,2 }, new int[2] {0,4 }, new int[2] {3,0 }, new int[2] {3,1 }, new int[2] {3,4 }
                     };
                    break;
                case 18:
                    pass = new int[10][]{
                        new int[2] {0,0 }, new int[2] {1,2 }, new int[2] {3,0 }, new int[2] {0,2 }, new int[2] {1,1},
                        new int[2] {3,2 }, new int[2] {0,4 }, new int[2] {1,0 }, new int[2] {2,0 }, new int[2] {3,4 }
                     };
                    break;
            }

            return pass;
        }


        public static void setPssses(int[][] pos, int i, int step)
        {
            Pass pass = new Pass(pos, i, step);
            if (passList.Count > i)
            {
                passList.RemoveAt(i);
                passList.Insert(i, pass);
            }
            else
            {
                passList.Add(pass);
            }
        }

        public static int[] getPeopleList(int i)
        {
            int[] people = null;
            switch (i)
            {
                case 1:
                    people = new int[12] { 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 2:
                    people = new int[12] { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 3:
                    people = new int[12] { 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 4:
                    people = new int[12] { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 5:
                    people = new int[12] { 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 6:
                    people = new int[12] { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 7:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 4 };
                    break;
                case 8:
                    people = new int[12] { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 9:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 4 };
                    break;
                case 10:
                    people = new int[12] { 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 11:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 4 };
                    break;
                case 12:
                    people = new int[12] { 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;

                case 13:
                    people = new int[12] { 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 14:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 4 };
                    break;
                case 15:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 4 };
                    break;
                case 16:
                    people = new int[12] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 4 };
                    break;
                case 17:
                    people = new int[12] { 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
                case 18:
                    people = new int[12] { 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 4 };
                    break;
            }
            return people;
        }

        public static Boolean getRectBool(int posX,int posY)
        {
            return rectangleUsing[posY * 4 + posX];
        }

        public static void setRectBool(int posX, int posY,Boolean isnull)
        {
            rectangleUsing[posY * 4 + posX] = isnull;
        }

 


        public class Pass
        {
            private int[][] passList;
            private int index;
            private int step;

            public Pass(int[][] passList, int index, int step)
            {
                this.passList = passList;
                this.index = index;
                this.step = step;
            }

            public int[][] PassList
            {
                get { return passList; }
                set { if (value != passList) passList = value; }
            }

            public int Index
            {
                get { return index; }
                set { if (value != index)index = value; }
            }

            public int Step
            {
                get { return step; }
                set { if (value != index)step = value; }
            }
        }
    }
}
