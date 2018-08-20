using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Luckynumber.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using Luckynumber.shared;


namespace Luckynumber.Model
{
    class vat_ctrl
    {


        public bool deleteallvat()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //  var rs = from tblVat in db.tblVats
            db.CommandTimeout = 0;
            db.ExecuteCommand("DELETE FROM tblVat");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }


        //public IQueryable vatsetlect_all(LinqtoSQLDataContext db)
        //{

        //    //var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tblVat in db.tblVats
        //             select tblVat;

        //    return rs;

        //}

        class datainportF
        {

            public string filename { get; set; }

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

        //public void vat_input()
        //{


        //    //      BackgroundWorker backgroundWorker1;
        //    //   CultureInfo provider = CultureInfo.InvariantCulture;
        //    //     backgroundWorker1 = new BackgroundWorker();

        //    OpenFileDialog theDialog = new OpenFileDialog();
        //    theDialog.Title = "Open Excel File Vat_out_zfi excel";
        //    theDialog.Filter = "Excel files|*.xlsx; *.xls";
        //    theDialog.InitialDirectory = @"C:\";
        //    if (theDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filename = theDialog.FileName.ToString();


        //        Thread t1 = new Thread(importsexcel);
        //        t1.IsBackground = true;
        //        t1.Start(new datainportF() { filename = filename });



        //        View.Caculating wat = new View.Caculating();
        //        Thread t2 = new Thread(showwait);
        //        t2.Start(new datashowwait() { wat = wat });


        //        t1.Join();
        //        if (t1.ThreadState != ThreadState.Running)
        //        {

        //            // t2.Abort();

        //            wat.Invoke(wat.myDelegate);



        //        }




        //        // check data download
        //        string connection_string = Utils.getConnectionstr();
        //        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //        var rs = from tblVat in db.tblVats
        //                 where tblVat.Invoice_Amount_Before_VAT == null || tblVat.VAT_Amount == null
        //                 select tblVat;


        //        if (rs.Count() > 0)
        //        {




        //            Viewtable viewtbl = new Viewtable(rs, db, "KHÔNG UPDLOAD ĐƯỢC DO LIST CÁC VAT THIẾU DATA  INVOICE AMOUNT & VAT AMOUNT !",1, DateTime.Today, DateTime.Today);
        //            viewtbl.Visible = false;
        //            viewtbl.ShowDialog();

        //            db.ExecuteCommand("DELETE FROM tblVat");
        //            db.SubmitChanges();



        //        }





        //    }



        //}


        private void importsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();

            vat_ctrl md = new vat_ctrl();

            bool kq = md.deleteallvat();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            //bulkCopy.ColumnMappings.Add("[InvoiceRegistrationNumber]", "[Invoice Registration Number]");
            //bulkCopy.ColumnMappings.Add("[InvoiceNumber]", "[Invoice Number]");
            //bulkCopy.ColumnMappings.Add("[SAPDeliveryNumber]", "[SAP Delivery Number]");
            //bulkCopy.ColumnMappings.Add("[SAPInvoiceNumber]", "[SAP Invoice Number]");
            //bulkCopy.ColumnMappings.Add("[ProFormaDate]", "[Pro Forma Date]");
            //bulkCopy.ColumnMappings.Add("[InvoiceAmountBeforeVAT]", "[Invoice Amount Before VAT]");//-sua am
            //bulkCopy.ColumnMappings.Add("[VATAmount]", "[VAT Amount]");
            //bulkCopy.ColumnMappings.Add("[CustomerNumber]", "[Customer Number]");
            //bulkCopy.ColumnMappings.Add("[CustomerName]", "[Customer Name]");
            //bulkCopy.ColumnMappings.Add("[StreetAddress]", "[Street Address]");


