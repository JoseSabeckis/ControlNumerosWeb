using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlNumerosWeb
{
    public partial class ControlMensaje : Form
    {
        bool bandera = true;

        public ControlMensaje(string num, int segundos)
        {
            InitializeComponent();

            timer.Interval = segundos;

            txtNumero.Text = num;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            bandera = false;            
            this.Close();
        }

        public bool Bandera()
        {
            return bandera;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bandera = true;
            this.Close();
        }
    }
}
