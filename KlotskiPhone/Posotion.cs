using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlotskiPhone
{
    public class Posotion
    {
        private int xPosition;
        private int yPosition;

        public Posotion(int x, int y)
        {
            this.xPosition = x;
            this.yPosition = y;
        }

        public int getXPosition()
        {
            return xPosition;
        }
        public void setXPosition(int x)
        {
            this.xPosition = x;
        }

        public void setYPosition(int y)
        {
            this.yPosition = y;
        }

        public int getYPosition()
        {
            return yPosition;
        }
    }
}
