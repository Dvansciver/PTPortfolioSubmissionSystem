Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class UserAdd
    Inherits System.Web.UI.Page

    Dim cnPT As New SqlConnection(WebConfigurationManager.ConnectionStrings("PT").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("User.aspx")

    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Dim Count As Integer

        Try

            Dim sqlSelect As String = "Select Count(Username) as UsernameCount From [User] where Username='" & txtUserName.Text & "'"
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            cnPT.Open()
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            Count = rdrGET("UsernameCount")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Insert Query Error: " & ex.ToString

        Finally
            cnPT.Close()
        End Try

        If Count > 0 Then

            rfvUserName.IsValid = False
            rfvUserName.ErrorMessage = "This username is already in use. Please try a different username."

        Else

            Dim sqlInsert As String = "Insert Into [User] (FirstName, MiddleInitial, LastName, Username, Password, Type) Values ('" & txtFirstName.Text & "', '" & txtMiddleInitial.Text.ToUpper & "', '" & txtLastName.Text & "', '" & txtUserName.Text.Trim.Replace("'", "`") & "', '" & txtPassword.Text & "', '" & ddlUserType.SelectedValue & "' )"

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
                Response.Redirect("User.aspx")
            End If

        End If
    End Sub
End Class