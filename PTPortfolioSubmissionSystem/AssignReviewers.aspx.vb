Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class AssignReviewers
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblPID.Text = Request("PortfolioID")


    End Sub

    Private Sub btnAssignReviewer_Click(sender As Object, e As System.EventArgs) Handles btnAssignReviewer.Click

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

        Dim sqlInsert As String = "Insert Into Review (UserID, PortfolioID) Values (" & ddlReviewers.SelectedValue & ", '" & lblPID.Text & "' )"

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
            Response.Redirect("AssignReviewers.aspx?PortfolioID=" & lblPID.Text)
        End If

    End Sub



    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Portfolio.aspx")
    End Sub
End Class