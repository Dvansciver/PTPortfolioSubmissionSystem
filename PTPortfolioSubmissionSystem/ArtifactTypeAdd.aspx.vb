Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactTypeAdd
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ArtifactType.aspx")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click

        Dim sqlInsert As String = "Insert Into ArtifactType (Type) Values ('" & txtArtifactType.Text & "' )"

        Try
            cnPT.Open()
            Dim daSC As New SqlDataAdapter
            daSC.InsertCommand = New SqlCommand(sqlInsert, cnPT)
            daSC.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Insert Query Error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        If lblError.Visible = False Then
            Response.Redirect("ArtifactType.aspx")
        End If

    End Sub
End Class