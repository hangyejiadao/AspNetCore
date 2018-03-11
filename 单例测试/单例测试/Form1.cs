using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 单例测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < 100000000; i++)
            {
                Test.GetInstanceA();
            }
            Console.WriteLine((DateTime.Now-now).Milliseconds); 
        }
    }

    public class Test
    {
        private static object obj = new object();
        public static Test instance;

        public static Test GetInstance()
        {
            if (instance==null)
            {
                lock (obj)
                {
                    if (instance==null)
                    {
                        instance = new Test();
                    }
                }
            }
            return instance;
        }

        public static Test GetInstanceA()
        {
            instance = null;
          
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new Test();
                    }
                }
            }
            return instance;
        }
    }
}
