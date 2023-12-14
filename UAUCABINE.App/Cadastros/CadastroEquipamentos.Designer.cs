namespace UAUCABINE.App.Cadastros
{
    partial class CadastroEquipamentos
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
            txtNomeEquip = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            materialTabControl1.SuspendLayout();
            tabPageCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Size = new Size(452, 157);
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Controls.Add(txtNomeEquip);
            tabPageCadastro.Size = new Size(444, 122);
            tabPageCadastro.Controls.SetChildIndex(txtNomeEquip, 0);
            tabPageCadastro.Controls.SetChildIndex(txtId, 0);
            // 
            // txtNomeEquip
            // 
            txtNomeEquip.AnimateReadOnly = false;
            txtNomeEquip.AutoCompleteMode = AutoCompleteMode.None;
            txtNomeEquip.AutoCompleteSource = AutoCompleteSource.None;
            txtNomeEquip.BackgroundImageLayout = ImageLayout.None;
            txtNomeEquip.CharacterCasing = CharacterCasing.Normal;
            txtNomeEquip.Depth = 0;
            txtNomeEquip.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNomeEquip.HideSelection = true;
            txtNomeEquip.Hint = "Equipamento";
            txtNomeEquip.LeadingIcon = null;
            txtNomeEquip.Location = new Point(6, 17);
            txtNomeEquip.MaxLength = 32767;
            txtNomeEquip.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtNomeEquip.Name = "txtNomeEquip";
            txtNomeEquip.PasswordChar = '\0';
            txtNomeEquip.PrefixSuffixText = null;
            txtNomeEquip.ReadOnly = false;
            txtNomeEquip.RightToLeft = RightToLeft.No;
            txtNomeEquip.SelectedText = "";
            txtNomeEquip.SelectionLength = 0;
            txtNomeEquip.SelectionStart = 0;
            txtNomeEquip.ShortcutsEnabled = true;
            txtNomeEquip.Size = new Size(306, 48);
            txtNomeEquip.TabIndex = 3;
            txtNomeEquip.TabStop = false;
            txtNomeEquip.TextAlign = HorizontalAlignment.Left;
            txtNomeEquip.TrailingIcon = null;
            txtNomeEquip.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "ID";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(342, 17);
            txtId.MaxLength = 32767;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = true;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(95, 48);
            txtId.TabIndex = 4;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            // 
            // CadastroEquipamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 224);
            Location = new Point(0, 0);
            Name = "CadastroEquipamentos";
            Text = "Cadastro de Equipamentos";
            materialTabControl1.ResumeLayout(false);
            tabPageCadastro.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtNomeEquip;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
    }
}