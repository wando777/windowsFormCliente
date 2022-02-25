using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioSQLServer
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public SQLServerClass db;

        public FicharioSQLServer(string Table)
        {
            status = true;

            try
            {
                db = new SQLServerClass();
                tabela = Table;
                mensagem = "Table connection has been created successfully";

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "There's an error with the table: " + ex.Message;
            }

        }

        public void Incluir(string Id, string jsonUnit)
        {
            status = true;

            //INSERT INTO CLIENTE (ID, JSON) VALUES ();


            try
            {

                var SQL = "INSERT INTO " + tabela + " (Id, JSON) VALUES ('" + Id + "', '" + jsonUnit + "')";
                db.SQLCommand(SQL);
                status = true;
                mensagem = "Object has been included successfully: " + Id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public string Buscar(string Id)
        {
            status = true;
            try
            {
                // SELECT ID, JSON FROM {TABELA} WHERE ID = {ID}; 

                var SQL = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    mensagem = "The object has been found with Id = " + Id;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Object not found: Id = " + Id;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {

                // SELECT ID, JSON FROM {TABELA};
                var SQL = "SELECT ID, JSON FROM " + tabela;
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        List.Add(conteudo);
                    }
                    mensagem = "The list of clients has been returned successfully";
                    return List;
                }
                else
                {
                    status = false;
                    mensagem = "The database is empty";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar lista de clientes: " + ex.Message;
            }
            return List;
        }

        public void Apagar(string Id)
        {
            status = true;
            try
            {
                if (!String.IsNullOrEmpty(Buscar(Id)))
                {
                    // DELETE FROM {TABELA} WHERE ID = {Id};

                    var SQL = "DELETE FROM " + tabela + " WHERE ID = '" + Id + "'";
                    db.SQLCommand(SQL);
                    status = true;
                    mensagem = Id + " has been deleted";
                }

                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                if (!String.IsNullOrEmpty(Buscar(Id)))
                {
                    // UPDATE {TABLE} SET {JSON} = {jsonUnit} WHERE ID = {Id};

                    var SQL = "UPDATE " + tabela + " SET JSON = '" + jsonUnit + "' WHERE ID = '" + Id + "'";
                    db.SQLCommand(SQL);
                    status = true;
                    mensagem = "The object has been updates successfully";
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }
    }
}
