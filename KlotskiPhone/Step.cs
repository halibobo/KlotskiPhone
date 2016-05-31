using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlotskiPhone
{
    class Step
    {
        private int index;
        private int step;
       

        public Step(int index)
        {
            this.index = index;
        }
        public int SStep
        {
            set
            {
                if (value != step)
                {
                    PassData.MoveAllCount++;
                    step = value;
                }
            }

            get
            {
               
                return step;
            }
        }
    }
}
