using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using AutoRepairShopDAL.Binding;


namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopPutOnStock : Form
    {
        public FormAutoRepairShopPutOnStock()
        {
            InitializeComponent();
        }
        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                List<SComponentView> listC = APIClient.GetRequest<List<SComponentView>>("api/Components/GetList");
                if (listC != null)
                {
                    comboBoxComponent.DisplayMember = "ComponentName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = listC;
                    comboBoxComponent.SelectedItem = null;
                }
                List<SStockView> listS = APIClient.GetRequest<List<SStockView>>("api/Stock/GetList");
                if (listS != null)
                {
                    comboBoxStock.DisplayMember = "StockName";
                    comboBoxStock.ValueMember = "Id";
                    comboBoxStock.DataSource = listS;
                    comboBoxStock.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStock.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<SStockComponentBinding, bool>("api/Main/PutMaterialsOnStock", new SStockComponentBinding
                {
                    ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                    StockId = Convert.ToInt32(comboBoxStock.SelectedValue),
                    Count = Convert.ToInt32(textBox.Text)
                });
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
