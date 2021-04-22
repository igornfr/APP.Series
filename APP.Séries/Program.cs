using System;

namespace APP.Séries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "S")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
             }

             Console.WriteLine("Obrigado pela preferência NFR!!");
             Console.ReadLine();
         }
            private static void ExcluirSerie()
            {
                Console.Write("Digite o id da Série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }

            private static void VisualizarSerie()
            {
                Console.Write("Digite o id da Série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                
                var serie = repositorio.RetornaPorId(indiceSerie);
                Console.WriteLine(serie);
            }
            private static void AtualizarSerie()
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                    Console.Write("Digite o genêro entre as opções acima: ");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.Write("Digite o Titulo da Série: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o ano de Inicio da Série: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite a Descrição da Série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

                    repositorio.Atualiza(indiceSerie, atualizaSerie);
            }

         private static void ListarSeries()
         {
             Console.WriteLine("Listar Séries");

             var lista = repositorio.Lista();

             if (lista.Count == 0)
             {
                 Console.WriteLine("Nenhuma série foi encontrada.");
                 return;
             }

             foreach (var serie in lista)
             {
                 var excluido = serie.retornaExcluido();
                 Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(),serie.retornaTitulo(), (excluido ? "#Excluido#" : ""));
             }
         }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite um genêro das opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("NFR Séries ao seu lazer!");
            Console.WriteLine("Qual opção você deseja?");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("L- Limpar Tela");
            Console.WriteLine("S- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
