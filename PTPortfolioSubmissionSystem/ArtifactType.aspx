<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArtifactType.aspx.vb" Inherits="PTPortfolioSubmissionSystem.ArtifactType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Artifact Types" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnAdd" Text="Add Artifact Type" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdArtifactTypes" runat="server" DataSourceID="SqlArtifactTypes" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Modify" DataNavigateUrlFields="ArtifactTypeID" DataNavigateUrlFormatString="ArtifactTypeModify.aspx?ArtifactTypeID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="10%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="ArtifactTypeID" DataNavigateUrlFormatString="ArtifactTypeDelete.aspx?ArtifactTypeID={0}" />
                    <asp:BoundField HeaderText="Artifact Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" SortExpression="Type" DataField="Type" />
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlArtifactTypes" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select ArtifactTypeID, Type From ArtifactType order by Type" >
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
</asp:Content>
