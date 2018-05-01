using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeiloesSystemTest
    {

        private IWebDriver firefox;
        private LeilaoPage leilao;
        private NovoLeilaoPage novoLeilao;
        private UsuarioPage usuario;
        private NovoUsuarioPage novoUsuario;

        [SetUp]
        public void AntesDosTestes()
        {
            firefox    = new FirefoxDriver();
            firefox.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
            leilao     = new LeilaoPage(firefox);
            novoLeilao = new NovoLeilaoPage(firefox);
            usuario = new UsuarioPage(firefox);
            novoUsuario  = new NovoUsuarioPage(firefox);
            usuario.visita();
            usuario.novo().cadastra("Renan", "renan@caelum.com.br");
            usuario.novo().cadastra("Paulo", "paulo@caelum.com.br");

        }

        [TearDown]
        public void DepoisDosTestes()
        {
            firefox.Close();
        }

        [Test]
        public void DeveCadastrarLeilao()
        {

            leilao.visita();

            leilao.novo().cadastra("Geladeira", "123", "Renan", true);

            Assert.IsTrue(leilao.existeNaListagem("Geladeira", 123, "Renan", true));

        }

        [Test]
        public void DeveValidarNomeValorInicial()
        {

            leilao.visita();

            leilao.novo().cadastra("", "", "Renan", true);

            Assert.IsTrue(novoLeilao.existeMensagemValidacaoLeilao("Nome obrigatorio!"));
            Assert.IsTrue(novoLeilao.existeMensagemValidacaoLeilao("Valor inicial deve ser maior que zero!"));
        }

        [Test]
        public void DeveDarLance()
        {


            leilao.visita();

            leilao.novo().cadastra("Geladeira", "250", "Renan", true);

            DetalhesDoLeilaoPage lances = leilao.detalhes(1);

            lances.lance("Paulo", 150);

            Assert.IsTrue(lances.existeLance("Paulo", 150));
        }
    }
}
