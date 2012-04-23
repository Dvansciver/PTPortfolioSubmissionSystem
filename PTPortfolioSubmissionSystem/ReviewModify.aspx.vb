Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ReviewModify
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblReviewID.Text = Request("ReviewID")
            ddlArtifacts.DataBind()

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT r.PortfolioID, r.UserID, r.Review, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + u.Type + ')' as Reviewer FROM Review r inner join [User] u on r.UserID=u.UserID where r.ReviewID = " & lblReviewID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblPortfolioID.Text = rdrGET("PortfolioID")
                lblUserID.Text = rdrGET("UserID")
                lblReviewer.Text = rdrGET("Reviewer")
                If IsDBNull(rdrGET("Review")) Then
                    lblReview.ForeColor = Drawing.Color.Red
                    lblReview.Text = "Pending"
                Else
                    lblReview.Text = rdrGET("Review")
                End If

                lblUsername.Text = rdrGET("Username")
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try

            SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & lblPortfolioID.Text & "' order by a.Artifact"

        End If

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT p.UserID, p.ReviewStage, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + p.ReviewStage + ')' as Portfolio FROM Portfolio p inner join [User] u on p.UserID=u.UserID where PortfolioID = " & lblPortfolioID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblPortfolioUserName.Text = rdrGET("Username")
            lblPortfolio.Text = rdrGET("Portfolio")
            lblReviewStage.Text = rdrGET("ReviewStage")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text.Replace(" ", "") & "/" & ddlArtifacts.SelectedValue


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("Review.aspx")

    End Sub


    Private Sub ddlArtifacts_DataBound(sender As Object, e As System.EventArgs) Handles ddlArtifacts.DataBound

        Dim SelectedValue As String = ddlArtifacts.SelectedValue
        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text & "/" & SelectedValue


    End Sub

    Private Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click


            lblReviewID.Text = Request("ReviewID")
            ddlArtifacts.DataBind()

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT r.PortfolioID, r.UserID, r.Review, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + u.Type + ')' as Reviewer FROM Review r inner join [User] u on r.UserID=u.UserID where r.ReviewID = " & lblReviewID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblPortfolioID.Text = rdrGET("PortfolioID")
            lblUserID.Text = rdrGET("UserID")
            lblReviewer.Text = rdrGET("Reviewer")
            If IsDBNull(rdrGET("Review")) Then
                lblReview.ForeColor = Drawing.Color.Red
                lblReview.Text = "Pending"
            Else
                lblReview.Text = rdrGET("Review")
            End If
            lblUsername.Text = rdrGET("Username")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & lblPortfolioID.Text & "' order by a.Artifact"

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT p.UserID, p.ReviewStage, u.UserID, u.Username, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName + ' (' + p.ReviewStage + ')' as Portfolio FROM Portfolio p inner join [User] u on p.UserID=u.UserID where PortfolioID = " & lblPortfolioID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblPortfolioUserName.Text = rdrGET("Username")
            lblPortfolio.Text = rdrGET("Portfolio")
            lblReviewStage.Text = rdrGET("ReviewStage")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text & "/" & ddlArtifacts.SelectedValue

    End Sub

    Private Sub btnModify_Click(sender As Object, e As System.EventArgs) Handles btnModify.Click


        Dim oldsavepath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Reviews\" & lblUsername.Text.Trim.Replace(" ", "") & "\"
        Dim savePath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Reviews\" & lblUsername.Text.Trim.Replace(" ", "") & "\"
        Dim fileName As String = FileupReview.FileName.Replace("'", "_").Replace(";", "_")
        Dim pathToCheck As String = savePath + fileName
        Dim tempfileName As String = ""

        If FileupReview.HasFile Then

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
            FileupReview.SaveAs(savePath)

            Dim sqlUpdate As String

            sqlUpdate = "UPDATE Review SET Review='" & fileName & "', PostDate='" & CDate(Date.Today.Date) & "' Where ReviewID= " & lblReviewID.Text

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
                If lblReview.Text = "Pending" Then

                Else
                    My.Computer.FileSystem.DeleteFile(oldsavepath + lblReview.Text)
                End If

            End Try


            If lblError.Visible = False Then
                Response.Redirect("Review.aspx")
            End If

        Else

            Dim sqlUpdate As String

            sqlUpdate = "UPDATE Review SET PostDate='" & CDate(Date.Today.Date) & "' Where ReviewID= " & lblReviewID.Text

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
                Response.Redirect("Review.aspx")
            End If

        End If

    End Sub
End Class