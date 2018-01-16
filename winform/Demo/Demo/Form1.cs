using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5000/";
            string result = HttpHelper.Request(url + "api/Values/", null, null, HttpMethod.GET);
            Console.WriteLine(result);

            string getid = HttpHelper.Request(url + "api/Values/Get?id=1", null, null, HttpMethod.GET);
            Console.WriteLine(getid);
        }
    }
}
