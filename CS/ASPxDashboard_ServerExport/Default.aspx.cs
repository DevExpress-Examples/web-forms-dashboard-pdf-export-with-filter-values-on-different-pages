using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASPxDashboard_ServerExport
{
    public partial class Default : System.Web.UI.Page
    {
        DashboardFileStorage fileStorage = new DashboardFileStorage("App_Data/Dashboards");
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.AllowExportDashboard = false;         
            ASPxDashboard1.SetDashboardStorage(fileStorage);
        }

        protected void ASPxButton1_Click(object sender, EventArgs e) {
            if (ASPxHiddenField1.Get("dashboardState") != null && ASPxHiddenField1.Get("filterItems") != null) {
                string dashboardStateJson = ASPxHiddenField1.Get("dashboardState").ToString();
                string[] parameters = ASPxHiddenField1.Get("filterItems").ToString().Split('|');

                MemoryStream resultStream = new MemoryStream();
                using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor()) {
                    documentProcessor.CreateEmptyDocument(resultStream);
                    for (int i = 0; i < parameters.Length; i++) {
                        DashboardState dashboardState = new DashboardState();
                        dashboardState.LoadFromJson(dashboardStateJson);
                        var filterItemState = dashboardState.Items.Where(item => item.ItemName == "comboBoxDashboardItem1").FirstOrDefault();
                        if (filterItemState != null) {
                            filterItemState.MasterFilterValues.Clear();
                            filterItemState.MasterFilterValues.Add(new object[] { parameters[i] });
                        }
                        DashboardPdfExportOptions pdfOptions = new DashboardPdfExportOptions();
                        pdfOptions.ShowTitle = DevExpress.Utils.DefaultBoolean.False;
                        ASPxDashboardExporter exporter = new ASPxDashboardExporter(ASPxDashboard1);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            exporter.ExportToPdf("Dashboard1", stream, new System.Drawing.Size(1024, 768), dashboardState, pdfOptions);
                            documentProcessor.AppendDocument(stream);
                        }
                    }
                }

                resultStream.Seek(0, SeekOrigin.Begin);
                Page.Response.Clear();
                Page.Response.ContentType = "application/pdf";
                Response.BinaryWrite(resultStream.ToArray());
                Page.Response.End();
            }
        }
    }
}