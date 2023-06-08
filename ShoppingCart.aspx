<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Project_Game_Portal.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <h1>Sepetim</h1>
                <asp:Repeater ID="cartRepeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Cart ID</th>
                                    <th>Oyun ID</th>
                                    <th>Oyun Adı</th>
                                    <th>Oyun Fiyatı</th>
                                    <th>Sil</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td id="CartID" runat="server"><%# Eval("CartID") %></td>
                            <td id="CartGameID" runat="server"><%# Eval("CartGameID") %></td>
                            <td><%# Eval("GameName") %></td>
                            <td><%# Eval("GamePrice") %></td>
                            <td>
                                <asp:Button CssClass="btn btn-danger btn-block" ID="btnSil" runat="server" OnClick="btnSil_Click" Text="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-4">
                <h2>Toplam Fiyat: <span id="totalPriceText" runat="server"></span></h2>
                <asp:Button CssClass="btn btn-success btn-block" ID="btnSiparisTamamla" runat="server" Text="Siparişi Tamamla" OnClick="btnSiparisTamamla_Click" />
            </div>
        </div>
    </div>
</asp:Content>
