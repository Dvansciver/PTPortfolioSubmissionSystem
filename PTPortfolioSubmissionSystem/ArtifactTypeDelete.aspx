<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactTypeDelete.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactTypeDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0">
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" ForeColor="Red" Text="Delete Artifact Type" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="10%" HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Artifact Type:"></asp:Label>&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" Font-Size="Large" ID="lblArtifactType"></asp:Label>
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
<asp:Label runat="server" ID="lblArtifactTypeID" Visible="false"></asp:Label>
</asp:Content>
