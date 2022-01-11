using System;

namespace DesafioDeProjeto
{
    public class Musica : EntidadeBase
    {
        private string Titulo { get; set; }
		private Genero Genero { get; set; }
		private string Album { get; set; }
        private string Artista { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        public Musica(int id, Genero genero, string titulo, string album, string artista, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Album = album;
            this.Artista = artista;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Álbum: " + this.Album + Environment.NewLine;
            retorno += "Artista: " + this.Artista + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public string retornaArtista()
		{
			return this.Artista;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}