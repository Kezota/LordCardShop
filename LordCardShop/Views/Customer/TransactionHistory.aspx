<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="LordCardShop.Views.Customer.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Your Transaction History</h2>
        <hr />

        <!-- GridView untuk menampilkan daftar transaksi -->
        <asp:GridView ID="gvTransactionHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-4" OnRowCommand="gvTransactionHistory_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" SortExpression="Subtotal" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <!-- Tombol untuk melihat detail transaksi -->
                        <asp:Button ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("TransactionID") %>' Text="View" CssClass="btn btn-sm btn-info" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- Label untuk menampilkan pesan -->
        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success mt-3 d-none" EnableViewState="false"></asp:Label>
    </div>
</asp:Content>
