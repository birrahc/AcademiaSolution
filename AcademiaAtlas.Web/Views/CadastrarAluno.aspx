<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarAluno.aspx.cs" Inherits="AcademiaAtlas.Web.Views.CadastrarAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecalho" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Panel runat="server" CssClass="conteudo">
        <asp:Panel runat="server" class="camada-1">
            <h2><asp:Label runat="server" ID="lblTituloCadUpd" Text="Cadastrar Aluno"></asp:Label></h2>
            <asp:Panel runat="server" class="camada-2">
               <asp:Panel runat="server" CssClass="divCamposCadatro">
                   <asp:Label runat="server" Text="Nome" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                   <asp:TextBox runat="server" ID="txbNome" width="65%" CssClass="inputCadastro"/>
               </asp:Panel>
               <asp:Panel runat="server" CssClass="divCamposCadatro">
                   <asp:Label runat="server" ID="pnlNascimento" Text="Nascimento" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                   <asp:TextBox runat="server" ID="txbNascimento" TextMode="Date" CssClass="inputCadastro" Width="160px"/>
                   <asp:Label runat="server" ID="lblSexo" Text="Sexo" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                        <asp:RadioButton ID="Masculino" runat="server" GroupName="grpnSexo" Text="M" />
                        <asp:RadioButton ID="Feminino" runat="server" GroupName="grpnSexo" Text="F" />
                   <asp:Label runat="server" Text="Cpf" width="11%"  CssClass="labelCadastro" Font-Bold="True" />
                   <asp:TextBox runat="server" ID="txbCpf" CssClass="inputCadastro"/>
               </asp:Panel>
              
                <asp:Panel runat="server" CssClass="divCamposCadatro">
                   <asp:Label runat="server" Text="WhatsApp" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                   <asp:TextBox runat="server" ID="txbWhatsApp" CssClass="inputCadastro" Width="130px"/>
                    <asp:Label runat="server" Text="Telefone" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                   <asp:TextBox runat="server" ID="txbTelefone" CssClass="inputCadastro" Width="130px"/>
                    <asp:Label runat="server" Text="Email" width="11%"  CssClass="labelCadastro" Font-Bold="True"/>
                   <asp:TextBox runat="server" ID="txbEmail" CssClass="inputCadastro" Width="280px"/>
               </asp:Panel>
                <asp:Panel runat="server" CssClass="divBotoes" Font-Bold="True">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_OnClick" CssClass="divbutton" Font-Bold="True"/>
                     <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_OnClick" CssClass="divbutton" Font-Bold="True"/>
                     <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_OnClick" CssClass="divbutton" Font-Bold="True"/>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Rodape" runat="server">
</asp:Content>
