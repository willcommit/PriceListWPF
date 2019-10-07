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


        public void setFileName()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            FileName = fd.FileName;
        }

        public ExcelPackage readExcel()
        {
            try
            {
                FileInfo newFile = new FileInfo(FileName);
                return new ExcelPackage(newFile);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }      
        }

        public ExcelPackage readExcel(string pwd)
        {
            try
            {
                MessageBox.Show("Please enter password");
                FileInfo newFile = new FileInfo(FileName);
                return new ExcelPackage(newFile, pwd);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void populatePartsList(ExcelPackage package, List<SparePart> parts)
        {
            var sheet = package.Workbook.Worksheets.First();

            int rowCount = sheet.Dimension.End.Row;

            for (int row = 2; row < rowCount; row++)
            {
                SparePart sparePart = new SparePart();
                sparePart.ItemCode = sheet.Cells[row, 1].Text.Trim();
                sparePart.Description = sheet.Cells[row, 2].Text.Trim();
                sparePart.Type = sheet.Cells[row, 3].Text.Trim();
                sparePart.FCAPrice = sheet.Cells[row, 5].Text.Trim();
                sparePart.Export = false;

                parts.Add(sparePart);
            }        
        }
    }
}