            batable.Columns.Add("InvoiceRegistrationNumber", typeof(string));
            batable.Columns.Add("InvoiceNumber", typeof(double));
            batable.Columns.Add("SAPDeliveryNumber", typeof(double));
            batable.Columns.Add("SAPInvoiceNumber", typeof(double));
            batable.Columns.Add("ProFormaDate", typeof(DateTime));
            batable.Columns.Add("InvoiceAmountBeforeVAT", typeof(double));
            batable.Columns.Add("VATAmount", typeof(double));
            batable.Columns.Add("CustomerNumber", typeof(double));
            batable.Columns.Add("CustomerName", typeof(string));
            batable.Columns.Add("StreetAddress", typeof(string));


            int InvoiceRegistrationNumber = -1;
            int InvoiceNumber = -1;
            int SAPDeliveryNumber = -1;
            int SAPInvoiceNumber = -1;
            int ProFormaDate = -1;
            int InvoiceAmountBeforeVAT = -1;
            int VATAmount = -1;
            int CustomerNumber = -1;
            int CustomerName = -1;
            int StreetAddress = -1;
            //     int CustomerNumber = -1;




            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    //OleDbCommand command = new OleDbCommand(
                    //             @"SELECT [Invoice Registration Number],[Invoice Number],[SAP Delivery Number],[SAP Invoice Number],
                    //                [Pro Forma Date],[Customer Number],[Customer Name],[Invoice Amount Before VAT],[       VAT Amount],
                    //                [Street Address] FROM [Sheet1$]
                    //                WHERE ([SAP Invoice Number] is not null ) ", conn);



                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Invoice Registration Number"))
                        {
                            InvoiceRegistrationNumber = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Invoice Number"))
                        {

                            InvoiceNumber = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("SAP Invoice Number"))
                        {

                            SAPInvoiceNumber = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim()==("SAP Delivery Number"))
                        {

                            SAPDeliveryNumber = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim()==("Customer Name"))
                        {
                            CustomerName = columid;

                        }
                        if (value.Trim()==("Pro Forma Date"))
                        {
                            ProFormaDate = columid;

                        }



                        if (value.Trim()==("Customer Number"))
                        {
                            CustomerNumber = columid;

                        }
                        if (value.Trim() == ("Invoice Amount Before VAT"))
                        {
                            InvoiceAmountBeforeVAT = columid;

                        }

                        if (value.Trim() == ("VAT Amount"))
                        {
                            VATAmount = columid;

                        }
                        if (value.Trim()==("Street Address"))
                        {
                            StreetAddress = columid;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (InvoiceRegistrationNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Invoice Registration Number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InvoiceNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Invoice Number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SAPInvoiceNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột SAP invoice Number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SAPDeliveryNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột SAP Delivery Number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProFormaDate == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Pro Forma Date ngày hóa đơn in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InvoiceAmountBeforeVAT == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Invoice Amount Before VAT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (VATAmount == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột VAT Amount", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustomerNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer Number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CustomerName == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (StreetAddress == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Street Address", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string SAPInvoiceNumberv = sourceData.Rows[rowixd][SAPInvoiceNumber].ToString();
                if (SAPInvoiceNumberv != "" && Utils.IsValidnumber(SAPInvoiceNumberv))
                {

                    if (double.Parse(SAPInvoiceNumberv) > 0)
                    {

                        //batable.Columns.Add("InvoiceRegistrationNumber", typeof(string));
                        //batable.Columns.Add("InvoiceNumber", typeof(double));
                        //batable.Columns.Add("SAPDeliveryNumber", typeof(double));
                        //batable.Columns.Add("SAPInvoiceNumber", typeof(double));
                        //batable.Columns.Add("ProFormaDate", typeof(DateTime));
                        //batable.Columns.Add("InvoiceAmountBeforeVAT", typeof(double));
                        //batable.Columns.Add("VATAmount", typeof(double));
                        //batable.Columns.Add("CustomerNumber", typeof(double));
                        //batable.Columns.Add("CustomerName", typeof(string));
                        //batable.Columns.Add("StreetAddress", typeof(string));

                        DataRow dr = batable.NewRow();

                        dr["InvoiceRegistrationNumber"] = sourceData.Rows[rowixd][InvoiceRegistrationNumber].ToString().Truncate(225).Trim();
                    
                        if (sourceData.Rows[rowixd][InvoiceNumber].ToString()!="" && Utils.IsValidnumber(sourceData.Rows[rowixd][InvoiceNumber].ToString()))
                        {

                            dr["InvoiceNumber"] = double.Parse(sourceData.Rows[rowixd][InvoiceNumber].ToString());
                        }

                        try
                        {
                            dr["SAPDeliveryNumber"] = double.Parse(sourceData.Rows[rowixd][SAPDeliveryNumber].ToString());

                            dr["SAPInvoiceNumber"] = double.Parse(sourceData.Rows[rowixd][SAPInvoiceNumber].ToString());

                            dr["ProFormaDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][ProFormaDate].ToString());
                            dr["InvoiceAmountBeforeVAT"] = double.Parse(sourceData.Rows[rowixd][InvoiceAmountBeforeVAT].ToString());//.Trim();
                            dr["VATAmount"] = double.Parse(sourceData.Rows[rowixd][VATAmount].ToString());

                            dr["CustomerNumber"] = double.Parse(sourceData.Rows[rowixd][CustomerNumber].ToString());//.Trim();
                            dr["CustomerName"] = sourceData.Rows[rowixd][CustomerName].ToString().Truncate(225).Trim() ;

                            dr["StreetAddress"] = sourceData.Rows[rowixd][StreetAddress].ToString().Truncate(225).Trim();


                        }
                        catch (Exception )
                        {

                            MessageBox.Show("Data có đủ cột nhưng dữ liệu ở dưới bị lost, please check", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                   

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
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tblVat";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("[InvoiceRegistrationNumber]", "[Invoice Registration Number]");
                bulkCopy.ColumnMappings.Add("[InvoiceNumber]", "[Invoice Number]");
                bulkCopy.ColumnMappings.Add("[SAPDeliveryNumber]", "[SAP Delivery Number]");
                bulkCopy.ColumnMappings.Add("[SAPInvoiceNumber]", "[SAP Invoice Number]");
                bulkCopy.ColumnMappings.Add("[ProFormaDate]", "[Pro Forma Date]");
                bulkCopy.ColumnMappings.Add("[InvoiceAmountBeforeVAT]", "[Invoice Amount Before VAT]");//-sua am
                bulkCopy.ColumnMappings.Add("[VATAmount]", "[VAT Amount]");
                bulkCopy.ColumnMappings.Add("[CustomerNumber]", "[Customer Number]");
                bulkCopy.ColumnMappings.Add("[CustomerName]", "[Customer Name]");
                bulkCopy.ColumnMappings.Add("[StreetAddress]", "[Street Address]");

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



        //private void importsexcelold(object obj)
        //{
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    vat_ctrl md = new vat_ctrl();

        //    bool kq = md.deleteallvat();

        //    datainportF inf = (datainportF)obj;

        //    string filename = inf.filename;

        //    string connectionString = "";
        //    if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
        //    {
        //        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
        //    }
        //    else
        //    {
        //        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
        //    }

        //    //------
        //    //---------------fill data

        //    System.Data.DataTable sourceData = new System.Data.DataTable();
        //    using (OleDbConnection conn =
        //                           new OleDbConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception ex)
        //        {

        //            MessageBox.Show(ex.ToString(), "Thông báo lỗi Open conext !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //        // Get the data from the source table as a SqlDataReader.
        //        OleDbCommand command = new OleDbCommand(
        //                            @"SELECT [Invoice Registration Number],[Invoice Number],[SAP Delivery Number],[SAP Invoice Number],
        //                            [Pro Forma Date],[Customer Number],[Customer Name],[Invoice Amount Before VAT],[       VAT Amount],
        //                            [Street Address] FROM [Sheet1$]
        //                            WHERE ([SAP Invoice Number] is not null ) ", conn);



        //        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        //        //   adapter.FillSchema(sourceData, SchemaType.Source);
        //        // sourceData.Columns["Pro Forma Date"].DataType = typeof(DateTime);
        //        //sourceData.Columns["Invoice Doc Nr"].DataType = typeof(float);
        //        //sourceData.Columns["Billed Qty"].DataType = typeof(float);
        //        //sourceData.Columns["Cond Value"].DataType = typeof(float);
        //        //sourceData.Columns["Sales Org"].DataType = typeof(string);
        //        //sourceData.Columns["Cust Name"].DataType = typeof(string);
        //        //sourceData.Columns["Outbound Delivery"].DataType = typeof(string);
        //        //sourceData.Columns["Mat Group"].DataType = typeof(string);
        //        //sourceData.Columns["Mat Group Text"].DataType = typeof(string);
        //        //sourceData.Columns["UoM"].DataType = typeof(string);


        //        try
        //        {

        //            adapter.Fill(sourceData);
        //        }
        //        catch (Exception ex)
        //        {

        //            MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        conn.Close();
        //    }

        //    //   Utils util = new Utils();
        //    string destConnString = Utils.getConnectionstr();

        //    //---------------fill data


        //    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
        //    {

        //        bulkCopy.DestinationTableName = "tblVat";
        //        // Write from the source to the destination.
        //        bulkCopy.ColumnMappings.Add("[Invoice Registration Number]", "[Invoice Registration Number]");
        //        bulkCopy.ColumnMappings.Add("[Invoice Number]", "[Invoice Number]");
        //        bulkCopy.ColumnMappings.Add("[SAP Delivery Number]", "[SAP Delivery Number]");
        //        bulkCopy.ColumnMappings.Add("[SAP Invoice Number]", "[SAP Invoice Number]");
        //        bulkCopy.ColumnMappings.Add("[Pro Forma Date]", "[Pro Forma Date]");
        //        bulkCopy.ColumnMappings.Add("[Invoice Amount Before VAT]", "[Invoice Amount Before VAT]");//-sua am
        //        bulkCopy.ColumnMappings.Add("[       VAT Amount]", "[VAT Amount]");


        //        bulkCopy.ColumnMappings.Add("[Customer Number]", "[Customer Number]");

        //        bulkCopy.ColumnMappings.Add("[Customer Name]", "[Customer Name]");

        //        bulkCopy.ColumnMappings.Add("[Street Address]", "[Street Address]");

        //        //    bulkCopy.ColumnMappings.Add("[Amount in local currency]", "[Region]");

        //        //     bulkCopy.ColumnMappings.Add("[Amount in local currency]", "[VAT Amount]");

        //        //   bulkCopy.ColumnMappings.Add("[Amount in local currency]", "[VAT Amount]");

        //        //    bulkCopy.ColumnMappings.Add("[Amount in local currency]", "[VAT Amount]");



        //        //          ,[Invoice Registration Number]
        //        //,[Invoice Number]
        //        //,[SAP Delivery Number]
        //        //,[SAP Invoice Number]
        //        //,[Pro Forma Date]
        //        //,[Invoice Amount Before VAT]
        //        //,[VAT Amount]
        //        //,[Customer Number]
        //        //,[Customer Name]
        //        //,[Street Address]
        //        //,[Region]






        //        #region   tìm id
        //        //   "Account"
        //        //    "Assignment"
        //        //    "Posting Date"
        //        //  "Document Type"
        //        //     "Document Number"
        //        //   "Business Area"
        //        //     "Amount in local currency"


        //        #endregion




        //        try
        //        {
        //            bulkCopy.WriteToServer(sourceData);
        //        }
        //        catch (Exception ex)
        //        {

        //            MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            Thread.CurrentThread.Abort();
        //        }

        //    }
        //}
        

        private string changevalueminus(string value)
        {

            if (value.Contains("-"))
            {
                if (value.IndexOf('-') == value.Length - 1)
                {
                    value = "-" + value.Substring(0, value.Length - 1);
                }

            }


            return value;


        }



    }// LASS




}// NAMSPACE



