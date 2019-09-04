using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Table;
using OfficeOpenXml.Drawing.Chart;
using System.Globalization;
using Microsoft.Win32;
using System.Windows;

namespace PriceList.Classes
{
    class Xlxs
    {
        public string FileName { get; set; }
        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public void setFileName()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            FileName = fd.FileName;
        }

        public void ReadXlxsToDb()
        {
            SparePartDB sparePartDB = new SparePartDB();
            FileInfo newFile = new FileInfo(FileName);
            try
            {
                SparePartDB.parts.Clear();
                ExcelPackage newPackage = new ExcelPackage(newFile, pwd);
                var sheet = newPackage.Workbook.Worksheets.First();

                int colCount = sheet.Dimension.End.Column;
                int rowCount = sheet.Dimension.End.Row;

                for (int row = 2; row < rowCount; row++)
                {
                    SparePart sparePart = new SparePart();
                    sparePart.ItemCode = sheet.Cells[row, 1].Text.Trim();
                    sparePart.Description = sheet.Cells[row, 2].Text.Trim();
                    sparePart.Type = sheet.Cells[row, 3].Text.Trim();
                    sparePart.FCAPrice = sheet.Cells[row, 5].Text.Trim();

                    SparePartDB.parts.Add(sparePart);               
                }

                sparePartDB.InsertDataFast(SparePartDB.parts);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}








