using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle_balaca
{
    abstract class ScaleAdapter : IScaleAdapter
    {

        public int _port = 1;
        public int _baudRate = 9600;
        public int _parity = 1;

        public bool open(int port = 1)
        {
            return true;
        }

        public double read()
        {
            return 0;
        }

        public bool close()
        {
            return true;
        }

    }

}
