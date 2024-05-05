# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.

## Minha Solução

### Método AdicionarVeiculo()
- Este método solicita ao usuário a placa do veículo a ser estacionado, verifica se a placa está no formato correto e se o veículo já não está estacionado. Se tudo estiver correto, adiciona a placa à lista de veículos estacionados.

### Método RemoverVeiculo()
- Este método permite ao usuário remover um veículo do estacionamento. Primeiro, solicita a placa do veículo a ser removido, verifica se a placa está no formato correto e se o veículo está realmente estacionado. Em seguida, solicita ao usuário a quantidade de horas que o veículo permaneceu estacionado, calcula o valor total com base nas taxas de estacionamento definidas e remove o veículo da lista.

### Método ListarVeiculos()
- Este método lista todos os veículos atualmente estacionados no estacionamento.

### Métodos de validação
- ValidarPlaca(string placa): Verifica se uma placa de veículo está no formato correto, seguindo o padrão brasileiro.
- ValidarTempoPermanencia(int tempo, out decimal taxaAdicional, decimal precoPorHora): Verifica se o tempo de permanência fornecido pelo usuário é válido e calcula uma taxa adicional, se necessário.
### Exceções
- O código lida com exceções que podem ocorrer durante a execução, como placa inválida, tentativa de remover um veículo não estacionado ou entrada inválida de horas.

### Observações
- O código é robusto, utilizando exceções para lidar com erros e fornecer mensagens claras ao usuário.
- Usa expressões regulares para validar o formato da placa.
- Calcula o valor do estacionamento com base nas horas de permanência e nas taxas definidas.
- Fornece feedback ao usuário durante todo o processo de adição e remoção de veículos.
