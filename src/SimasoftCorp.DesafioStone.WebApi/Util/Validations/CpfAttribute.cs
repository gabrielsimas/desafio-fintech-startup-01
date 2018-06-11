using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimasoftCorp.DesafioStone.WebApi.Util.Validations
{
    public class CpfAttribute:ValidationAttribute
    {      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool cpfValido = Cpf.CpfValido(value.ToString());

            if (cpfValido) return ValidationResult.Success;            
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));         
        }
    }
}