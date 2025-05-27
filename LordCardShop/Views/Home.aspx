<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LordCardShop.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container container-fluid mt-5">
        <h1>Hi, <asp:Label ID="lblUsername" runat="server" /></h1>
        <h3>Welcome to Lord Card Shop</h3>
        <p>Explore our wide selection of cards and more!</p>
    </section>
</asp:Content>
