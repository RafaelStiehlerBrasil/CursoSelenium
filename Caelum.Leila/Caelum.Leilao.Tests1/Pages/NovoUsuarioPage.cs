using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class NovoUsuarioPage
    {
        private IWebDriver driver;

        public NovoUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void cadastra(String nome, String email)
        {
            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));

            campoNome.SendKeys(nome);
            campoEmail.SendKeys(email);

            campoNome.Submit();
            Thread.Sleep(2000);
        }

        public bool existeMensagemValidacao(String mensagem)
        {
            return driver.PageSource.Contains(mensagem);

        }
    }
}
