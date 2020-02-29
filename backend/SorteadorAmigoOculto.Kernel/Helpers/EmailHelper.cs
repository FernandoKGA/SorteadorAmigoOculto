using System;
using System.Collections.Generic;
using System.IO;
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
            mailMessage.Subject = "Sorteador Amigo Oculto - Aqui está seu amigo oculto!";
            mailMessage.Body = GenerateBodyForEmail(pessoas.Value,identificadorSorteio);
            mailMessage.IsBodyHtml = true;
            return mailMessage;
        }

        private static string GenerateBodyForEmail(PessoaDTO pessoaDTO, Guid identificadorSorteio)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"EmailTemplates\","SorteioEmail.html");
            string html = File.ReadAllText(path);
            html = html.Replace("[[guid]]", identificadorSorteio.ToString());
            html = html.Replace("[[name]]", pessoaDTO.Nome);
            html = html.Replace("[[email]]", pessoaDTO.Email);
            return html;
        }
    }
}