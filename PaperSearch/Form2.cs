using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaperSearch
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            this.Controls.Add(pictureBox1);

            var basePath = Path.Combine(AppContext.BaseDirectory, "temp");
            string imagePath = Path.Combine(basePath, "orm.jpg");
            pictureBox1.Image = Image.FromFile(imagePath);

        }

    }
}
