using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace arconfirmationletter.Model
{
    class NKA
    {

        class datainportF
        {

            public string filename { get; set; }

        }


        class datauploadSumary
        {

            public string filename { get; set; }
            public DateTime todate { get; set; }
            public DateTime returdate { get; set; }

        }
        public bool deletetblNKACustomer()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //   var rs = from tblFBL5N in db.tblFBL5Ns
            //          select tblFBL5N;
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tblNKACustomer");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tblNKACustomer !" + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }

        public bool deleteNKASumarylist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //   var rs = from tblFBL5N in db.tblFBL5Ns
            //          select tblFBL5N;
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tblNKAArletterRpts");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tblNKAArletterRpts !" + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }

        public IQueryable NKACustomerselect_all(LinqtoSQLDataContext dblink)
        {

            // var db = new LinqtoSQLDataContext(connection_string);
            var rs = from p in dblink.tblNKACustomers
                     select p;

            return rs;

        }

        public IQueryable NKASumarylistselect_all(LinqtoSQLDataContext dblink)
        {

            // var db = new LinqtoSQLDataContext(connection_string);
            var rs = from p in dblink.tblNKAArletterRpts
                     select p;

            return rs;

        }


        //    NKADetaillistselect_all
        public IQueryable NKADetaillistselect_all(LinqtoSQLDataContext dblink)
        {

            // var db = new LinqtoSQLDataContext(connection_string);
            var rs = from p in dblink.tblNKAdetailDirectUps
                     select p;

            return rs;

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

        private void importsexceltblNKACustomer(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            //     fbl5n_ctrl md = new fbl5n_ctrl();

            //     bool kq = md.deleteFbl5n();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



         //   ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("No", typeof(double));
            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("SOrg", typeof(string));
            batable.Columns.Add("Area", typeof(string));
            batable.Columns.Add("Region", typeof(string));
            batable.Columns.Add("Group", typeof(string));
            batable.Columns.Add("GroupLetter", typeof(string));
            batable.Columns.Add("Branch", typeof(string));
            batable.Columns.Add("IncoT", typeof(string));
            batable.Columns.Add("KeyAcc", typeof(string));

            batable.Columns.Add("Pt", typeof(string));
            batable.Columns.Add("Plant", typeof(string));
            batable.Columns.Add("ASM", typeof(string));
            batable.Columns.Add("Name", typeof(string));
            batable.Columns.Add("Nameinletter", typeof(string));
            batable.Columns.Add("NameAccountofCustomer", typeof(string));
            batable.Columns.Add("Mail", typeof(string));
            batable.Columns.Add("Phone", typeof(string));
            batable.Columns.Add("Address", typeof(string));
            batable.Columns.Add("Account", typeof(string));



            int Noid = -1;
            int Customerid = -1;
            int SOrgid = -1;
            int Areaid = -1;
            int Regionid = -1;
            int Groupid = -1;
            int GroupLetterid = -1;
            int Branchid = -1;
            int IncoTid = -1;
            int KeyAccid = -1;

            int Ptid = -1;
            int Plantid = -1;
            int ASMid = -1;
            int Nameid = -1;
            int Nameinletterid = -1;
            int NameAccountofCustomerid = -1;
            int Mailid = -1;
            int Phoneid = -1;
            int Addressid = -1;
            int Accountid = -1;



            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    //                
                    //          
                    //  			


                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("No"))
                        {
                            Noid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Customer"))
                        {

                            Customerid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("SOrg."))
                        {

                            SOrgid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("Area"))
                        {
                            Areaid = columid;//

                        }
                        if (value.Trim() == ("Region"))
                        {
                            Regionid = columid;//

                        }



                        if (value.Trim() == ("Group"))
                        {
                            Groupid = columid;//

                        }
                        if (value.Trim() == ("Group Letter"))
                        {
                            GroupLetterid = columid;//

                        }


                        if (value.Trim() == ("Branch"))
                        {
                            Branchid = columid;//

                        }
                        if (value.Trim() == ("IncoT"))
                        {
                            IncoTid = columid;//

                        }
                        if (value.Trim() == ("KeyAcc"))
                        {
                            KeyAccid = columid;//

                        }

                        if (value.Trim() == ("Pt"))
                        {
                            Ptid = columid;//

                        }

                        if (value.Trim() == ("Plant"))
                        {
                            Plantid = columid;//


                        }
                        if (value.Trim() == ("ASM"))
                        {
                            ASMid = columid;//

                        }


                        if (value.Trim() == ("Name"))
                        {
                            Nameid = columid;//

                        }

                        if (value.Trim() == ("Name in letter"))
                        {
                            Nameinletterid = columid;//

                        }

                        if (value.Trim() == ("Name's Account of Customer"))
                        {
                            NameAccountofCustomerid = columid;//

                        }
                        if (value.Trim() == ("Mail"))
                        {
                            Mailid = columid;//

                        }

                        if (value.Trim() == ("Phone"))
                        {
                            Phoneid = columid;//

                        }

                        if (value.Trim() == ("Address"))
                        {
                            Addressid = columid;//

                        }
                        if (value.Trim() == ("Account"))
                        {
                            Accountid = columid;//

                        }

                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Noid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột No", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SOrgid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột SOrg.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Areaid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Area", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Regionid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Region", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Groupid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Group", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GroupLetterid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Group Letter", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Branchid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Branch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (IncoTid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột IncoT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (KeyAccid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột KeyAcc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Ptid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Pt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Plantid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Plant", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ASMid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột ASM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameinletterid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name in letter", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NameAccountofCustomerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name 's Account of Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Mailid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Phoneid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Phone", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Addressid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Address", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Accountid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Account", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string Customer = sourceData.Rows[rowixd][Customerid].ToString();
                if (Customer != "" && Utils.IsValidnumber(Customer))
                {

                    if (double.Parse(Customer) > 0)
                    {
                        DataRow dr = batable.NewRow();
                        try
                        {
                            dr["No"] = double.Parse(sourceData.Rows[rowixd][Noid].ToString());//.Trim
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Dữ liệu thiếu cột No dòng: " + rowixd.ToString() + "cột: " + Noid.ToString() + " bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());//.Trim();

                        dr["SOrg"] = sourceData.Rows[rowixd][SOrgid].ToString().Trim();

                        dr["Area"] = sourceData.Rows[rowixd][Areaid].ToString().Trim();
                        dr["Region"] = sourceData.Rows[rowixd][Regionid].ToString().Trim();
                        dr["Group"] = sourceData.Rows[rowixd][Groupid].ToString().Trim();
                        dr["GroupLetter"] = sourceData.Rows[rowixd][GroupLetterid].ToString().Trim();
                        dr["Branch"] = sourceData.Rows[rowixd][Branchid].ToString().Trim();
                        dr["IncoT"] = sourceData.Rows[rowixd][IncoTid].ToString().Trim();
                        dr["KeyAcc"] = sourceData.Rows[rowixd][KeyAccid].ToString().Trim();
                        dr["Pt"] = sourceData.Rows[rowixd][Ptid].ToString().Trim();
                        dr["Plant"] = sourceData.Rows[rowixd][Plantid].ToString().Trim();
                        dr["ASM"] = sourceData.Rows[rowixd][ASMid].ToString().Trim();
                        dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim();
                        dr["Nameinletter"] = sourceData.Rows[rowixd][Nameinletterid].ToString().Trim();
                        dr["NameAccountofCustomer"] = sourceData.Rows[rowixd][NameAccountofCustomerid].ToString().Trim();
                        dr["Mail"] = sourceData.Rows[rowixd][Mailid].ToString().Trim();
                        dr["Phone"] = sourceData.Rows[rowixd][Phoneid].ToString().Trim();
                        dr["Address"] = sourceData.Rows[rowixd][Addressid].ToString().Trim();
                        dr["Account"] = sourceData.Rows[rowixd][Accountid].ToString().Trim();


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

                bulkCopy.DestinationTableName = "tblNKACustomer";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("No", "[No]");
                bulkCopy.ColumnMappings.Add("Customer", "[Customer]");
                bulkCopy.ColumnMappings.Add("SOrg", "[SOrg]");
                bulkCopy.ColumnMappings.Add("Area", "[Area]");
                bulkCopy.ColumnMappings.Add("Region", "[Region]");
                bulkCopy.ColumnMappings.Add("Group", "[Group]");
                bulkCopy.ColumnMappings.Add("GroupLetter", "[Group Letter]");
                bulkCopy.ColumnMappings.Add("Branch", "[Branch]");
                bulkCopy.ColumnMappings.Add("IncoT", "[IncoT]");
                bulkCopy.ColumnMappings.Add("KeyAcc", "[KeyAcc]");
                bulkCopy.ColumnMappings.Add("Pt", "[Pt]");
                bulkCopy.ColumnMappings.Add("Plant", "[Plant]");
                bulkCopy.ColumnMappings.Add("ASM", "[ASM]");
                bulkCopy.ColumnMappings.Add("Name", "[Name]");
                bulkCopy.ColumnMappings.Add("Nameinletter", "[Name in letter]");
                bulkCopy.ColumnMappings.Add("NameAccountofCustomer", "[Name's Account of Customer]");
                bulkCopy.ColumnMappings.Add("Mail", "[Mail]");
                bulkCopy.ColumnMappings.Add("Phone", "[Phone]");
                bulkCopy.ColumnMappings.Add("Address", "[Address]");
                bulkCopy.ColumnMappings.Add("Account", "[Account]");



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

        public void NKACustomer_input()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File NKA Customer excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importsexceltblNKACustomer);
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



            //  return true;



        }


        private void importsexcelSumaryletter(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            //     fbl5n_ctrl md = new fbl5n_ctrl();

            //     bool kq = md.deleteFbl5n();

            datauploadSumary inf = (datauploadSumary)obj;

            string filename = inf.filename;

            DateTime todate = inf.todate;
            DateTime returdate = inf.returdate;


         //   ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("GroupLetter", typeof(string));
            batable.Columns.Add("Nameletter", typeof(string));

            batable.Columns.Add("Tongtiennonuoc", typeof(double));
            batable.Columns.Add("Tongtienthanhtoan", typeof(double));
            batable.Columns.Add("Tongno", typeof(double));

       //     batable.Columns.Add("Stt", typeof(string));
            batable.Columns.Add("toDate", typeof(DateTime));
            batable.Columns.Add("returndate", typeof(DateTime));



            int GroupLetterid = -1;
            int Nameletterid = -1;
            int Tongtiennonuocid = -1;
            int Tongtienthanhtoanid = -1;
            int Tongnoid = -1;



            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    //                
                    //          
                    //  			


                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Group Letter"))
                        {
                            GroupLetterid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Name letter"))
                        {

                            Nameletterid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("1.Tổng Tiền Nợ Nước"))
                        {

                            Tongtiennonuocid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("2.Tổng Tiền Thanh Toán"))
                        {
                            Tongtienthanhtoanid = columid;//

                        }
                        if (value.Trim() == ("Tổng Tiền Công Nợ (1)+(2)"))
                        {
                            Tongnoid = columid;//

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (GroupLetterid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Group Letter", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameletterid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name letter", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tongtiennonuocid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột 1.Tổng Tiền Nợ Nước  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tongtienthanhtoanid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột 2.Tổng Tiền Thanh Toán ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tongnoid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Tổng Tiền Công Nợ (1)+(2) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

       //     int stt = 0;

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string GroupLetter = sourceData.Rows[rowixd][GroupLetterid].ToString();
                string Nameletter = sourceData.Rows[rowixd][Nameletterid].ToString();
                string tongtiennuoc    =    sourceData.Rows[rowixd][Tongtiennonuocid].ToString();


                if (GroupLetter != "" && Nameletter != "" && Utils.IsValidnumber(tongtiennuoc))
                {
               //     stt = stt + 1;

                    DataRow dr = batable.NewRow();


                    dr["Tongtiennonuoc"] = double.Parse(sourceData.Rows[rowixd][Tongtiennonuocid].ToString());//.Trim();
                    dr["Tongtienthanhtoan"] = double.Parse(sourceData.Rows[rowixd][Tongtienthanhtoanid].ToString());//.Trim();
                    dr["Tongno"] = double.Parse(sourceData.Rows[rowixd][Tongnoid].ToString());//.Trim();

                    dr["GroupLetter"] = sourceData.Rows[rowixd][GroupLetterid].ToString().Trim();

                    dr["Nameletter"] = sourceData.Rows[rowixd][Nameletterid].ToString().Trim();



              //      dr["Stt"] = stt;
                    dr["toDate"] = todate;
                    dr["returndate"] = returdate;


                    batable.Rows.Add(dr);






                }

                #endregion
            }

            //    Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                bulkCopy.DestinationTableName = "tblNKAArletterRpts";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("GroupLetter", "[GroupLetter]");
                bulkCopy.ColumnMappings.Add("Nameletter", "[GroupName]");
                bulkCopy.ColumnMappings.Add("Tongtiennonuoc", "[tongnonuoc]");
                bulkCopy.ColumnMappings.Add("Tongtienthanhtoan", "[tongtienthanhtoan]");
                bulkCopy.ColumnMappings.Add("Tongno", "[tongno]");
           //     bulkCopy.ColumnMappings.Add("Stt", "[stt]");

                bulkCopy.ColumnMappings.Add("toDate", "[toDate]");
                bulkCopy.ColumnMappings.Add("returndate", "[returndate]");
           




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

        public void NKAsumary_input(DateTime todate, DateTime returdate)
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File NKA Sumary excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importsexcelSumaryletter);
                t1.IsBackground = true;
                t1.Start(new datauploadSumary() { filename = filename, todate = todate, returdate = returdate });

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



            //  return true;



        }




    }
}
