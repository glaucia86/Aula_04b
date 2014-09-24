using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Persistence;
using DAL.Model;
using Projeto.Input;

namespace Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Produto p = new Produto();
                Leitura l = new Leitura();

                p.Nome = l.LerNome();
                p.Descricao = l.LerDescricao();
                p.Preco = l.LerPreco();
                p.Quantidade_Estoque = l.LerQuantidadeEstoque();
                p.Data_Cadastro = l.LerDataCadastro();

                ProdutoDAL d = new ProdutoDAL();

                if (d.Insert(p))
                    Console.WriteLine("Dados Gravados com Sucesso!!!!");
                else
                    Console.WriteLine("Não foi possível realizar o Cadastro!");

                //Listando todos os dados contidos na tabela:
                foreach (Produto pro in d.Select())
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\nCódigo.....................: " + pro.Codigo);
                    Console.WriteLine("\nNome.......................: " + pro.Nome);
                    Console.WriteLine("\nDescrição..................: " + pro.Descricao);
                    Console.WriteLine("\nPreço......................: R$ " + pro.Preco);
                    Console.WriteLine("\nQuantidade Estoque.........: " + pro.Quantidade_Estoque);
                    Console.WriteLine("\nData Cadastro..............: " + pro.Data_Cadastro);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro.........: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
