namespace ClientForm
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.automobiliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNovogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretrazivanjeAutomobilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNoveUslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretrazivanjeUslugaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vlasnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNovogVlasnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeRacunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaRacunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeCurrentUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentUser = new System.Windows.Forms.TextBox();
            this.Logout = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automobiliToolStripMenuItem,
            this.uslugeToolStripMenuItem,
            this.vlasnikToolStripMenuItem,
            this.racunToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // automobiliToolStripMenuItem
            // 
            this.automobiliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosNovogToolStripMenuItem,
            this.pretrazivanjeAutomobilaToolStripMenuItem});
            this.automobiliToolStripMenuItem.Name = "automobiliToolStripMenuItem";
            this.automobiliToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.automobiliToolStripMenuItem.Text = "Autos";
            // 
            // unosNovogToolStripMenuItem
            // 
            this.unosNovogToolStripMenuItem.Name = "unosNovogToolStripMenuItem";
            this.unosNovogToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.unosNovogToolStripMenuItem.Text = "Add Auto";
            this.unosNovogToolStripMenuItem.Click += new System.EventHandler(this.addNewAutoToolStripMenuItem_Click);
            // 
            // pretrazivanjeAutomobilaToolStripMenuItem
            // 
            this.pretrazivanjeAutomobilaToolStripMenuItem.Name = "pretrazivanjeAutomobilaToolStripMenuItem";
            this.pretrazivanjeAutomobilaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pretrazivanjeAutomobilaToolStripMenuItem.Text = "Search Autos";
            this.pretrazivanjeAutomobilaToolStripMenuItem.Click += new System.EventHandler(this.searchAutosToolStripMenuItem_Click);
            // 
            // uslugeToolStripMenuItem
            // 
            this.uslugeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosNoveUslugeToolStripMenuItem,
            this.pretrazivanjeUslugaToolStripMenuItem});
            this.uslugeToolStripMenuItem.Name = "uslugeToolStripMenuItem";
            this.uslugeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.uslugeToolStripMenuItem.Text = "Services";
            // 
            // unosNoveUslugeToolStripMenuItem
            // 
            this.unosNoveUslugeToolStripMenuItem.Name = "unosNoveUslugeToolStripMenuItem";
            this.unosNoveUslugeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.unosNoveUslugeToolStripMenuItem.Text = "Add Service";
            this.unosNoveUslugeToolStripMenuItem.Click += new System.EventHandler(this.addServiceToolStripMenuItem_Click);
            // 
            // pretrazivanjeUslugaToolStripMenuItem
            // 
            this.pretrazivanjeUslugaToolStripMenuItem.Name = "pretrazivanjeUslugaToolStripMenuItem";
            this.pretrazivanjeUslugaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.pretrazivanjeUslugaToolStripMenuItem.Text = "Search Services";
            this.pretrazivanjeUslugaToolStripMenuItem.Click += new System.EventHandler(this.searchServicesToolStripMenuItem_Click);
            // 
            // vlasnikToolStripMenuItem
            // 
            this.vlasnikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosNovogVlasnikaToolStripMenuItem});
            this.vlasnikToolStripMenuItem.Name = "vlasnikToolStripMenuItem";
            this.vlasnikToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.vlasnikToolStripMenuItem.Text = "Owners";
            // 
            // unosNovogVlasnikaToolStripMenuItem
            // 
            this.unosNovogVlasnikaToolStripMenuItem.Name = "unosNovogVlasnikaToolStripMenuItem";
            this.unosNovogVlasnikaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.unosNovogVlasnikaToolStripMenuItem.Text = "Add Owner";
            this.unosNovogVlasnikaToolStripMenuItem.Click += new System.EventHandler(this.addOwnerToolStripMenuItem_Click);
            // 
            // racunToolStripMenuItem
            // 
            this.racunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreiranjeRacunaToolStripMenuItem,
            this.pretragaRacunaToolStripMenuItem});
            this.racunToolStripMenuItem.Name = "racunToolStripMenuItem";
            this.racunToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.racunToolStripMenuItem.Text = "Invoices";
            // 
            // kreiranjeRacunaToolStripMenuItem
            // 
            this.kreiranjeRacunaToolStripMenuItem.Name = "kreiranjeRacunaToolStripMenuItem";
            this.kreiranjeRacunaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.kreiranjeRacunaToolStripMenuItem.Text = "Add Invoice";
            this.kreiranjeRacunaToolStripMenuItem.Click += new System.EventHandler(this.addInvoiceToolStripMenuItem_Click);
            // 
            // pretragaRacunaToolStripMenuItem
            // 
            this.pretragaRacunaToolStripMenuItem.Name = "pretragaRacunaToolStripMenuItem";
            this.pretragaRacunaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pretragaRacunaToolStripMenuItem.Text = "Search Invoices";
            this.pretragaRacunaToolStripMenuItem.Click += new System.EventHandler(this.searchInvoicesToolStripMenuItem_Click);
            // 
            // btnChangeCurrentUser
            // 
            this.btnChangeCurrentUser.Location = new System.Drawing.Point(105, 163);
            this.btnChangeCurrentUser.Name = "btnChangeCurrentUser";
            this.btnChangeCurrentUser.Size = new System.Drawing.Size(143, 23);
            this.btnChangeCurrentUser.TabIndex = 8;
            this.btnChangeCurrentUser.Text = "Change Current User";
            this.btnChangeCurrentUser.UseVisualStyleBackColor = true;
            this.btnChangeCurrentUser.Click += new System.EventHandler(this.btnChangeCurrentUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Logged in as";
            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.Location = new System.Drawing.Point(122, 92);
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.ReadOnly = true;
            this.txtCurrentUser.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentUser.TabIndex = 9;
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(122, 207);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(109, 23);
            this.Logout.TabIndex = 10;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 265);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.txtCurrentUser);
            this.Controls.Add(this.btnChangeCurrentUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem automobiliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosNovogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretrazivanjeAutomobilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uslugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosNoveUslugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretrazivanjeUslugaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vlasnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosNovogVlasnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreiranjeRacunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaRacunaToolStripMenuItem;
        private System.Windows.Forms.Button btnChangeCurrentUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentUser;
        private System.Windows.Forms.Button Logout;
    }
}