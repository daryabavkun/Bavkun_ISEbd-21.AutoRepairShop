using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopSClient : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormAutoRepairShopSClient()
        {
            InitializeComponent();
        }
        private void FormAutoRepairShopClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SClientView client = APIClient.GetRequest<SClientView>("api/Client/Get/" + id.Value);
                    textBoxFIO.Text = client.ClientFIO;
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
                    APIClient.PostRequest<SClientBinding, bool>("api/Client/UpdElement", new SClientBinding
                    {
                        Id = id.Value,
                        ClientFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<SClientBinding, bool>("api/Client/AddElement", new SClientBinding
                    {
                        ClientFIO = textBoxFIO.Text
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
