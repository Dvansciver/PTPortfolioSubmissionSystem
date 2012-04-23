Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Class SubmitPortfolio
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblUserID.Text = Session("UserID")

    End Sub

    Private Sub grdPortfolios_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPortfolios.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim myLabel As New Label()
            myLabel = DirectCast(e.Row.FindControl("lblPostDate"), Label)
            Dim rowValue As String = myLabel.Text

            If rowValue Is Nothing OrElse rowValue.Length < 1 Then
                myLabel.Text = "Pending"
                myLabel.ForeColor = Drawing.Color.Red

            Else

                myLabel.Text = CDate(myLabel.Text)

            End If

            If CDate(e.Row.Cells(2).Text) < Date.Now Then
                e.Row.Cells(4).Enabled = False
                e.Row.Cells(4).Text = ""
            End If

        End If

    End Sub
End Class