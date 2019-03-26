namespace AutoRepairShopView
{
    partial class FormAutoRepairShopCreateSOrder
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.clientBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formAutoRepairShopClientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.productBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formAutoRepairShopComponentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.sClientBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formAutoRepairShopClientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formAutoRepairShopComponentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sClientBindingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.sClientBindingBindingSource;
            this.comboBox1.DisplayMember = "ClientFIO";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(129, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // formAutoRepairShopClientsBindingSource
            // 
            this.formAutoRepairShopClientsBindingSource.AllowNew = true;
            this.formAutoRepairShopClientsBindingSource.DataSource = typeof(AutoRepairShopView.FormAutoRepairShopSClients);
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.productBindingBindingSource;
            this.comboBox2.DisplayMember = "ProductName";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(129, 52);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(220, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // productBindingBindingSource
            // 
            this.productBindingBindingSource.DataSource = typeof(AutoRepairShopDAL.Binding.GoodBinding);
            // 
            // formAutoRepairShopComponentsBindingSource
            // 
            this.formAutoRepairShopComponentsBindingSource.DataSource = typeof(AutoRepairShopView.FormAutoRepairShopSComponents);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Изделие";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Сумма";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(129, 103);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(220, 22);
            this.textBox.TabIndex = 6;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(238, 183);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 33);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(129, 183);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 33);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 22);
            this.textBox2.TabIndex = 9;
            // 
            // sClientBindingBindingSource
            // 
            this.sClientBindingBindingSource.DataSource = typeof(AutoRepairShopDAL.Binding.SClientBinding);
            // 
            // FormAutoRepairShopCreateSOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 249);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "FormAutoRepairShopCreateSOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormAutoRepairShopCreateOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formAutoRepairShopClientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formAutoRepairShopComponentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sClientBindingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingSource formAutoRepairShopClientsBindingSource;
        private System.Windows.Forms.BindingSource formAutoRepairShopComponentsBindingSource;
        private System.Windows.Forms.BindingSource clientBindingBindingSource;
        private System.Windows.Forms.BindingSource productBindingBindingSource;
        private System.Windows.Forms.BindingSource sClientBindingBindingSource;
    }
}