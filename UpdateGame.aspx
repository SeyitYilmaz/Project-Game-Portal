<%@ Page Title="" Language="C#" MasterPageFile="~/_LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="UpdateGame.aspx.cs" Inherits="Project_Game_Portal.UpdateGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Layout" runat="server">
    <div class="row m-4">
        <div class="col-md-6 col-md-offset-3 mx-auto">
            <h1 class="text-center">Oyun Ekle</h1>
            <div class="form-group">
                <label for="txtGameName">Oyun Adı:</label>
                <input type="text" class="form-control" id="txtName" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtGameGenre">Oyun Türü:</label>
                <asp:DropDownList ID="drpGameType" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtGamePublisher">Oyun Yayıncısı:</label>
                <asp:DropDownList ID="drpGamePublisher" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtGamePrice">Oyun Fiyatı:</label>
                <input type="number" class="form-control" id="txtGamePrice" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtGamePlatform">Oyun Platformu:</label>
                <asp:DropDownList ID="drpGamePlatform" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="text-center">
                <asp:Button ID="btnUpdateGame" runat="server" Text="Düzenle" OnClick="btnUpdateGame_Click" CssClass="btn btn-warning" />
            </div>
        </div>
    </div>
</asp:Content>
