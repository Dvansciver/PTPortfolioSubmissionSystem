Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO
Public Class SubmitReview
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("IsClassroomObserver") = True Then
                trArtifacts.Visible = False
                lblDisclaimer.Visible = False
            End If

            lblUserID.Text = Session("UserID")

            ddlPortfolios.DataBind()
            ddlArtifacts.DataBind()
            SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & ddlPortfolios.SelectedValue & "' order by a.Artifact"

        End If

        Try

            cnPT.Open()
            If ddlPortfolios.Items.Count = 0 Then
                tblMain.Visible = False
                tblNoPortfolios.Visible = True
                lblRequired.Visible = True
                lblRequired.Text = "There are no portfolios for you to review at this time."
            Else

                Dim sqlSelect As String = "SELECT p.UserID, p.PortfolioID, p.ReviewStage, u.UserID, u.Username FROM Portfolio p inner join [User] u on p.UserID=u.UserID where p.PortfolioID = " & ddlPortfolios.SelectedValue
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                If rdrGET.HasRows Then
                    rdrGET.Read()
                    lblPortfolioUserName.Text = rdrGET("Username")
                    lblReviewStage.Text = rdrGET("ReviewStage")
                    lblPortfolioID.Text = rdrGET("PortfolioID")
                    rdrGET.Close()
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try
        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text.Replace(" ", "") & "/" & ddlArtifacts.SelectedValue


    End Sub

    Private Sub ddlPortfolios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPortfolios.SelectedIndexChanged

        SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & ddlPortfolios.SelectedValue & "' order by a.Artifact"

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT UserID, Username FROM [User] where UserID= " & lblUserID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblUsername.Text = rdrGET("Username")
            rdrGET.Close()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

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

            sqlUpdate = "UPDATE Review SET Review='" & fileName & "', PostDate='" & CDate(Date.Today.Date) & "' Where PortfolioID= " & lblPortfolioID.Text

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
                Response.Redirect("/Reviewer/Successful.aspx")
            End If

        Else
            lblRequired.Visible = True
            lblRequired.Text = "*Required"
        End If

    End Sub

    Private Sub ddlArtifacts_DataBound(sender As Object, e As System.EventArgs) Handles ddlArtifacts.DataBound

        Dim SelectedValue As String = ddlArtifacts.SelectedValue
        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text & "/" & SelectedValue


    End Sub

End Class