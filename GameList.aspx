﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="GameList.aspx.cs" Inherits="Project_Game_Portal.GameList" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="container">
        <div>
            <h1>Oyunlar</h1>
        </div>
        <div class="product-container">
            <asp:Repeater ID="GameDataList" runat="server">
                <ItemTemplate>
                    <div class="product">
                        <img class="card-img-top img-thumbnail" src="Assets/gameimage.jpg" alt="Card image cap">
                        <asp:Label ID="txtGameName" runat="server" Text='<%# Eval("GameName") %>'></asp:Label>
                        <div class="description">
                            <p class="card-text"><%#Eval("GameDescription") %></p>
                        </div>
                        <br />
                        <p class="card-text">Oyun ID:<%#Eval("GameID")%></i></p>
                        <p class="card-text">Yayıncı: <%#Eval("PublisherName") %></p>
                        <p class="card-text">Oyun Türü: <%#Eval("GameTypeName") %></p>
                        <p class="card-text">Oyun Platformu: <%#Eval("GamePlatform") %></p>
                        <p class="card-text">Fiyat: <%#Eval("GamePrice") %> TL</p>
                        <asp:Button CssClass="btn btn-custom btn-primary btn-block" ID="btnBuy" OnClick="btnBuy_Click" runat="server" Text="Satın Al" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
