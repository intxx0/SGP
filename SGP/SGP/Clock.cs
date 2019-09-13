using System;
using System.Windows.Forms;

namespace SGP
{
    public class Clock
    {

        private static string dtPattern = @"dd/MM/yyyy";
        private static string hrPattern = @"hh:mm:ss";

        public static DateTime dateTime;

        public void init()
        {

            while (true)
            {

                Clock.dateTime = DateTime.Now;

                frmPesagem.GetChild().lblHora.Invoke((MethodInvoker)delegate {
                    frmPesagem.GetChild().lblData.Text = Clock.dateTime.ToString(Clock.getDate());
                    frmPesagem.GetChild().lblHora.Text = Clock.dateTime.ToString(Clock.getTime());
                });

                System.Threading.Thread.Sleep(1000);

            }

        }

        public static string getDate()
        {

            Clock.dateTime = DateTime.Now;
            return Clock.dateTime.ToString(Clock.dtPattern);

        }

        public static string getTime()
        {

            Clock.dateTime = DateTime.Now;
            return Clock.dateTime.ToString(Clock.hrPattern);

        }

    }
}