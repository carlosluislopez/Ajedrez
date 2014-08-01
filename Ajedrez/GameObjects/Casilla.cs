namespace Ajedrez.GameObjects
{
    enum ColorCasilla {Blanco,Negro}
    class Casilla
    {
        public int Id { set; get; }
        public ColorCasilla Color { set; get; }
        public int Fila { set; get; }
        public int Columna { set; get; }
        public Pieza PiezaContenida { get; set; }
    }
}
