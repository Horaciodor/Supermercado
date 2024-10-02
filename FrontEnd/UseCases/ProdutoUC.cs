using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    internal class ProdutoUC
    {
        private readonly HttpClient _client;
        public ProdutoUC(HttpClient client)
        {
            _client = client;
        }
        public List<Produto> LisatarProduto()
        {
            return _client.GetFromJsonAsync<List<Produto>>("Produto/listar-produto").Result;
        }
        public void AdicionarProduto(Produto produto)
        {
            HttpResponseMessage responce = _client.PostAsJsonAsync("Produto/adicionar-p" +
                ".roduto", produto).Result;
        }
    }
}
