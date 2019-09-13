using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SGP
{
    class TestAdapter : IScaleAdapter
    {

        private double _abstractWeight = 0;

        private double getRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public bool open(int port = 0)
        {

            return true;

        }

        public int read()
        {

            double r;

            r = this.getRandomNumber(12330, 18950);

            /*while (r > this.abstractWeight)
                r = this.getRandomNumber(1250, 18950);*/

            return (int) r;
        }

        public bool close()
        {
            return true;
        }

    }

}
