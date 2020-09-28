# ApiEstacionamento

Aplica&ccedil;&atilde;o:
Projeto de uma API para controlar entrada e sa&iacute;da de ve&iacute;culos.

# Tecnologia utilizadas:<br> 
AutoMapper V10.0.0 <br> 
AspNetCore.Swagger V5.6.3 <br> 
Authentication.JwtBearer V3.1.8 <br> 
EntityFrameworkCore V3.1.8

# Persistência dos dados:<br>
Estou utilizando o recurso de in memory entity framework core.

# EndPoint:
Estabelecimento: <br> 
GET - /v1/estabelecimento/{id}<br> 
DELETE - /v1/estabelecimento/{id}<br> 
POST - /v1/estabelecimento<br> 
PUT - /v1/estabelecimento<br> 

Veiculo: <br> 
GET - /v1/veiculo/{id}<br> 
DELETE - /v1/veiculo/{id}<br> 
POST - /v1/veiculo<br> <br> 


Relat&oacute;rios:<br> 
GET - /v1/RelatorioEntradaSaidaVeiculoHora/{id}<br>  

Login:<br> 
POST - /v1/Login<br> 

# Tipo Entrada e Saida de Dados:
Entrada: Json<br> 
Saida: Json <br> 


# Exemplo de utilização da API:
Passar o id do estabelecimento.<br> 
GET - /v1/estabelecimento/{id}<br> 
Retorno:<br> 

```      
{
    "success": true,
    "data": {
        "id": "7d490744-df5e-414e-a92b-20bc1791d0f8",
        "cnpj": "",
        "endereco": "",
        "telefone": "",
        "qtdVagasMotos": ,
        "qtdVagasCarros": 
    },
    "erroList": null
}
```
___________________________________________________________________________________________________________
Passar o id do estabelecimento.<br> 
DELETE - /v1/estabelecimento/{id}<br> 
Retorno:<br> 
```
{
    "success": true,
    "data": {
        "id": "7d490744-df5e-414e-a92b-20bc1791d0f8",
        "cnpj": "",
        "endereco": "",
        "telefone": "",
        "qtdVagasMotos": ,
        "qtdVagasCarros": 
    },
    "erroList": null
}
```
___________________________________________________________________________________________________________
POST - /v1/estabelecimento<br> 
Paylod:<br> 
```
{
  "cnpj": "",
  "endereco": "",
  "telefone": "",
  "qtdVagasMotos": 10,
  "qtdVagasCarros": 10
}
```
Retorno:<br> 
```
{
    "success": true,
    "data": {
        "id": "7d490744-df5e-414e-a92b-20bc1791d0f8",
        "cnpj": "",
        "endereco": "",
        "telefone": "",
        "qtdVagasMotos": ,
        "qtdVagasCarros": 
    },
    "erroList": null
}
```
___________________________________________________________________________________________________________
