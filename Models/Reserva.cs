namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suite é maior ou igual ao número de hóspedes recebidos
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A suite nao suporta a quantidade de hospedes que serao recebidos.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calculo da diaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se os dias reservados forem >= a 10, conceder um desconto de 10%. Se nao, valor sem desconto
            return (DiasReservados >= 10) ? valor - (valor * 10 / 100) : valor;
        }
    }
}