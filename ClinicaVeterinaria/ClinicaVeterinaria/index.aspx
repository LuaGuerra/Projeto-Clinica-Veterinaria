<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_ClinicaVeterinaria.index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/estilo.css">
    <title>Clínica Veterinaria</title>
</head>
<body>
    <form id="form1" runat="server">
        <section id="area-busca">
            <asp:TextBox ID="inputBuscar" runat="server" placeholder="Informe nome do animal"></asp:TextBox>

            <asp:Button ID="Buscar" runat="server" Text="Buscar" OnClick="Buscar_Click"/>
        </section>

        <section id="resultados">
            <asp:Literal ID="carregarAnimais" runat="server"></asp:Literal>
            <%--<div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/brutus.png">
                    <div>
                        <h1>Brutus</h1>
                        <p>Buldog</p>
                    </div>
                </a>
            </div>

            <div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/flocos.png">
                    <div>
                        <h1>Flocos</h1>
                        <p>Dálmata</p>
                    </div>
                </a>
            </div>

            <div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/luna.png">
                    <div>
                        <h1>Luna</h1>
                        <p>Tabby Listrado</p>
                    </div>
                </a>
            </div>

            <div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/meg.png">
                    <div>
                        <h1>Meg</h1>
                        <p>Beagle</p>
                    </div>
                </a>
            </div>

            <div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/rico.png">
                    <div>
                        <h1>Rico</h1>
                        <p>Californiano</p>
                    </div>
                </a>
            </div>

            <div class="caixaAnimal">
                <a href="atendimento.html">
                    <img src="images/tico.png">
                    <div>
                        <h1>Tico</h1>
                        <p>Fox Paulistinha</p>
                    </div>
                </a>
            </div>--%>
        </section>
    </form>
</body>
</html>
