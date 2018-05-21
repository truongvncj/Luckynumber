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
            string enduser = Utils.getusername();
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tbl_Product  WHERE [tbl_Product].enduser  = '" + enduser + "'");

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
            string enduser = Utils.getusername();
           
            //          select tblFBL5N;
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM [dbo].[tbl_CTKM]   WHERE [tbl_CTKM].enduser = '"+ enduser+"'");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tbl_CTKM " + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }

        
        public bool deletePuchasesorderlist()
        {

            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();

            db.CommandTimeout = 0;
            try
            { // [tbl_CTKM]
                db.ExecuteCommand("DELETE FROM tbl_Salesorder  WHERE [tbl_Salesorder].enduser  = '" + enduser + "'");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tbl_Salesorder " + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;

            // throw new NotImplementedException();
        }

        public bool deleteFreePuchasesorderlist()
        {

            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tbl_SalesFreeOrder  WHERE [tbl_SalesFreeOrder].enduser  = '" + enduser + "'");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa bảng tbl_Salesorder " + ex.ToString());
            }
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;

            // throw new NotImplementedException();
        }


        public bool deletelishnhomKHKMlist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM [dbo].[tbl_NhomKHKM]    WHERE [tbl_NhomKHKM].enduser  = '" + enduser + "'");

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
            batable.Columns.Add("enduser", typeof(string));


       


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

            string enduser = Utils.getusername();

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

                        dr["Marterialcode"] = sourceData.Rows[rowixd][Marterialcodeid].ToString().Truncate(225).Trim();
                        dr["enduser"] = enduser;// sourceData.Rows[rowixd][Marterialcodeid].ToString().Truncate(225).Trim();



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
                bulkCopy.ColumnMappings.Add("enduser", "enduser");

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
            batable.Columns.Add("enduser", typeof(string));


            string enduser = Utils.getusername();



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
                        dr["enduser"] = enduser;// sourceData.Rows[rowixd][manhomKHkhuyenmai].ToString().Truncate(225).Trim();// double.Parse(sourceData.Rows[rowixd][manhomKHkhuyenmai].ToString());//.Truncate(225).Trim();

                    //    string enduser = Utils.getusername();

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
                bulkCopy.ColumnMappings.Add("enduser", "enduser");

              

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


        private void importNhomCTKMsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            luckyno md = new luckyno();

            bool kq = md.deletelishnhomKHKMlist();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("manhomkh", typeof(string));
            batable.Columns.Add("cokh", typeof(double));
            batable.Columns.Add("enduser", typeof(string));



            int manhomkhid = -1;
            int cokhid = -1;

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
                        if (value.Trim() == "Mã CTKM")  //Account
                        {
                            manhomkhid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sold-to pt"))
                        {

                            cokhid = columid;
                            //    headindex = 0;

                        }



                    }
                    #endregion


                }// colum

            }// roww off heatder



            if (manhomkhid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Mã CTKM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cokhid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Sold-to pt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enduser = Utils.getusername();

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region



                string codekhahang = sourceData.Rows[rowixd][cokhid].ToString();
                if (codekhahang != "" && Utils.IsValidnumber(codekhahang) && sourceData.Rows[rowixd][cokhid].ToString().Trim() != "")
                {

                    if (double.Parse(codekhahang) > 0)
                    {
                        DataRow dr = batable.NewRow();
                        dr["manhomkh"] = sourceData.Rows[rowixd][manhomkhid].ToString().Truncate(225).Trim();
                        dr["cokh"] = double.Parse(sourceData.Rows[rowixd][cokhid].ToString());//.Truncate(225).Trim();
                        dr["enduser"] = enduser;// sourceData.Rows[rowixd][manhomkhid].ToString().Truncate(225).Trim();

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

                bulkCopy.DestinationTableName = "tbl_NhomKHKM";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("manhomkh", "[Mã_nhóm_KH]");
                bulkCopy.ColumnMappings.Add("cokh", "[CodeKH]");
                bulkCopy.ColumnMappings.Add("enduser", "enduser");



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
        

        private void importFreePuchaseorderlistsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            luckyno md = new luckyno();

            bool kq = md.deleteFreePuchasesorderlist();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("Created", typeof(string));
            batable.Columns.Add("SOrg", typeof(string));
            batable.Columns.Add("POnumber", typeof(string));
            batable.Columns.Add("DocDate", typeof(DateTime));
            batable.Columns.Add("DlvDate", typeof(DateTime));
            batable.Columns.Add("Document", typeof(string));
            batable.Columns.Add("Soldtopt", typeof(double));
            batable.Columns.Add("Name", typeof(string));
            batable.Columns.Add("Material", typeof(string));
            batable.Columns.Add("Description", typeof(string));
            batable.Columns.Add("Orderqty", typeof(double));
            batable.Columns.Add("ConfirmQty", typeof(double));
            batable.Columns.Add("Status", typeof(string));

            batable.Columns.Add("Netprice", typeof(double));
            batable.Columns.Add("Rj", typeof(string));

            batable.Columns.Add("NetValue", typeof(double));
            batable.Columns.Add("enduser", typeof(string));

            int Createdid = -1;
            int SOrgid = -1;
            int POnumberid = -1;
            int DocDateid = -1;
            int DlvDateid = -1;
            int Documentid = -1;
            int Soldtoptid = -1;
            int Nameid = -1;
            int Materialid = -1;
            int Descriptionid = -1;
            int Orderqtyid = -1;
            int ConfirmQtyid = -1;
            int Statusid = -1;
            int Netpriceid = -1;
            int Rjid = -1;
            int NetValueid = -1;



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
                        if (value.Trim() == ("Created"))  //Account
                        {
                            Createdid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("SOrg."))
                        {

                            SOrgid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("PO number"))
                        {

                            POnumberid = columid;
                            //   headindex = 0;



                        }

                        if (value.Trim() == ("Doc. Date"))
                        {

                            DocDateid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("Dlv.Date"))
                        {
                            DlvDateid = columid;

                        }

                        if (value.Trim() == ("Document"))
                        {
                            Documentid = columid;

                        }
                        if (value.Trim() == ("Sold-to pt"))
                        {
                            Soldtoptid = columid;

                        }
                        if (value.Trim() == ("Name 1"))
                        {
                            Nameid = columid;

                        }
                        if (value.Trim() == ("Material"))
                        {
                            Materialid = columid;

                        }
                        if (value.Trim() == ("Description"))
                        {
                            Descriptionid = columid;

                        }
                        if (value.Trim() == ("Order qty"))
                        {
                            Orderqtyid = columid;

                        }
                        if (value.Trim() == ("ConfirmQty"))
                        {
                            ConfirmQtyid = columid;

                        }
                        if (value.Trim() == ("Status"))
                        {
                            Statusid = columid;

                        }
                        //if (value.Trim() == ("Document"))
                        //{
                        //    Itemid = columid;

                        //}
                        if (value.Trim() == ("Net price"))
                        {
                            Netpriceid = columid;

                        }
                        if (value.Trim() == ("Rj"))
                        {
                            Rjid = columid;

                        }
                        if (value.Trim() == ("Net Value"))
                        {
                            NetValueid = columid;

                        }


                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Createdid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Created", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (SOrgid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột SOrg", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (POnumberid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột PO number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DocDateid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Doc Date", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DlvDateid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Dlv Date", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Documentid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Document", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Soldtoptid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Sold to pt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Materialid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Material", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Descriptionid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Description", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (Orderqtyid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Order qty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ConfirmQtyid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Confirm Qty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Netpriceid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Net price", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Rjid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Rj", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NetValueid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Net Value", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string enduser = Utils.getusername();

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region



                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string NetValue = sourceData.Rows[rowixd][NetValueid].ToString();
                if (NetValue != "" && Utils.IsValidnumber(NetValue) && sourceData.Rows[rowixd][NetValueid].ToString().Trim() != "")
                {


                    DataRow dr = batable.NewRow();
                    dr["Created"] = sourceData.Rows[rowixd][Createdid].ToString().Truncate(225).Trim();
                    dr["SOrg"] = sourceData.Rows[rowixd][SOrgid].ToString().Truncate(225).Trim();
                    dr["POnumber"] = sourceData.Rows[rowixd][POnumberid].ToString().Truncate(225).Trim();

                    dr["DlvDate"] = Utils.chageExceldatetoData2(sourceData.Rows[rowixd][DlvDateid].ToString());//.Truncate(225).Trim();


                    dr["DocDate"] = Utils.chageExceldatetoData2(sourceData.Rows[rowixd][DocDateid].ToString());//.Truncate(225).Trim();


                    dr["Document"] = double.Parse(sourceData.Rows[rowixd][Documentid].ToString());//.Truncate(225).Trim();

                    dr["Soldtopt"] = double.Parse(sourceData.Rows[rowixd][Soldtoptid].ToString());//.Truncate(225).Trim();
                    dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Truncate(225).Trim();
                    dr["Material"] = sourceData.Rows[rowixd][Materialid].ToString().Truncate(225).Trim();

                    dr["Description"] = sourceData.Rows[rowixd][Descriptionid].ToString().Truncate(225).Trim();


                    dr["Status"] = sourceData.Rows[rowixd][Statusid].ToString().Truncate(225).Trim();
                    dr["Rj"] = sourceData.Rows[rowixd][Rjid].ToString().Truncate(225).Trim();
                    dr["Orderqty"] = double.Parse(sourceData.Rows[rowixd][Orderqtyid].ToString());//.Truncate(225).Trim();
                    dr["ConfirmQty"] = double.Parse(sourceData.Rows[rowixd][ConfirmQtyid].ToString());//.Truncate(225).Trim();
                    dr["Netprice"] = double.Parse(sourceData.Rows[rowixd][Netpriceid].ToString());//.Truncate(225).Trim();

                    dr["NetValue"] = double.Parse(sourceData.Rows[rowixd][NetValueid].ToString());//.Truncate(225).Trim();
                    dr["enduser"] = enduser;// sourceData.Rows[rowixd][Statusid].ToString().Truncate(225).Trim();
                    

                    batable.Rows.Add(dr);




                }

                #endregion
            }

            //    Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                bulkCopy.DestinationTableName = "tbl_SalesFreeOrder";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Created", "Created");
                bulkCopy.ColumnMappings.Add("SOrg", "SOrg");
                bulkCopy.ColumnMappings.Add("POnumber", "PO_number");
                bulkCopy.ColumnMappings.Add("DocDate", "Doc_Date");
                bulkCopy.ColumnMappings.Add("DlvDate", "Dlv_Date");
                bulkCopy.ColumnMappings.Add("Document", "Order_Number");
                bulkCopy.ColumnMappings.Add("Soldtopt", "Sold_to_party");
                bulkCopy.ColumnMappings.Add("Name", "Name");
                bulkCopy.ColumnMappings.Add("Material", "Material");
                bulkCopy.ColumnMappings.Add("Description", "Description");
                bulkCopy.ColumnMappings.Add("Orderqty", "Order_quantity");
                bulkCopy.ColumnMappings.Add("ConfirmQty", "ConfirmQty");
                bulkCopy.ColumnMappings.Add("Status", "Status");

                //    bulkCopy.ColumnMappings.Add("UCRate", "[Item]");

                bulkCopy.ColumnMappings.Add("Netprice", "Net_price");
                bulkCopy.ColumnMappings.Add("Rj", "Rj");
                //   bulkCopy.ColumnMappings.Add("UCRate", "[Plnt]");
                bulkCopy.ColumnMappings.Add("NetValue", "Net_value");
                bulkCopy.ColumnMappings.Add("enduser", "enduser");


                

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



        private void importPuchaseorderlistsexcel(object obj)
        {
            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            luckyno md = new luckyno();

            bool kq = md.deletePuchasesorderlist();

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            //      ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvider.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();

            batable.Columns.Add("Created", typeof(string));
            batable.Columns.Add("SOrg", typeof(string));
            batable.Columns.Add("POnumber", typeof(string));
            batable.Columns.Add("DocDate", typeof(DateTime));
            batable.Columns.Add("DlvDate", typeof(DateTime));
            batable.Columns.Add("Document", typeof(string));
            batable.Columns.Add("Soldtopt", typeof(double));
            batable.Columns.Add("Name", typeof(string));
            batable.Columns.Add("Material", typeof(string));
            batable.Columns.Add("Description", typeof(string));
            batable.Columns.Add("Orderqty", typeof(double));
            batable.Columns.Add("ConfirmQty", typeof(double));
            batable.Columns.Add("Status", typeof(string));

            batable.Columns.Add("Netprice", typeof(double));
            batable.Columns.Add("Rj", typeof(string));

            batable.Columns.Add("NetValue", typeof(double));
            batable.Columns.Add("enduser", typeof(string));
            
            int Createdid = -1;
            int SOrgid = -1;
            int POnumberid = -1;
            int DocDateid = -1;
            int DlvDateid = -1;
            int Documentid = -1;
            int Soldtoptid = -1;
            int Nameid = -1;
            int Materialid = -1;
            int Descriptionid = -1;
            int Orderqtyid = -1;
            int ConfirmQtyid = -1;
            int Statusid = -1;
            int Netpriceid = -1;
            int Rjid = -1;
            int NetValueid = -1;



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
                        if (value.Trim() == ("Created"))  //Account
                        {
                            Createdid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("SOrg."))
                        {

                            SOrgid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim() == ("PO number"))
                        {

                            POnumberid = columid;
                            //   headindex = 0;



                        }

                        if (value.Trim() == ("Doc. Date"))
                        {

                            DocDateid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim() == ("Dlv.Date"))
                        {
                            DlvDateid = columid;

                        }

                        if (value.Trim() == ("Document"))
                        {
                            Documentid = columid;

                        }
                        if (value.Trim() == ("Sold-to pt"))
                        {
                            Soldtoptid = columid;

                        }
                        if (value.Trim() == ("Name 1"))
                        {
                            Nameid = columid;

                        }
                        if (value.Trim() == ("Material"))
                        {
                            Materialid = columid;

                        }
                        if (value.Trim() == ("Description"))
                        {
                            Descriptionid = columid;

                        }
                        if (value.Trim() == ("Order qty"))
                        {
                            Orderqtyid = columid;

                        }
                        if (value.Trim() == ("ConfirmQty"))
                        {
                            ConfirmQtyid = columid;

                        }
                        if (value.Trim() == ("Status"))
                        {
                            Statusid = columid;

                        }
                        //if (value.Trim() == ("Document"))
                        //{
                        //    Itemid = columid;

                        //}
                        if (value.Trim() == ("Net price"))
                        {
                            Netpriceid = columid;

                        }
                        if (value.Trim() == ("Rj"))
                        {
                            Rjid = columid;

                        }
                        if (value.Trim() == ("Net Value"))
                        {
                            NetValueid = columid;

                        }


                    }
                    #endregion


                }// colum

            }// roww off heatder


            if (Createdid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Created", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (SOrgid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột SOrg", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (POnumberid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột PO number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DocDateid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Doc Date", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DlvDateid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Dlv Date", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Documentid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Document", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Soldtoptid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Sold to pt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nameid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Name 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Materialid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Material", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Descriptionid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Description", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (Orderqtyid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Order qty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ConfirmQtyid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Confirm Qty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Netpriceid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Net price", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Rjid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Rj", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NetValueid == -1)
            {
                MessageBox.Show("Dữ liệu thiếu cột Net Value", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string enduser = Utils.getusername();



            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region



                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string NetValue = sourceData.Rows[rowixd][NetValueid].ToString();
                if (NetValue != "" && Utils.IsValidnumber(NetValue) && sourceData.Rows[rowixd][NetValueid].ToString().Trim() != "")
                {


                    DataRow dr = batable.NewRow();
                    dr["Created"] = sourceData.Rows[rowixd][Createdid].ToString().Truncate(225).Trim();
                    dr["SOrg"] = sourceData.Rows[rowixd][SOrgid].ToString().Truncate(225).Trim();
                    dr["POnumber"] = sourceData.Rows[rowixd][POnumberid].ToString().Truncate(225).Trim();

                    dr["DlvDate"] = Utils.chageExceldatetoData2(sourceData.Rows[rowixd][DlvDateid].ToString());//.Truncate(225).Trim();


                    dr["DocDate"] = Utils.chageExceldatetoData2(sourceData.Rows[rowixd][DocDateid].ToString());//.Truncate(225).Trim();


                    dr["Document"] = double.Parse(sourceData.Rows[rowixd][Documentid].ToString());//.Truncate(225).Trim();

                    dr["Soldtopt"] = double.Parse(sourceData.Rows[rowixd][Soldtoptid].ToString());//.Truncate(225).Trim();
                    dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Truncate(225).Trim();
                    dr["Material"] = sourceData.Rows[rowixd][Materialid].ToString().Truncate(225).Trim();

                    dr["Description"] = sourceData.Rows[rowixd][Descriptionid].ToString().Truncate(225).Trim();


                    dr["Status"] = sourceData.Rows[rowixd][Statusid].ToString().Truncate(225).Trim();
                    dr["Rj"] = sourceData.Rows[rowixd][Rjid].ToString().Truncate(225).Trim();
                    dr["Orderqty"] = double.Parse(sourceData.Rows[rowixd][Orderqtyid].ToString());//.Truncate(225).Trim();
                    dr["ConfirmQty"] = double.Parse(sourceData.Rows[rowixd][ConfirmQtyid].ToString());//.Truncate(225).Trim();
                    dr["Netprice"] = double.Parse(sourceData.Rows[rowixd][Netpriceid].ToString());//.Truncate(225).Trim();

                    dr["NetValue"] = double.Parse(sourceData.Rows[rowixd][NetValueid].ToString());//.Truncate(225).Trim();

                    dr["enduser"] = enduser;// sourceData.Rows[rowixd][Nameid].ToString().Truncate(225).Trim();


                    batable.Rows.Add(dr);




                }

                #endregion
            }

            //    Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                bulkCopy.DestinationTableName = "tbl_Salesorder";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Created", "Created");
                bulkCopy.ColumnMappings.Add("SOrg", "SOrg");
                bulkCopy.ColumnMappings.Add("POnumber", "PO_number");
                bulkCopy.ColumnMappings.Add("DocDate", "Doc_Date");
                bulkCopy.ColumnMappings.Add("DlvDate", "Dlv_Date");
                bulkCopy.ColumnMappings.Add("Document", "Order_Number");
                bulkCopy.ColumnMappings.Add("Soldtopt", "Sold_to_party");
                bulkCopy.ColumnMappings.Add("Name", "Name");
                bulkCopy.ColumnMappings.Add("Material", "Material");
                bulkCopy.ColumnMappings.Add("Description", "Description");
                bulkCopy.ColumnMappings.Add("Orderqty", "Order_quantity");
                bulkCopy.ColumnMappings.Add("ConfirmQty", "ConfirmQty");
                bulkCopy.ColumnMappings.Add("Status", "Status");

                //    bulkCopy.ColumnMappings.Add("UCRate", "[Item]");

                bulkCopy.ColumnMappings.Add("Netprice", "Net_price");
                bulkCopy.ColumnMappings.Add("Rj", "Rj");
                //   bulkCopy.ColumnMappings.Add("UCRate", "[Plnt]");
                bulkCopy.ColumnMappings.Add("NetValue", "Net_value");
                bulkCopy.ColumnMappings.Add("enduser", "enduser");




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


        public void UpPUCHASEORDER()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Puchase Order List excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importPuchaseorderlistsexcel);
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


        public void UpFreePUCHASEORDER()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File FREE Puchase Order  excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importFreePuchaseorderlistsexcel);
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


        public void UpnhomCTKM()
        {
            //  throw new NotImplementedException();

            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Nhóm CTKM theo code khách hàng List excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {


                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importNhomCTKMsexcel);
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
