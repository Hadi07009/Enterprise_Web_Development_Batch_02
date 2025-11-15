<%@ Page Title="" Language="C#" MasterPageFile="~/HRSite.Master" AutoEventWireup="true" CodeBehind="EmployeeInformation.aspx.cs" Inherits="HR.UI.EmployeeInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">
    <tr>
        <td style="height: 26px; width: 149px">
            <asp:Label ID="Label1" runat="server" Text="Employee Name:"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
        </td>
        <td style="height: 26px"></td>
    </tr>
    <tr>
        <td style="height: 26px; width: 149px">
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
        <td style="height: 26px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 26px; width: 149px">
            <asp:Label ID="Label2" runat="server" Text="Mobile Number:"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
        </td>
        <td style="height: 26px"></td>
    </tr>
        <tr style="visibility:hidden">
        <td style="height: 26px; width: 149px">
            <asp:Label ID="Label4" runat="server" Text="ID:"></asp:Label></td>
        <td style="height: 26px">
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox></td>
        <td style="height: 26px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 26px; width: 149px">&nbsp;</td>
        <td style="height: 26px">
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:button runat="server" text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="False" />
        </td>
        <td style="height: 26px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 26px; width: 149px">&nbsp;</td>
        <td style="height: 26px">&nbsp;</td>
        <td style="height: 26px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 26px; " colspan="3">
            <asp:GridView ID="grdEmployee" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowCommand="grdEmployee_RowCommand" OnRowDeleting="grdEmployee_RowDeleting">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeName"  runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile No">
                        <ItemTemplate>
                            <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style="width: 149px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

</asp:Content>
