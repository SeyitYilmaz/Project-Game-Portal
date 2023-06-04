<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="GameList.aspx.cs" Inherits="Project_Game_Portal.GameList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="card-group">
        <asp:DataList ID="GameDataList" runat="server"
            CellPadding="10"
            CellSpacing="5"
            RepeatColumns="3"
            GridLines="Both"
            ShowHeader="False">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <div class="card">
                    <img class="card-img-top img-thumbnail" src="Assets/gameimage.jpg" alt="Card image cap">
                    <div class="card-body flex-fill">
                        <h5 class="card-title"><%#Eval("GameName") %></h5>
                        <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                        <p class="card-text">Yayıncı: <%#Eval("PublisherName") %></p>
                        <p class="card-text">Oyun Türü: <%#Eval("GameTypeName") %></p>
                        <p class="card-text">Oyun Platformu: <%#Eval("GamePlatform") %></p>
                        <p class="card-text">Fiyat: <%#Eval("GamePrice") %> TL</p>
                        <asp:Button CssClass="btn btn-primary btn-block" ID="btnBuy" runat="server" Text="Satin Al" />
                    </div>
                </div>
            </ItemTemplate>

        </asp:DataList>
        </div>

        <%-- <div class="card-group">
        <asp:DataList ID="GameDataList" runat="server"
            CellPadding="10"
            CellSpacing="5"
            RepeatColumns="4"
            GridLines="Both"
            HorizontalAlign="Right"
            ShowHeader="False">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <div class="card">
                    <img class="card-img-top img-thumbnail" src="Assets/gameimage.jpg" alt="Card image cap">
                    <div class="card-body flex-fill">
                        <h5 class="card-title"><%#Eval("GameName") %></h5>
                        <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                        <p class="card-text">Yayıncı: <%#Eval("GamePublisherID") %></p>
                        <p class="card-text">Oyun Türü: <%#Eval("GameTypeID") %></p>
                        <p class="card-text">Oyun Platformu: <%#Eval("GamePlatformID") %></p>
                        <p class="card-text">Fiyat: <%#Eval("GamePrice") %> TL</p>
                        <asp:Button CssClass="btn btn-primary btn-block" ID="btnBuy" runat="server" Text="Satin Al" />
                    </div>
                </div> --%>
        <%-- <asp:Image ID="ProductImage" CssClass="card-img-top" AlternateText="Product picture" Width="304px" Height="200px"
                ImageUrl="~/Assets/gameimage.jpg"
                runat="server" />
            <hr />

            <asp:Label ID="descriptionLabel" runat="server" Text="Gereksinim:"></asp:Label>
            <br />
            <asp:Label ID="lblDesc" runat="server" Text="Blanc için önerilen sistem gereksinimleri:
İşletim Sistemi: Windows 10
İşlemci: Intel Core i5-4570 veya AMD Ryzen 3 1200
Bellek: 8 GB RAM
Ekran Kartı: NVIDIA GeForce GTX 650 Ti, 2 GB veya AMD Radeon R7 360, 2 GB
Disk Alanı: 2 GB boş alan"></asp:Label>
            <hr />

            <asp:Label ID="Label9" runat="server" Text="Oyun Adı: "></asp:Label>
            <asp:Label ID="lblGameName" runat="server" Text='<%#Eval("GameName") %>'></asp:Label>
            <hr />

            <asp:Label ID="Label2" runat="server" Text="Fiyat: "></asp:Label>
            <asp:Label ID="lblGamePrice" runat="server" Text='<%#Eval("GamePrice") %>'></asp:Label>
            <hr />

            <asp:Label ID="Label3" runat="server" Text="Oyun Türü: "></asp:Label>
            <asp:Label ID="lblGameType" runat="server" Text='<%#Eval("GameTypeID") %>'></asp:Label>
            <hr />

            <asp:Label ID="Label5" runat="server" Text="Yayıncı: "></asp:Label>
            <asp:Label ID="lblPublisher" runat="server" Text='<%#Eval("GamePublisherID") %>'></asp:Label>
            <hr />

            <asp:Label ID="Label7" runat="server" Text="Platform: "></asp:Label>
            <asp:Label ID="lblGamePlatform" runat="server" Text='<%#Eval("GamePlatformID") %>'></asp:Label>
            <hr />

            <asp:Button CssClass="btn btn-primary" ID="btnBuy" runat="server" Text="Satin Al" />
            <br />--%>
</asp:Content>
