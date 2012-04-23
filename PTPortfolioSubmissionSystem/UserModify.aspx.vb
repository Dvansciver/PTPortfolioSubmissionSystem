Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class UserModify
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
                ddlUserType.SelectedValue = rdrGET("Type")
                lblType.Text = rdrGET("Type")
                txtFirstName.Text = rdrGET("FirstName")
                txtMiddleInitial.Text = rdrGET("MiddleInitial")
                txtLastName.Text = rdrGET("LastName")
                txtUserName.Text = rdrGET("Username")
                lblUsername.Text = rdrGET("Username")
                txtPassword.Text = rdrGET("Password")
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

    Private Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click

        Try

            cnPT.Open()
            Dim sqlSelect As String = "SELECT UserID, FirstName, MiddleInitial, LastName, Username, Password, Type FROM [User] where UserID = " & lblUserID.Text
            Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
            Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
            rdrGET.Read()
            ddlUserType.SelectedValue = rdrGET("Type")
            txtFirstName.Text = rdrGET("FirstName")
            txtMiddleInitial.Text = rdrGET("MiddleInitial")
            txtLastName.Text = rdrGET("LastName")
            txtUserName.Text = rdrGET("Username")
            lblUsername.Text = rdrGET("Username")
            txtPassword.Text = rdrGET("Password")
            rdrGET.Close()

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Read Query error: " & ex.ToString
        Finally
            cnPT.Close()
        End Try

    End Sub

    Private Sub btnModify_Click(sender As Object, e As System.EventArgs) Handles btnModify.Click

        Dim Count As Integer = 0

        Try

            Dim sqlSelect As String = "Select Count(Username) as UsernameCount From [User] Where Username='" & txtUserName.Text & "'"
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

        If Count > 0 And lblUsername.Text <> txtUserName.Text Then

            rfvUserName.IsValid = False
            rfvUserName.ErrorMessage = "This username is already in use. Please try a different username."

        Else

            Dim sqlSelect As String = ""
            Dim pCount As Integer = 0
            Dim rCount As Integer = 0

            If lblType.Text = "Candidate" Then

                sqlSelect = "Select u.UserID, p.UserID, Count(p.PortfolioID) as PortfolioCount From [User] u inner join Portfolio p on u.UserID=p.UserID Where p.UserID=" & lblUserID.Text & " Group By u.UserID, p.UserID"
                Try
                    Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                    cnPT.Open()
                    Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                    If rdrGET.HasRows Then
                        rdrGET.Read()
                        If IsDBNull(rdrGET("PortfolioCount")) Then
                            pCount = 0
                        Else
                            pCount = rdrGET("PortfolioCount")
                        End If
                        rdrGET.Close()
                    End If
                Catch ex As Exception
                    lblError.Visible = True
                    lblError.Text = "Insert Query Error: " & ex.ToString
                Finally
                    cnPT.Close()
                End Try

            ElseIf lblType.Text = "Peer Reviewer" Or lblType.Text = "Classroom Observer" Then

                sqlSelect = "Select u.UserID, r.UserID, Count(r.Review) as ReviewCount From [User] u inner join Review r on u.UserID=r.UserID Where p.UserID=" & lblUserID.Text & " Group By u.UserID, p.UserID"
                Try
                    Dim cmdGET As New SqlCommand(sqlSelect, cnPT)
                    cnPT.Open()
                    Dim rdrGET As SqlDataReader = cmdGET.ExecuteReader
                    If rdrGET.HasRows Then
                        rdrGET.Read()
                        If IsDBNull(rdrGET("ReviewCount")) Then
                            rCount = 0
                        Else
                            rCount = rdrGET("ReviewCount")
                        End If
                        rdrGET.Close()
                    End If
                Catch ex As Exception
                    lblError.Visible = True
                    lblError.Text = "Insert Query Error: " & ex.ToString
                Finally
                    cnPT.Close()
                End Try
            End If

            If (pCount > 0 Or rCount > 0) And (txtUserName.Text <> lblUsername.Text Or ddlUserType.SelectedValue <> lblType.Text) Then

                If txtUserName.Text <> lblUsername.Text Then
                    rfvUserName.IsValid = False
                    rfvUserName.ErrorMessage = "*Modifying this username is restricted. This username has files attached to it."
                ElseIf ddlUserType.SelectedValue <> lblType.Text Then
                    lblTypeError.Visible = True
                    lblTypeError.Text = "*Modifying this user's type is restricted. This user's type has files attached to it."
                End If

            Else

                Dim sqlUpdate As String

                sqlUpdate = "UPDATE [User] SET Type='" & ddlUserType.SelectedValue & "', FirstName='" & txtFirstName.Text & "', MiddleInitial='" & txtMiddleInitial.Text & "', LastName='" & txtLastName.Text & "', Username='" & txtUserName.Text & "', Password='" & txtPassword.Text & "' Where UserID= " & lblUserID.Text

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
                    Response.Redirect("User.aspx")
                End If

            End If

            End If

    End Sub
End Class