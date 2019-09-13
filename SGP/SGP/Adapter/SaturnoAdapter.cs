using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SGP
{
    class SaturnoAdapter : IScaleAdapter
    {

        public int _port = 1;
        public int _baudRate = 9600;
        public int _parity = 1;

        public bool open(int port = 1)
        {

            /*var method = this.GetType().GetMethod("AbreCom" + Convert.ToString(port));

            if (method != null)
                return false;

            this._port = port;

            System.Windows.Forms.MessageBox.Show("success");

            method.Invoke(null, null);
            return true;*/

            double r;

            if (port < 1 && port > 4)
                return false;

            switch (port)
            {
                case 1:
                    r = SaturnoAdapter.AbreCom1();
                    break;
                case 2:
                    r = SaturnoAdapter.AbreCom2();
                    break;
                case 3:
                    r = SaturnoAdapter.AbreCom3();
                    break;
                case 4:
                    r = SaturnoAdapter.AbreCom4();
                    break;
            }

            this._port = port;

            return true;

        }

        public int read()
        {
            double r = 0;

            if (this._port == 1) {
                r = SaturnoAdapter.LePeso1();
            } else if(this._port==2) {
                r = SaturnoAdapter.LePeso2();
            } else if(this._port==3) {
                r = SaturnoAdapter.LePeso3();
            } else if (this._port == 4) {
                r = SaturnoAdapter.LePeso4();
            }

            return (int) r;

        }

        public bool close()
        {
            return true;
        }

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double AbreCom1();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double AbreCom2();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double AbreCom3();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double AbreCom4();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double FechaCom1();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double FechaCom2();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double FechaCom3();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double FechaCom4();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double LePeso1();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double LePeso2();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double LePeso3();

        [DllImport("PesoSaturno_v11.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern double LePeso4();

    }

}
