using arconfirmationletter.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using arconfirmationletter.shared;

namespace arconfirmationletter.Model
{
    class Remarks
    {



        public bool deleteallremarks()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            // var rs = from tbl_Remark in db.tbl_Remarks
            //            select tbl_Remark;
            db.ExecuteCommand("DELETE FROM tbl_Remark");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }


        //public IQueryable Remarksetlect_all(LinqtoSQLDataContext db)
        //{

        //    //var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_Remark in db.tbl_Remarks
        //             select tbl_Remark;

        //    return rs;

        //}




        class datainportF
        {

            public string filename { get; set; }

        }



        public void Remark_input()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Remark excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importRemarksexcel);
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

        private void importRemarksexcel(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            Remarks Rm = new Remarks();

            bool kq = Rm.deleteallremarks();



            datainportF inf = (datainportF)obj;

            string filename = inf.filename;


        

            #region  new by datatable

        //    ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();


            batable.Columns.Add("DocumentNo", typeof(double));
            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("Remark", typeof(string));


    

            int DocumentNoid = -1;
            int Customerid = -1;
            int Remarkid = -1;
    



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
                        if (value.Trim() == ("DocumentNo") && DocumentNoid ==-1)
                        {
                            DocumentNoid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Customer")&& Customerid==-1)
                        {

                            Customerid = columid;
                            //    headindex = 0;

                        }



                        if (value.Trim() == ("Remark") && Remarkid ==-1)
                        {

                            Remarkid = columid;
                            //    headindex = 0;

                        }

                    
                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (DocumentNoid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột DocumentNoid", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Customerid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Remarkid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Remark", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region


                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string DocumentNoVal = sourceData.Rows[rowixd][DocumentNoid].ToString();
                if (DocumentNoVal != "" && Utils.IsValidnumber(DocumentNoVal))
                {

                    if (double.Parse(DocumentNoVal) > 0)
                    {

                    

                        DataRow dr = batable.NewRow();

                      
                        try
                        {
                            dr["Remark"] = sourceData.Rows[rowixd][Remarkid].ToString().Truncate(225).Trim();

                            dr["DocumentNo"] = double.Parse(sourceData.Rows[rowixd][DocumentNoid].ToString());

                            dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());

                         

                        }
                        catch (Exception )
                        {

                            MessageBox.Show("Data có đủ cột nhưng dữ liệu ở dưới bị lost, please check", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                bulkCopy.DestinationTableName = "tbl_Remark";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("[DocumentNo]", "[DocumentNo]");
                bulkCopy.ColumnMappings.Add("[Customer]", "[Customer]");
                bulkCopy.ColumnMappings.Add("[Remark]", "[Remark]");
             


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






    }
}
