using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace LoLAccManager
{
	public class Form1 : Form
	{
		public List<Account> yepAccs = new List<Account>();

		public BindingSource source = new BindingSource();

		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer components;

		private Panel BGForm;

		private Panel HeaderBG;

		private BunifuImageButton bunifuImageButton2;

		private BunifuImageButton bunifuImageButton1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private BunifuFlatButton btnAddAcc;

		private Panel panel1;

		private Panel panel3;

		public BunifuCustomDataGrid AccountGrid;

		private DataGridViewTextBoxColumn Username;

		private DataGridViewTextBoxColumn Password;

		private DataGridViewTextBoxColumn IGN;

		private DataGridViewTextBoxColumn Rank;

		private Panel panel2;

		private BunifuFlatButton btnLogin;

		private BunifuFlatButton btnAbout;

		private BunifuFlatButton btnCopy;

		private void AddDrag(Control Control)
		{
			Control.MouseDown += DragForm_MouseDown;
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private void DragForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(base.Handle, 161, 2, 0);
			}
		}

		public Form1()
		{
			InitializeComponent();
			yepAccs = Account.LoadAccounts();
			source.DataSource = yepAccs;
			AccountGrid.DataSource = source;
			AddDrag(HeaderBG);
			AddDrag(bunifuCustomLabel1);
			AddDrag(panel1);
			AddDrag(panel2);
			AddDrag(panel3);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void bunifuCustomLabel1_Click(object sender, EventArgs e)
		{
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void bunifuImageButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		public void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void bunifuFlatButton1_Click(object sender, EventArgs e)
		{
			new Form2().ShowDialog();
		}

		private void panel2_Paint_1(object sender, PaintEventArgs e)
		{
		}

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		private string GetLeaguePath()
		{
			string text = string.Empty;
			DriveInfo[] drives = DriveInfo.GetDrives();
			for (int i = 0; i < drives.Length; i++)
			{
				string text2 = Path.Combine(drives[i].Name, "Riot Games/League of Legends/");
				if (Directory.Exists(text2))
				{
					text = text2;
					break;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			return text;
		}

		public static string GetCommandLine(Process process)
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}");
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			return managementObjectCollection.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
		}

		public static Process[] GetProcessesByName(string name)
		{
			return Process.GetProcessesByName(name);
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string caption = "LoLAccountManager";
			MessageBox.Show("This feature is disabled.", caption);
		}

		private void label2_Click_1(object sender, EventArgs e)
		{
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void btnDeleteAccount_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow selectedRow in AccountGrid.SelectedRows)
			{
				AccountGrid.Rows.RemoveAt(selectedRow.Index);
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			Account account = yepAccs.ElementAt(AccountGrid.CurrentCell.RowIndex);
			string accountUser = account.AccountUser;
			string accountPass = account.AccountPass;
			Clipboard.SetDataObject(accountUser + ":" + accountPass);
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoLAccManager.Form1));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			BGForm = new System.Windows.Forms.Panel();
			btnCopy = new Bunifu.Framework.UI.BunifuFlatButton();
			btnAbout = new Bunifu.Framework.UI.BunifuFlatButton();
			panel2 = new System.Windows.Forms.Panel();
			btnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
			panel3 = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			btnAddAcc = new Bunifu.Framework.UI.BunifuFlatButton();
			AccountGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
			Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
			IGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
			HeaderBG = new System.Windows.Forms.Panel();
			bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
			bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			BGForm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)AccountGrid).BeginInit();
			HeaderBG.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton2).BeginInit();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).BeginInit();
			SuspendLayout();
			BGForm.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			BGForm.BackgroundImage = (System.Drawing.Image)resources.GetObject("BGForm.BackgroundImage");
			BGForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			BGForm.Controls.Add(btnCopy);
			BGForm.Controls.Add(btnAbout);
			BGForm.Controls.Add(panel2);
			BGForm.Controls.Add(btnLogin);
			BGForm.Controls.Add(panel3);
			BGForm.Controls.Add(panel1);
			BGForm.Controls.Add(btnAddAcc);
			BGForm.Controls.Add(AccountGrid);
			BGForm.Controls.Add(HeaderBG);
			BGForm.Location = new System.Drawing.Point(-6, -7);
			BGForm.Name = "BGForm";
			BGForm.Size = new System.Drawing.Size(635, 525);
			BGForm.TabIndex = 0;
			BGForm.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			btnCopy.Activecolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnCopy.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnCopy.BorderRadius = 0;
			btnCopy.ButtonText = "Copy selected account login";
			btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCopy.DisabledColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnCopy.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnCopy.Iconcolor = System.Drawing.Color.Transparent;
			btnCopy.Iconimage = null;
			btnCopy.Iconimage_right = null;
			btnCopy.Iconimage_right_Selected = null;
			btnCopy.Iconimage_Selected = null;
			btnCopy.IconMarginLeft = 0;
			btnCopy.IconMarginRight = 0;
			btnCopy.IconRightVisible = true;
			btnCopy.IconRightZoom = 0.0;
			btnCopy.IconVisible = true;
			btnCopy.IconZoom = 90.0;
			btnCopy.IsTab = false;
			btnCopy.Location = new System.Drawing.Point(221, 52);
			btnCopy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnCopy.Name = "btnCopy";
			btnCopy.Normalcolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnCopy.OnHovercolor = System.Drawing.Color.FromArgb(63, 71, 105);
			btnCopy.OnHoverTextColor = System.Drawing.Color.White;
			btnCopy.selected = false;
			btnCopy.Size = new System.Drawing.Size(157, 38);
			btnCopy.TabIndex = 10;
			btnCopy.Text = "Copy selected account login";
			btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCopy.Textcolor = System.Drawing.Color.White;
			btnCopy.TextFont = new System.Drawing.Font("Arial Rounded MT Bold", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnCopy.Click += new System.EventHandler(btnCopy_Click);
			btnAbout.Activecolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAbout.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnAbout.BorderRadius = 0;
			btnAbout.ButtonText = "About";
			btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAbout.DisabledColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAbout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnAbout.Iconcolor = System.Drawing.Color.Transparent;
			btnAbout.Iconimage = null;
			btnAbout.Iconimage_right = null;
			btnAbout.Iconimage_right_Selected = null;
			btnAbout.Iconimage_Selected = null;
			btnAbout.IconMarginLeft = 0;
			btnAbout.IconMarginRight = 0;
			btnAbout.IconRightVisible = true;
			btnAbout.IconRightZoom = 0.0;
			btnAbout.IconVisible = true;
			btnAbout.IconZoom = 90.0;
			btnAbout.IsTab = false;
			btnAbout.Location = new System.Drawing.Point(416, 455);
			btnAbout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnAbout.Name = "btnAbout";
			btnAbout.Normalcolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAbout.OnHovercolor = System.Drawing.Color.FromArgb(63, 71, 105);
			btnAbout.OnHoverTextColor = System.Drawing.Color.White;
			btnAbout.selected = false;
			btnAbout.Size = new System.Drawing.Size(174, 54);
			btnAbout.TabIndex = 9;
			btnAbout.Text = "About";
			btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnAbout.Textcolor = System.Drawing.Color.White;
			btnAbout.TextFont = new System.Drawing.Font("Arial Rounded MT Bold", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnAbout.Click += new System.EventHandler(btnAbout_Click);
			panel2.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel2.Location = new System.Drawing.Point(622, 9);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(10, 512);
			panel2.TabIndex = 6;
			btnLogin.Activecolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnLogin.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnLogin.BorderRadius = 0;
			btnLogin.ButtonText = "Login to selected account";
			btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLogin.DisabledColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnLogin.Iconcolor = System.Drawing.Color.Transparent;
			btnLogin.Iconimage = null;
			btnLogin.Iconimage_right = null;
			btnLogin.Iconimage_right_Selected = null;
			btnLogin.Iconimage_Selected = null;
			btnLogin.IconMarginLeft = 0;
			btnLogin.IconMarginRight = 0;
			btnLogin.IconRightVisible = true;
			btnLogin.IconRightZoom = 0.0;
			btnLogin.IconVisible = true;
			btnLogin.IconZoom = 90.0;
			btnLogin.IsTab = false;
			btnLogin.Location = new System.Drawing.Point(55, 52);
			btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnLogin.Name = "btnLogin";
			btnLogin.Normalcolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnLogin.OnHovercolor = System.Drawing.Color.FromArgb(63, 71, 105);
			btnLogin.OnHoverTextColor = System.Drawing.Color.White;
			btnLogin.selected = false;
			btnLogin.Size = new System.Drawing.Size(167, 38);
			btnLogin.TabIndex = 7;
			btnLogin.Text = "Login to selected account";
			btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnLogin.Textcolor = System.Drawing.Color.White;
			btnLogin.TextFont = new System.Drawing.Font("Arial Rounded MT Bold", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnLogin.Click += new System.EventHandler(btnLogin_Click);
			panel3.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel3.Location = new System.Drawing.Point(1, 38);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(10, 495);
			panel3.TabIndex = 6;
			panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
			panel1.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel1.Location = new System.Drawing.Point(-9, 515);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(858, 10);
			panel1.TabIndex = 5;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint_1);
			btnAddAcc.Activecolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAddAcc.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAddAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnAddAcc.BorderRadius = 0;
			btnAddAcc.ButtonText = "Add account";
			btnAddAcc.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAddAcc.DisabledColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAddAcc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnAddAcc.Iconcolor = System.Drawing.Color.Transparent;
			btnAddAcc.Iconimage = null;
			btnAddAcc.Iconimage_right = null;
			btnAddAcc.Iconimage_right_Selected = null;
			btnAddAcc.Iconimage_Selected = null;
			btnAddAcc.IconMarginLeft = 0;
			btnAddAcc.IconMarginRight = 0;
			btnAddAcc.IconRightVisible = true;
			btnAddAcc.IconRightZoom = 0.0;
			btnAddAcc.IconVisible = true;
			btnAddAcc.IconZoom = 90.0;
			btnAddAcc.IsTab = false;
			btnAddAcc.Location = new System.Drawing.Point(416, 395);
			btnAddAcc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnAddAcc.Name = "btnAddAcc";
			btnAddAcc.Normalcolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnAddAcc.OnHovercolor = System.Drawing.Color.FromArgb(63, 71, 105);
			btnAddAcc.OnHoverTextColor = System.Drawing.Color.White;
			btnAddAcc.selected = false;
			btnAddAcc.Size = new System.Drawing.Size(174, 54);
			btnAddAcc.TabIndex = 4;
			btnAddAcc.Text = "Add account";
			btnAddAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnAddAcc.Textcolor = System.Drawing.Color.White;
			btnAddAcc.TextFont = new System.Drawing.Font("Arial Rounded MT Bold", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnAddAcc.Click += new System.EventHandler(bunifuFlatButton1_Click);
			AccountGrid.AllowUserToAddRows = false;
			AccountGrid.AllowUserToDeleteRows = false;
			AccountGrid.AllowUserToOrderColumns = true;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			AccountGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			AccountGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			AccountGrid.BackgroundColor = System.Drawing.Color.FromArgb(40, 46, 72);
			AccountGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			AccountGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			AccountGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			AccountGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			AccountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			AccountGrid.Columns.AddRange(Username, Password, IGN, Rank);
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(56, 64, 99);
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(56, 64, 99);
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			AccountGrid.DefaultCellStyle = dataGridViewCellStyle3;
			AccountGrid.DoubleBuffered = true;
			AccountGrid.EnableHeadersVisualStyles = false;
			AccountGrid.GridColor = System.Drawing.Color.FromArgb(47, 54, 82);
			AccountGrid.HeaderBgColor = System.Drawing.Color.FromArgb(35, 40, 60);
			AccountGrid.HeaderForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			AccountGrid.Location = new System.Drawing.Point(55, 89);
			AccountGrid.Name = "AccountGrid";
			AccountGrid.ReadOnly = true;
			AccountGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(67, 76, 115);
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(67, 76, 115);
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			AccountGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			AccountGrid.Size = new System.Drawing.Size(323, 420);
			AccountGrid.TabIndex = 3;
			AccountGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(bunifuCustomDataGrid1_CellContentClick);
			Username.DataPropertyName = "AccountUser";
			Username.HeaderText = "Username";
			Username.Name = "Username";
			Username.ReadOnly = true;
			Username.Visible = false;
			Username.Width = 140;
			Password.DataPropertyName = "AccountPass";
			Password.HeaderText = "Password";
			Password.Name = "Password";
			Password.ReadOnly = true;
			Password.Visible = false;
			Password.Width = 140;
			IGN.DataPropertyName = "AccountIGN";
			IGN.HeaderText = "IGN";
			IGN.Name = "IGN";
			IGN.ReadOnly = true;
			IGN.Width = 140;
			Rank.DataPropertyName = "AccountRank";
			Rank.HeaderText = "Rank";
			Rank.Name = "Rank";
			Rank.ReadOnly = true;
			Rank.Width = 140;
			HeaderBG.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			HeaderBG.Controls.Add(bunifuImageButton2);
			HeaderBG.Controls.Add(bunifuImageButton1);
			HeaderBG.Controls.Add(bunifuCustomLabel1);
			HeaderBG.Location = new System.Drawing.Point(3, 6);
			HeaderBG.Name = "HeaderBG";
			HeaderBG.Size = new System.Drawing.Size(629, 40);
			HeaderBG.TabIndex = 0;
			HeaderBG.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
			bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			bunifuImageButton2.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton2.Image");
			bunifuImageButton2.ImageActive = null;
			bunifuImageButton2.Location = new System.Drawing.Point(565, 10);
			bunifuImageButton2.Name = "bunifuImageButton2";
			bunifuImageButton2.Size = new System.Drawing.Size(22, 22);
			bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			bunifuImageButton2.TabIndex = 2;
			bunifuImageButton2.TabStop = false;
			bunifuImageButton2.Zoom = 10;
			bunifuImageButton2.Click += new System.EventHandler(bunifuImageButton2_Click);
			bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
			bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
			bunifuImageButton1.ImageActive = null;
			bunifuImageButton1.Location = new System.Drawing.Point(593, 10);
			bunifuImageButton1.Name = "bunifuImageButton1";
			bunifuImageButton1.Size = new System.Drawing.Size(22, 22);
			bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			bunifuImageButton1.TabIndex = 1;
			bunifuImageButton1.TabStop = false;
			bunifuImageButton1.Zoom = 10;
			bunifuImageButton1.Click += new System.EventHandler(bunifuImageButton1_Click);
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			bunifuCustomLabel1.Location = new System.Drawing.Point(18, 10);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(184, 18);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "LoL Account Manager";
			bunifuCustomLabel1.Click += new System.EventHandler(bunifuCustomLabel1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(620, 514);
			base.Controls.Add(BGForm);
			Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form1";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "LoL Account Manager";
			base.Load += new System.EventHandler(Form1_Load);
			BGForm.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)AccountGrid).EndInit();
			HeaderBG.ResumeLayout(false);
			HeaderBG.PerformLayout();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton2).EndInit();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).EndInit();
			ResumeLayout(false);
		}
	}
}
