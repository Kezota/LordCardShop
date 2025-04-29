<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="LordCardShop.Views.OrderCardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Order Your Card</h2>

        <!-- Alert Section -->
        <asp:Panel ID="AlertPanel" runat="server" CssClass="alert d-none" role="alert">
            <asp:Label ID="AlertMessage" runat="server" />
        </asp:Panel>

        <div class="row">
            <asp:Repeater ID="CardRepeater" runat="server" OnItemCommand="CardRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card shadow-sm">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("CardName") %></h5>
                                <p class="card-text">Price: $<%# Eval("CardPrice") %></p>
                                <div class="d-flex justify-content-between">
                                    <asp:Button ID="BtnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary" CommandName="AddToCart" CommandArgument='<%# Eval("CardID") %>' />
                                    <asp:Button ID="BtnDetail" runat="server" Text="Detail" CssClass="btn btn-secondary" CommandName="ViewDetail" CommandArgument='<%# Eval("CardID") %>' />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
