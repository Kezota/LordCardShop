<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="AddCard.aspx.cs" Inherits="LordCardShop.Views.Admin.AddCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Add New Card</h2>

        <!-- Alert Section -->
        <asp:Panel ID="AlertPanel" runat="server" CssClass="alert d-none" role="alert">
            <asp:Label ID="AlertMessage" runat="server" />
        </asp:Panel>

        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Price</label>
            <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Type (Spell/Monster)</label>
            <asp:TextBox ID="TxtType" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Foil (Yes/No)</label>
            <asp:TextBox ID="TxtFoil" runat="server" CssClass="form-control" />
        </div>

        <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-success mt-3" OnClick="BtnInsert_Click" />
        <asp:Button ID="BackButton" runat="server" Text="Back to Cards" CssClass="btn btn-outline-primary mt-3" OnClick="BackButton_Click" />
    </div>
</asp:Content>
