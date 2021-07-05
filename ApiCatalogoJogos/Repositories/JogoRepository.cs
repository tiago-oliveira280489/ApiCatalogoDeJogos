using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("1"), new Jogo{ Id = Guid.Parse("1"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} },
            {Guid.Parse("2"), new Jogo{ Id = Guid.Parse("2"), Nome = "Fifa 20", Produtora = "EA", Preco = 190} },
            {Guid.Parse("3"), new Jogo{ Id = Guid.Parse("3"), Nome = "Fifa 19", Produtora = "EA", Preco = 180} },
            {Guid.Parse("4"), new Jogo{ Id = Guid.Parse("4"), Nome = "Fifa 18", Produtora = "EA", Preco = 170} },
            {Guid.Parse("5"), new Jogo{ Id = Guid.Parse("5"), Nome = "Street Fighter V", Produtora = "Capcom", Preco =  80 } },
            {Guid.Parse("6"), new Jogo{ Id = Guid.Parse("6"), Nome = "Gran Theft Auto V", Produtora = "Rockstar", Preco = 190} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
