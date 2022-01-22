using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsiario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    listarSeries();
                    break;
                    case "2":
                    inserirSerie();
                    break;
                    case "3":
                    atualizarSerie();
                    break;
                    case "4":
                    excluirSerie();
                    break;
                    case "5":
                    visualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsiario();
            }        
        }

        private static string obterOpcaoUsiario()
            {
                System.Console.WriteLine();
                System.Console.WriteLine("The Force Séries a seu Dispor!!!");
                System.Console.WriteLine("Informe a opção desejada:");

                System.Console.WriteLine("1- Listar Séries");
                System.Console.WriteLine("2- Inserir nova série");
                System.Console.WriteLine("3- Atualizar série");
                System.Console.WriteLine("4- Excluir série");
                System.Console.WriteLine("5- Visualizar série");
                System.Console.WriteLine("C- Limpar Tela");
                System.Console.WriteLine("X- Sair");
                System.Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                return opcaoUsuario;  
            }

        private static void listarSeries() {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
                
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornarExcluido();
                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornarId(), serie.retornarTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void inserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.proximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.inserir(novaSerie);
        }

        private static void atualizarSerie()
		{
			System.Console.WriteLine("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite o título da Série: ");
			string entradaTitulo = Console.ReadLine();

			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			System.Console.WriteLine("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizarSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.atualizar(indiceSerie, atualizarSerie);
		}

        private static void excluirSerie()
		{
		    System.Console.WriteLine("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.excluir(indiceSerie);
		}

        private static void visualizarSerie()
		{
			System.Console.WriteLine("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.retornarPorId(indiceSerie);

			Console.WriteLine(serie);
		}
    }
}