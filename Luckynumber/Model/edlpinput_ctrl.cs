using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using arconfirmationletter.View;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace arconfirmationletter.Model
{
    class edlpinput_ctrl
    {
        public bool deleteedlp()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //  var rs = from tblEDLP in db.tblEDLPs
            //          select tblEDLP;
            db.CommandTimeout = 0;
            db.ExecuteCommand("DELETE FROM tblEDLP");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            return true;
        }


        //public IQueryable Edlpsetlect_all(LinqtoSQLDataContext db)
        //{

        //    //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tblEDLP in db.tblEDLPs
        //             select tblEDLP;

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

        private void importsexcel2(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            edlpinput_ctrl md = new edlpinput_ctrl();

            bool kq = md.deleteedlp();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();




            batable.Columns.Add("Soldto", typeof(double));
            batable.Columns.Add("SalesOrg", typeof(string));
            batable.Columns.Add("CustName", typeof(string));
            batable.Columns.Add("InvoiceDocNr", typeof(double));
            batable.Columns.Add("OutboundDelivery", typeof(string));
            batable.Columns.Add("MatNumber", typeof(string));
            batable.Columns.Add("MatText", typeof(string));
            batable.Columns.Add("BilledQty", typeof(double));
            batable.Columns.Add("CondValue", typeof(double));
            batable.Columns.Add("MatGroup", typeof(string));
            batable.Columns.Add("MatGroupText", typeof(string));

            batable.Columns.Add("UoM", typeof(string));



            int Soldto = -1;
            int SalesOrg = -1;
            int CustName = -1;
            int InvoiceDocNr = -1;
            int OutboundDelivery = -1;
            int MatNumber = -1;
            int MatText = -1;
            int BilledQty = -1;
            int CondValue = -1;
            int MatGroup = -1;
            int MatGroupText = -1;
            int UoM = -1;



            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    #region
                    string value = sourceData.Rows[rowid][columid].ToString();
                    //OleDbCommand command = new OleDbCommand(
                    //                   @"SELECT [], [],[],[],
                    //                [], [], [],[],
                    //                [], [], [], [] FROM [Sheet1$]
                    //                 WHERE (([Invoice Doc Nr] is not null ) AND ([Sales Org]<> ''))", conn);



                    if (value != null && value != "")
                    {

                        //    #region setcolum
                        if (value.Trim() == ("Sold-to"))
                        {
                            Soldto = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sales Org"))
                        {

                            SalesOrg = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Cust Name"))
                        {

                            CustName = columid;
                            //    headindex = 0;

                        }

                        if (value.Trim() == ("Invoice Doc Nr"))
                        {

                            InvoiceDocNr = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("Outbound Delivery"))
                        {
                            OutboundDelivery = columid;

                        }
                        if (value.Trim() == ("Mat Number"))
                        {
                            MatNumber = columid;

                        }



                        if (value.Trim() == ("Mat Text"))
                        {
                            MatText = columid;

                        }
                        if (value.Trim() == ("Billed Qty"))
                        {
                            BilledQty = columid;

                        }

                        if (value.Trim() == ("Cond Value"))
                        {
                            CondValue = columid;

                        }
                        if (value.Trim() == ("Mat Group"))
                        {
                            MatGroup = columid;

                        }
                        if (value.Trim() == ("Mat Group Text"))
                        {
                            MatGroupText = columid;

                        }
                        if (value.Trim() == ("UoM"))
                        {
                            UoM = columid;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder

            #region




            if (Soldto == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Sold to  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SalesOrg == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  Sales Org", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustName == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột   Cust Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InvoiceDocNr == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Invoice Doc Nr  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OutboundDelivery == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Outbound Delivery", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MatNumber == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  Mat Number  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MatText == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  Mat Text", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BilledQty == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Billed Qty ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CondValue == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột CondValue ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MatGroup == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  MatGroup", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MatGroupText == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  MatGroupText", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UoM == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột  UoM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string InvoiceDocNrv = sourceData.Rows[rowixd][InvoiceDocNr].ToString();
                if (InvoiceDocNrv != "" && Utils.IsValidnumber(InvoiceDocNrv))
                {

                    if (double.Parse(InvoiceDocNrv) > 0)
                    {


                        DataRow dr = batable.NewRow();
                        dr["Soldto"] = double.Parse(sourceData.Rows[rowixd][Soldto].ToString());
                        dr["SalesOrg"] = sourceData.Rows[rowixd][SalesOrg].ToString().Trim();
                        dr["CustName"] = sourceData.Rows[rowixd][CustName].ToString().Trim();
                        if (Utils.IsValidnumber(sourceData.Rows[rowixd][InvoiceDocNr].ToString()))
                        {
                            dr["InvoiceDocNr"] = double.Parse(sourceData.Rows[rowixd][InvoiceDocNr].ToString());

                        }

                        dr["InvoiceDocNr"] = double.Parse(sourceData.Rows[rowixd][InvoiceDocNr].ToString());
                        dr["OutboundDelivery"] = sourceData.Rows[rowixd][OutboundDelivery].ToString().Trim();
                        dr["MatNumber"] = sourceData.Rows[rowixd][MatNumber].ToString().Trim();
                        dr["MatText"] = sourceData.Rows[rowixd][MatText].ToString().Trim();
                        if (Utils.IsValidnumber(sourceData.Rows[rowixd][BilledQty].ToString()))
                        {
                            dr["BilledQty"] = double.Parse(sourceData.Rows[rowixd][BilledQty].ToString());

                        }

                        if (Utils.IsValidnumber(sourceData.Rows[rowixd][CondValue].ToString()))
                        {
                            dr["CondValue"] = double.Parse(sourceData.Rows[rowixd][CondValue].ToString());

                        }

                        dr["MatGroup"] = sourceData.Rows[rowixd][MatGroup].ToString().Trim();
                        dr["MatGroupText"] = sourceData.Rows[rowixd][MatGroupText].ToString().Trim();

                        dr["UoM"] = sourceData.Rows[rowixd][UoM].ToString().Trim();




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
                bulkCopy.DestinationTableName = "tblEDLP";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("[Soldto]", "[Sold-to]");
                bulkCopy.ColumnMappings.Add("[SalesOrg]", "[Sales Org]");
                bulkCopy.ColumnMappings.Add("[CustName]", "[Cust Name]");
                bulkCopy.ColumnMappings.Add("[InvoiceDocNr]", "[Invoice Doc Nr]");
                bulkCopy.ColumnMappings.Add("[OutboundDelivery]", "[Outbound Delivery]");
                bulkCopy.ColumnMappings.Add("[MatNumber]", "[Mat Number]");
                bulkCopy.ColumnMappings.Add("[MatText]", "[Mat Text]");
                bulkCopy.ColumnMappings.Add("[BilledQty]", "[Billed Qty]");
                bulkCopy.ColumnMappings.Add("[CondValue]", "[Cond Value]");
                bulkCopy.ColumnMappings.Add("[MatGroup]", "[Mat Group]");
                bulkCopy.ColumnMappings.Add("[MatGroupText]", "[Mat Group Text]");
                bulkCopy.ColumnMappings.Add("[UoM]", "[UoM]");





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

        


        public void edlpinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Edlp excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

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


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }


        //  DataInput m = new DataInput();
        //  m.



    }
}
