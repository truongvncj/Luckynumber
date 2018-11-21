using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using Luckynumber.View;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;

//Luckynumber.LinqtoSQLDataContext

namespace Luckynumber.Control
{
    class Control
    {




        class datatoExport
        {
            public System.Data.DataTable dataGrid1 { get; set; }
            public string filename { get; set; }
            public string tittle { get; set; }
        }


        public static void exportsexcel(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;


            //      DataTable table, string filename
            DataTable dt = dat.dataGrid1;
            string filename = dat.filename;
            //   SpreadsheetDocument spse = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook);
            //Exporting to Excel

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            //ExcelDocument xls = new ExcelDocument();
            //xls.easy_WriteXLSFile_FromDataSet("datatable.xls", ds,
            //           new ExcelAutoFormat(DocumentFormat.OpenXml.Wordprocessing.Styles.AUTOFORMAT_EASYXLS1), "DataTable");


            //string folderPath = "C:\\Excel\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            try
            {
                //using (XLWorkbook wb = new XLWorkbook())
                //{

                ExportToExcel.ExportToExcel.ExportDataSet(ds, filename);
                //    wb.Worksheets.Add(ds);
                //    wb.SaveAs(filename);
                //}
                MessageBox.Show(filename + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Thông báo không excel export được ! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static string GetExcelColumnName(int columnIndex)
        {
            //  eg  (0) should return "A"
            //      (1) should return "B"
            //      (25) should return "Z"
            //      (26) should return "AA"
            //      (27) should return "AB"
            //      ..etc..
            char firstChar;
            char secondChar;
            char thirdChar;

            if (columnIndex < 26)
            {
                return ((char)('A' + columnIndex)).ToString();
            }

            if (columnIndex < 702)
            {
                firstChar = (char)('A' + (columnIndex / 26) - 1);
                secondChar = (char)('A' + (columnIndex % 26));

                return string.Format("{0}{1}", firstChar, secondChar);
            }

            int firstInt = columnIndex / 26 / 26;
            int secondInt = (columnIndex - firstInt * 26 * 26) / 26;
            if (secondInt == 0)
            {
                secondInt = 26;
                firstInt = firstInt - 1;
            }
            int thirdInt = (columnIndex - firstInt * 26 * 26 - secondInt * 26);

            firstChar = (char)('A' + firstInt - 1);
            secondChar = (char)('A' + secondInt - 1);
            thirdChar = (char)('A' + thirdInt);

            return string.Format("{0}{1}{2}", firstChar, secondChar, thirdChar);
        }



        public static void exportsexcelold(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;

            //    DataTable dataTble = new DataTable();
            //   DataSet dataSet, string outputPath

            // Create the Excel Application object
            cExcel.ApplicationClass excelApp = new cExcel.ApplicationClass();

            // Create a new Excel Workbook
            cExcel.Workbook excelWorkbook = excelApp.Workbooks.Add();

            int sheetIndex = 0;

            System.Data.DataTable DataTable = dat.dataGrid1;
            var tittle = dat.tittle;
            var ExcelFilePath = dat.filename;

            // Copy the DataTable to an object array
            //  object[,] Arr = new object[dt.Rows.Count, dt.Columns.Count];

            cExcel.Worksheet Worksheet = (cExcel.Worksheet)excelWorkbook.Sheets.Add(
            excelWorkbook.Sheets.get_Item(++sheetIndex),
            Type.Missing, 1, cExcel.XlSheetType.xlWorksheet);


            #region
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                //    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                //     Excel.Workbooks.Add();
                ColumnsCount = DataTable.Columns.Count;
                int RowsCount = DataTable.Rows.Count;
                // single worksheet
                //    Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int downloadtimes = 0;
                int rowdown = 30000;
                int totalrowcount = 0;
                int maxrows = 0;
                do
                {
                    downloadtimes++;
                    totalrowcount = rowdown * downloadtimes;


                    object[,] Cells = new object[rowdown, ColumnsCount];

                    //for (int j = 0; j < RowsCount; j++)
                    //    for (int i = 0; i < ColumnsCount; i++)
                    //        Cells[j, i] = DataTable.Rows[j][i
                    if (RowsCount >= (downloadtimes) * rowdown)
                    {
                        maxrows = (downloadtimes) * rowdown;
                    }
                    else
                    {
                        maxrows = RowsCount;
                    }
                    for (int j = (downloadtimes - 1) * rowdown; j < maxrows; j++)
                        for (int i = 0; i < ColumnsCount; i++)
                            Cells[j, i] = DataTable.Rows[j][i];



                    Worksheet.get_Range("A" + GetExcelColumnName((downloadtimes - 1) * rowdown + 1) + ":" + GetExcelColumnName(ColumnsCount - 1) + (RowsCount + 1).ToString(), Type.Missing).Value2 = Cells;


                } while (maxrows == RowsCount);


                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath, cExcel.XlFileFormat.xlOpenXMLWorkbook);
                        excelApp.Quit();
                        excelApp = null;
                        MessageBox.Show(ExcelFilePath + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! \n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    excelApp.Visible = true;
                }






            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
            #endregion


        }


        


        public void exportExceldatagridtofile(IQueryable IQuery, LinqtoSQLDataContext db, string tittle)
        {


            System.Data.DataTable datatable1 = new System.Data.DataTable();
            //

          //  Utils ul = new Utils();

            datatable1 = Utils.ToDataTable(db, IQuery);


            //  this.dataGridView2.DataSource =  dataGridView1.DataSource;
            //
            #region // connect to excel
            SaveFileDialog theDialog = new SaveFileDialog();
            //


            //   DataGridView dataGridView1 = new DataGridView();
            //   dataGridView1.DataSource = dataGrid.DataSource;

            theDialog.Title = "Export to Excel file";
            theDialog.Filter = "Excel files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";

            #endregion
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                //   DataGridView datagr1 = new DataGridView();
                //  datagr1 = dataGrid1;

                Thread t1 = new Thread(exportsexcel);
                t1.IsBackground = true;
                t1.Start(new datatoExport() { dataGrid1 = datatable1, filename = filename, tittle = tittle });
                // t1.Join();
            }



        }

    

    }

}