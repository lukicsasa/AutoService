using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Domain;
using UIController;

namespace UiController
{
    public class UIController
    {
        private readonly Connection _connection;

        public UIController()
        {
            //try
            //{
                _connection = new Connection();
                _connection.Connect();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private Employee CurrentUser { get; set; }

        public int Login(TextBox username, TextBox password)
        {
            var usernameText = username.Text;
            var passwordText = password.Text;

            var loginEmployee = new Employee
            {
                Username = usernameText,
                Password = passwordText
            };

            if (string.IsNullOrWhiteSpace(usernameText) || string.IsNullOrWhiteSpace(passwordText))
            {
                MessageBox.Show("All fields are required", "Error!");
                return 0;
            }
            var employee = _connection.Login(loginEmployee);
            if (employee != null)
            {
                MessageBox.Show("Login successfull.");
                CurrentUser = employee;
                return 1;
            }
            MessageBox.Show("Wrong username or password", "Error!");
            return 0;
        }

        public void SetCurrentUser(TextBox tx)
        {
            tx.Text = CurrentUser.FirstName.ToUpper() + " " + CurrentUser.LastName.ToUpper();
        }

        public void GetAllAutoTypes(ComboBox cb)
        {
            cb.DataSource = _connection.GetAllAutoTypes();
            cb.Text = string.Empty;
        }

        public void GetAllOwners(ComboBox cb)
        {
            cb.DataSource = _connection.GetAllOwners();
            cb.Text = string.Empty;
        }

        public void GetAllEmployees(ComboBox cb)
        {
            cb.DataSource = _connection.GetAllEmployees();
            cb.Text = string.Empty;
        }

        public void GetAllServices(ComboBox cb)
        {
            cb.DataSource = _connection.GetAllServices();
            cb.Text = string.Empty;
        }

        public void GetAllAutos(ComboBox cb)
        {
            cb.DataSource = _connection.GetAllAutos();
            cb.Text = string.Empty;
        }

        public void FindInvoiceItems(DataGridView dgvInvoiceItems, TextBox txtValue)
        {
            try
            {
                var invoiceItems = _connection.FindInvoiceItems(txtValue.Text);
                dgvInvoiceItems.DataSource = invoiceItems.ToList().Select(s => new
                    {s.Service.Name, s.Value}).ToList();
                dgvInvoiceItems.Text = string.Empty;
            }
            catch (Exception ex)
            {
            }
        }

        public Auto PopulateAutoUpdate(DataGridView dgvResults, ComboBox cbOwners, ComboBox cbTypes,
            TextBox tbYear, TextBox tbGas, TextBox tbColor, TextBox tbNumberOfDoors, TextBox tbRegNumber)
        {
            var auto = dgvResults.CurrentRow?.DataBoundItem as Auto;
            if (auto != null)
            {
                GetAllOwners(cbOwners);
                GetAllAutoTypes(cbTypes);

                var owners = cbOwners.DataSource as List<Owner>;
                cbOwners.SelectedItem = owners.FirstOrDefault(a => a.Id == auto.Owner.Id);
                var autoTypes = cbTypes.DataSource as List<AutoType>;
                cbTypes.SelectedItem = autoTypes.FirstOrDefault(a => a.Id == auto.AutoType.Id);
                cbTypes.SelectedItem = auto.AutoType;
                tbYear.Text = auto.ProductionYear.ToString();
                tbGas.Text = auto.Gas;
                tbColor.Text = auto.Color;
                tbNumberOfDoors.Text = auto.NumberOfDoors.ToString();
                tbRegNumber.Text = auto.RegNumber;
            }
            return auto;
        }

        public int AddService(TextBox tbServiceName, TextBox tbPrice, TextBox tbDescription)
        {
            try
            {
                var service = new Service
                {
                    Name = tbServiceName.Text,
                    Price = Convert.ToInt32(tbPrice.Text),
                    Description = tbDescription.Text
                };

                var result = _connection.Input(service);
                if (result > 0)
                {
                    MessageBox.Show("Service added!");
                    return 1;
                }
                MessageBox.Show("System has failed to save service!");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to save service!");
                return 0;
            }
        }


        public void FindService(TextBox tbCriteria, DataGridView dgvServices, ComboBox cbServices, bool change)
        {
            var criteria = tbCriteria.Text;
            var results = _connection.FindServices(criteria);

            if (results.Any())
            {
                if (dgvServices != null) dgvServices.DataSource = results;
                if (cbServices != null) cbServices.DataSource = results;
            }
            else
            {
                MessageBox.Show("System is unable to find services by given criteria!");
                if (dgvServices != null) dgvServices.DataSource = null;
                if (cbServices != null) cbServices.DataSource = null;
            }
        }

        public static Service PopulateServiceDetails(DataGridView dgvServices, TextBox tbServiceName,
            TextBox tbPrice, TextBox tbDescription, Button btnSave, Button btnCancel)
        {
            btnSave.Visible = true;
            btnCancel.Visible = false;
            var service = dgvServices.CurrentRow?.DataBoundItem as Service;
            if (service == null) return null;
            tbServiceName.Text = service.Name;
            tbPrice.Text = service.Price.ToString();
            tbDescription.Text = service.Description;
            return service;
        }

        public int UpdateService(int serviceId, TextBox tbServiceName, TextBox tbPrice, TextBox tbDescription)
        {
            try
            {
                var service = new Service
                {
                    Id = serviceId,
                    Name = tbServiceName.Text,
                    Price = Convert.ToInt32(tbPrice.Text),
                    Description = tbDescription.Text
                };

                var result = _connection.UpdateService(service);
                if (result > 0)
                {
                    MessageBox.Show("Service updated!");
                    return 1;
                }
                MessageBox.Show("System has failed to update service!");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to update service!");
                return 0;
            }
        }

        public void AddOwner(TextBox txtFirstName, TextBox txtLastName, TextBox txtPhone,
            TextBox txtEmail)
        {
            var owner = new Owner
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };
            try
            {
                var result = _connection.Input(owner);
                if (result > 0)
                {
                    MessageBox.Show("Owner saved!");
                    return;
                }
                MessageBox.Show("System has failed to save owner!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to save owner!");
            }
        }

