using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Windows.Forms;
using Unity;

namespace AutoRepairShopView
{
    public partial class FormAutoRepairShopSClient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ISClient service;
        private int? id;
        public FormAutoRepairShopSClient(ISClient service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormAutoRepairShopClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SClientView view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxFIO.Text = view.ClientFIO;
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
                    service.UpdElement(new SClientBinding
                    {
                        Id = id.Value,
                        ClientFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    service.AddElement(new SClientBinding
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
