using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

internal class Program
{
    public static void Main(string[] args)
    {
        Conjunto conj = new Conjunto(10);
        conj.Conectar(1, 2);
        conj.Conectar(2, 8);
        conj.Conectar(8, 4);
        conj.Conectar(4, 5);

        Console.WriteLine(conj.VerificarConexao(1, 2));
        Console.WriteLine(conj.VerificarConexao(1, 8));
        Console.WriteLine(conj.VerificarConexao(1, 5));

        conj.Desconectar(8, 4);
        Console.WriteLine(conj.VerificarConexao(1, 5));

        Console.WriteLine(conj.NivelConexao(1, 2));
        Console.WriteLine(conj.NivelConexao(1, 8));
        Console.WriteLine(conj.NivelConexao(1, 5));
    }
}