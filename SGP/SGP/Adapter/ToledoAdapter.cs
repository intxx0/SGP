using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGP
{
    abstract class ToledoAdapter : IScaleAdapter
    {

        public int _port = 1;
        public int _baudRate = 9600;
        public int _parity = 1;

        public bool open(int port = 1)
        {
            return true;
        }

        public int read()
        {
            return 0;
        }

        public bool close()
        {
            return true;
        }

    }

}
