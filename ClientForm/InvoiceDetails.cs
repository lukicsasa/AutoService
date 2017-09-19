using System;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class InvoiceDetails : Form
    {
        public InvoiceDetails(UiController.UIController uiController, DataGridView dgvResults)
        {
            InitializeComponent();
            uiController.PopulateInvoiceDetails(dgvResults, txtInvoiceNumber, txtDate, txtOwner, txtValue, dgvItems);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
