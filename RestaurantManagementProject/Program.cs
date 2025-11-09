using System;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show login as dialog. If login succeeds (DialogResult.OK) run main form.
            using (var login = new frmLogin())
            {
                DialogResult dr = login.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }
    }
}