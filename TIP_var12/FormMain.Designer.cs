
namespace TIP_var12
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.журналПроводокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.планСчетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.серияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.автомобилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.поставщикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.покупательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.подразделенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.журналПроводокToolStripMenuItem,
            this.отчетToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.планСчетовToolStripMenuItem,
            this.серияToolStripMenuItem,
            this.автомобилиToolStripMenuItem,
            this.поставщикToolStripMenuItem,
            this.покупательToolStripMenuItem,
            this.подразделенияToolStripMenuItem,
            this.услугиToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// журналПроводокToolStripMenuItem
			// 
			this.журналПроводокToolStripMenuItem.Name = "журналПроводокToolStripMenuItem";
			this.журналПроводокToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
			this.журналПроводокToolStripMenuItem.Text = "Журнал проводок";
			// 
			// планСчетовToolStripMenuItem
			// 
			this.планСчетовToolStripMenuItem.Name = "планСчетовToolStripMenuItem";
			this.планСчетовToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.планСчетовToolStripMenuItem.Text = "План счетов ";
			this.планСчетовToolStripMenuItem.Click += new System.EventHandler(this.планСчетовToolStripMenuItem_Click);
			// 
			// серияToolStripMenuItem
			// 
			this.серияToolStripMenuItem.Name = "серияToolStripMenuItem";
			this.серияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.серияToolStripMenuItem.Text = "Серия";
			// 
			// автомобилиToolStripMenuItem
			// 
			this.автомобилиToolStripMenuItem.Name = "автомобилиToolStripMenuItem";
			this.автомобилиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.автомобилиToolStripMenuItem.Text = "Автомобили";
			// 
			// поставщикToolStripMenuItem
			// 
			this.поставщикToolStripMenuItem.Name = "поставщикToolStripMenuItem";
			this.поставщикToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.поставщикToolStripMenuItem.Text = "Поставщик";
			// 
			// покупательToolStripMenuItem
			// 
			this.покупательToolStripMenuItem.Name = "покупательToolStripMenuItem";
			this.покупательToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.покупательToolStripMenuItem.Text = "Покупатель";
			// 
			// подразделенияToolStripMenuItem
			// 
			this.подразделенияToolStripMenuItem.Name = "подразделенияToolStripMenuItem";
			this.подразделенияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.подразделенияToolStripMenuItem.Text = "Подразделения";
			// 
			// услугиToolStripMenuItem
			// 
			this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
			this.услугиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.услугиToolStripMenuItem.Text = "Услуги";
			// 
			// отчетToolStripMenuItem
			// 
			this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
			this.отчетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.отчетToolStripMenuItem.Text = "Отчет";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "Главное меню";
			this.Load += new System.EventHandler(this.Main_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem планСчетовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem серияToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem автомобилиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem поставщикToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem покупательToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem подразделенияToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem журналПроводокToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
	}
}

