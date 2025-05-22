using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class Banco
{
    MySqlConnection conexao = null;

    public void Conectar()
    {
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=clinica_veterinaria";
        conexao = new MySqlConnection(linhaConexao);
        try
        {
            conexao.Open();
        }
        catch
        {
            throw new Exception("Erro ao conectar ao Servidor");
        }
    }

    public void Desconectar()
    {
        if (conexao != null)
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }

    public MySqlDataReader Consultar(string comando)
    {
        try
        {
            Conectar();
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            return cSQL.ExecuteReader();
        }
        catch
        {
            throw new Exception("Erro na consulta");
        }
    }

    public MySqlDataReader Consultar(string comando, List<MySqlParameter> parametros)
    {
        try
        {
            Conectar();
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            foreach (MySqlParameter parametro in parametros)
            {
                cSQL.Parameters.Add(parametro);
            }
            return cSQL.ExecuteReader();
        }
        catch
        {
            throw new Exception("Erro na consulta");
        }
    }

    public void Executar(string comando)
    {
        try
        {
            Conectar();
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            cSQL.ExecuteNonQuery();
        }
        catch
        {
            throw new Exception("Erro na execucao");
        }
        finally
        {
            Desconectar();
        }
    }

    public void Executar(string comando, List<MySqlParameter> parametros)
    {
        try
        {
            Conectar();
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            foreach (MySqlParameter parametro in parametros)
            {
                cSQL.Parameters.Add(parametro);
            }
            cSQL.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            Desconectar();
        }
    }
}

