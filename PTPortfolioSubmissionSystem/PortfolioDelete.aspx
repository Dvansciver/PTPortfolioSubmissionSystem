<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PortfolioDelete.aspx.vb" Inherits="PTPortfolioSubmissionSystem.PortfolioDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" ForeColor="Red" Text="Delete Portfolio" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="15%">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Candidate: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" Font-Size="Large" ID="lblCandidate"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Review Stage: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" Font-Size="Large" ID="lblReviewStage"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Due Date: " ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" Font-Size="Large" ID="lblDueDate"></asp:Label>
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
            <asp:Button runat="server" ID="btnDelete" Text="Delete" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="false"></asp:Label>
</asp:Content>
