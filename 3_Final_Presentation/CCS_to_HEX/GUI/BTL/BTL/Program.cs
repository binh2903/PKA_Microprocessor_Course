using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

// Ensure that Form1 is defined in the same namespace or add the correct using directive
namespace BTL
{
    public class Form1 : Form
    {
        public Form1()
        {
            // Initialize form components
        }
    }
}