        public int AddNewAuto(TextBox txtRegNumber, TextBox txtColor, TextBox txtProductionYear,
            TextBox txtDoors, TextBox txtGas, ComboBox cmbAutoType, ComboBox cmbOwner)
        {
            try
            {
                var auto = new Auto
                {
                    RegNumber = txtRegNumber.Text,
                    Color = txtColor.Text,
                    ProductionYear = Convert.ToInt32(txtProductionYear.Text),
                    NumberOfDoors = Convert.ToInt32(txtDoors.Text),
                    Gas = txtGas.Text
                };

                var owner = cmbOwner.SelectedItem as Owner;
                var autoType = cmbAutoType.SelectedItem as AutoType;
                if (autoType != null)
                    auto.AutoType = new AutoType
                    {
                        Id = autoType.Id
                    };
                if (owner != null)
                    auto.Owner = new Owner
                    {
                        Id = owner.Id
                    };

                var result = _connection.Input(auto);
                if (result > 0)
                {
                    MessageBox.Show("Auto saved!");
                    return 1;
                }
                MessageBox.Show("System has failed to save auto!");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to save auto!");
                return 0;
            }

            MessageBox.Show("Invalid year format!");
            return 0;
        }

        public int UpdateAuto(int autoId, TextBox txtRegNumber, TextBox txtColor, TextBox txtYear,
            TextBox txtDoors, TextBox txtGas, ComboBox cmbAutoType, ComboBox cmbOwner)
        {
            try
            {
                var auto = new Auto
                {
                    AutoId = autoId,
                    RegNumber = txtRegNumber.Text,
                    Color = txtColor.Text,
                    ProductionYear = Convert.ToInt32(txtYear.Text),
                    NumberOfDoors = Convert.ToInt32(txtDoors.Text),
                    Gas = txtGas.Text
                };

                var owner = cmbOwner.SelectedItem as Owner;
                var autoType = cmbAutoType.SelectedItem as AutoType;

                if (autoType != null)
                    auto.AutoType = new AutoType
                    {
                        Id = autoType.Id
                    };
                if (owner != null)
                    auto.Owner = new Owner
                    {
                        Id = owner.Id
                    };

                var result = _connection.UpdateAuto(auto);
                if (result > 0)
                {
                    MessageBox.Show("Auto saved!");
                    return 1;
                }
                MessageBox.Show("System has failed to save auto.");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to save auto.");
                return 0;
            }
        }

