using NUnit.Framework;
using ProjetoAmcom.Drivers;
using ProjetoAmcom.Page;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Playwright;
using System.Runtime.CompilerServices;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoAmcom.StepDefinitions
{
    [Binding]
    public class AmcomAutomationStep
    {
        private readonly Driver _driver;
        private readonly FormPage _formPage;

        public AmcomAutomationStep(Driver driver)
        {
            _driver = driver;
            _formPage = new FormPage(_driver.Page);
        }

        [Given(@"I, navigate application")]
        public async Task GivenINavigateToApplication()
        {
            await _driver.Page.GotoAsync("https://amcomtesteqa.z15.web.core.windows.net/");
        }

        [When(@"fill in the textbox of the form")]
        public async Task WhenFillInTheTextboxOfTheForm(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _formPage.Form((string)data.Nome, (string)data.SobreNome, (int)data.Telefone);
        }

        [When(@"fill in the textbox of the form reduced")]
        public async Task WhenFillInTheTextboxOfTheFormReduced(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _formPage.Form2((string)data.Nome, (string)data.SobreNome);
        }


        [When(@"fill in the textbox of the form most reduced")]
        public async Task WhenFillInTheTextboxOfTheFormMostReduced(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _formPage.Form3((string)data.Nome);
        }

        [When(@"I wait for (.*) seconds")]
        public void WhenIWaitForSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [When(@"I click in Selector color")]
        public async Task WhenIClickInSelectorColor()
        {
            await _driver.Page.ClickAsync("#colors");
        }

        [When(@"I Click Enviar Button")]
        public async Task WhenIClickEnviarButton()
        {
            await _formPage.ClickEnviar();
        }

        [Then(@"App return mensage confirm")]
        public async Task ThenAppReturnMensageConfirm()
        {
            var isExist = await _formPage.ConfirmMensage();
            Assert.IsTrue(isExist);
        }

        [Then(@"I closed the popup")]
        public async Task ThenIClosedThePopup()
        {
            await _formPage.ClickClose();
        }

        [Then(@"Wait to confirm (.*) seconds close")]
        public async Task ThenWaitToConfirmSecondsClose(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [Then(@"The element id ""([^""]*)"" with the color ""([^""]*)""")]
        public async Task ThenTheElementIdWithTheColor(string elementId, string corEsperada)
        {
            var elementHandle = await _driver.Page.QuerySelectorAsync($"{elementId}");
            var actualBackgroundColor = await elementHandle.EvaluateAsync("element => getComputedStyle(element).backgroundColor");

            // Verifica se a cor atual é igual à cor esperada
            Assert.AreEqual($"{corEsperada}", $"{actualBackgroundColor}");
        }


        [When(@"I scroll the page down")]
        public async Task GivenIScrollThePageDown()
        {
            await _driver.Page.EvaluateAsync("window.scrollBy(0, 500)");

        }

        [Given(@"I waiting (.*) seconds")]
        public async Task GivenIWaitingSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [When(@"I select to a color blue")]
        public async Task WhenISelectToAColorBlue()
        {
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("Enter");
        }

        [When(@"I select to a color Yellow")]
        public async Task WhenISelectToAColorYellow()
        {
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("Enter");
        }

        [When(@"I select to a color Red")]
        public async Task WhenISelectToAColorRed()
        {
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("ArrowDown");
            await _driver.Page.Keyboard.PressAsync("Enter");
        }

        [When(@"I click in Saudação button")]
        public async Task WhenIClickInSaudacaoButton()
        {
            await _formPage.ClickSaudacao();
        }

        [Then(@"The app returns a greeting message")]
        public async Task ThenTheAppReturnsAGreetingMessage()
        {
            bool isMorningAlertDisplayed = false;
            bool isAfternoonAlertDisplayed = false;
            bool isEveningAlertDisplayed = false;

            _driver.Page.Dialog += async (_, args) =>
            {
                string dialogMessage = args.Message;

                if (dialogMessage == "Bom dia")
                {
                    isMorningAlertDisplayed = true;
                }
                else if (dialogMessage == "Boa tarde")
                {
                    isAfternoonAlertDisplayed = true;
                }
                else if (dialogMessage == "Boa noite")
                {
                    isEveningAlertDisplayed = true;
                }

                await args.DismissAsync();
            };

            await _formPage.ClickSaudacao();

            Console.WriteLine(isMorningAlertDisplayed ? "O alerta 'Bom dia' foi exibido." : "O alerta 'Bom dia' não foi exibido.");
            Console.WriteLine(isAfternoonAlertDisplayed ? "O alerta 'Boa tarde' foi exibido." : "O alerta 'Boa tarde' não foi exibido.");
            Console.WriteLine(isEveningAlertDisplayed ? "O alerta 'Boa noite' foi exibido." : "O alerta 'Boa noite' não foi exibido.");


        }
    }
}
