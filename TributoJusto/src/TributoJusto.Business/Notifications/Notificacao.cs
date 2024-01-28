using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TributoJusto.Business.Notifications
{
    public class Notificacao
    {
        public string Mensagem { get; set; }
        public string Propriedade { get; set; }

        public Notificacao(string mensagem)
        {
            this.Mensagem = mensagem;
        }

        public Notificacao(string mensagem, string propriedade)
        {
            this.Mensagem = mensagem;
            this.Propriedade = propriedade;
        }
    }
}
