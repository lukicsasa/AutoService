using Domain;
using UiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class AddInvoiceItem : Form
    {
        private readonly UiController.UIController _uiController;
        private readonly List<InvoiceItem> _invoiceItems;
        private readonly DataGridView _dgvInvoiceItems;

        public AddInvoiceItem(UiController.UIController uiController, List<InvoiceItem> invoiceItems, DataGridView dgvInvoiceItems)
        {
            _dgvInvoiceItems = dgvInvoiceItems;
            _invoiceItems = invoiceItems;
            InitializeComponent();
            _uiController = uiController;
            _uiController.GetAllServices(cmbServices);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _uiController.AddNewInvoiceItem(_invoiceItems, cmbServices, txtValue);
            _dgvInvoiceItems.DataSource = new BindingList<InvoiceItem>(_invoiceItems);
            Dispose();
        }
    }
}
