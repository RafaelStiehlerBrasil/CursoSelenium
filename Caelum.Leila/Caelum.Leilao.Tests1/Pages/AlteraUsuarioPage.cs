using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class AlteraUsuarioPage
    {
        private IWebDriver driver;

        public AlteraUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public UsuarioPage Para(string nome, string email)
        {
            IWebElement txtNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement txtEmail = driver.FindElement(By.Name("usuario.email"));

            txtNome.Clear();
            txtEmail.Clear();
            txtNome.SendKeys(nome);
            txtEmail.SendKeys(email);

            txtNome.Submit();
            Thread.Sleep(1000);

            return new UsuarioPage(driver);
        }


    }

}
