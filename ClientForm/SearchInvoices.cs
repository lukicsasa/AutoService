using System;
using System.Windows.Forms;
using Domain;

namespace ClientForm
{
    public partial class SearchInvoices : Form
    {
        private readonly UiController.UIController _uiController;

        public SearchInvoices(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
            _uiController.GetAllAutos(cmbCriteria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _uiController.SearchInvoices(cmbCriteria, dgvInvoices, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new InvoiceDetails(_uiController, dgvInvoices).ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var result = _uiController.DeleteInvoice(dgvInvoices);
            if(result)
                _uiController.SearchInvoices(cmbCriteria, dgvInvoices, true);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var invoice = dgvInvoices.CurrentRow?.DataBoundItem as Invoice;
            new AddInvoice(_uiController,invoice, true).ShowDialog();
        }
    }
}
