<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePage.aspx.cs" Inherits="TestApplication.CreatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <h3>Stack Details</h3>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:HiddenField ID="hfStackId" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFruit" runat="server" Text="Fruit"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfruit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblVariety" runat="server" Text="Variety"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtvariety" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtquantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            &nbsp;<br />
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Fruit" HeaderText="Fruit" />
                    <asp:BoundField DataField="Variety" HeaderText="Variety" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:LinkButton ID="linkview" runat="server" CommandArgument='<%# Eval("StackId") %>' OnClick="gridView_OnClick">view</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField> 
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
