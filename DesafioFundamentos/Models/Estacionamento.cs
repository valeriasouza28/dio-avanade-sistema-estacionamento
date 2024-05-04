using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Implementado!!!!!
            //Solicita a placa do veículo ao usuário e armazena a placa
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            if (ValidarPlaca(placa))
            {
                // Adiciona a placa do veículo à lista de veículos estacionados
                veiculos.Add(placa);

                // Confirmação de que o veículo foi estacionado com sucesso
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine($"A placa {placa} brasileira não foi identificada.");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine().ToUpper();
            if (ValidarPlaca(placa))
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    int horas = Convert.ToInt32(Console.ReadLine());

                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool ValidarPlaca(string placa)
        {
            // Verifica se a placa não está vazia
            if (string.IsNullOrEmpty(placa))
            {
                return false;
            }

            // Expressão regular para validar o padrão de placas de veículos brasileiras
            string pattern = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            // Verifica se a placa corresponde ao padrão
            return Regex.IsMatch(placa, pattern);
        }

        public bool ValidarTempoPermanencia(int tempo, out decimal taxaAdicional, out decimal valorTaxaPorHora)
        {

            // Define o limite máximo de tempo de prmanência
            int limiteMaximo = 24;

            //Verifica se o tempo é um número inteiro positivo
            if (tempo <= 0)
            {
                taxaAdicional = 0; // Não hé taxa adicional se o tempo for negativo ou zero
                return false;
            }

            //Verifica se o tempo está dentro do  limite razoável (24 horas por dia)
            if (tempo > limiteMaximo)
            {
                //Ccalcula a taxa adicional com base no tempo excedido
                int horasExcedidas = tempo - limiteMaximo;
                taxaAdicional = horasExcedidas * valorTaxaPorHora; // valorTaxaPorHora é o valor da taxa pora excedida
                return false; // Retorna falso, indicando que o tempo excedeu o limite
            }

            // Se passou por todas as verificações, retorna verdadeiro, e não há taxa adicional
            taxaAdicional = 0;
            return true;
        }
    }
}
