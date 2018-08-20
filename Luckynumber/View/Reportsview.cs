//using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Luckynumber.View
{
    public partial class Reportsview : Form
    {
        public DataTable tbl1 { get; set; }
        public Reportsview(DataTable tbl1, DataTable tbl2, string rptname ) //IQueryable rs
        {
            InitializeComponent();

            this.tbl1 = tbl1;

         //   var db1 = new LinqtoSQLDataContext(connection_string);
         //var rs = from tblFBL5Nnew in db.tblFBL5Nnews
         //         where tblFBL5Nnew.Completed_use == true
         //         select new
         //         {
         //             ID = tblFBL5Nnew.id,
         //             Account = tblFBL5Nnew.Account,
         //             Amount = tblFBL5Nnew.Amount_in_local_currency,
         //             Deposit = tblFBL5Nnew.Deposit_amount,
         //             hn = "han oi"

            //         };



            // chọn báo cáo hiển thị
            // ARCOLrpt.rdlc
            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Luckynumber.Reports.ARCOLrpt.rdlc";

            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Luckynumber.Reports.RPt_callogs.rdlc";
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Luckynumber.Reports."+ rptname + "";
            // chọn báo cáo hiển thị

            // chọn data hiển thị


            ReportDataSource datasource = new ReportDataSource("DataSet1", tbl1);
           ReportDataSource datasource2 = new ReportDataSource("DataSet2", tbl2);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(datasource);
          this.reportViewer1.LocalReport.DataSources.Add(datasource2);

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing );

            // chọn data hiển thị

            // chọn kiểu hiển thị
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

           // this.reportViewer1.ZoomMode = ZoomMode.Percent;
           // this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            //
          //  this.reportViewer1.ShowExportButto = false;
            //if (rptname == "ARletter.rdlc")
            //{

            ////    tbl_ArletterRpt rptdata = new tbl_ArletterRpt();

            ////    ReportParameter rp0 = new ReportParameter("NO", rptdata.No.ToString());
            //////    ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            ////    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0 });
            //////    this.reportViewer1.LocalReport.Refresh();




            //}
            ////ReportParameter rp0 = new ReportParameter("Report_Parameter_UserName", tbl_ArletterRpt.);
            //ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0, rp1 });
            //ReportViewer1.LocalReport.Refresh();

            // chọn kiểu hiển thị

            this.reportViewer1.RefreshReport();

        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            var custGroupid = double.Parse(e.Parameters["custGroupid"].Values.First());
         //   var subSource = ((List<Cus>)mainSource.Value).Single(o => o.OrderID == orderId).Suppliers;

            e.DataSources.Add(new ReportDataSource("DataSet1", tbl1));



            //  throw new NotImplementedException();
        }
    }



}
