<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UserModify.aspx.vb" Inherits="PTPortfolioSubmissionSystem.UserModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Modify User" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="8%">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="User Type:"></asp:Label>&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlUserType">
            <asp:ListItem Value="Administrator" Text="Administrator" Selected="true" />
            <asp:ListItem Value="Candidate" Text="Candidate"/>
            <asp:ListItem Value="Classroom Observer" Text="Classroom Observer"/>
            <asp:ListItem Value="Peer Reviewer" Text="Peer Reviewer"/>
            </asp:DropDownList>
            <asp:Label runat="server" ID="lblTypeError" ForeColor="Red" Visible="false"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="First Name: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvFirstName" ControlToValidate="txtFirstName" ValidationGroup="grpUser" ErrorMessage="*Required" ForeColor="Red" />
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label  runat="server" Font-Bold="true" ForeColor="Black" Text="Middle Initial: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtMiddleInitial" MaxLength="1" Width="2%" ></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Last Name: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvLastName" ControlToValidate="txtLastName" ValidationGroup="grpUser" ErrorMessage="*Required" ForeColor="Red" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Username:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtUserName" MaxLength="50" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" ValidationGroup="grpUser" ErrorMessage="*Required" ForeColor="Red" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Password:" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtPassword" MaxLength="50" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ValidationGroup="grpUser" ErrorMessage="*Required" ForeColor="Red" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnModify" Text="Modify" ValidationGroup="grpUser" />&nbsp;  
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnReset" Text="Reset" />&nbsp;
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblType" Visible="false"></asp:Label>
</asp:Content>
