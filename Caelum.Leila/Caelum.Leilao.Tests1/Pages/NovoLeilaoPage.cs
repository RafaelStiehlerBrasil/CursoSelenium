using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class NovoLeilaoPage
    {
        private IWebDriver driver;

        public NovoLeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void cadastra(String nome, String valorInicial, string usuario, bool usado)
        {
            IWebElement campoNome = driver.FindElement(By.Name("leilao.nome"));
            campoNome.SendKeys(nome);

            IWebElement campoValorInicial = driver.FindElement(By.Name("leilao.valorInicial"));
            campoValorInicial.SendKeys(valorInicial);

            SelectElement cbUsuario = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));
            cbUsuario.SelectByText(usuario);

            if (usado)
            {
                IWebElement ckUsado = driver.FindElement(By.Name("leilao.usado"));
                ckUsado.Click();
            }

            campoNome.Submit();
            Thread.Sleep(2000);
        }

        public bool existeMensagemValidacaoLeilao(String mensagem)
        {
            return driver.PageSource.Contains(mensagem);

        }
    }
}
