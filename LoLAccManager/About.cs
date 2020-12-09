using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace LoLAccManager
{
	public class About : Form
	{
		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;

		private IContainer components;

		private Panel panel1;

		private Panel Drag4;

		private Panel Drag2;

		private Panel Drag3;

		private Panel Drag1;

		private BunifuImageButton bunifuImageButton1;

		private Label label1;

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

		public About()
		{
			InitializeComponent();
			AddDrag(Drag1);
			AddDrag(Drag2);
			AddDrag(Drag3);
			AddDrag(Drag4);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoLAccManager.About));
			panel1 = new System.Windows.Forms.Panel();
			Drag4 = new System.Windows.Forms.Panel();
			Drag2 = new System.Windows.Forms.Panel();
			Drag3 = new System.Windows.Forms.Panel();
			Drag1 = new System.Windows.Forms.Panel();
			bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
			label1 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			Drag1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.FromArgb(40, 46, 72);
			panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
			panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			panel1.Controls.Add(label1);
			panel1.Controls.Add(Drag4);
			panel1.Controls.Add(Drag2);
			panel1.Controls.Add(Drag3);
			panel1.Controls.Add(Drag1);
			panel1.Location = new System.Drawing.Point(-4, -2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(406, 423);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			Drag4.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			Drag4.Location = new System.Drawing.Point(-10, 31);
			Drag4.Name = "Drag4";
			Drag4.Size = new System.Drawing.Size(18, 414);
			Drag4.TabIndex = 3;
			Drag2.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			Drag2.Location = new System.Drawing.Point(395, 35);
			Drag2.Name = "Drag2";
			Drag2.Size = new System.Drawing.Size(200, 436);
			Drag2.TabIndex = 2;
			Drag3.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			Drag3.Location = new System.Drawing.Point(-7, 411);
			Drag3.Name = "Drag3";
			Drag3.Size = new System.Drawing.Size(478, 100);
			Drag3.TabIndex = 1;
			Drag1.BackColor = System.Drawing.Color.FromArgb(35, 40, 60);
			Drag1.Controls.Add(bunifuImageButton1);
			Drag1.Location = new System.Drawing.Point(-7, -10);
			Drag1.Name = "Drag1";
			Drag1.Size = new System.Drawing.Size(509, 51);
			Drag1.TabIndex = 0;
			bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
			bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
			bunifuImageButton1.ImageActive = null;
			bunifuImageButton1.Location = new System.Drawing.Point(373, 22);
			bunifuImageButton1.Name = "bunifuImageButton1";
			bunifuImageButton1.Size = new System.Drawing.Size(22, 22);
			bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			bunifuImageButton1.TabIndex = 4;
			bunifuImageButton1.TabStop = false;
			bunifuImageButton1.Zoom = 10;
			bunifuImageButton1.Click += new System.EventHandler(bunifuImageButton1_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.SystemColors.Control;
			label1.Location = new System.Drawing.Point(146, 385);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(97, 14);
			label1.TabIndex = 5;
			label1.Text = "Made by Rico Z";
			label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(395, 415);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "About";
			Text = "About";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			Drag1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).EndInit();
			ResumeLayout(false);
		}
	}
}
