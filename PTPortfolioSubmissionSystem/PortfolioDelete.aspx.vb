Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class PortfolioDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate, p.DueDate, u.UserID, u.Username, u.Firstname + ' ' + u.MiddleInitial + '. ' + u.Lastname as Candidate FROM Portfolio p inner join [User] u on p.UserID=u.UserID where p.PortfolioID = " & lblPortfolioID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblCandidate.Text = rdrGET("Candidate")
                lblReviewStage.Text = rdrGET("ReviewStage")
                If IsDBNull(rdrGET("PostDate")) Then
                    lblPostDate.ForeColor = Drawing.Color.Red
                    lblPostDate.Text = "Pending"
                Else
                    lblPostDate.Text = rdrGET("PostDate")
                End If
                lblDueDate.Text = rdrGET("DueDate")

        lblUsername.Text = rdrGET("Username")
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

        Response.Redirect("Portfolio.aspx")

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        Dim sqlDelete As String

        sqlDelete = "DELETE FROM Portfolio Where PortfolioID=" & lblPortfolioID.Text

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


            Dim di As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUsername.Text.Trim.Replace(" ", "") & lblReviewStage.Text.Replace("/", "").Replace(" ", "") & "\")
            Try

                di.Delete()

            Catch ex As Exception
                lblError.Visible = True
                lblError.Text = "Insert Query Error: " & ex.ToString
            End Try

            Response.Redirect("Portfolio.aspx")
        End If

    End Sub
End Class