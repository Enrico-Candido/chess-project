using tabuleiro;
using xadrez;

namespace console_chess {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.imprimirTabuleiro(partida.tab);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}