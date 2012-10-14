using System;
using System.Windows.Forms;

namespace D3Util
{
	static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
//#if DEBUG
//			Application.Run(new frmDebug());
//#endif
			Application.Run(new frmMain());
		}
	}
}
