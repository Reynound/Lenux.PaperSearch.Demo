using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperSearch
{
    public class ExportDto
    {
        [ExcelColumnWidth(70)]
        public string 论文名 { get; set; }

        [ExcelColumnWidth(100)]
        public string 句子 { get; set; }

        [ExcelColumnWidth(30)]
        public string 时间 { get; set; }
    }
}
