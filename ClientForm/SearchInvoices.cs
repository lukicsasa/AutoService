using System;
using System.Windows.Forms;

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
            _uiController.SearchInvoice(cmbCriteria, dgvInvoices, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new InvoiceDetails(_uiController, dgvInvoices).ShowDialog();
        }
    }
}
