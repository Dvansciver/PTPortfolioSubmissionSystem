Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class ReviewAdd
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then


            ddlPortfolios.DataBind()
            ddlArtifacts.DataBind()
            SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & ddlPortfolios.SelectedValue & "' order by a.Artifact"

        End If

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT p.UserID, p.ReviewStage, u.UserID, u.Username FROM Portfolio p inner join [User] u on p.UserID=u.UserID where PortfolioID = " & ddlPortfolios.SelectedValue
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            lblPortfolioUserName.Text = rdrGET("Username")
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

    Private Sub ddlPortfolios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPortfolios.SelectedIndexChanged

        SqlArtifacts.SelectCommand = "Select a.ArtifactID, a.PortfolioID, a.ArtifactTypeID, a.Artifact, a.Artifact + ' (' + t.Type + ')' as FullArtifact, t.ArtifactTypeID From Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID Where a.PortfolioID='" & ddlPortfolios.SelectedValue & "' order by a.Artifact"

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("Review.aspx")

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT UserID, Username FROM [User] where UserID= " & ddlReviewers.SelectedValue
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

        Dim di As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Reviews\" & lblUsername.Text.Trim.Replace(" ", "") & "\")
        Try

            di.Create()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Directory Create Error: " & ex.ToString
        End Try

        Dim savePath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Reviews\" & lblUsername.Text.Trim.Replace(" ", "") & "\"
        Dim fileName As String = FileupReview.FileName.Replace("'", "_").Replace(";", "_")
        Dim pathToCheck As String = savePath + fileName
        Dim tempfileName As String = ""

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

        Dim sqlInsert As String = "Insert Into Review (UserID, PortfolioID, Review, PostDate) Values (" & ddlReviewers.SelectedValue & ", " & ddlPortfolios.SelectedValue & ", '" & fileName & "', '" & CDate(Date.Today.Date) & "')"

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
            Response.Redirect("Review.aspx")
        End If

    End Sub

    Private Sub ddlArtifacts_DataBound(sender As Object, e As System.EventArgs) Handles ddlArtifacts.DataBound

        Dim SelectedValue As String = ddlArtifacts.SelectedValue
        lnkOpen.NavigateUrl = "~/Portfolios/" & lblPortfolioUserName.Text & lblReviewStage.Text & "/" & SelectedValue


    End Sub
End Class