<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="LordCardShop.Views.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container mt-5">
        <h2>Checkout</h2>
        <asp:Label ID="lblCheckoutMessage" runat="server" CssClass="alert alert-info d-none" />

        <asp:Repeater ID="rptCheckout" runat="server">
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

        <div class="mt-4">
            <h5>Total: <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-success" /></h5>
            <asp:Button ID="btnConfirmCheckout" runat="server" CssClass="btn btn-success mt-2" Text="Confirm Checkout" OnClick="btnConfirmCheckout_Click" />
        </div>
    </section>
</asp:Content>
