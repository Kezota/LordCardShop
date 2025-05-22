<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="LordCardShop.Views.CardDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Card Detail</h2>

        <!-- Alert Section -->
        <asp:Panel ID="AlertPanel" runat="server" CssClass="alert d-none" role="alert">
            <asp:Label ID="AlertMessage" runat="server" />
        </asp:Panel>

        <div class="card shadow p-4">
            <div class="card-body">
                <h3 class="card-title">
                    <asp:Label ID="CardNameLabel" runat="server" />
                </h3>
                <p class="card-text">
                    <strong>Price:</strong>
                    <asp:Label ID="CardPriceLabel" runat="server" />
                </p>
                <p class="card-text">
                    <strong>Description:</strong>
                    <asp:Label ID="CardDescLabel" runat="server" />
                </p>
                <p class="card-text">
                    <strong>Type:</strong>
                    <asp:Label ID="CardTypeLabel" runat="server" />
                </p>
                <p class="card-text">
                    <strong>Foil:</strong>
                    <asp:Label ID="CardFoilLabel" runat="server" />
                </p>

                <asp:Button ID="BackButton" runat="server" Text="Back to Order" CssClass="btn btn-secondary mt-3" OnClick="BackButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
