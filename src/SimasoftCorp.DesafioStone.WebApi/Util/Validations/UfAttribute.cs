using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimasoftCorp.DesafioStone.WebApi.Util.Validations
{
    public class UfAttribute : ValidationAttribute
    {
        private readonly string[] estadosDaFederacao = new string[] { "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA","MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN","RO","RR","RS","SC","SE","SP","TO" };
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (estadosDaFederacao.Contains(value.ToString())) return ValidationResult.Success;
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}