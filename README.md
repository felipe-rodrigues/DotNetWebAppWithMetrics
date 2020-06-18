# DotNetWebAppWithMetrics

Projeto de exemplo para coleta de métricas , usando [AppMetrics](https://www.app-metrics.io/) e [Prometheus](https://prometheus.io/docs/introduction/overview/)

## Começo

Clone o projeto em sua máquina e verifique se as depêndencias foram resolvidas pelo `nuget`

### Pré requisitos

- [Docker](https://www.docker.com/products/docker-desktop)

### Executando o projeto

Após a instalação do docker (desktop ou toolbox). Abra um terminal na pasta do projeto e execute o comando abaixo:
`docker-compose  up -d --build`

Se o comando executar corretamente , dois containers estarão executando em portas diferentes, são estes:

 - prometheus : 9090 responsável por coletar as métricas e disponibilizar uma interface para consulta das métricas
 - webappmetrics : 5000 web api para atualização das métricas
 
 
 #### Descrição das funcionalidades

Além das métricas de uma aplicação web dispostas por [default](https://www.app-metrics.io/web-monitoring/aspnet-core/tracking-middleware/).
Criamos 2 métricas identificadas pelos nomes, com as seguintes funcionalidades
- customersapi_customers_get_request  | Contagem de requisições de busca de clientes
- customersapi_customers_create_request | Contagem de novos clientes cadastrados

#### Testes

Para executarmos testes devemos fazer duas chamadas para a api disposta na porta `5000`

- **Get** `http://localhost:5000/api/customer`  | Atualiza a métrica `customersapi_customers_get_request`
- **Post** `http://localhost:5000/api/customer` | Atualiza a métrica `customersapi_customers_create_request` (Para essa chamada é **necessário** enviar no **corpo** da requisição um objeto no formato abaixo:
```
  {
    "name": <string>
  }
```

#### Visualização das métricas

Para a visualização e consulta das metricas coletadas, você deve acessar `http://localhost:9090/graph` e pesquisar por alguma das métricas informadas acima.

Segue o print de um dos resultados: ![results](https://github.com/felipe-rodrigues/DotNetWebAppWithMetrics/blob/master/prints/resultados.PNG)


*Observação* : Caso voce esteja utilizando docker toolbox você deverá trocar o endereço `localhost` por `192.168.99.100`
