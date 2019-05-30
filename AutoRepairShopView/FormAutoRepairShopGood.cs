using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using AutoRepairShopDAL.Binding;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopGood : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<GoodComponentView> productComponents;
        public FormAutoRepairShopGood()
        {
            InitializeComponent();
        }
        private void FormAutoRepairShopProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    GoodView view = APIClient.GetRequest<GoodView>("api/Good/Get/" + id.Value);
                    if (view != null)
                    {
                        textBox1.Text = view.ProductName;
                        textBox2.Text = view.Price.ToString();
                        productComponents = view.ProductComponent;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                productComponents = new List<GoodComponentView>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (productComponents != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = productComponents;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAutoRepairShopGoodComponent();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.ProductId = id.Value;
                    }
                    productComponents.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        productComponents.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
  

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productComponents == null || productComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<GoodComponentBinding> productComponentBM = new
               List<GoodComponentBinding>();
                for (int i = 0; i < productComponents.Count; ++i)
                {
                    productComponentBM.Add(new GoodComponentBinding
                    {
                        Id = productComponents[i].Id,
                        ProductId = productComponents[i].ProductId,
                        ComponentId = productComponents[i].ComponentId,
                        Count = productComponents[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<GoodBinding, bool>("api/Good/UpdElement", new GoodBinding
                    {
                        Id = id.Value,
                        ProductName = textBox1.Text,
                        Price = Convert.ToInt32(textBox2.Text),
                        ProductComponents = productComponentBM
                    });
                }
                else
                {
                    APIClient.PostRequest<GoodBinding, bool>("api/Good/AddElement", new GoodBinding
                    {
                        ProductName = textBox1.Text,
                        Price = Convert.ToInt32(textBox2.Text),
                        ProductComponents = productComponentBM
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormAutoRepairShopGoodComponent();
                form.Model =
               productComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.Model;
                    LoadData();
                }
            }
        }
    }
}
