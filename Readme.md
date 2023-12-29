<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128580211/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T511362)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ASPxDashboard_ServerExport/Default.aspx) (VB: [Default.aspx](./VB/ASPxDashboard_ServerExport/Default.aspx))
* [Default.aspx.cs](./CS/ASPxDashboard_ServerExport/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ASPxDashboard_ServerExport/Default.aspx.vb))
* [Global.asax](./CS/ASPxDashboard_ServerExport/Global.asax) (VB: [Global.asax](./VB/ASPxDashboard_ServerExport/Global.asax))
* [Global.asax.cs](./CS/ASPxDashboard_ServerExport/Global.asax.cs) (VB: [Global.asax.vb](./VB/ASPxDashboard_ServerExport/Global.asax.vb))
<!-- default file list end -->
# How to export Web Dashboard into PDF with different filter values on different pages


<p>This example demonstrates how to export a dashboard with different states (different master filters) to separate pages in a single PDF document. The example is based on the <a href="https://www.devexpress.com/Support/Center/p/T500219">How to implement server-side export in the ASP.NET Dashboard Control</a> example and uses the same <a href="https://documentation.devexpress.com/Dashboard/clsDevExpressDashboardWebASPxDashboardExportertopic.aspx">ASPxDashboardExporter</a> class to export a dashboard with different states to multiple documents on the server side. Then, multiple exported documents are joined in a single file using the <a href="https://documentation.devexpress.com/DocumentServer/DevExpress.Pdf.PdfDocumentProcessor.class">PdfDocumentProcessor</a> class.</p>

<br/>


