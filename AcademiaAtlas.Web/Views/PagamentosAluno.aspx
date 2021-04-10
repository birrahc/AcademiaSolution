<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagamentosAluno.aspx.cs" Inherits="AcademiaAtlas.Web.Views.PagamentosAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecalho" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Panel runat="server" CssClass="conteudo">
        <asp:Panel runat="server" class="camada-1">
            <h2>Pagamentos</h2>
            <asp:Panel runat="server" class="camada-2">
               <asp:Panel runat="server" CssClass="divCamposCadatro">
                   <asp:Label runat="server" ID="txtNome" width="98%"  CssClass="labelCadastro" Font-Bold="True" ForeColor="#333333"/>
                   
               </asp:Panel>
                    <asp:GridView ID="grvPagamentoAluno" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="IdPagamento"
                    HeaderStyle-CssClass="gvChildHeader" CssClass="fontArial textoCentro padding10px borderNone tdClara" AlternatingRowStyle-CssClass="gvAltRow" RowStyle-HorizontalAlign="Right" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle CssClass="gvAltRow" BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IdPagamento" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="DataPagt" HeaderText="Data" ShowHeader="false" />
                        <asp:BoundField DataField="DataInicio" HeaderText="De" ShowHeader="false" />
                        <asp:BoundField DataField="DataFinal" HeaderText="Até" ShowHeader="false" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor R$" ShowHeader="false" />
                        <asp:BoundField DataField="Desconto" HeaderText="Desconto R$" ShowHeader="false" />
                        <asp:BoundField DataField="Observacao" HeaderText="Observação" ShowHeader="false" />
                        <asp:CommandField ButtonType="Image" SelectText="Selecionar" ShowSelectButton="True" SelectImageUrl="~/imagens/olho.png" ControlStyle-Width="30px" ControlStyle-CssClass="largura50px" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle CssClass="gvChildHeader" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Rodape" runat="server">
</asp:Content>
