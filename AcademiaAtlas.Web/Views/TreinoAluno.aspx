<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TreinoAluno.aspx.cs" Inherits="AcademiaAtlas.Web.Views.TreinoAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecalho" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Panel runat="server" CssClass="conteudo">
        <asp:Panel runat="server" class="camada-1">
            <h2>Treinos</h2>
            <asp:Panel runat="server" class="camada-2">

               <asp:Panel runat="server" CssClass="divCamposCadatro margin-top10px" Width="99.5%">

                   <asp:Panel runat="server" ID="pnlLabelInicio" CssClass="RelatorioPesquisa">
                       <asp:Label runat="server"  Text="De" Width="30px"/>
                       <asp:TextBox runat="server" TextMode="Date" ID="txtDaInicio"/>
                   </asp:Panel>

                   <asp:Panel runat="server" ID="pnlLabelFim" CssClass="RelatorioPesquisa">
                       <asp:Label runat="server" Text="Até" Width="40px"/>
                       <asp:TextBox runat="server" TextMode="Date" ID="txtDataFim" />
                   </asp:Panel>

                   <asp:Panel runat="server" ID="Panel1" CssClass="RelatorioPesquisa">
                       <asp:Button runat="server" ID="btnGerarRelatorio" Text="Gerar Relatorio" OnClick="btnGerarRelatorio_Click" />
                   </asp:Panel>
                   <div style="clear:both"></div>
               </asp:Panel>

                    <asp:GridView ID="grvRelatorio" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="IdPagamento"
                    HeaderStyle-CssClass="gvChildHeader" CssClass="fontArial textoCentro padding10px borderNone tdClara" AlternatingRowStyle-CssClass="gvAltRow" RowStyle-HorizontalAlign="Right" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle CssClass="gvAltRow" BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IdPagamento" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" ShowHeader="false">
                            <HeaderStyle CssClass="textoAlinhadoCentro" />
                            <ItemStyle Width="55%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataPagt" HeaderText="Data" ShowHeader="false" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle CssClass="textoAlinhadoCentro" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Valor" HeaderText="Valor R$" ShowHeader="false">
                            <HeaderStyle CssClass="textoAlinhadoCentro" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Desconto" HeaderText="Desconto R$" ShowHeader="false">
                            <HeaderStyle CssClass="textoAlinhadoCentro" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
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
                <asp:Panel runat="server" ID="pnlTotalLiquido" CssClass="relatarioValores">
                    <asp:Panel runat="server" ID="pnlCalculos" CssClass="RelatorioPesquisa">
                        <asp:Label runat="server" Text="Total Liquido R$"/>
                        <asp:TextBox runat="server" ID="txtTotalLiq"/>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlTotal" CssClass="RelatorioPesquisa">
                        <asp:Label runat="server" Text="Total R$"/>
                        <asp:TextBox runat="server" ID="txtTotal"/>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlDesconto" CssClass="RelatorioPesquisa">
                        <asp:Label runat="server" Text="Total Desconto R$"/>
                        <asp:TextBox runat="server" ID="txtDesconto"/>
                    </asp:Panel>
                     <div style="clear:both"></div>
               </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Rodape" runat="server">
</asp:Content>
