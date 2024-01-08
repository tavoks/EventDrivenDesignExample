using ExemploProjetoOrientadoEventos;

class program
{
    static void Main()
    {
        Carro meuCarro = new Carro();

        //Assinando os eventos

        meuCarro.CarroLigado += CarroLigadoHandler;
        meuCarro.VelocidadeAlterada += VelocidadeAlteradaHandler;

        meuCarro.Ligar();
        meuCarro.Acelerar(20);
        meuCarro.Frear(5);
        meuCarro.Desligar();
    }

    static void CarroLigadoHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Evento: Carro ligado!");
    }

    static void VelocidadeAlteradaHandler(object sender, int novaVelocidade)
    {
        Console.WriteLine($"Evento: Velocidade alterada para {novaVelocidade} km/h");
    }
}

