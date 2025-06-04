<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LordCardShop.Views.Customer.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container mt-5">
        <h2>Your Cart</h2>
        <asp:Label ID="lblCartMessage" runat="server" CssClass="alert alert-info d-none" />

        <asp:Repeater ID="rptCart" runat="server">
            <HeaderTemplate>
                <div class="row fw-bold border-bottom pb-2 mb-2">
                    <div class="col-md-4">Card Name</div>
                    <div class="col-md-2">Price</div>
                    <div class="col-md-4">Description</div>
                    <div class="col-md-2">Quantity</div>
                    <div class="col-md-2">Action</div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="row mb-2">
                    <div class="col-md-4"><%# Eval("CardName") %></div>
                    <div class="col-md-2">Rp <%# Eval("CardPrice") %></div>
                    <div class="col-md-4"><%# Eval("CardType") %></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" Text='<%# Eval("Quantity") %>' Enabled="false" />
                    </div>
                    <div class="col-md-2">
                        <!-- Tombol untuk menambah quantity -->
                        <asp:Button ID="btnIncreaseQuantity" runat="server" Text="Increase" CssClass="btn btn-sm btn-success" OnClick="btnUpdateQuantity_Click" CommandArgument="increase" />
                        <!-- Tombol untuk mengurangi quantity -->
                        <asp:Button ID="btnDecreaseQuantity" runat="server" Text="Decrease" CssClass="btn btn-sm btn-warning" OnClick="btnUpdateQuantity_Click" CommandArgument="decrease" />
                        <!-- Tombol untuk menghapus item -->
                        <asp:Button ID="btnRemoveCard" runat="server" Text="Remove" CssClass="btn btn-sm btn-danger" OnClick="btnRemoveCard_Click" />
                    </div>
                    <!-- Menambahkan Label untuk CartID dan CardID yang tersembunyi -->
                    <asp:Label ID="lblCartID" runat="server" Text='<%# Eval("CartID") %>' Visible="false" />
                    <asp:Label ID="lblCardID" runat="server" Text='<%# Eval("CardID") %>' Visible="false" />
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="d-flex justify-content-between mt-4">
            <asp:Button ID="btnCheckout" runat="server" CssClass="btn btn-primary" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />
            <asp:Button ID="btnClearCart" runat="server" CssClass="btn btn-danger" Text="Clear Cart" OnClick="btnClearCart_Click" />
        </div>
    </section>
</asp:Content>
