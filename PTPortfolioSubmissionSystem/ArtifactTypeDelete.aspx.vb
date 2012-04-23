Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactTypeDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblArtifactTypeID.Text = Request("ArtifactTypeID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT ArtifactTypeID, Type FROM ArtifactType where ArtifactTypeID = " & lblArtifactTypeID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblArtifactType.Text = rdrGET("Type")
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ArtifactType.aspx")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        Dim sqlDelete As String

        sqlDelete = "DELETE FROM ArtifactType Where ArtifactTypeID=" & lblArtifactTypeID.Text

        Try
            cnPT.Open()
            Dim objCommand As New SqlCommand(sqlDelete, cnPT)
            objCommand.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Delete error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        If lblError.Visible = False Then
            Response.Redirect("ArtifactType.aspx")
        End If

    End Sub
End Class