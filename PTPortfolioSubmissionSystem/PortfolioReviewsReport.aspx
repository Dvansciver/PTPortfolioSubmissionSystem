<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PortfolioReviewsReport.aspx.vb" Inherits="PTPortfolioSubmissionSystem.PortfolioReviewsReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Portfolio Reviews Report" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Candidate:" ></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblCandidate" ForeColor="Black" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
       <asp:TableCell> 
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Review Stage:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblReviewStage" Font-Size="Large" ForeColor="Black"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell> 
            <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Portfolio Submitted:"></asp:Label>&nbsp;
            <asp:Label runat="server" ID="lblPostDate" Font-Size="Large" ForeColor="Black"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
<asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdReviews" EmptyDataText="No reviewers have been assigned to this portfolio!" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-Font-Bold="true" runat="server" DataSourceID="SqlReviews" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="Reviewer" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" SortExpression="Reviewer" DataField="Reviewer" />
                    <asp:BoundField HeaderText="Review Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Type" SortExpression="Type"/>
                    <asp:TemplateField HeaderText="Review Submitted" SortExpression="ReviewDate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblReviewDate" Text='<%# Eval("ReviewDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlReviews" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select r.ReviewID, r.UserID, r.PortfolioID, r.PostDate as ReviewDate, u.UserID, u.Type, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer From Review r inner join [User] u on r.UserID=u.UserID where r.PortfolioID=@PID order by Reviewer" >
            <SelectParameters>
            <asp:ControlParameter ControlID="lblPortfolioID" Name="PID" />
            </SelectParameters>
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnBack" Text="Back" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblPortfolioID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
</asp:Content>
