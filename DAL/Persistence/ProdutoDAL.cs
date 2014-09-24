using DAL.Model;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class ProdutoDAL : Conexao
    {
        //Método Insert:
        public bool Insert(Produto p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Produto(Nome, Descricao, Preco, Quantidade_Estoque, Data_Cadastro) values(@nome, @descricao, @preco, @quantidade_estoque, @data_cadastro)", Con);

                Cmd.Parameters.AddWithValue("@nome", p.Nome);
                Cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                Cmd.Parameters.AddWithValue("@preco", p.Preco);
                Cmd.Parameters.AddWithValue("@quantidade_estoque", p.Quantidade_Estoque);
                Cmd.Parameters.AddWithValue("@data_cadastro", p.Data_Cadastro);

                return Cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("\tErro para gravar no BD.....: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Update:
        public bool Update(Produto p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("update Produto set Nome=@nome, Descricao=@descricao, Preco=@preco, Quantidade_Estoque=@quantidade_estoque, Data_Cadastro=data_cadastro", Con);

                Cmd.Parameters.AddWithValue("@nome", p.Nome);
                Cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                Cmd.Parameters.AddWithValue("@preco", p.Preco);
                Cmd.Parameters.AddWithValue("@quantidade_estoque", p.Quantidade_Estoque);
                Cmd.Parameters.AddWithValue("@data_cadastro", p.Data_Cadastro);

                return Cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("\tErro na atualização no BD.....: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Delete:
        public bool Delete(int IdCodigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Produto where IdProduto=@idcodigo", Con);

                Cmd.Parameters.AddWithValue("@idcodigo", IdCodigo);

                return Cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                throw new Exception("\tErro ao deletar no BD.......: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Select:
        public List<Produto> Select()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Produto", Con);
                Dr = Cmd.ExecuteReader();

                List<Produto> lista = new List<Produto>();

                while (Dr.Read())
                {
                    Produto p = new Produto();

                    p.Codigo            = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome              = Convert.ToString(Dr["Nome"]);
                    p.Descricao         = Convert.ToString(Dr["Descricao"]);
                    p.Preco             = Convert.ToDecimal(Dr["Preco"]);
                    p.Quantidade_Estoque = Convert.ToInt32(Dr["Quantidade_Estoque"]);
                    p.Data_Cadastro     = Convert.ToDateTime(Dr["Data_Cadastro"]);

                    lista.Add(p);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("\tErro ao selecionar os itens no BD......: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Método Select By Id:
        public List<Produto> SelectById(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Produto where Codigo=@codigo", Con);
                Cmd.Parameters.AddWithValue("@codigo", Codigo);
                Dr = Cmd.ExecuteReader();

                List<Produto> lista = new List<Produto>();

                while (Dr.Read())
                {
                    Produto p = new Produto();

                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.Descricao = Convert.ToString(Dr["Descricao"]);
                    p.Preco = Convert.ToDecimal(Dr["Preco"]);
                    p.Quantidade_Estoque = Convert.ToInt32(Dr["Quantidade_Estoque"]);
                    p.Data_Cadastro = Convert.ToDateTime(Dr["Data_Cadastro"]);

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("\tErro ao selecionar todos os itens do BD........: " + e.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
