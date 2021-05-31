using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auditoria.Vista.FrameMDI;

namespace Auditoria.Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddWindow<CustomForm>() where CustomForm : Form, new()
        {
            Form window = panel5.Controls.OfType<CustomForm>().FirstOrDefault();

            if (window == null)
            {
                window = new CustomForm();
                window.TopLevel = false;
                window.Dock = DockStyle.Fill;
                panel5.Controls.Add(window);
                panel5.Tag = window;
                window.Show();
                window.BringToFront();
            }
            else
            {
                window.BringToFront();
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            AddWindow<Monitoreo>();
        }
    }
}
