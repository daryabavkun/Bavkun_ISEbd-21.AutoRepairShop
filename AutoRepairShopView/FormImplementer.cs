using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;

namespace AutoRepairShopView
{
    public partial class FormImplementer : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormImplementer()
        {
            InitializeComponent();
        }
        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ImplementerView view = APIClient.GetRequest<ImplementerView>("api/Implementer/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxFIO.Text = view.ImplementerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<ImplementerBinding,
                   bool>("api/Implementer/UpdElement", new ImplementerBinding
                   {
                       Id = id.Value,
                       ImplementerFIO = textBoxFIO.Text
                   });
                }
                else
                {
                    APIClient.PostRequest<ImplementerBinding,
                   bool>("api/Implementer/AddElement", new ImplementerBinding
                   {
                       ImplementerFIO = textBoxFIO.Text
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
