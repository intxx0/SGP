using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGP
{
    interface IScaleAdapter
    {

        bool open(int port);
        int read();
        bool close();

    }
}
