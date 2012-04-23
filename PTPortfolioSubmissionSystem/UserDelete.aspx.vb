Imports System.Data.SqlClient
Imports System.Web.Configuration
Public Class UserDelete
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            lblUserID.Text = Request("UserID")

            Try

                cnPT.Open()
                Dim sqlSelect As String = "SELECT UserID, FirstName, MiddleInitial, LastName, Username, Password, Type FROM [User] where UserID = " & lblUserID.Text
                Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                rdrGET.Read()
                lblType.Text = rdrGET("Type")
                lblFirstName.Text = rdrGET("FirstName")
                lblMiddleInitial.Text = rdrGET("MiddleInitial")
                lblLastName.Text = rdrGET("LastName")
                lblUsername.Text = rdrGET("Username")
                lblPassword.Text = rdrGET("Password")
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
        Response.Redirect("User.aspx")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click

        Dim sqlDelete As String

        sqlDelete = "DELETE FROM [User] Where UserID=" & lblUserID.Text

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
            Response.Redirect("User.aspx")
        End If

    End Sub
End Class