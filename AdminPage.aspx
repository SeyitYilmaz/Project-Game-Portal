<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project_Game_Portal.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <h1>Veriler</h1>
        <asp:Repeater ID="gameRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Oyun ID</th>
                            <th>Oyun Adı</th>
                            <th>Oyun Fiyatı</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("GameID") %></td>
                    <td id="GameName" runat="server"><%# Eval("GameName") %></td>
                    <td><%# Eval("GamePrice") %>TL</td>
                    <td>
                        <asp:Button CssClass="btn btn-warning btn-block" ID="btnDuzenle" runat="server" Text="Düzenle" OnClick="btnDuzenle_Click"/></td>
                    <td>
                        <asp:Button CssClass="btn btn-danger btn-block" ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
