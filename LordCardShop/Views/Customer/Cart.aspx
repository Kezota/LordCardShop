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
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="row mb-2">
                    <div class="col-md-4"><%# Eval("CardName") %></div>
                    <div class="col-md-2">Rp <%# Eval("CardPrice") %></div>
                    <div class="col-md-4"><%# Eval("CardType") %></div>
                    <div class="col-md-2"><%# Eval("Quantity") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Button ID="btnCheckout" runat="server" CssClass="btn btn-primary mt-4" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />
    </section>
</asp:Content>
