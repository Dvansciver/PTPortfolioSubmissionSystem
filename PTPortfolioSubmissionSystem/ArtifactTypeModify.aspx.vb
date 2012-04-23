Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactTypeModify
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
                txtArtifactType.Text = rdrGET("Type")
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

    Private Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT ArtifactTypeID, Type FROM ArtifactType where ArtifactTypeID = " & lblArtifactTypeID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            txtArtifactType.Text = rdrGET("Type")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

    End Sub

    Private Sub btnModify_Click(sender As Object, e As System.EventArgs) Handles btnModify.Click

        Dim sqlUpdate As String

        sqlUpdate = "UPDATE ArtifactType SET Type='" & txtArtifactType.Text & "' Where ArtifactTypeID= " & lblArtifactTypeID.Text

        Try
            cnPT.Open()
            Dim daSL As New SqlDataAdapter
            daSL.UpdateCommand = New SqlCommand(sqlUpdate, cnPT)
            daSL.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Update error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        If lblError.Visible = False Then
            Response.Redirect("ArtifactType.aspx")
        End If
    End Sub
End Class