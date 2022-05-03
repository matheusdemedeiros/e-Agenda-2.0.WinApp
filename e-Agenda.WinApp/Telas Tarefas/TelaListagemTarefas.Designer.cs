namespace e_Agenda.WinApp.Telas_Tarefas
{
    partial class TelaListagemTarefas
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
            this.tabControlTarefas = new System.Windows.Forms.TabControl();
            this.tabPageTarefasPendentes = new System.Windows.Forms.TabPage();
            this.listTarefasPendentes = new System.Windows.Forms.ListBox();
            this.tabPageTarefasConcluidas = new System.Windows.Forms.TabPage();
            this.listTarefasConcluidas = new System.Windows.Forms.ListBox();
            this.btnCadastrarItens = new System.Windows.Forms.Button();
            this.btnAtualizarItens = new System.Windows.Forms.Button();
            this.tabControlTarefas.SuspendLayout();
            this.tabPageTarefasPendentes.SuspendLayout();
            this.tabPageTarefasConcluidas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.BackColor = System.Drawing.Color.White;
            this.btnInserir.Location = new System.Drawing.Point(143, 9);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(79, 29);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(228, 9);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(79, 29);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(313, 9);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(79, 29);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnOrdenarPorPrioridade
            // 
            this.btnOrdenarPorPrioridade.BackColor = System.Drawing.Color.White;
            this.btnOrdenarPorPrioridade.Location = new System.Drawing.Point(398, 9);
            this.btnOrdenarPorPrioridade.Name = "btnOrdenarPorPrioridade";
            this.btnOrdenarPorPrioridade.Size = new System.Drawing.Size(148, 29);
            this.btnOrdenarPorPrioridade.TabIndex = 3;
            this.btnOrdenarPorPrioridade.Text = "Ordenar por prioridade";
            this.btnOrdenarPorPrioridade.UseVisualStyleBackColor = false;
            this.btnOrdenarPorPrioridade.Click += new System.EventHandler(this.btnOrdenarPorPrioridade_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tarefas";
            // 
            // btnVisualizacaoComum
            // 
            this.btnVisualizacaoComum.BackColor = System.Drawing.Color.White;
            this.btnVisualizacaoComum.Location = new System.Drawing.Point(552, 9);
            this.btnVisualizacaoComum.Name = "btnVisualizacaoComum";
            this.btnVisualizacaoComum.Size = new System.Drawing.Size(133, 28);
            this.btnVisualizacaoComum.TabIndex = 7;
            this.btnVisualizacaoComum.Text = "Visualização comum";
            this.btnVisualizacaoComum.UseVisualStyleBackColor = false;
            this.btnVisualizacaoComum.Click += new System.EventHandler(this.btnVisualizacaoComum_Click);
            // 
            // tabControlTarefas
            // 
            this.tabControlTarefas.Controls.Add(this.tabPageTarefasPendentes);
            this.tabControlTarefas.Controls.Add(this.tabPageTarefasConcluidas);
            this.tabControlTarefas.Location = new System.Drawing.Point(15, 44);
            this.tabControlTarefas.Name = "tabControlTarefas";
            this.tabControlTarefas.SelectedIndex = 0;
            this.tabControlTarefas.Size = new System.Drawing.Size(1024, 347);
            this.tabControlTarefas.TabIndex = 8;
            // 
            // tabPageTarefasPendentes
            // 
            this.tabPageTarefasPendentes.Controls.Add(this.listTarefasPendentes);
            this.tabPageTarefasPendentes.Location = new System.Drawing.Point(4, 24);
            this.tabPageTarefasPendentes.Name = "tabPageTarefasPendentes";
            this.tabPageTarefasPendentes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTarefasPendentes.Size = new System.Drawing.Size(1016, 319);
            this.tabPageTarefasPendentes.TabIndex = 0;
            this.tabPageTarefasPendentes.Text = "Tarefas Pendentes";
            this.tabPageTarefasPendentes.UseVisualStyleBackColor = true;
            // 
            // listTarefasPendentes
            // 
            this.listTarefasPendentes.FormattingEnabled = true;
            this.listTarefasPendentes.HorizontalScrollbar = true;
            this.listTarefasPendentes.ItemHeight = 15;
            this.listTarefasPendentes.Location = new System.Drawing.Point(6, 15);
            this.listTarefasPendentes.Name = "listTarefasPendentes";
            this.listTarefasPendentes.Size = new System.Drawing.Size(1004, 289);
            this.listTarefasPendentes.TabIndex = 6;
            // 
            // tabPageTarefasConcluidas
            // 
            this.tabPageTarefasConcluidas.Controls.Add(this.listTarefasConcluidas);
            this.tabPageTarefasConcluidas.Location = new System.Drawing.Point(4, 24);
            this.tabPageTarefasConcluidas.Name = "tabPageTarefasConcluidas";
            this.tabPageTarefasConcluidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTarefasConcluidas.Size = new System.Drawing.Size(1016, 319);
            this.tabPageTarefasConcluidas.TabIndex = 1;
            this.tabPageTarefasConcluidas.Text = "Tarefas Concluídas";
            this.tabPageTarefasConcluidas.UseVisualStyleBackColor = true;
            // 
            // listTarefasConcluidas
            // 
            this.listTarefasConcluidas.FormattingEnabled = true;
            this.listTarefasConcluidas.HorizontalScrollbar = true;
            this.listTarefasConcluidas.ItemHeight = 15;
            this.listTarefasConcluidas.Location = new System.Drawing.Point(10, 15);
            this.listTarefasConcluidas.Name = "listTarefasConcluidas";
            this.listTarefasConcluidas.Size = new System.Drawing.Size(1000, 289);
            this.listTarefasConcluidas.TabIndex = 7;
            // 
            // btnCadastrarItens
            // 
            this.btnCadastrarItens.BackColor = System.Drawing.Color.White;
            this.btnCadastrarItens.Location = new System.Drawing.Point(691, 10);
            this.btnCadastrarItens.Name = "btnCadastrarItens";
            this.btnCadastrarItens.Size = new System.Drawing.Size(103, 28);
            this.btnCadastrarItens.TabIndex = 9;
            this.btnCadastrarItens.Text = "Cadastrar itens";
            this.btnCadastrarItens.UseVisualStyleBackColor = false;
            this.btnCadastrarItens.Click += new System.EventHandler(this.btnCadastrarItens_Click);
            // 
            // btnAtualizarItens
            // 
            this.btnAtualizarItens.BackColor = System.Drawing.Color.White;
            this.btnAtualizarItens.Location = new System.Drawing.Point(800, 10);
            this.btnAtualizarItens.Name = "btnAtualizarItens";
            this.btnAtualizarItens.Size = new System.Drawing.Size(111, 28);
            this.btnAtualizarItens.TabIndex = 8;
            this.btnAtualizarItens.Text = "Atualizar itens";
            this.btnAtualizarItens.UseVisualStyleBackColor = false;
            this.btnAtualizarItens.Click += new System.EventHandler(this.btnAtualizarItens_Click);
            // 
            // TelaListagemTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAtualizarItens);
            this.Controls.Add(this.btnCadastrarItens);
            this.Controls.Add(this.tabControlTarefas);
            this.Controls.Add(this.btnVisualizacaoComum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrdenarPorPrioridade);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnInserir);
            this.Name = "TelaListagemTarefas";
            this.Size = new System.Drawing.Size(1053, 394);
            this.tabControlTarefas.ResumeLayout(false);
            this.tabPageTarefasPendentes.ResumeLayout(false);
            this.tabPageTarefasConcluidas.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControlTarefas;
        private System.Windows.Forms.TabPage tabPageTarefasPendentes;
        private System.Windows.Forms.ListBox listTarefasPendentes;
        private System.Windows.Forms.TabPage tabPageTarefasConcluidas;
        private System.Windows.Forms.ListBox listTarefasConcluidas;
        private System.Windows.Forms.Button btnCadastrarItens;
        private System.Windows.Forms.Button btnAtualizarItens;
    }
}