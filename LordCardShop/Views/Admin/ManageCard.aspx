<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AppLayout.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="LordCardShop.Views.Admin.ManageCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Manage Cards</h2>

        <!-- Alert Section -->
        <asp:Panel ID="AlertPanel" runat="server" CssClass="alert d-none" role="alert">
            <asp:Label ID="AlertMessage" runat="server" />
        </asp:Panel>

        <asp:Button ID="BtnAddCard" runat="server" Text="Add New Card" CssClass="btn btn-success mb-3" OnClick="BtnAddCard_Click" />

        <asp:GridView ID="CardGridView" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="CardGridView_RowCommand" OnRowDataBound="CardGridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CardID" HeaderText="ID" />
                <asp:BoundField DataField="CardName" HeaderText="Name" />
                <asp:BoundField DataField="CardPrice" HeaderText="Price" />
                <asp:BoundField DataField="CardType" HeaderText="Type" />
                <asp:TemplateField HeaderText="Is Foil">
                    <ItemTemplate>
                        <asp:Label ID="lblIsFoil" runat="server" Text='<%# Eval("IsFoil") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="UpdateCard" CommandArgument='<%# Eval("CardID") %>' Text="Update" CssClass="btn btn-primary btn-sm" />
                        <asp:Button ID="BtnDelete" runat="server" CommandName="DeleteCard" CommandArgument='<%# Eval("CardID") %>' Text="Delete" CssClass="btn btn-danger btn-sm ml-2" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
