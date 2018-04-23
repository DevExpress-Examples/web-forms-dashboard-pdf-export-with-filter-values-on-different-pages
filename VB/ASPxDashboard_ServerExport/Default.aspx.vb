Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.Pdf
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Namespace ASPxDashboard_ServerExport
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Private fileStorage As New DashboardFileStorage("App_Data/Dashboards")
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxDashboard1.AllowExportDashboard = False
			ASPxDashboard1.SetDashboardStorage(fileStorage)
		End Sub

		Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If ASPxHiddenField1.Get("dashboardState") IsNot Nothing AndAlso ASPxHiddenField1.Get("filterItems") IsNot Nothing Then
				Dim dashboardStateJson As String = ASPxHiddenField1.Get("dashboardState").ToString()
				Dim parameters() As String = ASPxHiddenField1.Get("filterItems").ToString().Split("|"c)

				Dim resultStream As New MemoryStream()
				Using documentProcessor As New PdfDocumentProcessor()
					documentProcessor.CreateEmptyDocument(resultStream)
					For i As Integer = 0 To parameters.Length - 1
						Dim dashboardState As New DashboardState()
						dashboardState.LoadFromJson(dashboardStateJson)
						Dim filterItemState = dashboardState.Items.Where(Function(item) item.ItemName = "comboBoxDashboardItem1").FirstOrDefault()
						If filterItemState IsNot Nothing Then
							filterItemState.MasterFilterValues.Clear()
							filterItemState.MasterFilterValues.Add(New Object() { parameters(i) })
						End If
						Dim pdfOptions As New DashboardPdfExportOptions()
						pdfOptions.ShowTitle = DevExpress.Utils.DefaultBoolean.False
						Dim exporter As New ASPxDashboardExporter(ASPxDashboard1)
						Using stream As New MemoryStream()
							exporter.ExportToPdf("Dashboard1", stream, New System.Drawing.Size(1024, 768), dashboardState, pdfOptions)
							documentProcessor.AppendDocument(stream)
						End Using
					Next i
				End Using

				resultStream.Seek(0, SeekOrigin.Begin)
				Page.Response.Clear()
				Page.Response.ContentType = "application/pdf"
				Response.BinaryWrite(resultStream.ToArray())
				Page.Response.End()
			End If
		End Sub
	End Class
End Namespace