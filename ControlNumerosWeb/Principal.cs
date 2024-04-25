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
        List<Estadistica> listaFinal;
        bool bandera = true;

        public Principal()
        {
            InitializeComponent();

            lista = new List<NumberControl>();
            listaSalidor = new List<Salidor>();
            listaFinal = new List<Estadistica>();

            ActualizarGrilla();
            ActualizarGrillaSalidores();
            GrillaFinal();
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
            BtnFinal.Enabled = false;

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
                    Colores();
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
            BtnFinal.Enabled = true;
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

        public void VerProbabilidades()
        {
            foreach (var item in listaSalidor)
            {

                var n = new Estadistica
                {
                    Numero = item.Numero,
                    Probabilidad = (listaSalidor.Count() * item.Salio).ToString("N4")
                };

                listaFinal.Add(n);

            }        
        }

        public void Colores()
        {
            int rojos = 0;
            int negros = 0;
            int ceros = 0;

            foreach (var item in listaSalidor)
            {
                var x = item.Numero;

                if (x == 3 || x == 1 || x == 5 || x == 9 || x == 7 || x == 12 || x == 14 ||
                    x == 18 || x == 16 || x == 21 || x == 19 || x == 23 || x == 27 || x == 25 || x == 30 ||
                    x == 32 || x == 36 || x == 34)
                {
                    rojos += item.Salio;
                }

                if (x == 2 || x == 6 || x == 4 || x == 8 || x == 11 || x == 10 || x == 15 ||
                    x == 13 || x == 17 || x == 20 || x == 24 || x == 22 || x == 26 || x == 29 || x == 28 ||
                    x == 33 || x == 31 || x == 35)
                {
                    negros += item.Salio;
                }

                if (x == 0)
                {
                    ceros += item.Salio;
                }

            }

            lblRojos.Text = $"Rojos: {rojos}";
            lblNegros.Text = $"Negros: {negros}";
            lblCero.Text = $"Ceros: {ceros}";

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

        private void BtnFinal_Click(object sender, EventArgs e)
        {
            VerProbabilidades();
            GrillaFinal();
        }

        public void GrillaFinal()
        {
            dgvGrillaEstadisticas.DataSource = listaFinal.ToList();
            dgvGrillaEstadisticas.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrillaEstadisticas.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrillaEstadisticas.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrillaEstadisticas.Columns["Probabilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrillaEstadisticas.Columns["Probabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrillaEstadisticas.Columns["Probabilidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
