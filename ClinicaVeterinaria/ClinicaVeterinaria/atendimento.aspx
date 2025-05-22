<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="atendimento.aspx.cs" Inherits="_ClinicaVeterinaria.atendimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Clínica Veterinária</title>
    <link rel="stylesheet" href="css/estilo.css">
    <link rel="stylesheet" href="css/estiloAtendimento.css">
</head>
<body>
    <form id="form1" runat="server">
        <section id="area-titulo">
            <h1>Atendimento</h1>
            <a href="index.aspx" class="botao">Voltar</a>
        </section>

        <section id="area-tratamento">
            <h1>Registro de atendimento</h1>
            <div id="form">
                <div class="item-form">
                    <label>Nome do animal:</label>
                    <asp:TextBox ID="nomeDoAnimal" runat="server"></asp:TextBox>
                </div>

                <div class="item-form">
                    <label>Data:</label>
                    <asp:TextBox ID="date" runat="server" Enabled="false"></asp:TextBox>
                </div>

                <div class="item-form">
                    <label>Tratamento:</label>
                  
                        <asp:DropDownList ID="DropDownList" runat="server"></asp:DropDownList>
                    
                </div>

                <div class="item-form-bloco">
                    <label>Descrição do Tratamento:</label>
                    <textarea disabled id="descricao"></textarea>
                </div>

                <div class="item-form-bloco">
                    <label>Descrição do Atendimento:</label>
                    <asp:TextBox ID="ds_Atendimento" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="Salvar" runat="server" Text="Salvar" OnClick="Salvar_Click" />
            </div>
        </section>

        <section id="area-historico">
            <h1>Histórico</h1>
            <asp:Literal ID="prontuario" runat="server"></asp:Literal>
            <%--<table>
                <thead>
                    <th>Data</th>
                    <th>Tratamento</th>
                    <th>Descrição do Tratamento</th>
                </thead>
                <tbody>
                    <tr>
                        <td class="data">30/08/2024 às 11:35</td>
                        <td>Vermifugação</td>
                        <td>Houve reação alérgica e foi adminitrado Apoquel 6g</td>
                    </tr>
                    <tr>
                        <td class="data">30/08/2024 às 11:30</td>
                        <td>Vacina Antirrábica</td>
                        <td>Renovar em 1 ano</td>
                    </tr>
                </tbody>
            </table>--%>
        </section>
    </form>
    <script src="js/dropDown.js" ></script>
</body>
</html>
