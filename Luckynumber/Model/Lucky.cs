﻿using System;
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

        public bool deleteProgramelist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //   var rs = from tblFBL5N in db.tblFBL5Ns
            //          select tblFBL5N;
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tbl_CTKM");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tbl_CTKM " + ex.ToString());
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


        private void importProgamelistsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            luckyno md = new luckyno();

            bool kq = md.deleteProgramelist();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("mactring", typeof(string));
            batable.Columns.Add("pomessage", typeof(string));
            batable.Columns.Add("maspmua", typeof(string));
            batable.Columns.Add("maspmuakm", typeof(string));
        //    batable.Columns.Add("tenspmua", typeof(string));
         //   batable.Columns.Add("tenspkm", typeof(string));
            batable.Columns.Add("tylekm", typeof(double));
            batable.Columns.Add("tungay", typeof(DateTime));

            batable.Columns.Add("denngay", typeof(DateTime));
            batable.Columns.Add("manhomKHkhuyenmai", typeof(string));





            int mactringid = -1;
            int pomessageid = -1;
            int maspmuaid = -1;
            int maspmuakmid = -1;
            int tylekmid = -1;
            int tungayid = -1;
            int denngayid = -1;
            int manhomKHkhuyenmai = -1;
            string value = "";
            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                  
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
                        if (value.Trim() == "Mã CT")  //Account
                        {
                            mactringid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("PO Message"))
                        {

                            pomessageid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("Mã SP Mua"))
                        {

                            maspmuaid = columid;
                            //   headindex = 0;



                        }

                        if (value.Trim() == ("Mã SP KM"))
                        {

                            maspmuakmid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("Tỷ lệ CTKM"))
                        {
                            tylekmid = columid;

                        }
                        if (value.Trim() == ("Từ ngày"))
                        {
                            tungayid = columid;

                        }
                        if (value.Trim() == ("Đến Ngày"))
                        {
                            denngayid = columid;

                        }
                        if (value.Trim() == ("Mã Nhóm khách hàng"))
                        {
                            manhomKHkhuyenmai = columid;

                        }

                    }
                    #endregion


                }// colum

            }// roww off heatder

     

            if (mactringid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Mã CT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pomessageid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột PO Message", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (maspmuaid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Mã SP Mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (maspmuakmid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Mã SP KM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tylekmid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Tỷ lệ CTKM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tungayid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Từ ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (denngayid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Đến Ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (manhomKHkhuyenmai == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cộtMã Nhóm khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region



                string tylekmkq = sourceData.Rows[rowixd][tylekmid].ToString();
                if (tylekmkq != "" && Utils.IsValidnumber(tylekmkq) && sourceData.Rows[rowixd][tylekmid].ToString().Trim() != "")
                {

                    if (double.Parse(tylekmkq) > 0)
                    {
                        DataRow dr = batable.NewRow();
                        dr["mactring"] = sourceData.Rows[rowixd][mactringid].ToString().Truncate(225).Trim();
                        dr["pomessage"] = sourceData.Rows[rowixd][pomessageid].ToString().Truncate(225).Trim();

                        dr["maspmua"] = sourceData.Rows[rowixd][maspmuaid].ToString().Truncate(225).Trim();
                        dr["maspmuakm"] = sourceData.Rows[rowixd][maspmuakmid].ToString().Truncate(225).Trim();




                        dr["tylekm"] = double.Parse(sourceData.Rows[rowixd][tylekmid].ToString());//.Truncate(225).Trim();


                        dr["tungay"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][tungayid].ToString());//.Truncate(225).Trim();

                        dr["denngay"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][denngayid].ToString());//.Truncate(225).Trim();
                        dr["manhomKHkhuyenmai"] = sourceData.Rows[rowixd][manhomKHkhuyenmai].ToString().Truncate(225).Trim();// double.Parse(sourceData.Rows[rowixd][manhomKHkhuyenmai].ToString());//.Truncate(225).Trim();
                   


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

                bulkCopy.DestinationTableName = "tbl_CTKM";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("mactring", "[Mã CT]");
                bulkCopy.ColumnMappings.Add("pomessage", "[PO Message]");
                bulkCopy.ColumnMappings.Add("maspmua", "[Mã SP Mua]");
                bulkCopy.ColumnMappings.Add("maspmuakm", "[Mã SP KM]");
                bulkCopy.ColumnMappings.Add("tylekm", "[Tỷ lệ CTKM]");
                bulkCopy.ColumnMappings.Add("tungay", "[Từ ngày]");
                bulkCopy.ColumnMappings.Add("denngay", "[Đến Ngày]");
                bulkCopy.ColumnMappings.Add("manhomKHkhuyenmai", "[Nhóm khách hàng]");



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



        public void UploadProgamelist()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Progarme List excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importProgamelistsexcel);
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
