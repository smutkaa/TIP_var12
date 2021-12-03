
namespace TIP_var12
{
    partial class FormPurchaseDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPurchaseDoc));
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxCout = new System.Windows.Forms.TextBox();
            this.textBoxPurchasePrice = new System.Windows.Forms.TextBox();
            this.textBoxRetailPrice = new System.Windows.Forms.TextBox();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.comboBoxCar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Name = "dateTimePicker";
            // 
            // textBoxCout
            // 
            resources.ApplyResources(this.textBoxCout, "textBoxCout");
            this.textBoxCout.Name = "textBoxCout";
            // 
            // textBoxPurchasePrice
            // 
            resources.ApplyResources(this.textBoxPurchasePrice, "textBoxPurchasePrice");
            this.textBoxPurchasePrice.Name = "textBoxPurchasePrice";
            // 
            // textBoxRetailPrice
            // 
            resources.ApplyResources(this.textBoxRetailPrice, "textBoxRetailPrice");
            this.textBoxRetailPrice.Name = "textBoxRetailPrice";
            // 
            // comboBoxProvider
            // 
            resources.ApplyResources(this.comboBoxProvider, "comboBoxProvider");
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Name = "comboBoxProvider";
            // 
            // comboBoxCar
            // 
            resources.ApplyResources(this.comboBoxCar, "comboBoxCar");
            this.comboBoxCar.FormattingEnabled = true;
            this.comboBoxCar.Name = "comboBoxCar";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // FormPurchaseDoc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCar);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.textBoxRetailPrice);
            this.Controls.Add(this.textBoxPurchasePrice);
            this.Controls.Add(this.textBoxCout);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "FormPurchaseDoc";
            this.Load += new System.EventHandler(this.FormPurchaseDoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxCout;
        private System.Windows.Forms.TextBox textBoxPurchasePrice;
        private System.Windows.Forms.TextBox textBoxRetailPrice;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label6;
    }
}