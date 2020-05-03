﻿using DevIO.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DevIO.Business.Notificacoes
{
    public class Notificacao
    {
        public string Mensagem { get; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }


    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;


        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {

            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacao()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
