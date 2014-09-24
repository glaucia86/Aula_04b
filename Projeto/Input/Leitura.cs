using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Input
{
    public class Leitura
    {
        public string LerNome()
        {
            try
            {
                Console.Write("Informe o Nome do Produto.....: ");
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro.....:" + e.Message);
                return LerNome();
            }
        }

        public string LerDescricao()
        {
            try
            {
                Console.Write("Informe a Descrição do Produto......: ");
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro......: " + e.Message);
                return LerDescricao();
            }
        }

        public decimal LerPreco()
        {
            try
            {
                Console.Write("Informe o Preço do Produto......: R$ ");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro......: " + e.Message);
                return LerPreco();
            }
        }

        public int LerQuantidadeEstoque()
        {
            try
            {
                Console.Write("Informe a Quantidade de Produtos no Estoque.........: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro......: " + e.Message);
                return LerQuantidadeEstoque();
            }
        }

        public DateTime LerDataCadastro()
        {
            try
            {
                Console.Write("Informe a Data de Cadastro do Produto.......: ");
                return Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\tErro.......: " + e.Message);
                return LerDataCadastro();
            }
        }
    }
}
