<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PortfolioModify.aspx.vb" Inherits="PTPortfolioSubmissionSystem.PortfolioModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Modify Portfolio" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="15%">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Candidate: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlCandidates" DataSourceID="sqlCandidates" DataTextField="Candidate" DataValueField="UserID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlCandidates" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select UserID, FirstName + ' ' + MiddleInitial + '. ' + LastName as Candidate, Type From [User] Where Type='Candidate' order by Candidate"></asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Review Stage: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" ID="ddlReviewStage" >
            <asp:ListItem Value="1st" Text="1st" />
            <asp:ListItem Value="2nd" Text="2nd"/>
            <asp:ListItem Value="3rd" Text="3rd"/>
            <asp:ListItem Value="2+1" Text="2+1"/>
            <asp:ListItem Value="Tenure/Promotion" Text="Tenure/Promotion"/>
            <asp:ListItem Value="5 Year Post Tenure" Text="5 Year Post Tenure"/>
            <asp:ListItem Value="Full Professor" Text="Full Professor"/>
            <asp:ListItem Value="5 Year Post Full Professor" Text="5 Year Post Full Professor"/>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Due Date(MM/DD/YYYY): "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txtDueDate" Width="8%"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revDueDate" runat="server" ControlToValidate="txtDueDate" Display="Dynamic" ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$" ForeColor="Red" ErrorMessage="*Invalid Date"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvDueDate" runat="server" ControlToValidate="txtDueDate" Display="Dynamic" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Date Submitted: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" Font-Size="Large" ID="lblPostDate"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnModify" Text="Modify" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnReset" Text="Reset" CausesValidation="false" />&nbsp;
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CausesValidation="false" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
</asp:Content>
