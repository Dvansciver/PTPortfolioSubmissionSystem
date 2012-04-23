Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ArtifactAdd
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT p.PortfolioID, p.UserID, p.PostDate, p.ReviewStage, u.UserID, u.Username, u.Firstname, u.MiddleInitial, u.LastName FROM Portfolio p inner join [User] u on p.UserID=u.UserID where p.PortfolioID = " & lblPortfolioID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblUserName.Text = rdrGET("Username")
                lblReviewStage.Text = rdrGET("ReviewStage")
                lblRS.Text = rdrGET("ReviewStage")
                lblCandidateName.Text = rdrGET("Firstname") & " " & rdrGET("MiddleInitial") & ". " & rdrGET("Lastname")
                If IsDBNull(rdrGET("PostDate")) Then
                    lblDateSubmitted.ForeColor = Drawing.Color.Red
                    lblDateSubmitted.Text = "Pending"
                Else
                    lblDateSubmitted.Text = rdrGET("PostDate")
                End If
                rdrGET.Close()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Read Query error: " & ex.ToString
            Finally
                cnPT.Close()
            End Try

        End If

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Dim savePath As String = "C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUserName.Text.Trim.Replace(" ", "") & lblReviewStage.Text.Replace("/", "").Replace(" ", "") & "\"
        Dim fileName As String = FileupArtifact.FileName.Replace("'", "_").Replace(";", "_")
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
        FileupArtifact.SaveAs(savePath)

        Dim sqlInsert As String = "Insert Into Artifact (PortfolioID, ArtifactTypeID, Artifact) Values (" & lblPortfolioID.Text & ", '" & ddlArtifactType.SelectedValue & "', '" & fileName & "' )"

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
            Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Artifact.aspx?PortfolioID=" & lblPortfolioID.Text)
    End Sub
End Class