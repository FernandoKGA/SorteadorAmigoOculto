using System;
using System.Collections.Generic;
using System.Net.Mail;
using SorteadorAmigoOculto.Kernel.Model.DTO;

namespace SorteadorAmigoOculto.Kernel.Helpers
{
    public static class EmailHelper
    {
        public static MailMessage CriarMensagem(string from, KeyValuePair<PessoaDTO,PessoaDTO> pessoas, Guid identificadorSorteio)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(pessoas.Key.Email);
            mailMessage.Subject = "Sorteador Amigo Oculto - Aqui está seu amigo secreto!";
            mailMessage.Body = GenerateBodyForEmail(pessoas.Value,identificadorSorteio);
            mailMessage.IsBodyHtml = true;
            return mailMessage;
        }

        private static string GenerateBodyForEmail(PessoaDTO pessoaDTO, Guid identificadorSorteio)
        {
            
            return null;
        }
    }
}