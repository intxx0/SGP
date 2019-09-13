using System;
using System.Windows.Forms;
using System.Configuration;

namespace SGP
{
    public class Scale
    {

        private IScaleAdapter _adapter;

        public Scale()
        {
            string adapter = ConfigurationManager.AppSettings["Scale_Adapter"].ToString();
            int port = Convert.ToInt16(ConfigurationManager.AppSettings["Scale_Port"]);

            Type type = Type.GetType("SGP." + adapter);

            if (type != null)
            {
                this._adapter = (IScaleAdapter)Activator.CreateInstance(type);
                this._adapter.open(port);
            }
        }

        public void init()
        {
            if (this._adapter != null)
            {

                double weight;

                while (true)
                {

                    weight = (double) this._adapter.read();

                    if (frmPesagem.typeWeight == 1)
                    {
                        frmPesagem.GetChild().txtPesoBruto.Invoke((MethodInvoker)delegate
                        {
                            frmPesagem.GetChild().txtPesoBruto.Text = Convert.ToString(weight);
                            frmPesagem.GetChild().weight = Convert.ToString(weight);
                        });
                    }
                    else if (frmPesagem.typeWeight == 2)
                    {
                        frmPesagem.GetChild().txtPesoBruto.Invoke((MethodInvoker)delegate
                        {

                            int pesoBruto = Convert.ToInt32(frmPesagem.GetChild().txtPesoBruto.Text.ToString());
                            int pesoLiquido = pesoBruto - ((int)weight);

                            frmPesagem.GetChild().txtPesoTara.Text = Convert.ToString((int)weight);
                            frmPesagem.GetChild().txtPesoLiquido.Text = Convert.ToString(pesoLiquido);

                        });
                    }

                    System.Threading.Thread.Sleep(1000);

                }

            }

        }

    }
}