        public void FindAuto(TextBox tbCriteria, DataGridView dgvAutos, bool change)
        {
            var criteria = tbCriteria.Text;
            var results = _connection.FindAuto(criteria);

            if (results.Any())
            {
                if (dgvAutos != null) dgvAutos.DataSource = results;
            }
            else
            {
                if (change) MessageBox.Show("System can't find any autos by given criteria!");
                if (dgvAutos != null) dgvAutos.DataSource = null;
            }
        }

        public void DeleteAuto(DataGridView dgvResults, TextBox tbCriteria)
        {
            var dr = MessageBox.Show("Are you sure you want to delete auto?", "Alert!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    var auto = dgvResults.CurrentRow.DataBoundItem as Auto;
                    var result = _connection.DeleteAuto(auto);
                    if (result > 0)
                    {
                        MessageBox.Show("Auto deleted!");
                        FindAuto(tbCriteria, dgvResults, false);
                    }
                    else
                    {
                        MessageBox.Show("System has failed to delete auto!");
                    }
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        public void SearchInvoice(ComboBox cmbCriteria, DataGridView dgvInvoices, bool change)
        {
            var txtCriteria = cmbCriteria.SelectedItem as Auto;
            if (txtCriteria == null) return;
            var criteria = txtCriteria.AutoId.ToString();
            var invoices = _connection.FindInvoice(criteria);

            if (invoices.Any())
            {
                if (dgvInvoices != null) dgvInvoices.DataSource = invoices;
            }
            else
            {
                if (change) MessageBox.Show("System can't find any invoices by given criteria!");
                if (dgvInvoices != null) dgvInvoices.DataSource = null;
            }
        }

        public void PopulateInvoiceDetails(DataGridView dgvResults, TextBox txtInvoiceNumber, TextBox txtDate,
            TextBox txtOwner, TextBox txtValue, DataGridView dgvInvoiceItems)
        {
            var invoice = dgvResults.CurrentRow?.DataBoundItem as Invoice;
            if (invoice != null)
            {
                txtInvoiceNumber.Text = invoice.InvoiceNumber.ToString();
                txtDate.Text = invoice.Date.ToShortDateString();

                txtOwner.Text = invoice.Auto.AutoId.ToString();
                txtValue.Text = invoice.Total.ToString();
            }
            FindInvoiceItems(dgvInvoiceItems, txtInvoiceNumber);
        }

        public void AddNewInvoiceItem(List<InvoiceItem> invoiceItems, ComboBox cmbService, TextBox txtValue)
        {
            try
            {
                var service = cmbService.SelectedItem as Service;
                var invoiceItem = new InvoiceItem
                {
                    Service = service,
                    Value = Convert.ToInt32(txtValue.Text)
                };
                invoiceItems.Add(invoiceItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create invoice item!");
            }
        }

        public void AddInvoice(List<InvoiceItem> invoiceItems, DateTimePicker dtpDateTimePicker, ComboBox cmbAutos, ComboBox cmbEmployees)
        {
            try
            {
                var auto = cmbAutos.SelectedItem as Auto;
                var employee = cmbEmployees.SelectedItem as Employee;

                var invoice = new Invoice
                {
                    Date = dtpDateTimePicker.Value,
                    Auto = new Auto
                    {
                        AutoId = auto.AutoId
                    },
                    Total = invoiceItems.Sum(s => s.Value),
                    Employee = new Employee
                    {
                        Id = employee.Id
                    },
                    InvoiceItems = new BindingList<InvoiceItem>(invoiceItems)
                };

                var id = _connection.GetNewId(invoice);
                invoice.InvoiceNumber = id;

                var result = _connection.Input(invoice);
                if (result > 0)
                {
                    MessageBox.Show("Invoice has been added!");
                    foreach (var item in invoice.InvoiceItems)
                    {
                        item.InvoiceNumber = invoice.InvoiceNumber;
                        _connection.Input(item);
                    }
                }
                else
                {
                    MessageBox.Show("System has failed to save an invoice!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System has failed to save an invoice!");
            }
        }
    }
}