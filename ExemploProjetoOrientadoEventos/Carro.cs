using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploProjetoOrientadoEventos
{
    public class Carro
    {
        private bool ligado;
        private int velocidade;

        // Definindo os eventos
        public event EventHandler CarroLigado;
        public event EventHandler<int> VelocidadeAlterada;

        public bool Ligado
        {
            get { return ligado; }
        }

        public int Velocidade
        {
            get { return velocidade; }
        }

        public void Ligar()
        {
            if (!ligado)
            {
                ligado = true;
                Console.WriteLine("Carro ligado.");
                OnCarroLigado();
            }
        }

        public void Desligar()
        {
            if (ligado)
            {
                ligado = false;
                velocidade = 0;
                Console.WriteLine("Carro desligado.");
            }
            else
            {
                Console.WriteLine("O carro já está desligado.");
            }
        }

        public void Acelerar(int quantidade)
        {
            if (ligado)
            {
                velocidade += quantidade;
                Console.WriteLine($"Acelerando. Velocidade: {velocidade} km/h");
                OnVelocidadeAlterada();
            }
            else
            {
                Console.WriteLine("O carro precisa estar ligado para acelerar.");
            }
        }

        public void Frear(int quantidade)
        {
            if (ligado)
            {
                velocidade = Math.Max(0, velocidade - quantidade);
                Console.WriteLine($"Freando. Velocidade: {velocidade} km/h");
                OnVelocidadeAlterada();
            }
            else
            {
                Console.WriteLine("O carro precisa estar ligado para frear.");
            }
        }

        // Método privado para acionar o evento CarroLigado
        private void OnCarroLigado()
        {
            CarroLigado?.Invoke(this, EventArgs.Empty);
        }

        // Método privado para acionar o evento VelocidadeAlterada
        private void OnVelocidadeAlterada()
        {
            VelocidadeAlterada?.Invoke(this, velocidade);
        }
    }
}
