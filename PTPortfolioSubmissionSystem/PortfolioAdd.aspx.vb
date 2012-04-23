Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class PortfolioAdd
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Portfolio.aspx")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click


        Dim sqlInsert As String = "Insert Into Portfolio (UserID, ReviewStage, DueDate) Values (" & ddlCandidates.SelectedValue & ", '" & ddlReviewStage.SelectedValue & "', '" & CDate(txtDueDate.Text) & "' )"

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

                Try

                    cnPT.Open()
                    Dim sqlSelect As String = "SELECT UserID, Username FROM [User] where UserID= " & ddlCandidates.SelectedValue
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

                Dim di As DirectoryInfo = New DirectoryInfo("C:\Documents and Settings\Daniel Van Sciver\Desktop\PTPortfolioSubmissionSystem\PTPortfolioSubmissionSystem\Portfolios\" & lblUsername.Text.Trim.Replace(" ", "") & ddlReviewStage.SelectedValue.Replace("/", "").Replace(" ", "") & "\")
                Try

                    di.Create()

                Catch ex As Exception
                    lblError.Visible = True
                lblError.Text = "Directory Create Error: " & ex.ToString
                End Try

                Response.Redirect("Portfolio.aspx")

            End If

    End Sub

End Class