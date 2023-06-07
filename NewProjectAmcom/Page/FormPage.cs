using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoAmcom.Page;

public class FormPage
{
    private readonly ILocator _txtNome;
    private readonly ILocator _txtSobreNome;
    private readonly ILocator _txtTelefone;
    private readonly ILocator _btnEnviar;
    private readonly ILocator _lnkPopUpMensage;
    private readonly ILocator _btnSelecionarCor;
    private readonly ILocator _btnClose;
    private readonly IPage _page;

    public FormPage(IPage page)
    {
        _page = page;
        _txtNome = page.Locator("#fname");
        _txtSobreNome = page.Locator("#lname");
        _txtTelefone = page.Locator("#phone");
        _btnSelecionarCor = page.Locator("text=Selecione uma cor");
        _btnEnviar = page.Locator("text=Enviar");
        _lnkPopUpMensage = page.Locator("text=Enviado com sucesso");
        _btnClose = page.Locator("xpath=//button[contains(@onclick,'closeModal()')]");

    }



    public async Task ClickSelecionar()
    {
        await _btnSelecionarCor.ClickAsync();
    }

    public async Task ClickEnviar()
    {
        await _btnEnviar.ClickAsync();
    }

    public async Task Form(string Nome, string Sobrenome, int Telefone)
    {
        await _txtNome.FillAsync(Nome);
        await _txtSobreNome.FillAsync(Sobrenome);
        await _txtTelefone.FillAsync(Telefone.ToString());

    }

    public async Task<bool> ConfirmMensage()
    {
        return await _lnkPopUpMensage.IsVisibleAsync();
    }

    public async Task ClickClose()
    {
        await _btnClose.ClickAsync();
    }

}

