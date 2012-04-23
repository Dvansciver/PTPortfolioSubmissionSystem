Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")
            lblArtifactID.Text = Request("ArtifactID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, t.ArtifactTypeID, t.Type, p.PortfolioID, p.UserID, p.ReviewStage, u.UserID, u.Username FROM ((Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID) inner join Portfolio p on a.PortfolioID=p.PortfolioID) inner join [User] u on p.UserID=u.UserID where a.ArtifactID = " & lblArtifactID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblArtifact.Text = rdrGET("Artifact")
                lblArtifactType.Text = rdrGET("Type")
                lblReviewStage.Text = rdrGET("ReviewStage")
                lblUserName.Text = rdrGET("Username")
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

        Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        Dim sqlDelete As String
        Dim ArtifactPath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUserName.Text.Trim.Replace(" ", "") & lblReviewStage.Text.Replace("/", "").Replace(" ", "") & "\" & lblArtifact.Text

        sqlDelete = "DELETE FROM Artifact Where ArtifactID=" & lblArtifactID.Text

        Try
            cnPT.Open()
            Dim objCommand As New SqlCommand(sqlDelete, cnPT)
            objCommand.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Delete error: " & ex.ToString
        Finally
            cnPT.Close()
            My.Computer.FileSystem.DeleteFile(ArtifactPath)
        End Try

        If lblError.Visible = False Then
            Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)
        End If

    End Sub
End Class