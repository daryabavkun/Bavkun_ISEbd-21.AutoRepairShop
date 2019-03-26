using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using Unity;
using AutoRepairShopDAL.Binding;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopGoodComponent : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public GoodComponentView Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private readonly ISComponent service;
        private GoodComponentView model;
        public FormAutoRepairShopGoodComponent(ISComponent service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormAutoRepairShopProductComponent_Load(object sender, EventArgs e)
        {
            try
            {
                List<SComponentView> list = service.GetList();
                if (list != null)
                {
                    comboBox.DisplayMember = "ComponentName";
                    comboBox.ValueMember = "Id";
                    comboBox.DataSource = list;
                    comboBox.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBox.Enabled = false;
                comboBox.SelectedValue = model.ComponentId;
                textBox.Text = model.Count.ToString();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new GoodComponentView
                    {
                        ComponentId = Convert.ToInt32(comboBox.SelectedValue),
                        ComponentName = comboBox.Text,
                        Count = Convert.ToInt32(textBox.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBox.Text);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
