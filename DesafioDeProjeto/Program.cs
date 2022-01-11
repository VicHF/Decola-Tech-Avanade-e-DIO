using System;

namespace DesafioDeProjeto
{
    class Program
    {
        static MusicaRepositorio repositorio = new MusicaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusicas();
						break;
					case "2":
						InserirMusica();
						break;
					case "3":
						AtualizarMusica();
						break;
					case "4":
						ExcluirMusica();
						break;
					case "5":
						VisualizarMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Agradecemos por utilizar nossos serviços :)");
			Console.ReadLine();
        }
			
        private static void ExcluirMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusica);
		}

        private static void VisualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var musica = repositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(musica);
		}

        private static void AtualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero musical entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da Música: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Álbum da Música: ");
			string entradaAlbum = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Artista: ");
			string entradaArtista = Console.ReadLine();

			Musica atualizaMusica = new Musica(id: indiceMusica,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
                                        album: entradaAlbum,
										ano: entradaAno,
										artista: entradaArtista);

			repositorio.Atualiza(indiceMusica, atualizaMusica);
		}
        private static void ListarMusicas()
		{
			Console.WriteLine("Listar músicas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var musica in lista)
			{
                var excluido = musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: {1} - {2} {3}", musica.retornaId(), musica.retornaTitulo(), musica.retornaArtista(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova música");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero musical entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da Música: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Álbum da Música: ");
			string entradaAlbum = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Artista: ");
			string entradaArtista = Console.ReadLine();

			Musica novaMusica = new Musica(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										album: entradaAlbum,
										ano: entradaAno,
										artista: entradaArtista);

			repositorio.Insere(novaMusica);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Musicolândia a seu dispor!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar músicas");
			Console.WriteLine("2- Inserir nova música");
			Console.WriteLine("3- Alterar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
