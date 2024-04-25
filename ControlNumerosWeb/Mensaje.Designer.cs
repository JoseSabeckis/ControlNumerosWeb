
namespace ControlNumerosWeb
{
    partial class ControlMensaje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMensaje));
            this.lblSalio = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParar = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSalio
            // 
            this.lblSalio.AutoSize = true;
            this.lblSalio.BackColor = System.Drawing.Color.White;
            this.lblSalio.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalio.Location = new System.Drawing.Point(23, 25);
            this.lblSalio.Name = "lblSalio";
            this.lblSalio.Size = new System.Drawing.Size(84, 35);
            this.lblSalio.TabIndex = 0;
            this.lblSalio.Text = "Salio:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(113, 22);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(154, 43);
            this.txtNumero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Se Reiniciara en Segundos";
            // 
            // btnParar
            // 
            this.btnParar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnParar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParar.Location = new System.Drawing.Point(54, 131);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(167, 35);
            this.btnParar.TabIndex = 3;
            this.btnParar.Text = "PARAR";
            this.btnParar.UseVisualStyleBackColor = false;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ControlMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(281, 178);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblSalio);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(297, 217);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 217);
            this.Name = "ControlMensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalio;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Timer timer;
    }
}