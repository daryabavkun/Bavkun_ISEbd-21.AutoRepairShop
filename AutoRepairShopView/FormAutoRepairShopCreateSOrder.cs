using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using Unity;
using AutoRepairShopDAL.Binding;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopCreateSOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ISClient serviceC;
        private readonly IGood serviceP;
        private readonly IMain serviceM;
        public FormAutoRepairShopCreateSOrder(ISClient serviceC, IGood serviceP, IMain serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceP = serviceP;
            this.serviceM = serviceM;
        }
        private void FormAutoRepairShopCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<SClientView> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBox1.DisplayMember = "ClientFIO";
                    comboBox1.ValueMember = "Id";
                    comboBox1.DataSource = listC;
                    comboBox1.SelectedItem = null;
                }
                List<GoodView> listP = serviceP.GetList();
                if (listP != null)
                {
                    comboBox2.DisplayMember = "ProductName";
                    comboBox2.ValueMember = "Id";
                    comboBox2.DataSource = listP;
                    comboBox2.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBox2.SelectedValue != null &&
           !string.IsNullOrEmpty(textBox.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBox2.SelectedValue);
                    GoodView product = serviceP.GetElement(id);
                    int count = Convert.ToInt32(textBox.Text);
                    textBox2.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }    
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new SOrderBinding
                {
                    ClientId = Convert.ToInt32(comboBox1.SelectedValue),
                    ProductId = Convert.ToInt32(comboBox2.SelectedValue),
                    Count = Convert.ToInt32(textBox.Text),
                    Sum = Convert.ToInt32(textBox2.Text)
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
