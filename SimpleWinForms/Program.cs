using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Margins margins = new Margins(100, 100, 100, 100);
            Margins margins2 = null;

            using (Stream s = new MemoryStream())
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, margins);
                
                s.Seek(0, SeekOrigin.Begin);
                margins2 = (Margins)b.Deserialize(s);

            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
