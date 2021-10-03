using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BotanapolyAPI.Controllers;
using BotanapolyAPI.Models;
using System.Threading;

namespace BotanapolyVista
{
    public partial class MainWindow : Window
    {
        BotanapolyController controller = new BotanapolyController();
        int idPartida = 3;
        int?[] jugadoresId;
        Color[] conjuntos = new Color[] { Colors.Brown, Colors.Lavender, Colors.DarkViolet, Colors.DarkOrange,
            Colors.DarkKhaki, Colors.DarkRed, Colors.Fuchsia, Colors.Cyan,
            Colors.Black, Colors.Ivory, Colors.LightSteelBlue, Colors.MidnightBlue,
            Colors.YellowGreen};
        Color[] jugadoresColores = new Color[] { Colors.Pink, Colors.Blue, Colors.Yellow, Colors.AntiqueWhite, Colors.Green, Colors.Orange};
        int indexTablero = 0;
        bool controlColor = true;
        IEnumerable<Casilla> casillasRaw;
        WrapPanel[] Tablero;
        Rectangle[][] posicionesJugador;
        Rectangle[][] edificaciones;
        Casilla[] casillas;
        public void checkChanges()
        {
            this.Dispatcher.Invoke(() =>
            {
                while (true)
                {
                    MessageBox.Show("");
                    IEnumerable<Jugador> jugadores = controller.GetJugadores(idPartida);
                    for (int i = 0; i < posicionesJugador.Length; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            posicionesJugador[i][j].Fill = new SolidColorBrush(Colors.Transparent);
                            if(casillas[i].Tipo == 2)
                            {
                                edificaciones[i][j].Fill = new SolidColorBrush(Colors.Gray);
                            }
                        }
                    }
                    foreach (Jugador jugador in jugadores)
                    {
                        IEnumerable<PropiedadesJugador> propiedades = controller.GetPropiedadesJugador(jugador.Id);
                        PropiedadesJugador[] propiedadesArray = propiedades == null ? null : propiedades.ToArray();
                        for (int i = 0; i < jugadoresId.Length; i++)
                        {
                            if (jugadoresId[i] == jugador.Id)
                            {
                                Casilla c = casillasRaw.FirstOrDefault(o => o.Id == jugador.Posicion);
                                posicionesJugador[(int)c.Orden-1][i].Fill = new SolidColorBrush(jugadoresColores[i]);
                                break;
                            }
                        }
                        if (propiedadesArray != null)
                        {
                            for (int i = 0; i < propiedadesArray.Length; i++)
                            {
                                int? nivelEdificacion = propiedadesArray[i].NivelEdificacion;
                                for (int j = 0; j < nivelEdificacion; j++)
                                {
                                    edificaciones[(int)propiedadesArray[i].Id][j].Fill = new SolidColorBrush(Colors.Red);
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        private WrapPanel createCasilla(int column, int row, Grid grid, int direccion)
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = direccion == 1 || direccion == 3 ? Orientation.Horizontal : Orientation.Vertical;
            wrapPanel.FlowDirection = direccion == 2 || direccion == 4 ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            wrapPanel.LayoutTransform = direccion == 1 || direccion == 2 ? new RotateTransform(180) : new RotateTransform(0);
            Rectangle[] posicionesJugadorSingle = new Rectangle[6];
            Rectangle[] edificacionesSingle = new Rectangle[6];
            for (int i = 0; i < 6; i++)
            {
                Rectangle r = new Rectangle();
                edificacionesSingle[i] = r;
                r.Width = 10;
                r.Height = 10;
                if (casillas[indexTablero].Tipo == 2)
                {
                    r.Fill = new SolidColorBrush(Colors.Gray);
                }
                wrapPanel.Children.Add(r);
            }
            edificaciones[indexTablero] = edificacionesSingle;
            for (int i = 0; i < 6; i++)
            {
                Rectangle r = new Rectangle();
                posicionesJugadorSingle[i] = r;
                r.Width = 10;
                r.Height = 10;
                wrapPanel.Children.Add(r);
            }
            posicionesJugador[indexTablero] = posicionesJugadorSingle;
            if (casillas[indexTablero].Tipo >= 2 && casillas[indexTablero].Tipo <= 5)
            {
                Rectangle r = new Rectangle();
                r.Width = direccion == 1 || direccion == 3 ? 60 : 5;
                r.Height = direccion == 1 || direccion == 3 ? 5 : 60;
                r.Fill = new SolidColorBrush(conjuntos[(int)casillas[indexTablero].Conjunto]);
                wrapPanel.Children.Add(r);
            }
            Label label = new Label();
            label.Content = casillas[indexTablero].Orden;
            switch (casillas[indexTablero].Tipo)
            {
                case 1:
                    wrapPanel.Background = new SolidColorBrush(Colors.DarkSalmon);
                    break;
                case 2:
                    wrapPanel.Background = new SolidColorBrush(Colors.White);
                    break;
                case 3:
                    wrapPanel.Background = new SolidColorBrush(Colors.DarkOrchid);
                    break;
                case 4:
                    wrapPanel.Background = new SolidColorBrush(Colors.LightGray);
                    break;
                case 5:
                    wrapPanel.Background = new SolidColorBrush(Colors.Aquamarine);
                    break;
                case 6:
                    wrapPanel.Background = new SolidColorBrush(Colors.Bisque);
                    break;
                case 7:
                    wrapPanel.Background = new SolidColorBrush(Colors.OliveDrab);
                    break;
                case 8:
                    wrapPanel.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    break;
            }
            wrapPanel.Children.Add(label);
            Grid.SetRow(wrapPanel, row);
            Grid.SetColumn(wrapPanel, column);
            grid.Children.Add(wrapPanel);
            controlColor = !controlColor;
            return wrapPanel;
        }
        private Grid createGrid(int largo_ancho)
        {
            int tamanhoCelda = 60;

            Grid grid = new Grid();

            grid.Width = largo_ancho * tamanhoCelda;
            grid.Height = largo_ancho * tamanhoCelda;

            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;

            grid.Background = new SolidColorBrush(Colors.DarkTurquoise);

            for (int i = 0; i < largo_ancho; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(tamanhoCelda);
                grid.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i < largo_ancho; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(tamanhoCelda);
                grid.RowDefinitions.Add(row);
            }

            indexTablero = 0;

            for(int i = 0; i < largo_ancho; i++)
            {
                Tablero[indexTablero] = createCasilla(i, 0, grid, 1);
                indexTablero++;
            }

            for (int i = 1; i < largo_ancho; i++)
            {
                Tablero[indexTablero] = createCasilla(11, i, grid, 2);
                indexTablero++;
            }

            for (int i = largo_ancho-2; i >= 0; i--)
            {
                Tablero[indexTablero] = createCasilla(i, 11, grid, 3);
                indexTablero++;
            }

            for (int i = largo_ancho - 2; i > 0; i--)
            {
                Tablero[indexTablero] = createCasilla(0, i, grid, 4);
                indexTablero++;
            }

            return grid;
        }
        public MainWindow()
        {
            InitializeComponent();
            Partida partida = controller.ObtenerDatosPartida(idPartida);
            IEnumerable<Jugador> jugadores = controller.GetJugadores(idPartida);
            List<Jugador> jugadoresOrdenados = jugadores.OrderBy(x => x.Orden).ToList();
            foreach(Jugador jugador in jugadoresOrdenados)
            {
                if (jugador.Orden == 0) jugadoresOrdenados.Remove(jugador);
                else break;
            }
            jugadoresId = new int?[jugadoresOrdenados.Count];
            for(int i = 0; i < jugadoresOrdenados.Count; i++)
            {
                jugadoresId[i] = jugadoresOrdenados[i].Id;
            }
            casillasRaw = controller.GetTablero(partida.Tablero);
            this.casillas = casillasRaw.OrderBy(x => x.Orden).ToArray();
            this.Tablero = new WrapPanel[this.casillas.Length];
            this.posicionesJugador = new Rectangle[40][];
            this.edificaciones = new Rectangle[40][];
            int alto_ancho = casillas.Length / 4 + 1;
            this.Width = alto_ancho * 60 + 100;
            this.Height = alto_ancho * 60 + 100;
            this.Background = new SolidColorBrush(Colors.DarkTurquoise); ;
            this.Content = createGrid(alto_ancho);
            Thread thread = new Thread(new ThreadStart(checkChanges));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
