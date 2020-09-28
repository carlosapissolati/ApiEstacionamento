using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEstacionamento.Domain.ValueObject
{
    public static class Cnpj 
    {

        public static bool VerificarCnpjValido(string _value)
        {
            if (string.IsNullOrEmpty(_value)) return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            _value = _value.Trim();
            _value = _value.Replace(".", "").Replace("-", "").Replace("/", "");
            if (_value.Length != 14)
                return false;
            tempCnpj = _value.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return _value.EndsWith(digito);
        }
    }
}
