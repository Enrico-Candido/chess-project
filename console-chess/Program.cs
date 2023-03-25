using tabuleiro;
using xadrez;

namespace console_chess {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 4));
            tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(4, 5));

            Tela.imprimirTabuleiro(tab);
        }
    }
}