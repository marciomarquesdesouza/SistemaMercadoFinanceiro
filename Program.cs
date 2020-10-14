using System;

namespace SistemaMercadofinanceiro
{
  class Program
  {
    static void Main(string[] args)
    {
      CodigoAtivo[] ativos = new CodigoAtivo[10];
      var indiceAtivo = 0;
      String opcaoUsuario = ObterOpcao();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            //Inserir ação nova na carteira
            Console.WriteLine("Informe o código da ação:");
            CodigoAtivo ativo = new CodigoAtivo();
            ativo.Codigo = Console.ReadLine();

            Console.WriteLine("Informe o preço unitário da ação:");

            if (decimal.TryParse(Console.ReadLine(), out decimal precoAcao))
            {
              ativo.PrecoAcao = precoAcao;
            }
            else
            {
              throw new ArgumentException("Valor deve ser decimal");
            }

            Console.WriteLine("Informe a quantidade de ações:");

            if (decimal.TryParse(Console.ReadLine(), out decimal qtdAcao))
            {
              ativo.QtdAcao = qtdAcao;
            }
            else
            {
              throw new ArgumentException("Valor deve ser decimal");
            }

            ativos[indiceAtivo] = ativo;
            indiceAtivo++;

            break;
          case "2":
            //Listar ações da carteira
            foreach (var a in ativos)
            {
              if (!string.IsNullOrEmpty(a.Codigo))
              {
                Console.WriteLine($"AÇÃO: {a.Codigo} - PREÇO UNIT: R$ {a.PrecoAcao} - QTD. AÇÕES: {a.QtdAcao}");
              }
            }

            break;
          case "3":
            //Calcular valor total de cada ação
            foreach (var a in ativos)
            {
              if (!string.IsNullOrEmpty(a.Codigo))
              {
                Console.WriteLine($"AÇÃO: {a.Codigo} - VALOR TOTAL: R$ {a.PrecoAcao * a.QtdAcao}");
              }
            }

            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcao();
      }
    }

    private static string ObterOpcao()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada: ");
      Console.WriteLine("1 - Inserir ação nova na carteira");
      Console.WriteLine("2 - Listar ações da carteira");
      Console.WriteLine("3 - Calcular valor total de cada ação");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      String opcaoUsuario = Console.ReadLine();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
