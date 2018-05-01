using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Caelum.Leilao
{
    [TestFixture]
    public class UsuariosSystemTest
    {

        private IWebDriver firefox;
        private UsuarioPage usuario;
        private NovoUsuarioPage novoUsuario;

        [SetUp]
        public void AntesDosTestes()
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
            usuario     = new UsuarioPage(firefox);
            novoUsuario = new NovoUsuarioPage(firefox);
        }

        [TearDown]
        public void DepoisDosTestes()
        {
            firefox.Close();
        }

        [Test]
        public void DeveCadastrarEditarExcluirUsuario()
        {
            usuario.visita();

            usuario.novo().cadastra("Renan", "renan.saggio@gmail.com");

            Assert.IsTrue(usuario.existeNaListagem("Renan", "renan.saggio@gmail.com"));

            usuario.Altera(1).Para("Rafael Stiehler", "rafael.stiehler@gmail.com");

            Assert.IsTrue(usuario.existeNaListagem("Rafael Stiehler", "rafael.stiehler@gmail.com"));

            usuario.ExcluirUsuario();

            Assert.IsFalse(usuario.existeNaListagem("Renan", "renan.saggio@gmail.com"));
        }

        [Test]
        public void DeveValidarNome()
        {
            usuario.visita();

            usuario.novo().cadastra("", "renan.saggio@gmail.com");

            Assert.IsTrue(novoUsuario.existeMensagemValidacao("Nome obrigatorio!"));

        }

        [Test]
        public void DeveValidarNomeEmail()
        {
            usuario.visita();

            usuario.novo().cadastra("", "");

            Assert.IsTrue(novoUsuario.existeMensagemValidacao("Nome obrigatorio!"));
            Assert.IsTrue(novoUsuario.existeMensagemValidacao("E-mail obrigatorio!"));
        }


    }
}
