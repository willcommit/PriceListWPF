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

        public void populatePartsList(ExcelPackage package, List<Product> products)
        {
            var sheet = package.Workbook.Worksheets.First();

            int rowCount = sheet.Dimension.End.Row;

            for (int row = 2; row < rowCount; row++)
            {
                Product product = new Product();
                product.ItemNo = sheet.Cells[row, 1].Text.Trim();
                product.Model = sheet.Cells[row, 2].Text.Trim();
                product.Description = sheet.Cells[row, 10].Text.Trim();
                product.UnitPrice = Int32.Parse(sheet.Cells[row, 3].Text.Trim());
                product.DiscountDealer = Int32.Parse(sheet.Cells[row, 5].Text.Trim());
                product.DiscountMyndighet = Int32.Parse(sheet.Cells[row, 6].Text.Trim());
                product.UnitCost = Int32.Parse(sheet.Cells[row, 8].Text.Trim());

                products.Add(product);
            }      
        }
    }
}








