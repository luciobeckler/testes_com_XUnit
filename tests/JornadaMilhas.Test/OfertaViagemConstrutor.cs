using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vitoria", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]

        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);                                                                                                                                                                        

            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemErroDeRotaOuPeriodoQuandoRotaNull()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100;


            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        }

        [Fact]
        public void RetornaMensagemErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = -100;


            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 01, 02), new DateTime(2024, 01, 01));
            double preco = -100;
            int quantidadeErrosEsperado = 3;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(quantidadeErrosEsperado, oferta.Erros.Count());
        }

    }
}