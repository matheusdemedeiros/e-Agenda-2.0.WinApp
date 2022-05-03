namespace e_Agenda.WinApp.Telas_Compromissos
{
    partial class TelaListagemCompromissos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFiltrarPeriodo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.tabControlCompromissos = new System.Windows.Forms.TabControl();
            this.tabPageCompromissosFuturos = new System.Windows.Forms.TabPage();
            this.dateTimePickerHoraFimPeriodo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraInicioPeriodo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataFimPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDataInicioPeriodo = new System.Windows.Forms.DateTimePicker();
            this.listCompromissosFuturos = new System.Windows.Forms.ListBox();
            this.tabPageCompromissosPassados = new System.Windows.Forms.TabPage();
            this.listCompromissosPassados = new System.Windows.Forms.ListBox();
            this.btnCompromissosSemana = new System.Windows.Forms.Button();
            this.btnCompromissosDia = new System.Windows.Forms.Button();
            this.tabControlCompromissos.SuspendLayout();
            this.tabPageCompromissosFuturos.SuspendLayout();
            this.tabPageCompromissosPassados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.BackColor = System.Drawing.Color.White;
            this.btnInserir.Location = new System.Drawing.Point(258, 10);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(111, 28);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(369, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 28);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(480, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(111, 28);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnFiltrarPeriodo
            // 
            this.btnFiltrarPeriodo.BackColor = System.Drawing.Color.White;
            this.btnFiltrarPeriodo.Location = new System.Drawing.Point(591, 10);
            this.btnFiltrarPeriodo.Name = "btnFiltrarPeriodo";
            this.btnFiltrarPeriodo.Size = new System.Drawing.Size(111, 28);
            this.btnFiltrarPeriodo.TabIndex = 3;
            this.btnFiltrarPeriodo.Text = "Filtrar por período";
            this.btnFiltrarPeriodo.UseVisualStyleBackColor = false;
            this.btnFiltrarPeriodo.Click += new System.EventHandler(this.btnFiltrarPeriodo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(61, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compromissos";
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.BackColor = System.Drawing.Color.White;
            this.btnLimparFiltro.Location = new System.Drawing.Point(702, 10);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(111, 28);
            this.btnLimparFiltro.TabIndex = 7;
            this.btnLimparFiltro.Text = "Limpar filtro";
            this.btnLimparFiltro.UseVisualStyleBackColor = false;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // tabControlCompromissos
            // 
            this.tabControlCompromissos.Controls.Add(this.tabPageCompromissosFuturos);
            this.tabControlCompromissos.Controls.Add(this.tabPageCompromissosPassados);
            this.tabControlCompromissos.Location = new System.Drawing.Point(15, 44);
            this.tabControlCompromissos.Name = "tabControlCompromissos";
            this.tabControlCompromissos.SelectedIndex = 0;
            this.tabControlCompromissos.Size = new System.Drawing.Size(1024, 347);
            this.tabControlCompromissos.TabIndex = 8;
            this.tabControlCompromissos.SelectedIndexChanged += new System.EventHandler(this.tabControlCompromissos_SelectedIndexChanged);
            // 
            // tabPageCompromissosFuturos
            // 
            this.tabPageCompromissosFuturos.Controls.Add(this.dateTimePickerHoraFimPeriodo);
            this.tabPageCompromissosFuturos.Controls.Add(this.dateTimePickerHoraInicioPeriodo);
            this.tabPageCompromissosFuturos.Controls.Add(this.dateTimePickerDataFimPeriodo);
            this.tabPageCompromissosFuturos.Controls.Add(this.label3);
            this.tabPageCompromissosFuturos.Controls.Add(this.label2);
            this.tabPageCompromissosFuturos.Controls.Add(this.dateTimePickerDataInicioPeriodo);
            this.tabPageCompromissosFuturos.Controls.Add(this.listCompromissosFuturos);
            this.tabPageCompromissosFuturos.Location = new System.Drawing.Point(4, 24);
            this.tabPageCompromissosFuturos.Name = "tabPageCompromissosFuturos";
            this.tabPageCompromissosFuturos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompromissosFuturos.Size = new System.Drawing.Size(1016, 319);
            this.tabPageCompromissosFuturos.TabIndex = 1;
            this.tabPageCompromissosFuturos.Text = "Compromissos Futuros";
            this.tabPageCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerHoraFimPeriodo
            // 
            this.dateTimePickerHoraFimPeriodo.CustomFormat = "HH:mm";
            this.dateTimePickerHoraFimPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraFimPeriodo.Location = new System.Drawing.Point(718, 8);
            this.dateTimePickerHoraFimPeriodo.Name = "dateTimePickerHoraFimPeriodo";
            this.dateTimePickerHoraFimPeriodo.ShowUpDown = true;
            this.dateTimePickerHoraFimPeriodo.Size = new System.Drawing.Size(61, 23);
            this.dateTimePickerHoraFimPeriodo.TabIndex = 17;
            // 
            // dateTimePickerHoraInicioPeriodo
            // 
            this.dateTimePickerHoraInicioPeriodo.CustomFormat = "HH:mm";
            this.dateTimePickerHoraInicioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraInicioPeriodo.Location = new System.Drawing.Point(351, 8);
            this.dateTimePickerHoraInicioPeriodo.Name = "dateTimePickerHoraInicioPeriodo";
            this.dateTimePickerHoraInicioPeriodo.ShowUpDown = true;
            this.dateTimePickerHoraInicioPeriodo.Size = new System.Drawing.Size(61, 23);
            this.dateTimePickerHoraInicioPeriodo.TabIndex = 16;
            // 
            // dateTimePickerDataFimPeriodo
            // 
            this.dateTimePickerDataFimPeriodo.Location = new System.Drawing.Point(454, 8);
            this.dateTimePickerDataFimPeriodo.MinDate = new System.DateTime(2022, 5, 2, 0, 0, 0, 0);
            this.dateTimePickerDataFimPeriodo.Name = "dateTimePickerDataFimPeriodo";
            this.dateTimePickerDataFimPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerDataFimPeriodo.Size = new System.Drawing.Size(257, 23);
            this.dateTimePickerDataFimPeriodo.TabIndex = 12;
            this.dateTimePickerDataFimPeriodo.Value = new System.DateTime(2022, 5, 2, 20, 22, 9, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Até:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filtrar desde:";
            // 
            // dateTimePickerDataInicioPeriodo
            // 
            this.dateTimePickerDataInicioPeriodo.Location = new System.Drawing.Point(87, 8);
            this.dateTimePickerDataInicioPeriodo.MinDate = new System.DateTime(2022, 5, 2, 0, 0, 0, 0);
            this.dateTimePickerDataInicioPeriodo.Name = "dateTimePickerDataInicioPeriodo";
            this.dateTimePickerDataInicioPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerDataInicioPeriodo.Size = new System.Drawing.Size(257, 23);
            this.dateTimePickerDataInicioPeriodo.TabIndex = 9;
            this.dateTimePickerDataInicioPeriodo.Value = new System.DateTime(2022, 5, 2, 20, 22, 9, 0);
            // 
            // listCompromissosFuturos
            // 
            this.listCompromissosFuturos.FormattingEnabled = true;
            this.listCompromissosFuturos.HorizontalScrollbar = true;
            this.listCompromissosFuturos.ItemHeight = 15;
            this.listCompromissosFuturos.Location = new System.Drawing.Point(6, 45);
            this.listCompromissosFuturos.Name = "listCompromissosFuturos";
            this.listCompromissosFuturos.Size = new System.Drawing.Size(1004, 259);
            this.listCompromissosFuturos.TabIndex = 7;
            // 
            // tabPageCompromissosPassados
            // 
            this.tabPageCompromissosPassados.Controls.Add(this.listCompromissosPassados);
            this.tabPageCompromissosPassados.Location = new System.Drawing.Point(4, 24);
            this.tabPageCompromissosPassados.Name = "tabPageCompromissosPassados";
            this.tabPageCompromissosPassados.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompromissosPassados.Size = new System.Drawing.Size(1016, 319);
            this.tabPageCompromissosPassados.TabIndex = 0;
            this.tabPageCompromissosPassados.Text = "Compromissos Passados";
            this.tabPageCompromissosPassados.UseVisualStyleBackColor = true;
            // 
            // listCompromissosPassados
            // 
            this.listCompromissosPassados.FormattingEnabled = true;
            this.listCompromissosPassados.HorizontalScrollbar = true;
            this.listCompromissosPassados.ItemHeight = 15;
            this.listCompromissosPassados.Location = new System.Drawing.Point(6, 15);
            this.listCompromissosPassados.Name = "listCompromissosPassados";
            this.listCompromissosPassados.Size = new System.Drawing.Size(1004, 289);
            this.listCompromissosPassados.TabIndex = 6;
            // 
            // btnCompromissosSemana
            // 
            this.btnCompromissosSemana.BackColor = System.Drawing.Color.White;
            this.btnCompromissosSemana.Location = new System.Drawing.Point(813, 10);
            this.btnCompromissosSemana.Name = "btnCompromissosSemana";
            this.btnCompromissosSemana.Size = new System.Drawing.Size(111, 28);
            this.btnCompromissosSemana.TabIndex = 9;
            this.btnCompromissosSemana.Text = "Semana atual";
            this.btnCompromissosSemana.UseVisualStyleBackColor = false;
            this.btnCompromissosSemana.Click += new System.EventHandler(this.btnCompromissosSemana_Click);
            // 
            // btnCompromissosDia
            // 
            this.btnCompromissosDia.BackColor = System.Drawing.Color.White;
            this.btnCompromissosDia.Location = new System.Drawing.Point(924, 10);
            this.btnCompromissosDia.Name = "btnCompromissosDia";
            this.btnCompromissosDia.Size = new System.Drawing.Size(111, 28);
            this.btnCompromissosDia.TabIndex = 8;
            this.btnCompromissosDia.Text = "Hoje";
            this.btnCompromissosDia.UseVisualStyleBackColor = false;
            this.btnCompromissosDia.Click += new System.EventHandler(this.btnCompromissosDia_Click);
            // 
            // TelaListagemCompromissos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCompromissosDia);
            this.Controls.Add(this.btnCompromissosSemana);
            this.Controls.Add(this.tabControlCompromissos);
            this.Controls.Add(this.btnLimparFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrarPeriodo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnInserir);
            this.Name = "TelaListagemCompromissos";
            this.Size = new System.Drawing.Size(1053, 394);
            this.tabControlCompromissos.ResumeLayout(false);
            this.tabPageCompromissosFuturos.ResumeLayout(false);
            this.tabPageCompromissosFuturos.PerformLayout();
            this.tabPageCompromissosPassados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFiltrarPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimparFiltro;
        private System.Windows.Forms.TabControl tabControlCompromissos;
        private System.Windows.Forms.TabPage tabPageCompromissosPassados;
        private System.Windows.Forms.ListBox listCompromissosPassados;
        private System.Windows.Forms.TabPage tabPageCompromissosFuturos;
        private System.Windows.Forms.ListBox listCompromissosFuturos;
        private System.Windows.Forms.Button btnCompromissosSemana;
        private System.Windows.Forms.Button btnCompromissosDia;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFimPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInicioPeriodo;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraFimPeriodo;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraInicioPeriodo;
    }
}
