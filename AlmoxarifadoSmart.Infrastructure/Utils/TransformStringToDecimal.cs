using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoSmart.Infrastructure.Utils;

public abstract class TransformStringToDecimal
{

    public static decimal StringToDecimal(string price)
    {
        // Define as configurações culturais para o Brasil
        CultureInfo cultureInfo = new CultureInfo("pt-BR");

        // Remove os caracteres especiais e espaços da string
        string cleanedPrice = price.Replace("R$", "").Trim();

        // Converte a string para decimal usando as configurações culturais adequadas
        decimal result = decimal.Parse(cleanedPrice, NumberStyles.Currency, cultureInfo);

        return result;
    }
}
