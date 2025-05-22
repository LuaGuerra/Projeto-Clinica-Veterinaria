using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _ClinicaVeterinaria
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Animais_ctrl animais = new Animais_ctrl();
                List<Animal> list_animais = animais.carregarAnimais();

                for (int i = 0; i < list_animais.Count; i++)
                {
                    carregarAnimais.Text += $@"<div class='caixaAnimal'>
                                                <a href='atendimento.aspx?c={list_animais[i].Codigo_Animal}'>
                                                    <img src='images/{list_animais[i].Nome_Animal}.png'>
                                                    <div>
                                                        <h1>{list_animais[i].Nome_Animal}</h1>
                                                        <p>{list_animais[i].Nome_Especie}</p>
                                                    </div>
                                                </a>
                                            </div>";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel carregar animais na tela!" + ex.Message);
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            string filtro = inputBuscar.Text;
            if (filtro != "")
            {
                try
                {
                    Animais_ctrl animais = new Animais_ctrl();
                    List<Animal> list_animais = animais.Filtro(filtro);

                    carregarAnimais.Text = "";
                    for (int i = 0; i < list_animais.Count; i++)
                    {
                        carregarAnimais.Text += $@"<div class='caixaAnimal'>
                                                <a href='atendimento.aspx?c={list_animais[i].Codigo_Animal}'>
                                                    <img src='images/{list_animais[i].Nome_Animal}.png'>
                                                    <div>
                                                        <h1>{list_animais[i].Nome_Animal}</h1>
                                                        <p>{list_animais[i].Nome_Especie}</p>
                                                    </div>
                                                </a>
                                            </div>";
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel filtrar animais!" + ex.Message);
                }
            }
            else
            {
                try
                {
                    Animais_ctrl animais = new Animais_ctrl();
                    List<Animal> list_animais = animais.carregarAnimais();
                    carregarAnimais.Text = "";
                    for (int i = 0; i < list_animais.Count; i++)
                    {
                        carregarAnimais.Text += $@"<div class='caixaAnimal'>
                                                <a href='atendimento.aspx?c={list_animais[i].Codigo_Animal}'>
                                                    <img src='images/{list_animais[i].Nome_Animal}.png'>
                                                    <div>
                                                        <h1>{list_animais[i].Nome_Animal}</h1>
                                                        <p>{list_animais[i].Nome_Especie}</p>
                                                    </div>
                                                </a>
                                            </div>";
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel carregar animais na tela!" + ex.Message);
                }
            }

        }
    }
}