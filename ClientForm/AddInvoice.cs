using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ClientForm
{
    public partial class AddInvoice : Form
    {
        private readonly UiController.UIController _uiController;
        private readonly List<InvoiceItem> _invoiceItems = new List<InvoiceItem>();

        public AddInvoice(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
            var invoice = new Invoice();
            _uiController.GetAllAutos(cmbAuto);
            _uiController.GetAllEmployees(cmbEmployee);
            txtValue.Text = "0";
            btnSubmitInvoice.Visible = false;
        }

        private void btnAddInvoiceItem_Click(object sender, EventArgs e)
        {
            new AddInvoiceItem(_uiController, _invoiceItems, dgvItems).ShowDialog();
            if (_invoiceItems.Any())
            {
                btnSubmitInvoice.Visible = true;
                txtValue.Text = _invoiceItems.Sum(s => s.Value).ToString();
            }
            else
            {
                txtValue.Text = "0";
            }
            //_uiController.FindInvoiceItems(dgvInvoiceItems, txtValue);
        }

        private void AddInvoice_Load(object sender, EventArgs e)
        {
            _uiController.FindInvoiceItems(dgvItems, txtValue);
        }

        private void btnSubmitInvoice_Click(object sender, EventArgs e)
        {
            _uiController.AddInvoice(_invoiceItems, dateTimePicker, cmbAuto, cmbEmployee);
            Dispose();
        }
    }
}
