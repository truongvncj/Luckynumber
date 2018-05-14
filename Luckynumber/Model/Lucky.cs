using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using arconfirmationletter.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using arconfirmationletter.shared;

namespace arconfirmationletter.Model
{
    class luckyno
    {
       
        public bool deleteProductlist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //   var rs = from tblFBL5N in db.tblFBL5Ns
            //          select tblFBL5N;
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tbl_Product");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tbl_Product " + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }

        public static void viewall()
        {
            string connection_string = Utils.getConnectionstr();
          
        }

        class datainportF
        {

            public string filename { get; set; }

        }

        private void importproductlistsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            luckyno md = new luckyno();

            bool kq = md.deleteProductlist();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("Marterialcode", typeof(string));
            batable.Columns.Add("Marterialname", typeof(string));
            batable.Columns.Add("Packsize", typeof(string));
            batable.Columns.Add("PCQuychuan", typeof(double));
            batable.Columns.Add("UCRate", typeof(double));
            //batable.Columns.Add("DocumentNumber", typeof(double));
            //batable.Columns.Add("Amountinlocalcurrency", typeof(double));
            //batable.Columns.Add("Deposit", typeof(double));


            int Marterialcodeid = -1;
            int Marterialnameid = -1;
            int Packsizeid = -1;
            int PCQuychuanid = -1;
            int UCRateid = -1;
      
            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = "";
                    try
                    {
                        value = sourceData.Rows[rowid][columid].ToString();

                    }
                    catch (Exception)
                    {
                        value = "";
                        //  throw;
                    }
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Marterial code"))  //Account
                        {
                            Marterialcodeid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Marterial name"))
                        {

                            Marterialnameid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("Pack size"))
                        {

                            Packsizeid = columid;
                            //   headindex = 0;



                        }

                        if (value.Trim() == ("PC Quy chuan"))
                        {

                            PCQuychuanid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("UC Rate"))
                        {
                            UCRateid = columid;

                        }
                      
                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Marterialcodeid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Marterial code", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Marterialnameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Marterial name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Packsizeid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Pack size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PCQuychuanid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột PCQuychuan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UCRateid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột UC Rate", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

      

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region
                

                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string PCQuychuan = sourceData.Rows[rowixd][PCQuychuanid].ToString();
                if (PCQuychuan != "" && Utils.IsValidnumber(PCQuychuan) && sourceData.Rows[rowixd][PCQuychuanid].ToString().Trim() != "")
                {

                    if (double.Parse(PCQuychuan) > 0)
                    {
                        DataRow dr = batable.NewRow();
                        dr["Marterialcode"] = sourceData.Rows[rowixd][Marterialcodeid].ToString().Truncate(225).Trim();
                        dr["Marterialname"] = sourceData.Rows[rowixd][Marterialnameid].ToString().Truncate(225).Trim();
                        dr["Packsize"] = sourceData.Rows[rowixd][Packsizeid].ToString().Truncate(225).Trim();
                        dr["PCQuychuan"] = double.Parse(sourceData.Rows[rowixd][PCQuychuanid].ToString());//.Truncate(225).Trim();
                        dr["UCRate"] = double.Parse(sourceData.Rows[rowixd][UCRateid].ToString());//.Truncate(225).Trim();

                  


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }

            //    Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                bulkCopy.DestinationTableName = "tbl_Product";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Marterialcode", "[Marterial code]");
                bulkCopy.ColumnMappings.Add("Marterialname", "[Marterial name]");
                bulkCopy.ColumnMappings.Add("Packsize", "[Pack size]");
                bulkCopy.ColumnMappings.Add("PCQuychuan", "[PC Quy chuan]");
                bulkCopy.ColumnMappings.Add("UCRate", "[UC Rate]");
             

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }





        }

        class datashowwait
        {

            public View.Caculating wat { get; set; }


        }



        private void showwait(object obj)
        {
            // View.Caculating wat = new View.Caculating();

            //            View.Caculating wat = (View.Caculating)obj;
            datashowwait obshow = (datashowwait)obj;

            View.Caculating wat = obshow.wat;

            wat.ShowDialog();


        }

        // ThreadProclose



        public void Uploadproductlist()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Product List excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importproductlistsexcel);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });



                View.Caculating wat = new View.Caculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }


            }

        }

    } // en class
} // endname space
