using System;
using System.Collections.Generic;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using AutoRepairShopDAL.Binding;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopSComponent : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormAutoRepairShopSComponent()
        {
            InitializeComponent();
        }
        private void FormAutoRepairShopComponent_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SComponentView view = APIClient.GetRequest<SComponentView>("api/Material/Get/" + id.Value); ;
                    if (view != null)
                    {
                        textBox.Text = view.ComponentName;
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
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<SComponentBinding, bool>("api/Material/UpdElement", new SComponentBinding
                    {
                        Id = id.Value,
                        ComponentName = textBox.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<SComponentBinding, bool>("api/Material/AddElement", new SComponentBinding
                    {
                        ComponentName = textBox.Text
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
