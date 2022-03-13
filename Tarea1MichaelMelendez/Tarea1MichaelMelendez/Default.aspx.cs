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
        //Variable para crear las cookies que almacenan informacion
        HttpCookie info = new HttpCookie("Info");
        //Variable para generar numeros aleatorios
        Random random = new Random();
        /// <summary>
        /// Metodo principal para cuando se realiza una accion dentro de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se valida para que solo se ejecute al iniciar la aplicacion
            if (!IsPostBack)
            {
                //limpia las cookies que puedan existir 
                if (Request.Cookies["Info"] != null)
                {
                    Response.Cookies["Info"].Expires = DateTime.Now.AddDays(-1);
                }
            }

        }

        #region "Eventos onclick matrix juego"
        /// <summary>
        /// Metodo onclik del boton de la posicion 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_1_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(1);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_2_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(2);
        }

        /// <summary>
        /// Metodo onclik del boton de la posicion 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_3_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(3);
        }

        /// <summary>
        /// Metodo onclik del boton de la posicion 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_4_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(4);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_5_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(5);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_6_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(6);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_7_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(7);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_8_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(8);
        }
        /// <summary>
        /// Metodo onclik del boton de la posicion 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void position_9_Click(object sender, EventArgs e)
        {
            //Valida y escribe la ficha en la posicion seleccionada por el jugador
            escribirFichaJugadorMaquina(9);
        }

        #endregion

        #region "Eventos onclick determinar ficha"
        /// <summary>
        /// Metodo para seleccionar la ficha X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ficha_x_Click(object sender, EventArgs e)
        {
            //Se crean las variables y se almacenan en cookies para la ejecucion del juego
            info["fichaJugador"] = "X";
            info["fichaMaquina"] = "O";
            info.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(info);
            //Se indica al usuario la ficha seleccionada
            lbl_mensajes.Text = "La ficha seleccionada fue X";
        }
        /// <summary>
        /// Metodo para seleccionar la ficha O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ficha_o_Click(object sender, EventArgs e)
        {
            //Se crean las variables y se almacenan en cookies para la ejecucion del juego
            info["fichaJugador"] = "O";
            info["fichaMaquina"] = "X";
            info.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(info);
            //Se indica al usuario la ficha seleccionada
            lbl_mensajes.Text = "La ficha seleccionada fue O";
        }

        #endregion

        #region "Evento onclick boton jugar"
        /// <summary>
        /// Metodo para dar inicio al juego o reiniciar el juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_jugar_Click(object sender, EventArgs e)
        {
            //Variable para obtener el valor de las cookies
            HttpCookie reqCookies = Request.Cookies["Info"];
            //Valida si es la accion de jugar
            if (btn_jugar.Text.ToString().ToUpper().Equals("JUGAR"))
            {
                //Valida que existan cookies
                if (reqCookies != null)
                {
                    //Valida que las cookies no esten vacias
                    if (!reqCookies["fichaJugador"].ToString().Equals("") && !reqCookies["fichaMaquina"].ToString().Equals(""))
                    {
                        //Genera un numero random para obtener la ficha que inicia el juego
                        int ficha = random.Next(1, 50);
                        string fichaInicial = ficha > 1 && ficha < 25 ? reqCookies["fichaJugador"].ToString() : reqCookies["fichaMaquina"].ToString();
                        //Inidica en pantalla la ficha que inicia el juegi
                        lbl_mensajes.Text = "Juego iniciado, inicia la ficha " + fichaInicial;
                        //Si la ficha es mayor a 25 el juego inicia por la maquina
                        if (ficha > 25)
                        {
                            //Se genera una posicion aleatoria para escribir en la matrix del juego
                            int posicionRandom = random.Next(1, 9);
                            //Escribe la primer jugada en la posicion obtenida anteriormente
                            escribirPosicionGrid(posicionRandom, fichaInicial);
                        }
                    }
                    else
                    {
                        //Mensaje de validacion
                        lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
                    }
                }
                else
                {
                    //Mensaje de validacion
                    lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
                }
            }
            else
            {
                //Limpia el juego para una nueva partida
                limpiar();
            }
        }

        #endregion

        #region "Metodos logica del juego"
        /// <summary>
        /// Metodo que permite escribir una posicion en pantalla segun la posicion y ficha indicada
        /// </summary>
        /// <param name="posicion">Posicion que debe escribir</param>
        /// <param name="ficha">Ficha que debe escribir</param>
        /// <returns></returns>
        private bool escribirPosicionGrid(int posicion, string ficha)
        {
            //Variable de control
            bool flag = false;
            //Busca la posicion, valida si no se encuentra utiliazada y escribe la ficha, 
            //si se encontrara ya seleccionada se indica un mensaje al jugador
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
        /// <summary>
        /// Metodo que permite determinar la posicion para la jugada de la maquina
        /// </summary>
        /// <param name="posicion"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que permite escribir las fichas segun la posicion indicada
        /// </summary>
        /// <param name="posicionJudador">numero de la posicion</param>
        /// <returns></returns>
        private bool escribirFichaJugadorMaquina(int posicionJudador)
        {
            //Variable que permite obtener las cookies
            HttpCookie reqCookies = Request.Cookies["Info"];
            bool flag = false;
            //Valida que existan cookies
            if (reqCookies != null)
            {
                //Escribe la posicion
                bool flag2 = escribirPosicionGrid(posicionJudador, reqCookies["fichaJugador"].ToString());
                //Verifica si existe algun ganador
                flag = obtenerGanador();
                //Si no existe ganador escribe la posicion de la maquina
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
                //Verifica nuevamente si existe un ganador
                obtenerGanador();

            }
            else
            {
                //Mensaje de validacion
                lbl_mensajes.Text = "Debe seleccionar una ficha antes de iniciar el juego";
            }

            return flag;
        }

        /// <summary>
        /// Metodo que permite obtener todas las posiciones asociadas a una ficha
        /// </summary>
        /// <param name="ficha">valor de ficha</param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que valida las posiciones en la matriz para identificar si existe algun ganador
        /// </summary>
        /// <returns></returns>
        private bool obtenerGanador()
        {
            HttpCookie reqCookies = Request.Cookies["Info"];
            List<int> posicionesJugador = obtenerPosicionesXFicha(reqCookies["fichaJugador"].ToString());
            List<int> posicionesMaquina = obtenerPosicionesXFicha(reqCookies["fichaMaquina"].ToString());
            bool flag = verificarGanador(posicionesJugador, reqCookies["fichaJugador"].ToString());

            bool flag2 = verificarGanador(posicionesMaquina, reqCookies["fichaMaquina"].ToString());

            return flag || flag2;
        }
        /// <summary>
        /// Metodo que verifica un ganador y cambia el estilo de la matriz para indicarlo
        /// </summary>
        /// <param name="listaPosciones"></param>
        /// <param name="ficha"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que permite reiniciar el juego
        /// </summary>
        private void limpiar()
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        #endregion
    }
}