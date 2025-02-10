using tabuleiro;


namespace xadrez
{
    class Torre : Peca
    {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(Posicao.linha, Posicao.coluna); // Aqui copiamos a posição original da peça

            // Para cima
            while (true)
            {
                pos.linha--;  // Move uma casa para cima
                if (!tab.posicaoValida(pos)) break; // Verifica se a posição ainda é válida
                if (tab.peca(pos) != null)
                {
                    mat[pos.linha, pos.coluna] = tab.peca(pos).cor != cor; // Se houver peça, só continua se for de cor oposta
                    break; // Não move mais se encontrar uma peça
                }
                mat[pos.linha, pos.coluna] = true; // Marca como um movimento possível
            }

            pos.definirValores(Posicao.linha, Posicao.coluna); // Reseta posição

            // Para baixo
            while (true)
            {
                pos.linha++; // Move uma casa para baixo
                if (!tab.posicaoValida(pos)) break; // Verifica se a posição ainda é válida
                if (tab.peca(pos) != null)
                {
                    mat[pos.linha, pos.coluna] = tab.peca(pos).cor != cor;
                    break; // Não move mais se encontrar uma peça
                }
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(Posicao.linha, Posicao.coluna);

            // Para direita
            while (true)
            {
                pos.coluna++; // Move uma casa para a direita
                if (!tab.posicaoValida(pos)) break;
                if (tab.peca(pos) != null)
                {
                    mat[pos.linha, pos.coluna] = tab.peca(pos).cor != cor;
                    break;
                }
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(Posicao.linha, Posicao.coluna);

            // Para esquerda
            while (true)
            {
                pos.coluna--; // Move uma casa para a esquerda
                if (!tab.posicaoValida(pos)) break;
                if (tab.peca(pos) != null)
                {
                    mat[pos.linha, pos.coluna] = tab.peca(pos).cor != cor;
                    break;
                }
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
