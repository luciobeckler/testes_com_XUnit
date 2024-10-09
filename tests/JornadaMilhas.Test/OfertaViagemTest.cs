using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTest
    {
        [Fact]
         public void TestandoOfertaValida()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100;

            var validacao = true;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void TestandoErro()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100;


            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        }

        [Fact]
        public void TestandoPrecoNegativo()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = -100;


            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}