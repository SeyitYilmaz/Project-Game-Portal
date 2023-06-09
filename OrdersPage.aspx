<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="OrdersPage.aspx.cs" Inherits="Project_Game_Portal.OrdersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <div>
            <h1>Siparişler</h1>
        </div>
        <div class="product-container">
            <asp:Repeater ID="GameDataList" runat="server">
                <ItemTemplate>
                    <div class="product">
                        <h4>Sipariş ID:<asp:Label ID="txtGameName" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label></h4> 
                        <br />
                        <p class="card-text">Oyun Adı:<%#Eval("GameName")%></p>
                        <p class="card-text">Kullanıcı Mail:<%#Eval("UserMail")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
