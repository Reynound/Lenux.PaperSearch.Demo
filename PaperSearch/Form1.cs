using DevExpress.XtraPrinting.Native;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Native;
using MiniExcelLibs;
using System.IO;
using static iText.Svg.SvgConstants;
using DevExpress.XtraEditors;
using System.Diagnostics;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace PaperSearch
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        int count = 0;

        public Form1()
        {
            InitializeComponent();

        }



        #region 页面

        private void Form1_Load(object sender, EventArgs e)
        {
            CmbxInitialize();
        }

        private void CmbxInitialize()
        {
            var lst = new List<CmbxDto>()
            {
                new CmbxDto(){Key = 1,Value="分段落(不完善)"},
                new CmbxDto(){Key = 2,Value="分语句"}
            };
            cmbxExport.Properties.DataSource = lst;
            cmbxExport.Properties.DisplayMember = "Value";
            cmbxExport.Properties.ValueMember = "Key";
            cmbxExport.ItemIndex = 2;
            cmbxExport.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value"));
        }

        private void keyLabel_MouseHover(object sender, EventArgs e)
        {
            labKey.Text = "多个关键词请使用英文逗号连接";
        }

        private void keyLabel_MouseLeave(object sender, EventArgs e)
        {
            labKey.Text = "关键词";
        }

        #endregion

        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnImport_Click(object sender, EventArgs e)
        {
            dic.Clear();
            lstPaper.Items.Clear();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择文件";
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "所有文件 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        string fileNameOnly = System.IO.Path.GetFileName(fileName);
                        dic.Add(fileNameOnly, fileName);
                        lstPaper.Items.Add(fileNameOnly);
                    }
                }
            }

        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var keys = txtKey.Text.Split(",")
                .Where(key => !string.IsNullOrEmpty(key))
                .ToList();

            if (lstRes.Items.Count != 0) lstRes.Items.Insert(0, "-------------");

            if (keys != null && keys.Any())
            {
                //string pattern = $@"\b{string.Join(@"\W*?\b.*?\b", keys)}.*?[.?!。！？]";
                var notMatchFileName = new List<string>();

                //查询内容
                if (dic.Count > 0)
                {
                    count++;
                    if (count == 3)
                    {
                        //var result1=MessageBox.Show("今天已经很努力了，休息一下吧😋", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (result1 == DialogResult.OK)
                        //{
                        //    var result2 = MessageBox.Show("但是真的要休息吗🤔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    if (result2 == DialogResult.OK)
                        //    {
                        //        var result3 = MessageBox.Show("那就在查一会吧", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        Form2 form = new Form2();
                        //        form.StartPosition = FormStartPosition.CenterScreen;
                        //        form.ShowDialog();
                        //        return;
                        //    }
                        //}
                    }
                    foreach (var fileName in dic)
                    {

                        PdfDocument pdfDoc = new PdfDocument(new PdfReader(fileName.Value));
                        bool matched = false;
                        var matchCount = 0;

                        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                        {
                            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                            new PdfCanvasProcessor(strategy).ProcessPageContent(pdfDoc.GetPage(i));
                            string pageText = strategy.GetResultantText();
                            string a = pageText.Replace("\r\n","");
                            var sentences = new List<string>();
                            if (Convert.ToInt32(cmbxExport.EditValue) == 2) sentences = Regex.Split(pageText, @"(?<=[.!?。！？])\s*").ToList();
                            else
                            {
                                sentences = Regex.Split(pageText, @"(?:\.|""|\?)\s*\n").ToList();
                            }

                            List<string> matchedSentences = new List<string>();

                            foreach (var sentence in sentences)
                            {
                                bool allKeywordsFound = true;
                                foreach (var keyword in keys)
                                {
                                    if (!sentence.Contains(keyword))
                                    {
                                        allKeywordsFound = false;
                                        break;
                                    }
                                }
                                matched = true;
                                if (allKeywordsFound)
                                {
                                    matchCount++;
                                    lstLog.Items.Insert(0, System.DateTime.Now.ToString() + $" & 《{fileName.Key}》 & {sentence}");
                                }
                            }
                        }
                        if (matched) lstRes.Items.Insert(0, $"《{fileName.Key}》 & 共匹配{matchCount}处");
                        pdfDoc.Close();
                    }

                    if (notMatchFileName.Count != 0)
                    {

                        var msg = $"下列文件未匹配到关键词{Environment.NewLine}";
                        StringBuilder sb = new StringBuilder();

                        foreach (var item in notMatchFileName)
                        {
                            sb.Append(item);
                            sb.AppendLine(Environment.NewLine);
                        }
                        if (sb.Length > 0 && sb[sb.Length - 1] == '\n')
                        {
                            sb.Length--;
                        }

                        msg = msg + sb.ToString();
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else MessageBox.Show("请先选择要查找的论文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("请输入关键词", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lstLog.Items.Insert(0, $"${System.DateTime.Now.ToString()}本次用时{(DateTime.Now - start).Seconds}s");
        }

        private void HaveRest()
        {
            // 指定要打开的URL  
            string url = "https://www.baidu.com";

            // 使用Process类启动默认浏览器并加载URL  
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                // 如果由于某种原因（如URL格式不正确）Process.Start失败，则显示错误消息  
                MessageBox.Show($"{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClr_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
            lstRes.Items.Clear();
        }

        /// <summary>
        /// 导出日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnExport_Click(object sender, EventArgs e)
        {
            await ExportListBoxToExcel(lstLog);
        }

        private async Task ExportListBoxToExcel(ListBoxControl listBox)
        {
            // 将ListBox项转换为List<string>  
            List<ExportDto> values = new List<ExportDto>();
            foreach (var item in listBox.Items)
            {
                var a = item;
                if (!item.ToString().StartsWith("$"))
                {
                    var data = item.ToString().Split("&");
                    var value = new ExportDto()
                    {
                        论文名 = data[1],
                        时间 = data[0],
                        句子 = data[2]
                    };
                    values.Add(value);
                }
            }

            var preFileName = DateTime.Now.ToString("yyyyMMddHHmmssyyyy");
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var basePath = Path.Combine(desktopPath, "temp");
            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

            var filePath = Path.Combine(basePath, $"{preFileName}.xlsx");
            await MiniExcel.SaveAsAsync(filePath, values);

            MessageBox.Show("ListBox内容已成功导出到Excel文件: " + filePath);
        }



    }
}
