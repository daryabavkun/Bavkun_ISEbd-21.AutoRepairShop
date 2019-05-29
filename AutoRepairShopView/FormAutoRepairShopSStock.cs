using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using AutoRepairShopDAL.Binding;


namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopSStock : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormAutoRepairShopSStock()
        {
            InitializeComponent();
        }
        private void FormAutoRepairShopSStock_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SStockView view = APIClient.GetRequest<SStockView>("api/Stock/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.StockName;
                        dataGridView.DataSource = view.StockComponent;
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
                    APIClient.PostRequest<SStockBinding, bool>("api/Stock/UpdElement", new SStockBinding
                    {
                        Id = id.Value,
                        StockName = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<SStockBinding, bool>("api/Stock/AddElement", new SStockBinding
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