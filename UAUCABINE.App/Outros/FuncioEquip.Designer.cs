namespace UAUCABINE.App.Outros
{
    partial class FuncioEquip
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
            gridFunc = new DataGridView();
            gridEquip = new DataGridView();
            btnSair = new ReaLTaiizor.Controls.MaterialButton();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridFunc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridEquip).BeginInit();
            SuspendLayout();
            // 
            // gridFunc
            // 
            gridFunc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFunc.Location = new Point(6, 159);
            gridFunc.Name = "gridFunc";
            gridFunc.RowTemplate.Height = 25;
            gridFunc.Size = new Size(377, 220);
            gridFunc.TabIndex = 0;
            // 
            // gridEquip
            // 
            gridEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEquip.Location = new Point(400, 159);
            gridEquip.Name = "gridEquip";
            gridEquip.RowTemplate.Height = 25;
            gridEquip.Size = new Size(394, 220);
            gridEquip.TabIndex = 1;
            // 
            // btnSair
            // 
            btnSair.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSair.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSair.Depth = 0;
            btnSair.HighEmphasis = true;
            btnSair.Icon = null;
            btnSair.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnSair.Location = new Point(708, 405);
            btnSair.Margin = new Padding(4, 6, 4, 6);
            btnSair.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnSair.Name = "btnSair";
            btnSair.NoAccentTextColor = Color.Empty;
            btnSair.Size = new Size(64, 36);
            btnSair.TabIndex = 2;
            btnSair.Text = "Sair";
            btnSair.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSair.UseAccentColor = false;
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(115, 120);
            label1.Name = "label1";
            label1.Size = new Size(165, 36);
            label1.TabIndex = 3;
            label1.Text = "Funcionários";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(505, 120);
            label2.Name = "label2";
            label2.Size = new Size(185, 36);
            label2.TabIndex = 4;
            label2.Text = "Equipamentos";
            // 
            // FuncioEquip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSair);
            Controls.Add(gridEquip);
            Controls.Add(gridFunc);
            Name = "FuncioEquip";
            Text = "Funcionários e Equipamentos da Festa";
            ((System.ComponentModel.ISupportInitialize)gridFunc).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridEquip).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridFunc;
        private DataGridView gridEquip;
        private ReaLTaiizor.Controls.MaterialButton btnSair;
        private Label label1;
        private Label label2;
    }
}