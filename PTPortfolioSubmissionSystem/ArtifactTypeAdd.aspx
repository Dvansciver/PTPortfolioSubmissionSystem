<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactTypeAdd.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactTypeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain">
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label runat="server" Text="Add Artifact Type" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label runat="server" Font-Bold="true" ForeColor="Black" Text="Artifact Type:"></asp:Label>&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:textbox runat="server" ID="txtArtifactType" ></asp:textbox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button runat="server" ID="btnAdd" Text="Submit" />&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
</asp:Content>
