
namespace TIP_var12
{
    partial class FormCar
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelPurchasePrice = new System.Windows.Forms.Label();
            this.labelRetailPrice = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPurchasePrice = new System.Windows.Forms.TextBox();
            this.textBoxRetailPrice = new System.Windows.Forms.TextBox();
            this.labelSeries = new System.Windows.Forms.Label();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(28, 34);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название";
            // 
            // labelPurchasePrice
            // 
            this.labelPurchasePrice.AutoSize = true;
            this.labelPurchasePrice.Location = new System.Drawing.Point(28, 135);
            this.labelPurchasePrice.Name = "labelPurchasePrice";
            this.labelPurchasePrice.Size = new System.Drawing.Size(93, 13);
            this.labelPurchasePrice.TabIndex = 1;
            this.labelPurchasePrice.Text = "Закупочная цена";
            // 
            // labelRetailPrice
            // 
            this.labelRetailPrice.AutoSize = true;
            this.labelRetailPrice.Location = new System.Drawing.Point(31, 184);
            this.labelRetailPrice.Name = "labelRetailPrice";
            this.labelRetailPrice.Size = new System.Drawing.Size(88, 13);
            this.labelRetailPrice.TabIndex = 2;
            this.labelRetailPrice.Text = "Розничная цена";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(149, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(170, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxPurchasePrice
            // 
            this.textBoxPurchasePrice.Location = new System.Drawing.Point(149, 132);
            this.textBoxPurchasePrice.Name = "textBoxPurchasePrice";
            this.textBoxPurchasePrice.Size = new System.Drawing.Size(170, 20);
            this.textBoxPurchasePrice.TabIndex = 4;
            // 
            // textBoxRetailPrice
            // 
            this.textBoxRetailPrice.Location = new System.Drawing.Point(149, 181);
            this.textBoxRetailPrice.Name = "textBoxRetailPrice";
            this.textBoxRetailPrice.Size = new System.Drawing.Size(170, 20);
            this.textBoxRetailPrice.TabIndex = 5;
            // 
            // labelSeries
            // 
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(31, 79);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(38, 13);
            this.labelSeries.TabIndex = 6;
            this.labelSeries.Text = "Серия";
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Location = new System.Drawing.Point(149, 79);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(170, 21);
            this.comboBoxSeries.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(244, 223);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(149, 223);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 280);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxSeries);
            this.Controls.Add(this.labelSeries);
            this.Controls.Add(this.textBoxRetailPrice);
            this.Controls.Add(this.textBoxPurchasePrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelRetailPrice);
            this.Controls.Add(this.labelPurchasePrice);
            this.Controls.Add(this.labelName);
            this.Name = "FormCar";
            this.Text = "Автомобиль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPurchasePrice;
        private System.Windows.Forms.Label labelRetailPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPurchasePrice;
        private System.Windows.Forms.TextBox textBoxRetailPrice;
        private System.Windows.Forms.Label labelSeries;
        private System.Windows.Forms.ComboBox comboBoxSeries;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}