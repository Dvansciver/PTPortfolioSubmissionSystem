Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class PortfolioModify
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblPortfolioID.Text = Request("PortfolioID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT PortfolioID, UserID, ReviewStage, PostDate, DueDate FROM Portfolio where PortfolioID = " & lblPortfolioID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                ddlCandidates.SelectedValue = rdrGET("UserID")
                ddlReviewStage.SelectedValue = rdrGET("ReviewStage")
                If IsDBNull(rdrGET("PostDate")) Then
                    lblPostDate.ForeColor = Drawing.Color.Red
                    lblPostDate.Text = "Pending"
                Else
                    lblPostDate.Text = rdrGET("PostDate")
                End If
                txtDueDate.Text = Format(CDate(rdrGET("DueDate")), "MM/dd/yyyy")
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

    Private Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT PortfolioID, UserID, ReviewStage, PostDate, DueDate FROM Portfolio where PortfolioID = " & lblPortfolioID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            ddlCandidates.SelectedValue = rdrGET("UserID")
            ddlReviewStage.Text = rdrGET("ReviewStage")
            lblPostDate.Text = rdrGET("PostDate")
            If IsDBNull(rdrGET("DueDate")) Then

            Else
                txtDueDate.Text = Format(CDate(rdrGET("DueDate")), "MM/dd/yyyy")
            End If
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

            If txtDueDate.Text = "" Then

                sqlUpdate = "UPDATE Portfolio SET UserID=" & ddlCandidates.SelectedValue & ", ReviewStage='" & ddlReviewStage.SelectedValue & "', PostDate='" & CDate(Date.Today.Date) & "', DueDate=NULL Where PortfolioID= " & lblPortfolioID.Text

            Else

                sqlUpdate = "UPDATE Portfolio SET UserID=" & ddlCandidates.SelectedValue & ", ReviewStage='" & ddlReviewStage.SelectedValue & "', PostDate='" & CDate(Date.Today.Date) & "', DueDate='" & CDate(txtDueDate.Text) & "' Where PortfolioID= " & lblPortfolioID.Text

            End If

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
                    lblError.Text = "Insert Query Error: " & ex.ToString
                End Try

                Response.Redirect("Portfolio.aspx")

            End If

    End Sub
End Class