<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master"
    AutoEventWireup="true" CodeBehind="ListGame.aspx.cs"
    Inherits="Project_Game_Portal.ListGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <asp:DataList ID="GameDataList" runat="server"
        BorderColor="Black"
        CellPadding="10"
        CellSpacing="5"
        RepeatColumns="3" 
        GridLines="Both"
        BorderWidth="1px"
        HorizontalAlign="Right" ShowHeader="False">

        <HeaderStyle BackColor="#aaaadd"></HeaderStyle>

        <AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>

        <HeaderTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </HeaderTemplate>

        <ItemTemplate>

            <asp:Image ID="ProductImage" AlternateText="Product picture" Width="304px" Height="200px"
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
            <br />
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>
