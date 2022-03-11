<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tarea1MichaelMelendez._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_4063" data-image-width="450" data-image-height="300">
        <div class="u-clearfix u-sheet u-sheet-1">
            <h1 class="u-align-center-lg u-align-center-md u-align-center-sm u-align-center-xs u-custom-font u-text u-text-body-color u-text-1">Juego gato</h1>
            <div class="u-list u-list-1">
                <div class="u-repeater u-repeater-1">
                    <div class="u-container-style u-list-item u-repeater-item">
                        <div class="u-container-layout u-similar-container u-container-layout-1">
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-1" ID="position_1" runat="server" OnClick="position_1_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-2" ID="position_4" runat="server" OnClick="position_4_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-3" ID="position_7" runat="server" OnClick="position_7_Click" />
                        </div>
                    </div>
                    <div class="u-align-left u-container-style u-list-item u-repeater-item">
                        <div class="u-container-layout u-similar-container u-container-layout-2">
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-1" ID="position_2" runat="server" OnClick="position_2_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-2" ID="position_5" runat="server" OnClick="position_5_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-3" ID="position_8" runat="server" OnClick="position_8_Click" />
                        </div>
                    </div>
                    <div class="u-container-style u-list-item u-repeater-item">
                        <div class="u-container-layout u-similar-container u-container-layout-3">
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-1" ID="position_3" runat="server" OnClick="position_3_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-2" ID="position_6" runat="server" OnClick="position_6_Click" />
                            <asp:Button class="u-border-2 u-border-black u-btn u-button-style u-hover-black u-none u-text-hover-white u-btn-3" ID="position_9" runat="server" OnClick="position_9_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <h4 class="u-text u-text-2">Seleccion​​e&nbsp;<br>
                una ficha
            </h4>

            <div class="u-container-style u-group u-group-1">
                <div class="u-container-layout">
                    <asp:Button class="u-border-1 u-border-active-palette-2-base u-border-hover-palette-1-base u-btn u-button-style u-none u-text-black u-btn-10"
                        ID="ficha_x" runat="server" Text="X" OnClick="ficha_x_Click" />
                    <asp:Button class="u-border-1 u-border-active-palette-2-base u-border-hover-palette-1-base u-btn u-button-style u-none u-text-black u-btn-11"
                        ID="ficha_o" runat="server" Text="O" OnClick="ficha_o_Click" />
                </div>
            </div>
            <asp:Button class="u-black u-border-none u-btn u-btn-round u-button-style u-hover-custom-color-1 u-radius-28 u-btn-12"
                ID="btn_jugar" runat="server" Text="JUGAR" OnClick="btn_jugar_Click" />


            <img class="u-hidden-sm u-hidden-xs u-image u-image-default u-preserve-proportions u-image-1" src="images/gato.png" alt="" data-image-width="512" data-image-height="512">
            <img class="u-hidden-md u-hidden-sm u-hidden-xs u-image u-image-default u-preserve-proportions u-image-2" src="images/gato.png" alt="" data-image-width="512" data-image-height="512">

            <asp:Label ID="lbl_mensajes" class="u-text u-text-palette-4-dark-1 u-text-3" runat="server" Text=""></asp:Label>

        </div>
    </section>

</asp:Content>
