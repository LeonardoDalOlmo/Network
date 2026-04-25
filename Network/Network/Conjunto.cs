using System;
using System.Collections.Generic;
using System.Text;

namespace Network
{
    internal class Conjunto
    {

        private List<int>[] conexoes;
        private int elementos;

        public Conjunto(int qtde)
        {
            if (qtde == 0)
            {
                throw new ArgumentException("A quantidade de elementos deve ser maior que zero.");
            }

            elementos = qtde;

            conexoes = new List<int>[qtde + 1];
            for (int i = 1; i <= qtde; i++)
            {
                conexoes[i] = new List<int>();
            }

            Console.WriteLine("Network criada com " + qtde + " elementos.");
        }

        private void ValidarElemento(int elemento)
        {
            if (elemento < 1 || elemento > elementos)
            {
                throw new ArgumentException(elemento + " fora do intervalo permitido");
            }
        }


        public void Conectar(int elemento1, int elemento2)
        {
            try
            {
                ValidarElemento(elemento1);
                ValidarElemento(elemento2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            if (elemento1 == elemento2)
            {
                throw new ArgumentException("Não é possível conectar um elemento a ele mesmo.");
            }

            if (conexoes[elemento1].Contains(elemento2))
            {
                throw new ArgumentException("Elementos já estão conectados.");
            }

            conexoes[elemento1].Add(elemento2);
            conexoes[elemento2].Add(elemento1);

            Console.WriteLine("Elementos " + elemento1 + " e " + elemento2 + " conectados com sucesso");
        }

        public void Desconectar(int elemento1, int elemento2)
        {
            try
            {
                ValidarElemento(elemento1);
                ValidarElemento(elemento2);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            if (elemento1 == elemento2)
            {
                throw new ArgumentException("Não é possível desconectar um elemento de ele mesmo.");
            }

            if (!conexoes[elemento1].Contains(elemento2))
            {
                throw new ArgumentException("Elementos não estão conectados.");
            }

            conexoes[elemento1].Remove(elemento2);
            conexoes[elemento2].Remove(elemento1);

            Console.WriteLine("Elementos " + elemento1 + " e " + elemento2 + " desconectados com sucesso");
        }

        public bool VerificarConexao(int elemento1, int elemento2)
        {
            try
            {
                ValidarElemento(elemento1);
                ValidarElemento(elemento2);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            if (elemento1 == elemento2)
            {
                throw new ArgumentException("Não é possível verificar a conexão de um elemento com ele mesmo.");
            }

            bool[] visitados = new bool[elementos + 1];
            bool resultado = BuscarConexao(elemento1, elemento2, visitados);

            Console.WriteLine("Elementos " + elemento1 + " e " + elemento2 + " estão " + (resultado ? "conectados" : "desconectados"));
            return resultado;
        }

        private bool BuscarConexao(int comeco, int fim, bool[] visitados)
        {
            List<int> fila = new List<int>();
            fila.Add(comeco);
            visitados[comeco] = true;

            while (fila.Count > 0)
            {
                int atual = fila[0];
                fila.RemoveAt(0);

                if (atual == fim)
                {
                    return true;
                }

                foreach (int vizinho in conexoes[atual])
                {
                    if (!visitados[vizinho])
                    {
                        visitados[vizinho] = true;
                        fila.Add(vizinho);
                    }
                }
            }

            return false;
        }

        public int NivelConexao(int elemento1, int elemento2)
        {
            try
            {
                ValidarElemento(elemento1);
                ValidarElemento(elemento2);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            if (elemento1 == elemento2)
            {
                throw new ArgumentException("Não é possível verificar o nível de conexão de um elemento com ele mesmo.");
            }

            int nivel = CalcularNivel(elemento1, elemento2);

            Console.WriteLine("O nível de conexão entre os elementos " + elemento1 + " e " + elemento2 + " é: " + nivel);

            return nivel;

        }

        private int CalcularNivel(int comeco, int fim)
        {
            List<int[]> fila = new List<int[]>();
            bool[] visitados = new bool[elementos + 1];

            fila.Add(new int[] { comeco, 0 });
            visitados[comeco] = true;

            int posicao = 0;

            while (posicao < fila.Count)
            {
                int[] atual = fila[posicao];
                posicao++;

                int elementoAtual = atual[0];
                int distancia = atual[1];

                if (elementoAtual == fim)
                {
                    return distancia;
                }

                foreach (int vizinho in conexoes[elementoAtual])
                {
                    if (!visitados[vizinho])
                    {
                        visitados[vizinho] = true;
                        fila.Add(new int[] { vizinho, distancia + 1 });
                    }
                }

            }

            return 0;

        }
    }
}
