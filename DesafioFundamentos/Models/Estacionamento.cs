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
            if (precoInicial <= 0 || precoPorHora <= 0)
            {
                throw new ArgumentException("Os preços devem ser números positivos.");
            }
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            try
            {
                //Solicita a placa do veículo ao usuário e armazena a placa
                Console.WriteLine(
                    "Digite a placa do veículo para estacionar. Seguindo padrão brasileiro com 3 letras, 1 numero, 1 letra, 2 numeros:"
                    );
                string placa = Console.ReadLine().ToUpper();

                if (!ValidarPlaca(placa))
                {
                    throw new ArgumentException($"A placa {placa} brasileira não foi identificada.");

                }
                if (veiculos.Contains(placa))
                {
                    throw new InvalidOperationException("Este veículo já está estacionado.");
                }
                else
                {
                    // Adiciona a placa do veículo à lista de veículos estacionados
                    veiculos.Add(placa);

                    // Confirmação de que o veículo foi estacionado com sucesso
                    Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar veículo: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao adicionar veículo: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }

        }

        public void RemoverVeiculo()
        {
            try
            {
                if (veiculos.Count == 0)
                {
                    Console.WriteLine("Não há veículos estacionados para remover.");
                    return;
                }
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                string placa = Console.ReadLine().ToUpper();
                if (!ValidarPlaca(placa))
                {
                    throw new ArgumentException($"A placa {placa} brasileira não foi identificada.");
                }
                // Verifica se o veículo existe
                if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    throw new InvalidOperationException("O veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas; //= Convert.ToInt32(Console.ReadLine());//horas
                if (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
                {
                    throw new ArgumentException("Por favor, forneça um número válido de horas.");

                    return;
                }

                decimal valorTotal = 0;
                decimal taxaAdicional = 0;

                //Verifica se o tempo de permanencia é válido e calcula a taxa adicional, se necessário
                bool tempoValido = ValidarTempoPermanencia(horas, out taxaAdicional, precoPorHora);

                if (tempoValido)
                {

                    // Calcula valor total do estacionamento
                    valorTotal = precoInicial + precoPorHora * horas;
                }
                else
                {
                    // Define o limite máximo de tempo de prmanência
                    int limiteMaximo = 24;

                    // Se o  tempo excdeu o limite, adiciona a taxa adicional ao valor total
                    valorTotal = precoInicial + precoPorHora * limiteMaximo + taxaAdicional;
                }

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao remover veículo: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao remover veículo: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
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

        public bool ValidarTempoPermanencia(int tempo, out decimal taxaAdicional, decimal precoPorHora)
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
                //Calcula a taxa adicional com base no tempo excedido
                int horasExcedidas = tempo - limiteMaximo;
                taxaAdicional = horasExcedidas * precoPorHora; // valorTaxaPorHora é o valor da taxa pora excedida
                return false; // Retorna falso, indicando que o tempo excedeu o limite
            }

            // Se passou por todas as verificações, retorna verdadeiro, e não há taxa adicional
            taxaAdicional = 0;
            return true;
        }
    }
}
