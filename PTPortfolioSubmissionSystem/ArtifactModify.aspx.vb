Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactModify
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
                ddlArtifactType.SelectedValue = rdrGET("ArtifactTypeID")
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

    Private Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click


        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT a.ArtifactID, a.ArtifactTypeID, a.Artifact, t.ArtifactTypeID, t.Type FROM Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID where a.ArtifactID = " & lblArtifactID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblArtifact.Text = rdrGET("Artifact")
            ddlArtifactType.SelectedValue = rdrGET("ArtifactTypeID")

            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

    End Sub

    Private Sub btnModify_Click(sender As Object, e As System.EventArgs) Handles btnModify.Click

        Dim oldsavepath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUserName.Text.Trim.Replace(" ", "") & lblReviewStage.Text.Replace("/", "").Replace(" ", "") & "\"
        Dim savePath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUserName.Text.Trim.Replace(" ", "") & lblReviewStage.Text.Replace("/", "").Replace(" ", "") & "\"
        Dim fileName As String = FileupArtifact.FileName.Replace("'", "_").Replace(";", "_")
        Dim pathToCheck As String = savePath + fileName
        Dim tempfileName As String = ""

        If FileupArtifact.HasFile Then

            If (System.IO.File.Exists(pathToCheck)) Then
                Dim counter As Integer = 2
                While (System.IO.File.Exists(pathToCheck))
                    tempfileName = counter.ToString() + fileName
                    pathToCheck = savePath + tempfileName
                    counter = counter + 1
                End While
                fileName = tempfileName
            End If

            savePath += fileName
            FileupArtifact.SaveAs(savePath)

            Dim sqlUpdate As String

            sqlUpdate = "UPDATE Artifact SET ArtifactTypeID=" & ddlArtifactType.SelectedValue & ", Artifact='" & fileName & "' Where ArtifactID= " & lblArtifactID.Text

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
                My.Computer.FileSystem.DeleteFile(oldsavepath + lblArtifact.Text)
            End Try


            If lblError.Visible = False Then
                Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)
            End If

        Else

            Dim sqlUpdate As String

            sqlUpdate = "UPDATE Artifact SET ArtifactTypeID=" & ddlArtifactType.SelectedValue & " Where ArtifactID= " & lblArtifactID.Text

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
                Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)
            End If

        End If


    End Sub
End Class