using System;
using System.Windows.Forms;

namespace LoLAccManager
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Form1());
			Application.Run(new Form2());
		}
	}
}
