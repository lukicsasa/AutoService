﻿using UiController;
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
    public partial class MainMenu : Form
    {
        private readonly UiController.UIController _uiController;

        public MainMenu()
        {
            try
            {
                InitializeComponent();
                _uiController = new UiController.UIController();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnChangeCurrentUser_Click(object sender, EventArgs e)
        {
            new Login(_uiController).ShowDialog();
            _uiController.SetCurrentUser(txtCurrentUser);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                new Login(_uiController).ShowDialog();
                _uiController.SetCurrentUser(txtCurrentUser);
            }
            catch (Exception ex)
            {
                Dispose();
            }
        }

        private void addNewAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddAuto(_uiController).ShowDialog();
        }

        private void searchAutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SearchAutos(_uiController).ShowDialog();
        }

        private void addServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddService(_uiController).ShowDialog();
        }

        private void searchServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SearchServices(_uiController).ShowDialog();
        }

        private void addOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddOwner(_uiController).ShowDialog();
        }

        private void addInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddInvoice(_uiController, null).ShowDialog();
        }

        private void searchInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SearchInvoices(_uiController).ShowDialog();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            var result = _uiController.Logout();
            if (result)
            {
                Hide();
                new MainMenu().ShowDialog();
            }
        }
    }
}
