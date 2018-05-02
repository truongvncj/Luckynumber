using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using arconfirmationletter.shared;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace arconfirmationletter.Model
{
    class customerinput_ctrl
    {


        public void deleteunuselistcustomer()
        {

            #region // xóa data bảng tblCustomer
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_unuserCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();



            //  return true;
            #endregion
        }




        public bool customerdeleted()
        {
            #region // xóa data bảng tblCustomer
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tblCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();



            return true;
            #endregion

        }


        class datainportF
        {

            public string filename { get; set; }

        }
        private void importsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tblCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;



            #region  new




            #region  new by datatable

            //     ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();


            //@"SELECT Customer, [Sales Organization],
            //                        [Name 1], Address, [Telephone 1] FROM [Sheet1$]

            //                         WHERE  (Customer IS NOT NULL)", conn);




            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("SalesOrganization", typeof(string));
            batable.Columns.Add("Name", typeof(string));
            batable.Columns.Add("Address", typeof(string));
            batable.Columns.Add("Telephone", typeof(string));




            int Customerid = -1;
            int Organizationid = -1;
            int Nameid = -1;
            int Addressid = -1;
            int Telephoneid = -1;





            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Customer") && Customerid == -1)
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sales Organization") && Organizationid == -1)
                        {

                            Organizationid = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Name 1") && Nameid == -1)
                        {

                            Nameid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("Address") && Addressid == -1)
                        {

                            Addressid = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Telephone 1") && Telephoneid == -1)
                        {

                            Telephoneid = columid;
                            //    headindex = 0;

                        }
                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Organizationid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Organization", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Addressid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Address", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Telephoneid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Telephone", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Customerid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal))
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {
                            if (sourceData.Rows[rowixd][Organizationid].ToString().Length > 200)
                            {

                                dr["SalesOrganization"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["SalesOrganization"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim();

                            }

                            dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                            //dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());
                            if (sourceData.Rows[rowixd][Nameid].ToString().Length > 200)
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim();
                            }



                            if (sourceData.Rows[rowixd][Addressid].ToString().Length > 200)
                            {
                                dr["Address"] = sourceData.Rows[rowixd][Addressid].ToString().Trim().Substring(0, 200);
                            }
                            else
                            {
                                dr["Address"] = sourceData.Rows[rowixd][Addressid].ToString().Trim();
                            }

                            if (sourceData.Rows[rowixd][Telephoneid].ToString().Length > 200)
                            {
                                dr["Telephone"] = sourceData.Rows[rowixd][Telephoneid].ToString().Trim().Substring(0, 200);
                            }
                            else
                            {
                                dr["Telephone"] = sourceData.Rows[rowixd][Telephoneid].ToString().Trim();
                            }
                        }
                        catch (Exception ex2)
                        {

                            MessageBox.Show(ex2.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion

            //   Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                //batable.Columns.Add("Customer", typeof(double));
                //batable.Columns.Add("SalesOrganization", typeof(string));
                //batable.Columns.Add("Name", typeof(string));
                //batable.Columns.Add("Address", typeof(string));
                //batable.Columns.Add("Telephone", typeof(string));



                bulkCopy.DestinationTableName = "tblCustomer";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Customer", "[Customer]");
                bulkCopy.ColumnMappings.Add("SalesOrganization", "[SOrg]");
                bulkCopy.ColumnMappings.Add("Name", "[Name 1]");
                bulkCopy.ColumnMappings.Add("Address", "[Address]");
                bulkCopy.ColumnMappings.Add("Telephone", "[Telephone 1]");



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
            #endregion end new





            //   Thread.CurrentThread.Abort();

        }

        private void importunsendcustomer(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_Unsendlist");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;


            //#region old


            //string connectionString = "";
            //if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            //{
            //    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            //}
            //else
            //{
            //    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            //}
            ////---------------fill data

            //System.Data.DataTable sourceData = new System.Data.DataTable();
            //using (OleDbConnection conn =
            //                       new OleDbConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }


            //    // Get the data from the source table as a SqlDataReader.
            //    OleDbCommand command = new OleDbCommand(
            //                        @"SELECT Sorg, Customer,
            //                        Name FROM [Sheet1$]

            //                         WHERE  (Customer IS NOT NULL)", conn);

            //    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //    try
            //    {
            //        adapter.Fill(sourceData);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }


            //    conn.Close();
            //}


            //#endregion old
            /////     Utils util = new Utils();


            #region  new by datatable

            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();


            //@"SELECT Customer, [Sales Organization],
            //                        [Name 1], Address, [Telephone 1] FROM [Sheet1$]

            //                         WHERE  (Customer IS NOT NULL)", conn);


            batable.Columns.Add("Customer", typeof(double));

            //   batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("Sorg", typeof(string));
            batable.Columns.Add("Name", typeof(string));



            int Customerid = -1;
            int Organizationid = -1;
            int Nameid = -1;




            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Customer") && Customerid == -1)
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sorg") && Organizationid == -1)
                        {

                            Organizationid = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Name") && Nameid == -1)
                        {

                            Nameid = columid;
                            //    headindex = 0;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Organizationid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Organization", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Customerid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal))
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {
                            if (sourceData.Rows[rowixd][Organizationid].ToString().Length > 10)
                            {

                                dr["Sorg"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim().Substring(0, 10);

                            }
                            else
                            {
                                dr["Sorg"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim();

                            }

                            dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                            //dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());
                            if (sourceData.Rows[rowixd][Nameid].ToString().Length > 200)
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim();
                            }



                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Data có đủ cột nhưng dữ liệu ở dưới bị lost, please check", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion




            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.DestinationTableName = "tbl_Unsendlist";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Sorg", "Sorg");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Name", "Name");
                //   bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //    bulkCopy.ColumnMappings.Add("Telephone 1", "[Telephone 1]");

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            // goik hàm update trên ser 

            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustListnotsend", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






            //   Thread.CurrentThread.Abort();

        }

        private void inputcustomerUNUSEinput(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            //db.ExecuteCommand("DELETE FROM tbl_Unsendlist");
            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;






            #region  new by datatable

            //    ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();



            batable.Columns.Add("Customer", typeof(double));




            int Customerid = -1;



            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Customer") && Customerid == -1)
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }


                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Customerid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != null)
                {

                    if (double.Parse(DocumentNoVal) > 0 && double.Parse(DocumentNoVal) < 99999999)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {


                            //dr["Customer"] = double.Parse(DocumentNoVal);
                            //  dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                            dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Data có đủ cột nhưng dữ liệu ở dưới bị lost, please check", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion



            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.DestinationTableName = "tbl_unuserCustomer";
                // Write from the source to the destination.
                //   bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                //     bulkCopy.ColumnMappings.Add("Name", "Name");
                //   bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //    bulkCopy.ColumnMappings.Add("Telephone 1", "[Telephone 1]");

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi bulkcopy unuse !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            // goik hàm update trên ser 

            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustListnotsend", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






            //   Thread.CurrentThread.Abort();

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



        public void customerUNUSEinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Unuse excel data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(inputcustomerUNUSEinput);
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

        public void customerinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Customer excel data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsexcel2);
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

        public void customerinputunsendlist()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Unsend customer data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importunsendcustomer);
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

        public void customerBegibalancelist()
        {
            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Begine Balance data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importBeginbalance);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                //      ThreadPool.QueueUserWorkItem(new WaitCallback(importsexcel)); //join


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










            // throw new NotImplementedException();
        }

        public void importBeginbalance(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tblFBL5beginbalace");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;


            //#region old


            //string connectionString = "";
            //if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            //{
            //    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            //}
            //else
            //{
            //    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            //}
            ////---------------fill data

            //System.Data.DataTable sourceData = new System.Data.DataTable();
            //using (OleDbConnection conn =
            //                       new OleDbConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }


            //    // Get the data from the source table as a SqlDataReader.
            //    OleDbCommand command = new OleDbCommand(
            //                        @"SELECT Account, Business_Area, Amount_in_local_currency,Fullgood_amount, Deposit_amount,Empty_Amount,Empty_Amount_Notmach,
            //                        Adjusted_amount, Payment_amount,Ketvothuong,Chaivothuong,Ketvolit,Chaivo1lit,
            //                        Ketnhuathuong, Ketnhua1lit,joy20l,Binhpmicc02,binhpmix9l,palletgo,paletnhua

            //                         FROM [Sheet1$]

            //                         WHERE  (Account IS NOT NULL)", conn);
            //    //              Account Business_Area   Amount_in_local_currency Fullgood_amount Deposit_amount Empty_Amount    Empty_Amount_Notmach Adjusted_amount Payment_amount id  codeGroup Ketvothuong Chaivothuong Ketvolit    Chaivo1lit Ketnhuathuong   Ketnhua1lit joy20l  Binhpmicc02 binhpmix9l  palletgo paletnhua

            //    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //    try
            //    {
            //        adapter.Fill(sourceData);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }


            //    conn.Close();
            //}


            //#endregion odl


            #region  new by datatable

            //   ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();


            //@"SELECT Customer, [Sales Organization],
            //                        [Name 1], Address, [Telephone 1] FROM [Sheet1$]

            //                         WHERE  (Customer IS NOT NULL)", conn);




            batable.Columns.Add("Account", typeof(double));

            batable.Columns.Add("Amount_in_local_currency", typeof(double));
            batable.Columns.Add("Fullgood_amount", typeof(double));
            batable.Columns.Add("Deposit_amount", typeof(double));

            batable.Columns.Add("Empty_Amount", typeof(double));

            batable.Columns.Add("Empty_Amount_Notmach", typeof(double));
            batable.Columns.Add("Adjusted_amount", typeof(double));
            batable.Columns.Add("Payment_amount", typeof(double));

            batable.Columns.Add("Ketvothuong", typeof(int));
            batable.Columns.Add("Chaivothuong", typeof(int));
            batable.Columns.Add("Ketvolit", typeof(int));
            batable.Columns.Add("Chaivo1lit", typeof(int));
            batable.Columns.Add("Ketnhuathuong", typeof(int));
            batable.Columns.Add("Ketnhua1lit", typeof(int));
            batable.Columns.Add("joy20l", typeof(int));
            batable.Columns.Add("Binhpmicc02", typeof(int));
            batable.Columns.Add("binhpmix9l", typeof(int));

            batable.Columns.Add("palletgo", typeof(int));
            batable.Columns.Add("paletnhua", typeof(int));
            batable.Columns.Add("Business_Area", typeof(string));
            // batable.Columns.Add("Account", typeof(double));
            // batable.Columns.Add("Account", typeof(double));
            // batable.Columns.Add("Account", typeof(double));
            //  batable.Columns.Add("Account", typeof(double));


            int Accountid = -1;
            int Business_Areaid = -1;
            int Amount_in_local_currencyid = -1;
            int Fullgood_amountid = -1;
            int Deposit_amountid = -1;
            int Empty_Amountid = -1;

            int Empty_Amount_Notmachid = -1;
            int Adjusted_amountid = -1;
            int Payment_amountid = -1;
            int Ketvothuongid = -1;

            int Chaivothuongid = -1;
            int Ketvolitid = -1;

            int Chaivo1litid = -1;
            int Ketnhuathuongid = -1;
            int Ketnhua1litid = -1;
            int joy20lid = -1;
            int Binhpmicc02id = -1;
            int binhpmix9lid = -1;
            int palletgoid = -1;


            int paletnhuaid = -1;





            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Account") && Accountid == -1)
                        {
                            Accountid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Business_Area") && Business_Areaid == -1)
                        {

                            Business_Areaid = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Amount_in_local_currency") && Amount_in_local_currencyid == -1)
                        {

                            Amount_in_local_currencyid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("Fullgood_amount") && Fullgood_amountid == -1)
                        {

                            Fullgood_amountid = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Deposit_amount") && Deposit_amountid == -1)
                        {

                            Deposit_amountid = columid;
                            //    headindex = 0;

                        }
                        //Empty_Amountid
                        if (value.Trim() == ("Empty_Amount") && Empty_Amountid == -1)
                        {

                            Empty_Amountid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Empty_Amount_Notmach") && Empty_Amount_Notmachid == -1)
                        {

                            Empty_Amount_Notmachid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Adjusted_amount") && Adjusted_amountid == -1)
                        {

                            Adjusted_amountid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Payment_amount") && Payment_amountid == -1)
                        {

                            Payment_amountid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Ketvothuong") && Ketvothuongid == -1)
                        {

                            Ketvothuongid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Chaivothuong") && Chaivothuongid == -1)
                        {

                            Chaivothuongid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Ketvolit") && Ketvolitid == -1)
                        {

                            Ketvolitid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("Chaivo1lit") && Chaivo1litid == -1)
                        {

                            Chaivo1litid = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Ketnhuathuong") && Ketnhuathuongid == -1)
                        {

                            Ketnhuathuongid = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Ketnhua1lit") && Ketnhua1litid == -1)
                        {

                            Ketnhua1litid = columid;
                            //    headindex = 0;

                        }
                        // joy20lid

                        if (value.Trim() == ("joy20l") && joy20lid == -1)
                        {

                            joy20lid = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Binhpmicc02") && Binhpmicc02id == -1)
                        {

                            Binhpmicc02id = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("binhpmix9l") && binhpmix9lid == -1)
                        {

                            binhpmix9lid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("palletgo") && palletgoid == -1)
                        {

                            palletgoid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim() == ("paletnhua") && paletnhuaid == -1)
                        {

                            paletnhuaid = columid;
                            //    headindex = 0;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder




            if (Accountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Account", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Business_Areaid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Business_Area", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Amount_in_local_currencyid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Amount_in_local_currency", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Fullgood_amountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Fullgood_amount", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Deposit_amountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Deposit_amount", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Empty_Amountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Empty_Amount", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Empty_Amount_Notmachid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Empty_Amount_Notmach", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Adjusted_amountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Adjusted_amount", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Ketvothuongid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Ketvothuong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Chaivothuongid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Chaivothuong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Ketvolitid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Ketvolit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Chaivo1litid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Chaivo1lit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Ketnhuathuongid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Ketnhuathuong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Ketnhua1litid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Ketnhua1lit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (joy20lid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột joy20l", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Binhpmicc02id == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Binhpmicc02", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (binhpmix9lid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột binhpmix9l", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (palletgoid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột palletgo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (paletnhuaid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột paletnhua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region



                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Accountid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal))
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {


                            dr["Account"] = double.Parse(sourceData.Rows[rowixd][Accountid].ToString());

                            //dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());
                            if (sourceData.Rows[rowixd][Business_Areaid].ToString().Length > 10)
                            {
                                dr["Business_Area"] = sourceData.Rows[rowixd][Business_Areaid].ToString().Trim().Substring(0, 10);

                            }
                            else
                            {
                                dr["Business_Area"] = sourceData.Rows[rowixd][Business_Areaid].ToString().Trim();
                            }


                            DocumentNoVal = sourceData.Rows[rowixd][Fullgood_amountid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Fullgood_amount"] = double.Parse(sourceData.Rows[rowixd][Fullgood_amountid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Deposit_amountid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Deposit_amount"] = double.Parse(sourceData.Rows[rowixd][Deposit_amountid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Empty_Amountid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Empty_Amount"] = double.Parse(sourceData.Rows[rowixd][Empty_Amountid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Amount_in_local_currencyid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Amount_in_local_currency"] = double.Parse(sourceData.Rows[rowixd][Amount_in_local_currencyid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Empty_Amount_Notmachid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Empty_Amount_Notmach"] = double.Parse(sourceData.Rows[rowixd][Empty_Amount_Notmachid].ToString());
                            }



                            DocumentNoVal = sourceData.Rows[rowixd][Adjusted_amountid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Adjusted_amount"] = double.Parse(sourceData.Rows[rowixd][Adjusted_amountid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Payment_amountid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Payment_amount"] = double.Parse(sourceData.Rows[rowixd][Payment_amountid].ToString());


                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Ketvothuongid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Ketvothuong"] = int.Parse(sourceData.Rows[rowixd][Ketvothuongid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Chaivothuongid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Chaivothuong"] = int.Parse(sourceData.Rows[rowixd][Chaivothuongid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Ketvolitid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Ketvolit"] = int.Parse(sourceData.Rows[rowixd][Ketvolitid].ToString());
                            }

                            DocumentNoVal = sourceData.Rows[rowixd][Ketnhuathuongid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {

                                dr["Ketnhuathuong"] = int.Parse(sourceData.Rows[rowixd][Ketnhuathuongid].ToString());

                            }



                            DocumentNoVal = sourceData.Rows[rowixd][Chaivo1litid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Chaivo1lit"] = int.Parse(sourceData.Rows[rowixd][Chaivo1litid].ToString());
                            }


                            DocumentNoVal = sourceData.Rows[rowixd][Ketnhua1litid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Ketnhua1lit"] = int.Parse(sourceData.Rows[rowixd][Ketnhua1litid].ToString());

                            }


                            DocumentNoVal = sourceData.Rows[rowixd][joy20lid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["joy20l"] = int.Parse(sourceData.Rows[rowixd][joy20lid].ToString());
                            }


                            DocumentNoVal = sourceData.Rows[rowixd][Binhpmicc02id].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["Binhpmicc02"] = int.Parse(sourceData.Rows[rowixd][Binhpmicc02id].ToString());
                            }


                            DocumentNoVal = sourceData.Rows[rowixd][binhpmix9lid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["binhpmix9l"] = int.Parse(sourceData.Rows[rowixd][binhpmix9lid].ToString());
                            }


                            DocumentNoVal = sourceData.Rows[rowixd][palletgoid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["palletgo"] = int.Parse(sourceData.Rows[rowixd][palletgoid].ToString());

                            }

                            DocumentNoVal = sourceData.Rows[rowixd][paletnhuaid].ToString();
                            if (Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != "")
                            {
                                dr["paletnhua"] = int.Parse(sourceData.Rows[rowixd][paletnhuaid].ToString());

                            }



                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Data có đủ cột nhưng lõi,please check" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion



            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {



                bulkCopy.DestinationTableName = "tblFBL5beginbalace";
                // Write from the source to the destination.  Account
                bulkCopy.ColumnMappings.Add("Account", "Account");
                bulkCopy.ColumnMappings.Add("Business_Area", "[Business Area]");
                bulkCopy.ColumnMappings.Add("Amount_in_local_currency", "[Amount in local currency]");

                bulkCopy.ColumnMappings.Add("Deposit_amount", "[Deposit amount]");
                bulkCopy.ColumnMappings.Add("Fullgood_amount", "[Fullgood amount]");
                bulkCopy.ColumnMappings.Add("Empty_Amount", "[Empty Amount]");
                bulkCopy.ColumnMappings.Add("Empty_Amount_Notmach", "[Empty Amount Notmach]");


                bulkCopy.ColumnMappings.Add("Adjusted_amount", "[Adjusted amount]");
                bulkCopy.ColumnMappings.Add("Payment_amount", "[Payment amount]");
                bulkCopy.ColumnMappings.Add("Ketvothuong", "Ketvothuong");
                bulkCopy.ColumnMappings.Add("Chaivothuong", "Chaivothuong");
                bulkCopy.ColumnMappings.Add("Ketvolit", "Ketvolit");
                bulkCopy.ColumnMappings.Add("Chaivo1lit", "Chaivo1lit");
                bulkCopy.ColumnMappings.Add("Ketnhuathuong", "Ketnhuathuong");
                bulkCopy.ColumnMappings.Add("Ketnhua1lit", "Ketnhua1lit");
                bulkCopy.ColumnMappings.Add("joy20l", "joy20l");
                bulkCopy.ColumnMappings.Add("Binhpmicc02", "Binhpmicc02");
                bulkCopy.ColumnMappings.Add("binhpmix9l", "binhpmix9l");
                bulkCopy.ColumnMappings.Add("palletgo", "palletgo");
                bulkCopy.ColumnMappings.Add("paletnhua", "paletnhua");

                //bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //bulkCopy.ColumnMappings.Add("Address", "[Address]");

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


        }

        public void customerinputsendlist()
        {
            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Send customer data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsendcustomer);
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

        public void importsendcustomer(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_Unsendlist"); // where tbl_Unsendlist.Customer <> null
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;


            #region  new




            #region  new by datatable

            //   ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();


            //@"SELECT Customer, [Sales Organization],
            //                        [Name 1], Address, [Telephone 1] FROM [Sheet1$]

            //                         WHERE  (Customer IS NOT NULL)", conn);




            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("Sorg", typeof(string));
            batable.Columns.Add("Name", typeof(string));
            //  batable.Columns.Add("Address", typeof(string));
            //  batable.Columns.Add("Telephone", typeof(string));




            int Customerid = -1;
            int Organizationid = -1;
            int Nameid = -1;
            //  int Addressid = -1;
            //  int Telephoneid = -1;





            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Customer") && Customerid == -1)
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sorg") && Organizationid == -1)
                        {

                            Organizationid = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Name") && Nameid == -1)
                        {

                            Nameid = columid;
                            //    headindex = 0;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Organizationid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Organization", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Customerid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal))
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {
                            if (sourceData.Rows[rowixd][Organizationid].ToString().Length > 200)
                            {

                                dr["Sorg"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["Sorg"] = sourceData.Rows[rowixd][Organizationid].ToString().Trim();

                            }

                            if (sourceData.Rows[rowixd][Customerid].ToString() != "" && Utils.IsValidnumber(sourceData.Rows[rowixd][Customerid].ToString()))
                            {
                                try
                                {
                                    dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString().Trim());

                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("data : " + sourceData.Rows[rowixd][Customerid].ToString().Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //throw;
                                }

                            }
                            //dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());
                            if (sourceData.Rows[rowixd][Nameid].ToString().Length > 200)
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim();
                            }




                        }
                        catch (Exception ex5)
                        {

                            MessageBox.Show(ex5.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion


            #endregion end new



            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.DestinationTableName = "tbl_Unsendlist";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Sorg", "Sorg");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Name", "Name");
                //   bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //    bulkCopy.ColumnMappings.Add("Telephone 1", "[Telephone 1]");

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            // goik hàm update trên ser 

            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustListsend", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();

            }
            catch
            {
                Thread.CurrentThread.Abort();

            }

            //       rdr1 = cmd1.ExecuteReader();


            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }



            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






            //   Thread.CurrentThread.Abort();
        }

        public void customerinputGroupsending()
        {


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Send customer data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importGroupcustomer);
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

        public void importGroupcustomer(object obj)
        {

            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tblCustomerTmp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;





            #region  new by datatable

            //    ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();



            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("GroupNAme", typeof(string));



            int Customerid = -1;
            int GroupNAmeid = -1;



            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();


                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Customer") && Customerid == -1)
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("GroupNAme") && GroupNAmeid == -1)
                        {
                            GroupNAmeid = columid;
                            //  headindex = rowid;
                        }

                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GroupNAmeid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột GroupNAme", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][Customerid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal) && DocumentNoVal != null)
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {





                        DataRow dr = batable.NewRow();


                        try
                        {


                            //dr["Customer"] = double.Parse(DocumentNoVal);
                            //  dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                            dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                            if (sourceData.Rows[rowixd][GroupNAmeid].ToString().Length > 200)
                            {

                                dr["GroupNAme"] = sourceData.Rows[rowixd][GroupNAmeid].ToString().Trim().Substring(0, 200);

                            }
                            else
                            {
                                dr["GroupNAme"] = sourceData.Rows[rowixd][GroupNAmeid].ToString().Trim();

                            }


                        }
                        catch (Exception ex3)
                        {

                            MessageBox.Show(ex3.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        batable.Rows.Add(dr);


                    }

                }

                #endregion
            }


            #endregion




            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.DestinationTableName = "tblCustomerTmp";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("GroupNAme", "SendingGroup");
                //   bulkCopy.ColumnMappings.Add("Name", "Name");
                //   bulkCopy.ColumnMappings.Add("Address", "[Address]");
                //    bulkCopy.ColumnMappings.Add("Telephone 1", "[Telephone 1]");

                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }
            // update laij cacs ble kahcs hanfg cos group giong lis laf black

            #region update laij cacs ble kahcs hanfg cos group giong lis laf black va update gruop
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            //    destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatelistGruopsendingCustomer", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


            // update lai code kacsh hanfg theo group sending







        }








    }
}
