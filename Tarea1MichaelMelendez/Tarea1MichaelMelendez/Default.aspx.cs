using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea1MichaelMelendez
{
    public partial class _Default : Page
    {
        HttpCookie info = new HttpCookie("Info");

        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.Cookies["Info"] != null)
                {
                    Response.Cookies["Info"].Expires = DateTime.Now.AddDays(-1);
                }
            }

        }

        protected void position_1_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(1);
        }

        protected void position_2_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(2);
        }

        protected void position_3_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(3);
        }

        protected void position_4_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(4);
        }

        protected void position_5_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(5);
        }

        protected void position_6_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(6);
        }

        protected void position_7_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(7);
        }

        protected void position_8_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(8);
        }

        protected void position_9_Click(object sender, EventArgs e)
        {
            escribirFichaJugadorMaquina(9);
        }

        protected void ficha_x_Click(object sender, EventArgs e)
        {

            info["fichaJugador"] = "X";
            info["fichaMaquina"] = "O";
            info.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(info);
            lbl_mensajes.Text = "La ficha seleccionada fue X";
        }

        protected void ficha_o_Click(object sender, EventArgs e)
        {
            info["fichaJugador"] = "O";
            info["fichaMaquina"] = "X";
            info.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(info);
            lbl_mensajes.Text = "La ficha seleccionada fue O";
        }

        protected void btn_jugar_Click(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["Info"];
            if (btn_jugar.Text.ToString().ToUpper().Equals("JUGAR"))
            {
                if (reqCookies != null)
                {
                    if (!reqCookies["fichaJugador"].ToString().Equals("") && !reqCookies["fichaMaquina"].ToString().Equals(""))
                    {
                        int ficha = random.Next(1, 50);
                        string fichaInicial = ficha > 1 && ficha < 25 ? reqCookies["fichaJugador"].ToString() : reqCookies["fichaMaquina"].ToString();
                        lbl_mensajes.Text = "Juego iniciado, inicia la ficha " + fichaInicial;

                        if (ficha > 25)
                        {
                            int posicionRandom = random.Next(1, 9);
                            escribirPosicionGrid(posicionRandom, fichaInicial);
                        }
                    }
                    else
                    {
                        lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
                    }
                }
                else
                {
                    lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
                }
            }
            else
            {
                limpiar();
            }
        }

        private bool escribirPosicionGrid(int posicion, string ficha)
        {
            bool flag = false;
            switch (posicion)
            {

                case 1:
                    if (position_1.Text.Length < 1)
                        position_1.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 2:
                    if (position_2.Text.Length < 1)
                        position_2.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 3:
                    if (position_3.Text.Length < 1)
                        position_3.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 4:
                    if (position_4.Text.Length < 1)
                        position_4.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 5:
                    if (position_5.Text.Length < 1)
                        position_5.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 6:
                    if (position_6.Text.Length < 1)
                        position_6.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 7:
                    if (position_7.Text.Length < 1)
                        position_7.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 8:
                    if (position_8.Text.Length < 1)
                        position_8.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;
                case 9:
                    if (position_9.Text.Length < 1)
                        position_9.Text = ficha;
                    else
                    {
                        lbl_mensajes.Text = "Posición utilizada, seleccione otra";
                        flag = true;
                    }
                    break;


            }
            return flag;
        }
        private string obtenerValorPosicionMaquina(int posicion)
        {
            switch (posicion)
            {

                case 1:
                    return position_1.Text.ToString();
                case 2:
                    return position_2.Text.ToString();
                case 3:
                    return position_3.Text.ToString();
                case 4:
                    return position_4.Text.ToString();
                case 5:
                    return position_5.Text.ToString();
                case 6:
                    return position_6.Text.ToString();
                case 7:
                    return position_7.Text.ToString();
                case 8:
                    return position_8.Text.ToString();
                case 9:
                    return position_9.Text.ToString();
            }
            return null;
        }

        private bool escribirFichaJugadorMaquina(int posicionJudador)
        {
            HttpCookie reqCookies = Request.Cookies["Info"];
            bool flag = false;
            if (reqCookies != null)
            {

                bool flag2 = escribirPosicionGrid(posicionJudador, reqCookies["fichaJugador"].ToString());

                flag = obtenerGanador();

                if (!flag && !flag2)
                {
                    int posicion = random.Next(1, 9);
                    string valor = obtenerValorPosicionMaquina(posicion);
                    while (valor.Length > 0)
                    {
                        posicion = random.Next(1, 9);
                        valor = obtenerValorPosicionMaquina(posicion);
                    }
                    escribirPosicionGrid(posicion, reqCookies["fichaMaquina"].ToString());
                }

                obtenerGanador();

            }
            else
            {
                lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
            }

            return flag;
        }

        private List<int> obtenerPosicionesXFicha(string ficha)
        {
            List<int> posiciones = new List<int>();

            if (position_1.Text.ToString().Equals(ficha))
                posiciones.Add(1);
            if (position_2.Text.ToString().Equals(ficha))
                posiciones.Add(2);
            if (position_3.Text.ToString().Equals(ficha))
                posiciones.Add(3);
            if (position_4.Text.ToString().Equals(ficha))
                posiciones.Add(4);
            if (position_5.Text.ToString().Equals(ficha))
                posiciones.Add(5);
            if (position_6.Text.ToString().Equals(ficha))
                posiciones.Add(6);
            if (position_7.Text.ToString().Equals(ficha))
                posiciones.Add(7);
            if (position_8.Text.ToString().Equals(ficha))
                posiciones.Add(8);
            if (position_9.Text.ToString().Equals(ficha))
                posiciones.Add(9);

            return posiciones;

        }

        private bool obtenerGanador()
        {
            HttpCookie reqCookies = Request.Cookies["Info"];
            List<int> posicionesJugador = obtenerPosicionesXFicha(reqCookies["fichaJugador"].ToString());
            List<int> posicionesMaquina = obtenerPosicionesXFicha(reqCookies["fichaMaquina"].ToString());
            bool flag = verificarGanador(posicionesJugador, reqCookies["fichaJugador"].ToString());

            bool flag2 = verificarGanador(posicionesMaquina, reqCookies["fichaMaquina"].ToString());

            return flag || flag2;
        }

        private bool verificarGanador(List<int> listaPosciones, string ficha)
        {

            if (listaPosciones.Contains(1) && listaPosciones.Contains(2) && listaPosciones.Contains(3))
            {
                position_1.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-1 u-button-style-ok";
                position_2.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-2 u-button-style-ok";
                position_3.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-3 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(4) && listaPosciones.Contains(5) && listaPosciones.Contains(6))
            {
                position_4.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-4 u-button-style-ok";
                position_5.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-5 u-button-style-ok";
                position_6.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-6 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(7) && listaPosciones.Contains(8) && listaPosciones.Contains(9))
            {
                position_7.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-7 u-button-style-ok";
                position_8.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-8 u-button-style-ok";
                position_9.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-9 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(1) && listaPosciones.Contains(4) && listaPosciones.Contains(7))
            {
                position_1.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-1 u-button-style-ok";
                position_4.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-4 u-button-style-ok";
                position_7.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-7 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(2) && listaPosciones.Contains(5) && listaPosciones.Contains(8))
            {
                position_2.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-2 u-button-style-ok";
                position_5.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-5 u-button-style-ok";
                position_8.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-8 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(3) && listaPosciones.Contains(6) && listaPosciones.Contains(9))
            {
                position_3.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-3 u-button-style-ok";
                position_6.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-6 u-button-style-ok";
                position_9.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-9 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(1) && listaPosciones.Contains(5) && listaPosciones.Contains(9))
            {
                position_1.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-1 u-button-style-ok";
                position_5.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-5 u-button-style-ok";
                position_9.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-9 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }
            if (listaPosciones.Contains(3) && listaPosciones.Contains(5) && listaPosciones.Contains(4))
            {
                position_3.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-3 u-button-style-ok";
                position_5.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-5 u-button-style-ok";
                position_4.CssClass = "u-border-2 u-border-black u-btn u-hover-black u-none u-text-hover-white u-btn-4 u-button-style-ok";
                lbl_mensajes.Text = "El jugador con ficha " + ficha + " ha ganado la partdia";
                btn_jugar.Text = "Limpiar";
                return true;
            }

            return false;
        }

        private void limpiar()
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}