using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;


namespace Caelum.Leilao
{
    public class UsuarioPage
    {
        private IWebDriver driver;

        public UsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/usuarios");
        }

        public NovoUsuarioPage novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new NovoUsuarioPage(driver);
        }

        public bool existeNaListagem(String nome, String email)
        {
            return driver.PageSource.Contains(nome) &&
            driver.PageSource.Contains(email);

        }

        public AlteraUsuarioPage Altera(int posicao)
        {
            driver.FindElements(By.LinkText("editar"))[posicao - 1].Click();
            Thread.Sleep(1000);
            return new AlteraUsuarioPage(driver);
        }


        public void ExcluirUsuario()
        {
            int posicao = 1; // queremos o 1o botao da pagina
            driver.FindElements(By.TagName("button"))[posicao - 1].Click();
            // pega o alert que está aberto
            IAlert alert = driver.SwitchTo().Alert();
            // confirma
            alert.Accept();
            Thread.Sleep(1000);
        }

    }
}
