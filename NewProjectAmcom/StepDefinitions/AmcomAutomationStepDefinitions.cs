using NUnit.Framework;
using ProjetoAmcom.Drivers;
using ProjetoAmcom.Page;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Playwright;
using System.Runtime.CompilerServices;

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

    }
}
