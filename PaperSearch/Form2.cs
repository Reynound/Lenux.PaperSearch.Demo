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
                                                                // 将PictureBox添加到窗体上  
            this.Controls.Add(pictureBox1);

            // 假设你的图片文件名为"example.jpg"，并且它位于应用程序的根目录下  
            // 你需要根据你的实际路径和文件名来调整下面的代码  
            var basePath = Path.Combine(AppContext.BaseDirectory, "temp");
            string imagePath = Path.Combine(basePath, "orm.jpg");
            pictureBox1.Image = Image.FromFile(imagePath); // 加载并显示图片  

        }

    }
}
