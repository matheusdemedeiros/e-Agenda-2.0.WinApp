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
            this.btnOrdenarPorPrioridade = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVisualizacaoComum = new System.Windows.Forms.Button();
            this.tabControlCompromissos = new System.Windows.Forms.TabControl();
            this.tabPageCompromissosPassados = new System.Windows.Forms.TabPage();
            this.listCompromissosPassados = new System.Windows.Forms.ListBox();
            this.tabPageCompromissosFuturos = new System.Windows.Forms.TabPage();
            this.listCompromissosFuturos = new System.Windows.Forms.ListBox();
            this.btnCadastrarItens = new System.Windows.Forms.Button();
            this.btnAtualizarItens = new System.Windows.Forms.Button();
            this.tabControlCompromissos.SuspendLayout();
            this.tabPageCompromissosPassados.SuspendLayout();
            this.tabPageCompromissosFuturos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.BackColor = System.Drawing.Color.White;
            this.btnInserir.Location = new System.Drawing.Point(210, 9);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(79, 29);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(295, 9);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(79, 29);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(380, 9);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(79, 29);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            // 
            // btnOrdenarPorPrioridade
            // 
            this.btnOrdenarPorPrioridade.BackColor = System.Drawing.Color.White;
            this.btnOrdenarPorPrioridade.Location = new System.Drawing.Point(465, 9);
            this.btnOrdenarPorPrioridade.Name = "btnOrdenarPorPrioridade";
            this.btnOrdenarPorPrioridade.Size = new System.Drawing.Size(148, 29);
            this.btnOrdenarPorPrioridade.TabIndex = 3;
            this.btnOrdenarPorPrioridade.Text = "Ordenar por prioridade";
            this.btnOrdenarPorPrioridade.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compromissos";
            // 
            // btnVisualizacaoComum
            // 
            this.btnVisualizacaoComum.BackColor = System.Drawing.Color.White;
            this.btnVisualizacaoComum.Location = new System.Drawing.Point(619, 9);
            this.btnVisualizacaoComum.Name = "btnVisualizacaoComum";
            this.btnVisualizacaoComum.Size = new System.Drawing.Size(133, 28);
            this.btnVisualizacaoComum.TabIndex = 7;
            this.btnVisualizacaoComum.Text = "Visualização comum";
            this.btnVisualizacaoComum.UseVisualStyleBackColor = false;
            // 
            // tabControlCompromissos
            // 
            this.tabControlCompromissos.Controls.Add(this.tabPageCompromissosPassados);
            this.tabControlCompromissos.Controls.Add(this.tabPageCompromissosFuturos);
            this.tabControlCompromissos.Location = new System.Drawing.Point(15, 44);
            this.tabControlCompromissos.Name = "tabControlCompromissos";
            this.tabControlCompromissos.SelectedIndex = 0;
            this.tabControlCompromissos.Size = new System.Drawing.Size(1024, 347);
            this.tabControlCompromissos.TabIndex = 8;
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
            // tabPageCompromissosFuturos
            // 
            this.tabPageCompromissosFuturos.Controls.Add(this.listCompromissosFuturos);
            this.tabPageCompromissosFuturos.Location = new System.Drawing.Point(4, 24);
            this.tabPageCompromissosFuturos.Name = "tabPageCompromissosFuturos";
            this.tabPageCompromissosFuturos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompromissosFuturos.Size = new System.Drawing.Size(1016, 319);
            this.tabPageCompromissosFuturos.TabIndex = 1;
            this.tabPageCompromissosFuturos.Text = "Compromissos Futuros";
            this.tabPageCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // listCompromissosFuturos
            // 
            this.listCompromissosFuturos.FormattingEnabled = true;
            this.listCompromissosFuturos.HorizontalScrollbar = true;
            this.listCompromissosFuturos.ItemHeight = 15;
            this.listCompromissosFuturos.Location = new System.Drawing.Point(10, 15);
            this.listCompromissosFuturos.Name = "listCompromissosFuturos";
            this.listCompromissosFuturos.Size = new System.Drawing.Size(1000, 289);
            this.listCompromissosFuturos.TabIndex = 7;
            // 
            // btnCadastrarItens
            // 
            this.btnCadastrarItens.BackColor = System.Drawing.Color.White;
            this.btnCadastrarItens.Location = new System.Drawing.Point(758, 10);
            this.btnCadastrarItens.Name = "btnCadastrarItens";
            this.btnCadastrarItens.Size = new System.Drawing.Size(103, 28);
            this.btnCadastrarItens.TabIndex = 9;
            this.btnCadastrarItens.Text = "Cadastrar itens";
            this.btnCadastrarItens.UseVisualStyleBackColor = false;
            // 
            // btnAtualizarItens
            // 
            this.btnAtualizarItens.BackColor = System.Drawing.Color.White;
            this.btnAtualizarItens.Location = new System.Drawing.Point(867, 10);
            this.btnAtualizarItens.Name = "btnAtualizarItens";
            this.btnAtualizarItens.Size = new System.Drawing.Size(111, 28);
            this.btnAtualizarItens.TabIndex = 8;
            this.btnAtualizarItens.Text = "Atualizar itens";
            this.btnAtualizarItens.UseVisualStyleBackColor = false;
            // 
            // TelaListagemCompromissos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAtualizarItens);
            this.Controls.Add(this.btnCadastrarItens);
            this.Controls.Add(this.tabControlCompromissos);
            this.Controls.Add(this.btnVisualizacaoComum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrdenarPorPrioridade);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnInserir);
            this.Name = "TelaListagemCompromissos";
            this.Size = new System.Drawing.Size(1053, 394);
            this.tabControlCompromissos.ResumeLayout(false);
            this.tabPageCompromissosPassados.ResumeLayout(false);
            this.tabPageCompromissosFuturos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnOrdenarPorPrioridade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVisualizacaoComum;
        private System.Windows.Forms.TabControl tabControlCompromissos;
        private System.Windows.Forms.TabPage tabPageCompromissosPassados;
        private System.Windows.Forms.ListBox listCompromissosPassados;
        private System.Windows.Forms.TabPage tabPageCompromissosFuturos;
        private System.Windows.Forms.ListBox listCompromissosFuturos;
        private System.Windows.Forms.Button btnCadastrarItens;
        private System.Windows.Forms.Button btnAtualizarItens;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
