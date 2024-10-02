using Core.Entidades;
using FrontEnd.Models.DTOs;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;
public class Sistema
{
    private static Usuario UsuarioLogado { get; set; }
    private readonly UsuarioUC _usuarioUC;
    private readonly ProdutoUC _produtoUC;
    public Sistema(HttpClient cliente)
    {
        _usuarioUC = new UsuarioUC(cliente);
    }
    public void IniciarSistema()
    {
        int resposta = -1;
        while (resposta != 0)
        {
            if(UsuarioLogado == null)
            {
                resposta = ExibirLogin();
                if (resposta == 1)
                {
                FazerLogin();
                }
            if (resposta == 2)
            {
                Usuario usuario = CriarUsuario();
                _usuarioUC.CadastrarUsuario(usuario);
                Console.WriteLine("Usuario cadastrado com suscesso");
            }
            if (resposta == 3)
            {
                List<Usuario> usuarios = _usuarioUC.ListarUsuarios();
                foreach (Usuario u in usuarios)
                {
                    Console.WriteLine(u.ToString());
                }
            }
            }
            else
            {
                ExibirMenuPricipal();
            } 
        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("--------- LOGIN ---------");
        Console.WriteLine("1 - Deseja Fazer Login");
        Console.WriteLine("2 - Deseja se Cadastrar");
        Console.WriteLine("3 - listar Usuario Cadastra");
        return int.Parse(Console.ReadLine());
    }
    public Usuario CriarUsuario()
    {
        Usuario usuario = new Usuario();
        Console.WriteLine("Digite seu nome");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Digite sua senha");
        usuario.Senha = Console.ReadLine();
        Console.WriteLine("Digite seu Email");
        usuario.Email = Console.ReadLine();
        return usuario;
    }
    public Produto CriarProduto()
    {
        Produto usuario = new Produto();
        Console.WriteLine("Digite seu nome: ");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Digite seu preco: ");
        usuario.Preco = double.Parse(Console.ReadLine());
        return usuario;
    }
    public void FazerLogin()
    {
        Console.WriteLine("Digite seu username");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha");
        string senha = Console.ReadLine();
        UsuarioLoginDTO usoDTO = new UsuarioLoginDTO()
        {
            Username = username,
            Senha = senha
        };
        Usuario usuario = _usuarioUC.FazerLogin(usoDTO);
        if(usuario == null)
        {
            Console.WriteLine("Usuario ou senha invalidos!!");
        }
        UsuarioLogado = usuario;
        Console.WriteLine("Usuario logado!");
    }
    public void ExibirMenuPricipal()
    {
        Console.WriteLine("1 - Listar Produtos");
        Console.WriteLine("2 - Cadastra Produto");
        Console.WriteLine("3 - Realizar uma compra");
        Console.WriteLine("Qual operação deseja realizar?");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {
            List<Produto> prod = _produtoUC.LisatarProduto();
            foreach (Produto p in prod)
            {
                Console.WriteLine(p.ToString());
            }
        }
        if (resposta == 2)
        {
            Produto produto = CriarProduto();
            _produtoUC.AdicionarProduto(produto);
            Console.WriteLine("Produto criado com suscesso");
        }
        if (resposta == 3)
        {

        }
    }

}
