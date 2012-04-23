<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Artifact.aspx.vb" Inherits="PTPortfolioSubmissionSystem.Artifact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Artifacts" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnAdd" Text="Add Artifact" />&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Portfolio:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblCandidateName"></asp:Label>&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Review Stage:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblReviewStage"></asp:Label>&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Date Submitted:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblPostDate"></asp:Label>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
     <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdArtifacts" runat="server" DataSourceID="SqlArtifacts" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Modify" DataNavigateUrlFields="PortfolioID, ArtifactID" DataNavigateUrlFormatString="ArtifactModify.aspx?PortfolioID={0}&ArtifactID={1}" />
                    <asp:HyperLinkField ItemStyle-Width="8%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="PortfolioID, ArtifactID" DataNavigateUrlFormatString="ArtifactDelete.aspx?PortfolioID={0}&ArtifactID={1}" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Artifact" ItemStyle-Width="30%" ItemStyle-Font-Bold="true" SortExpression="Artifact">
                        <ItemTemplate> 
                            <asp:HyperLink ID="hlkArtifact" runat="server" Target="_blank" text='<%# Eval("Artifact") %>' NavigateUrl='<%# String.Format("~/Portfolios/{0}{1}/{2}",Eval("Username"),Eval("ReviewStage").Replace(" ", ""),Eval("Artifact")) %>'></asp:HyperLink>
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    <asp:BoundField HeaderText="Artifact Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Type" SortExpression="Type"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlArtifacts" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select a.ArtifactID, a.Artifact, a.ArtifactTypeID, a.PortfolioID, t.ArtifactTypeID, t.Type, p.PortfolioID, p.UserID, p.ReviewStage, u.UserID, u.Username From ((Artifact a inner join ArtifactType t on a.ArtifactTypeID=t.ArtifactTypeID) inner join Portfolio p on a.PortfolioID=p.PortfolioID) inner join [User] u on p.UserID=u.UserID where a.PortfolioID=@PortfolioID order by t.Type" >
            <SelectParameters>
                <asp:ControlParameter ControlID="lblPortfolioID" Name="PortfolioID" />
            </SelectParameters>
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" />&nbsp;
            <asp:Button runat="server" ID="btnBack" Text="Back" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
</asp:Content>
