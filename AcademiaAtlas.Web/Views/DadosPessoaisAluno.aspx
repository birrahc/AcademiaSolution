<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DadosPessoaisAluno.aspx.cs" Inherits="AcademiaAtlas.Web.Views.DadosPessoaisAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecalho" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Panel runat="server" CssClass="conteudo-duplo">
        <asp:Panel runat="server" CssClass="camada-1">
            <h2>Alunos </h2>
            <asp:Panel runat="server" ID="pnlCampo" CssClass="painelSearch">
                <asp:TextBox runat="server" ID="txtSearch" CssClass="txtSearch"/>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlBotao" CssClass="botaoSearch">
                <asp:Button runat="server" ID="btnSearch" Text="Buscar" CssClass="btnSearch" OnClick="btnSearch_Click"/>
            </asp:Panel>
            <asp:Panel runat="server" CssClass="camada-2">
                <div style="overflow-y: scroll; width:100% ; height:95%; margin-top:5px;" >
                <asp:GridView ID="grvAluno" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="IdPessoa"
                    HeaderStyle-CssClass="gvChildHeader" CssClass="fontArial textoCentro padding10px borderNone tdClara" AlternatingRowStyle-CssClass="gvAltRow" RowStyle-HorizontalAlign="Right" OnSelectedIndexChanged="grvAluno_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle CssClass="gvAltRow" BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idPessoa" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="Nome" ShowHeader="false" />
                        <asp:CommandField ButtonType="Image" SelectText="Selecionar" ShowSelectButton="True" SelectImageUrl="~/imagens/olho.png" ControlStyle-Width="30px" ControlStyle-CssClass="largura50px" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle CssClass="gvChildHeader" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle HorizontalAlign="Right" BackColor="#DCDCDC" />
                    <SelectedRowStyle BackColor="#880f14" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
                    </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>

    <asp:Panel runat="server" CssClass="conteudo-duplo">
        <asp:Panel runat="server" ID="pnlDadosPessoais" CssClass="camada-1">
            <h2>Dados Pessoais</h2>
            <asp:Panel runat="server" CssClass="camada-2">
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Nome" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblNome" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Sexo" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblSexo" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Nascimento" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblNascimento" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Idade" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblIdade" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Cpf" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblCpf" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="WhatsApp" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblWhatsApp" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Email" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblEmail" Width="60%"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="marginTop5px">
                    <asp:Label runat="server" Text="Telefone" Width="30%" CssClass="bgcolorRed" Font-Bold="True" ForeColor="White"></asp:Label>
                    <asp:Label runat="server" ID="lblTelefone" Width="60%"></asp:Label>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlLInkButton" CssClass="pnlLinkButtons">
                <asp:LinkButton ID="lnkEditarAluno" runat="server" OnClick="lnkEditarAluno_Onclick" ForeColor="white">Editar</asp:LinkButton>
                <asp:LinkButton ID="lnkPagmentos" runat="server" OnClick="lnkPagmentos_Onclick" ForeColor="white">Pagamentos</asp:LinkButton>
                <asp:LinkButton ID="lnkTreinos" runat="server" OnClick="lnkTreinos_Onclick" ForeColor="white">Treinos</asp:LinkButton>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Rodape" runat="server">
</asp:Content>
