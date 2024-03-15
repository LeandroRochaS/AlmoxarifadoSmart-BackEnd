
using AlmoxarifadoSmart.API;
using AlmoxarifadoSmart.Application.Services.Implementations.Log;
using AlmoxarifadoSmart.Application.Services.Interfaces;
using AlmoxarifadoSmart.Core.Entities;
using AlmoxarifadoSmart.Core.Enums;
using AlmoxarifadoSmart.Infrastructure.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AlmoxarifadoSmart.Application.Scrapers;

public class ScraperMagazineLuiza : IScraperMagazineLuiza
{

    private readonly ILogService _registerLogService;

    public ScraperMagazineLuiza(ILogService registerLogService)
    {
        _registerLogService = registerLogService;
    }

    public StoreProdutoModel GetInfoProduct(string descricaoProduto, int idProduto)
    {

        StoreProdutoModel produtoScraper = new StoreProdutoModel();
        try
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.SetLoggingPreference("browser", OpenQA.Selenium.LogLevel.All);
            chromeOptions.SetLoggingPreference("driver", OpenQA.Selenium.LogLevel.All);
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--disable-gpu");

            // Desativa as mensagens no console do Chrome
            chromeOptions.AddArgument("--disable-logging");
            chromeOptions.AddArgument("--log-level=3");
            chromeOptions.AddArgument("--silent");

            // Inicializa o ChromeDriver com as opções configuradas
            using (IWebDriver driver = new ChromeDriver(chromeOptions))
            {


                // Abre a página
                driver.Navigate().GoToUrl($"https://www.magazineluiza.com.br/busca/{descricaoProduto}");

          

                // Encontra o elemento que possui o atributo data-testid
                IWebElement priceElement = driver.FindElement(By.CssSelector("[data-testid='price-value']"));

                IWebElement tagAElement = driver.FindElement(By.CssSelector("[data-testid='product-card-container']"));

                var link = tagAElement.GetAttribute("href");

                // Verifica se o elemento foi encontrado
                if (priceElement != null && link != null)
                {

                    // Obtém o preço do primeiro produto
                    string firstProductPrice = priceElement.Text;

                    produtoScraper.Price = TransformStringToDecimal.StringToDecimal(firstProductPrice);
                    produtoScraper.Link = link;
                    produtoScraper.Store = StoresEnum.MagazineLuiza;

                    // Registra o log com o ID do produto
                    _registerLogService.RegistrarLog("leandrorocha", DateTime.Now, "WebScraping - Magazine Luiza", "Sucesso", idProduto);

                    // Retorna o preço
                    return produtoScraper;
                }
                else
                {
                    Console.WriteLine("Preço não encontrado.");

                    // Registra o log com o ID do produto
                    _registerLogService.RegistrarLog("leandrorocha", DateTime.Now, "WebScraping - Magazine Luiza", "Preço não encontrado", idProduto);

                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a página: {ex.Message}");

            // Registra o log com o ID do produto
            _registerLogService.RegistrarLog("leandrorocha", DateTime.Now, "Web Scraping - Magazine Luiza", $"Erro: {ex.Message}", idProduto);

            return null;
        }
    }


}