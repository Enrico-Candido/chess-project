using tabuleiro;

namespace xadrez {
    class Peao : Peca {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }
        public override string ToString() {
            return "P";
        }
        private bool existeInimigo(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool livre(Posicao pos) {
            return tab.peca(pos) == null;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                // jogadaespecial en pessant
                if (posicao.linha == 3) {
                    Posicao esquerdaDoPeao = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerdaDoPeao) && existeInimigo(esquerdaDoPeao) && tab.peca(esquerdaDoPeao) == partida.vulneravelEnPassant) {
                        mat[esquerdaDoPeao.linha - 1, esquerdaDoPeao.coluna] = true;
                    }
                    Posicao direitaDoPeao = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direitaDoPeao) && existeInimigo(direitaDoPeao) && tab.peca(direitaDoPeao) == partida.vulneravelEnPassant) {
                        mat[direitaDoPeao.linha - 1, direitaDoPeao.coluna] = true;
                    }
                }
            }
            else {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                // jogadaespecial en pessant
                if (posicao.linha == 4) {
                    Posicao esquerdaDoPeao = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerdaDoPeao) && existeInimigo(esquerdaDoPeao) && tab.peca(esquerdaDoPeao) == partida.vulneravelEnPassant) {
                        mat[esquerdaDoPeao.linha + 1, esquerdaDoPeao.coluna] = true;
                    }
                    Posicao direitaDoPeao = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direitaDoPeao) && existeInimigo(direitaDoPeao) && tab.peca(direitaDoPeao) == partida.vulneravelEnPassant) {
                        mat[direitaDoPeao.linha + 1, direitaDoPeao.coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
