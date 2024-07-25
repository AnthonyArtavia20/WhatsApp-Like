using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole(); // Mostrar la consola
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            Console.WriteLine(message);
            MessageBox.Show("Message printed to console: " + message);
        }
    }
}
