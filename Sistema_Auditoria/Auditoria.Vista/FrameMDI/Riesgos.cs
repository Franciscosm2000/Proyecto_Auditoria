using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auditoria.Controler;

namespace Auditoria.Vista.FrameMDI
{
    public partial class Riesgos : Form
    {
        public Riesgos()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RiesgoController.Show();
        }
    }
}
