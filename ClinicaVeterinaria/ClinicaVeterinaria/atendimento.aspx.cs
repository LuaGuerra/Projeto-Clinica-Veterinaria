using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _ClinicaVeterinaria
{
    public partial class atendimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["c"]))
            {
                Response.Redirect("index.aspx");
                return;
            }

            if (!IsPostBack)
            {
                DropDownList.Items.Clear();
                int codigo_Animal = int.Parse(Request["c"].ToString());
                Animais_ctrl animais = new Animais_ctrl();
                Animal animal = animais.nomePeloCd(codigo_Animal);
                nomeDoAnimal.Text = animal.Nome_Animal;
                date.Text = DateTime.Now.ToString().Substring(0, 10);

                Tratamentos_ctrl tratamentos = new Tratamentos_ctrl();
                List<Tratamento> list_tratamento = tratamentos.carregar_tratamentos();
                DropDownList.Items.Add(new ListItem("Selecione o Tratamento", ""));
                DropDownList.Items[0].Attributes["disabled"] = "disabled";
                DropDownList.Items[0].Attributes["selected"] = "selected";

                for (int i = 0; i < list_tratamento.Count; i++)
                {
                    DropDownList.Items.Add(new ListItem(list_tratamento[i].nome_Tratamento, list_tratamento[i].ds_Tratamento.ToString()));
                }

                try
                {
                    Prontuarios_ctrl prontuarios = new Prontuarios_ctrl();
                    List<Prontuario> list_prontuario = prontuarios.carregar_Prontuario(codigo_Animal);


                    prontuario.Text = $@"<table>
                                                        <thead>
                                                            <th>Data</th>
                                                            <th>Tratamento</th>
                                                            <th>Descrição do Tratamento</th>
                                                        </thead>";
                    for (int i = 0; i < list_prontuario.Count; i++)
                    {
                        Tratamento tratamento = tratamentos.nm_Tratamento(list_prontuario[i].codigo_Tratamento);
                        prontuario.Text += $@"<tbody>
                                                            <tr>
                                                                <td class='data'>{list_prontuario[i].dt_Tratamento.ToString().Substring(0, 10)} às {list_prontuario[i].dt_Tratamento.ToString().Substring(10)}</td>
                                                                <td>{tratamento.nome_Tratamento}</td>
                                                                <td>{list_prontuario[i].descricao_Prontuario}</td>
                                                            </tr>
                                                        </tbody>";
                    }
                    prontuario.Text += $"</table>";
                }
                catch { }
            }
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            string Selecionado = DropDownList.Text;
            if (Selecionado != "")
            {
                string observacao = ds_Atendimento.Text;
                DateTime data = DateTime.Now;
                string dataFormat = data.ToString("yyyy-MM-dd hh:mm:ss");
                Tratamentos_ctrl tratamentos = new Tratamentos_ctrl();
                Tratamento tratamento = tratamentos.codigo_Tratamento(Selecionado);
                int codigoAnimal = int.Parse(Request["c"].ToString());

                Prontuarios_ctrl prontuarios = new Prontuarios_ctrl();
                prontuarios.criar_Prontuario(codigoAnimal, tratamento.codigo_Tratamento, dataFormat, observacao);

                try
                {
                    prontuario.Text = "";
                    List<Prontuario> lista_prontuario = prontuarios.carregar_Prontuario(codigoAnimal);

                    prontuario.Text = $@"<table>
                                            <thead>
                                                <th>Data</th>
                                                <th>Tratamento</th>
                                                <th>Descrição do Tratamento</th>
                                            </thead>";
                    for (int i = 0; i < lista_prontuario.Count; i++)
                    {
                        Tratamento tratamento2 = tratamentos.nm_Tratamento(lista_prontuario[i].codigo_Tratamento);
                        prontuario.Text += $@"<tbody>
                                                <tr>
                                                    <td class='data'>{lista_prontuario[i].dt_Tratamento.ToString().Substring(0, 10)} as {lista_prontuario[i].dt_Tratamento.ToString().Substring(10)}</td>
                                                    <td>{tratamento2.nome_Tratamento}</td>
                                                    <td>{lista_prontuario[i].descricao_Prontuario}</td>
                                                </tr>
                                            </tbody>";
                    }
                    prontuario.Text += $"</table>";
                }
                catch { }
            }
            return;
        }
    }
}