namespace Ajedrez.GameObjects
{
    enum ColorCasilla {Blanco,Negro}
    class Casilla
    {
        public int Id { set; get; }
        public ColorCasilla Color { set; get; }
        public string Fila { set; get; }
        public int Columna { set; get; }
        public static Pieza PiezaContenida { get; set; }
    }
}
