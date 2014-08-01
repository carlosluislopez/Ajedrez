namespace Ajedrez.GameObjects
{
    public enum ColorFicha { Blanco, Negro };
    class Pieza
    {
        public int Id { set; get; }
        public string Tipo { set; get; }
        public ColorFicha Color { set; get; }
    }
}
