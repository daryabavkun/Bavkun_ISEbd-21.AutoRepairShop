using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using Unity;
using AutoRepairShopDAL.Binding;


namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopSStock : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ISStock service;
        private int? id;
        public FormAutoRepairShopSStock(ISStock service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormAutoRepairShopSStock_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SStockView view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.StockName;
                        dataGridView.DataSource = view.StockComponents;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode =
                       DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SStockBinding
                    {
                        Id = id.Value,
                        StockName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new SStockBinding
                    {
                        StockName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}