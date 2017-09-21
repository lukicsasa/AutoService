using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace ClientForm
{
    public partial class AddInvoice : Form
    {
        private readonly UiController.UIController _uiController;
        private  List<InvoiceItem> _invoiceItems = new List<InvoiceItem>();
        private readonly bool _update;
        private readonly Invoice _invoice;

        public AddInvoice(UiController.UIController uiController, Invoice invoice, bool update = false)
        {
            InitializeComponent();
            _uiController = uiController;
            _update = update;
            _uiController.GetAllAutos(cmbAuto);
            _uiController.GetAllEmployees(cmbEmployee);
            txtValue.Text = "0";
            _invoice = invoice;
            if (_invoice != null)
            {
                if (_invoice.InvoiceItems.Any())
                {
                    btnSubmitInvoice.Visible = true;
                    txtValue.Text = _invoice.InvoiceItems.Sum(s => s.Value).ToString();
                }
                _invoiceItems = invoice.InvoiceItems;
                cmbAuto.SelectedItem = invoice.Auto;
                cmbEmployee.SelectedItem = invoice.Employee;
            }
            else
            {
                btnSubmitInvoice.Visible = false;
            }
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
        }

        private void AddInvoice_Load(object sender, EventArgs e)
        {
            _invoiceItems = _uiController.FindInvoiceItems(dgvItems, _invoice?.InvoiceNumber.ToString());
        }

        private void btnSubmitInvoice_Click(object sender, EventArgs e)
        {
            if (_update)
            {
                _uiController.UpdateInvoice(_invoice, _invoiceItems, dateTimePicker, cmbAuto, cmbEmployee);
            }
            else
            {
                _uiController.AddInvoice(_invoiceItems, dateTimePicker, cmbAuto, cmbEmployee);
            }
            Dispose();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.SelectedRows)
            {
                var item = row.DataBoundItem as InvoiceItem;
                dgvItems.Rows.Remove(row);
                _invoiceItems.RemoveAll(r => r.Value == item.Value && r.Service.Name == item.Service.Name);
                txtValue.Text = _invoiceItems.Sum(s => s.Value).ToString();
            }

            if (!_invoiceItems.Any())
            {
                btnSubmitInvoice.Visible = false;
            }
        }
    }
}
