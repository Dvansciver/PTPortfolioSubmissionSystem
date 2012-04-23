Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactType
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("ArtifactTypeAdd.aspx")
    End Sub
End Class