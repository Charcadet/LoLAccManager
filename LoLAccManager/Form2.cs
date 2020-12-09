using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoLAccManager
{
	public class Form2 : Form
	{
		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer components;

		private Panel panel1;

		private Panel panel2;

		private Label label1;

		private BunifuImageButton bunifuImageButton1;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private TextBox txtUser;

		private Label label2;

		private Label label3;

		private TextBox txtPassword;

		private Label label4;

		private TextBox txtIGN;

		private PictureBox pictureBox1;

		private BunifuFlatButton btnOk;

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

		public Form2()
		{
			InitializeComponent();
			AddDrag(panel2);
			AddDrag(label1);
			AddDrag(panel3);
			AddDrag(panel4);
			AddDrag(panel5);
		}

		private void Form2_Load(object sender, EventArgs e)
		{
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Save()
		{
			if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtIGN.Text))
			{
				return;
			}
			Form1 form = new Form1();
			string value = JsonConvert.SerializeObject(new Account
			{
				AccountUser = txtUser.Text,
				AccountPass = txtPassword.Text,
				AccountIGN = txtIGN.Text,
				AccountRank = string.Empty
			});
			string path = "accountData.json";
			JArray jArray = new JArray();
			using (StreamReader reader = File.OpenText(path))
			{
				using JsonTextReader reader2 = new JsonTextReader(reader);
				jArray = (JArray)JToken.ReadFrom(reader2);
				jArray.Add(value);
			}
			using (StreamWriter streamWriter = new StreamWriter(path, append: false))
			{
				streamWriter.WriteLine(jArray.ToString());
				streamWriter.Close();
			}
			form.yepAccs = Account.LoadAccounts();
			form.source.DataSource = form.yepAccs;
			form.AccountGrid.DataSource = form.source;
			form.AccountGrid.Update();
			Application.Restart();
			Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Save();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoLAccManager.Form2));
			panel1 = new System.Windows.Forms.Panel();
			btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
			label4 = new System.Windows.Forms.Label();
			txtIGN = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtPassword = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtUser = new System.Windows.Forms.TextBox();
			panel5 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
			label1 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			panel1.Controls.Add(btnOk);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(txtIGN);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(txtPassword);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(txtUser);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new System.Drawing.Point(-17, -22);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(322, 481);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			btnOk.Activecolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnOk.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnOk.BorderRadius = 0;
			btnOk.ButtonText = "Add Account";
			btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
			btnOk.DisabledColor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnOk.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnOk.Iconcolor = System.Drawing.Color.Transparent;
			btnOk.Iconimage = null;
			btnOk.Iconimage_right = null;
			btnOk.Iconimage_right_Selected = null;
			btnOk.Iconimage_Selected = null;
			btnOk.IconMarginLeft = 0;
			btnOk.IconMarginRight = 0;
			btnOk.IconRightVisible = true;
			btnOk.IconRightZoom = 0.0;
			btnOk.IconVisible = true;
			btnOk.IconZoom = 90.0;
			btnOk.IsTab = false;
			btnOk.Location = new System.Drawing.Point(48, 384);
			btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnOk.Name = "btnOk";
			btnOk.Normalcolor = System.Drawing.Color.FromArgb(35, 40, 60);
			btnOk.OnHovercolor = System.Drawing.Color.FromArgb(63, 71, 105);
			btnOk.OnHoverTextColor = System.Drawing.Color.White;
			btnOk.selected = false;
			btnOk.Size = new System.Drawing.Size(241, 43);
			btnOk.TabIndex = 10;
			btnOk.Text = "Add Account";
			btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnOk.Textcolor = System.Drawing.Color.White;
			btnOk.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnOk.Click += new System.EventHandler(btnOk_Click);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			label4.Location = new System.Drawing.Point(48, 310);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(136, 17);
			label4.TabIndex = 6;
			label4.Text = "Summoner name:";
			txtIGN.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			txtIGN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtIGN.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtIGN.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			txtIGN.Location = new System.Drawing.Point(49, 328);
			txtIGN.MaxLength = 16;
			txtIGN.Name = "txtIGN";
			txtIGN.Size = new System.Drawing.Size(240, 26);
			txtIGN.TabIndex = 7;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			label3.Location = new System.Drawing.Point(47, 256);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(85, 17);
			label3.TabIndex = 4;
			label3.Text = "Password:";
			txtPassword.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtPassword.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPassword.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			txtPassword.Location = new System.Drawing.Point(48, 274);
			txtPassword.MaxLength = 150;
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '•';
			txtPassword.Size = new System.Drawing.Size(241, 26);
			txtPassword.TabIndex = 5;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			label2.Location = new System.Drawing.Point(45, 202);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(88, 17);
			label2.TabIndex = 2;
			label2.Text = "Username:";
			txtUser.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUser.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUser.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			txtUser.Location = new System.Drawing.Point(46, 220);
			txtUser.MaxLength = 16;
			txtUser.Name = "txtUser";
			txtUser.Size = new System.Drawing.Size(243, 26);
			txtUser.TabIndex = 3;
			txtUser.TextChanged += new System.EventHandler(textBox1_TextChanged);
			panel5.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel5.Location = new System.Drawing.Point(-313, 58);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(336, 485);
			panel5.TabIndex = 2;
			panel5.Paint += new System.Windows.Forms.PaintEventHandler(panel5_Paint);
			panel4.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel4.Location = new System.Drawing.Point(314, 58);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(49, 475);
			panel4.TabIndex = 2;
			panel4.Paint += new System.Windows.Forms.PaintEventHandler(panel4_Paint);
			panel3.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel3.Location = new System.Drawing.Point(3, 465);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(336, 100);
			panel3.TabIndex = 1;
			panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
			panel2.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			panel2.Controls.Add(bunifuImageButton1);
			panel2.Controls.Add(label1);
			panel2.Location = new System.Drawing.Point(-13, 15);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(440, 48);
			panel2.TabIndex = 0;
			panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
			bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
			bunifuImageButton1.ImageActive = null;
			bunifuImageButton1.Location = new System.Drawing.Point(302, 12);
			bunifuImageButton1.Name = "bunifuImageButton1";
			bunifuImageButton1.Size = new System.Drawing.Size(21, 29);
			bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			bunifuImageButton1.TabIndex = 1;
			bunifuImageButton1.TabStop = false;
			bunifuImageButton1.Zoom = 10;
			bunifuImageButton1.Click += new System.EventHandler(bunifuImageButton1_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.FromArgb(227, 227, 227);
			label1.Location = new System.Drawing.Point(42, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(102, 17);
			label1.TabIndex = 1;
			label1.Text = "Add Account";
			label1.Click += new System.EventHandler(label1_Click);
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pictureBox1.Location = new System.Drawing.Point(13, 39);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(299, 166);
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(302, 450);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form2";
			Text = "Add Account";
			base.Load += new System.EventHandler(Form2_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
