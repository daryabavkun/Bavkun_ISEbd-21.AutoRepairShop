namespace AutoRepairShopView
{
    partial class FormAutoRepairShopPutOnStock
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.comboBoxStock = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.sStockViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sComponentViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sStockViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sComponentViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(136, 111);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(231, 22);
            this.textBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Компонент:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Склад:";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.DataSource = this.sComponentViewBindingSource;
            this.comboBoxComponent.DisplayMember = "ComponentName";
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(136, 60);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(231, 24);
            this.comboBoxComponent.TabIndex = 8;
            // 
            // comboBoxStock
            // 
            this.comboBoxStock.DataSource = this.sStockViewBindingSource;
            this.comboBoxStock.DisplayMember = "StockName";
            this.comboBoxStock.FormattingEnabled = true;
            this.comboBoxStock.Location = new System.Drawing.Point(136, 20);
            this.comboBoxStock.Name = "comboBoxStock";
            this.comboBoxStock.Size = new System.Drawing.Size(231, 24);
            this.comboBoxStock.TabIndex = 7;
            this.comboBoxStock.Click += new System.EventHandler(this.FormPutOnStock_Load);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(264, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 33);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(155, 160);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 33);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // sStockViewBindingSource
            // 
            this.sStockViewBindingSource.DataSource = typeof(AutoRepairShopDAL.View.SStockView);
            // 
            // sComponentViewBindingSource
            // 
            this.sComponentViewBindingSource.DataSource = typeof(AutoRepairShopDAL.View.SComponentView);
            // 
            // FormAutoRepairShopPutOnStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 245);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxStock);
            this.Name = "FormAutoRepairShopPutOnStock";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormPutOnStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sStockViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sComponentViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.ComboBox comboBoxStock;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource sComponentViewBindingSource;
        private System.Windows.Forms.BindingSource sStockViewBindingSource;
    }
}