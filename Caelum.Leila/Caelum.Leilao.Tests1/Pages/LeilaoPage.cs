using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;


namespace Caelum.Leilao
{
    public class LeilaoPage
    {
        private IWebDriver driver;

        public LeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/leiloes");
        }

        public NovoLeilaoPage novo()
        {
            driver.FindElement(By.LinkText("Novo Leilão")).Click();
            return new NovoLeilaoPage(driver);
        }

        public bool existeNaListagem(string produto, double valor, string usuario, bool usado)
        {
            return driver.PageSource.Contains(produto) &&
                    driver.PageSource.Contains(Convert.ToString(valor)) &&
                    driver.PageSource.Contains(usuario) &&
                    driver.PageSource.Contains(usado ? "Sim" : "Não");
        }


        public bool existeMensagemValidacao(String mensagem)
        {
            return driver.PageSource.Contains(mensagem);

        }

        public DetalhesDoLeilaoPage detalhes(int posicao)
        {
            driver.FindElements(By.LinkText("exibir"))[posicao - 1].Click();
            return new DetalhesDoLeilaoPage(driver);

        }

    }
}
