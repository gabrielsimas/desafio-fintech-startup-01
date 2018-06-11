using System.Collections.Generic;

namespace SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado
{
    public abstract class Validacao
    {
        private static List<string> erros = new List<string>();        

        public static bool EhValida { get; protected set; }
        public static void MensagemDaValidacao(string mensagem)
        {
            erros.Add(mensagem);
            if (EhValida) EhValida = false;
        }

        public static string ListaErrosDeValidacao()
        {
            return erros.Count > 0 ? string.Join("\n", erros.ToArray()) : null;
        }
    }
}
