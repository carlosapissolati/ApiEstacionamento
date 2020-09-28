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
PUT - /v1/estabelecimento<br> 
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
Passar o id do estabelecimento.<br> 
GET - /v1/veiculo/{id}
Retorno:<br> 
```
{
  "estabelecimentoId": "c5ee40a4-6a75-4a9a-8e3d-f7774eabb13b",
  "marca": "",
  "modelo": "",
  "cor": "",
  "placa": "",
  "tipo": 1 - Automovel , 2 - Moto
}
```
___________________________________________________________________________________________________________
Passar o id do estabelecimento.<br> 
DELETE - /v1/veiculo/{id}<br>
Retorno:<br> 
```
{
  "estabelecimentoId": "c5ee40a4-6a75-4a9a-8e3d-f7774eabb13b",
  "marca": "",
  "modelo": "",
  "cor": "",
  "placa": "",
  "tipo": 1 - Automovel , 2 - Moto
}
```
___________________________________________________________________________________________________________
POST - /v1/veiculo<br>
Paylod:<br>
```
{
  "estabelecimentoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "marca": "string",
  "modelo": "string",
  "cor": "string",
  "placa": "string",
   "tipo": 1 - Automovel , 2 - Moto
}
```
Retorno:<br>
```
{
    "success": true,
    "data": {
        "id": "adc4da41-f533-478d-a2c0-0eeabf8889f1",
        "estabelecimentoId": "39c18432-ef4b-4882-acea-906d241063a4",
        "marca": "string",
        "modelo": "string",
        "cor": "string",
        "placa": "string",
         "tipo": 1 - Automovel , 2 - Moto
    },
    "erroList": null
}
```
___________________________________________________________________________________________________________
PUT - /v1/veiculo<br>
Paylod:<br>
```
{
  "estabelecimentoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "marca": "string",
  "modelo": "string",
  "cor": "string",
  "placa": "string",
   "tipo": 1 - Automovel , 2 - Moto
}
```
Retorno:<br>
```
{
    "success": true,
    "data": {
        "id": "adc4da41-f533-478d-a2c0-0eeabf8889f1",
        "estabelecimentoId": "39c18432-ef4b-4882-acea-906d241063a4",
        "marca": "string",
        "modelo": "string",
        "cor": "string",
        "placa": "string",
         "tipo": 1 - Automovel , 2 - Moto
    },
    "erroList": null
}
```
___________________________________________________________________________________________________________
POST - /v1/veiculo/controle<br>
Paylod:<br>
```
{
  "veiculoId": "da8ce00b-ab3f-4d16-85a0-1c5dde7af4a7",
  "estabelecimentoId": "04f32352-c606-4a30-994b-3c5332dd8077",
  "tipoControle": 1 - Entrada, 2 - Saida
  "tipo":  1 - Automovel , 2 - Moto
}
```
Retorno:<br>
```
{
    "success": true,
    "data": "Sucesso",
    "erroList": null
}
```
___________________________________________________________________________________________________________
Passar o id do estabelecimento.<br> 
GET - /v1/RelatorioEntradaSaidaVeiculoHora/{id}
Retorno:
```
[
  {
    "nomeEstabelecimento": null,
    "hora": "2020-09-28T14:00:00",
    "qtdEntrada": 1,
    "qtdSaida": 0
  }
]
```
