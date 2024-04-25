using HtmlAgilityPack;
using ScrapySharp.Extensions;
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
    public partial class Principal : Form
    {
        HtmlWeb htmlWeb;
        List<NumberControl> lista;
        List<Salidor> listaSalidor;
        bool bandera = true;

        public Principal()
        {
            InitializeComponent();

            lista = new List<NumberControl>();
            listaSalidor = new List<Salidor>();

            ActualizarGrilla();
            ActualizarGrillaSalidores();
        }

        public void BanderaTrue()
        {
            bandera = true;
        }

        public void BanderaFalse()
        {
            bandera = false;
        }

        public bool MensajeControl()
        {
            if (string.IsNullOrEmpty(txtPaginaWeb.Text))
            {
                MessageBox.Show("Carga la Url de la web...", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
            return false;
        }

        private void btnControlar_Click(object sender, EventArgs e)
        {
            if (MensajeControl())
            {
                return;
            }

            btnControlar.Enabled = false;
            txtPaginaWeb.Enabled = false;
            nudSegundos.Enabled = false;

            lblTiempo.Text = "Control Repetitivo...";
            ControlRepetitivo();

            //

            /*
            foreach (var item in doc.DocumentNode.CssSelect("p"))
            {

                list.Add(item.InnerHtml);

            }

            dgvGrilla.DataSource = list.ToList();
            */
        }

        public void ControlRepetitivo()
        {
            do
            {
                string num = VerificarNumero();

                if (num != null)
                {
                    var form = new ControlMensaje(num, (int)nudSegundos.Value * 1000);
                    form.ShowDialog();

                    bandera = form.Bandera();

                    ActualizarGrilla();
                    ActualizarGrillaSalidores();
                }
                else
                {
                    bandera = false;
                }
                

            } while (bandera);      

            lblTiempo.Text = "...";
            btnControlar.Enabled = true;
            txtPaginaWeb.Enabled = true;
            nudSegundos.Enabled = true;
        }

        public string VerificarNumero()
        {
            htmlWeb = new HtmlWeb();
            string web = txtPaginaWeb.Text;

            try
            {
                HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load($"{web}");

                HtmlNode paso1 = doc.DocumentNode.CssSelect("p").First();

                string n1 = paso1.InnerHtml;

                txtEncontrado.Text = $"{n1}";//

                var n2 = Convert.ToInt64(n1);

                var num = new NumberControl
                {
                    Numero = n2,
                    Registro = lista.Count() + 1,
                };

                lista.Add(num);

                //Salidor
                AddSalidor(num);

                return n1;
            }
            catch
            {
                MessageBox.Show("Error Pagina Web...", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }

        public void AddSalidor(NumberControl sal)
        {
            var num = listaSalidor.FirstOrDefault(x => x.Numero == sal.Numero);

            if (num != null )
            {

                var update = listaSalidor.FirstOrDefault(x => x.Numero == sal.Numero);

                update.Salio++;

            }
            else
            {
                var n = new Salidor
                {
                    Salio = 1,
                    Numero = sal.Numero
                };

                listaSalidor.Add(n);
            }
            
        }

        public void Segundos()
        {
            Thread.Sleep(20000);
        }

        public void ActualizarGrilla()
        {      
            dgvGrilla.DataSource = lista.OrderByDescending(x => x.Registro).ToList();
            dgvGrilla.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Registro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Registro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
        }

        public void ActualizarGrillaSalidores()
        {
            dgvGrillaSalidores.DataSource = listaSalidor.OrderByDescending(x => x.Salio).ToList();

            dgvGrillaSalidores.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrillaSalidores.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrillaSalidores.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrillaSalidores.Columns["Salio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrillaSalidores.Columns["Salio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrillaSalidores.Columns["Salio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            /*
            if (MessageBox.Show("Seguro de Parar?..","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnStop.Enabled = false;
                btnControlar.Enabled = true;
                txtPaginaWeb.Enabled = true;
                BanderaFalse();

                lblTiempo.Text = ".";
            }    
            */   
        }

        private void lblAleatorio_Click(object sender, EventArgs e)
        {
            var random = new Random();

            var num = random.Next(0, (int)nudMax.Value);

            lblAleatorio.Text = $"{num} -";
        }
    }
}
