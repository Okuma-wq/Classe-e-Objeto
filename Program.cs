using System;

namespace Personagens
{
    class Program
    {
        static void Main(string[] args)
        {
          //Instaciando objeto
          

          Personagem jogador1 = new Personagem();
          Console.WriteLine("Jogador 1, digite:");
          Console.Write("Nome: ");
          Console.ForegroundColor = ConsoleColor.Yellow;
          jogador1.nome = Console.ReadLine();
          Console.ResetColor();
          Console.Write("Idade: ");
          Console.ForegroundColor = ConsoleColor.Yellow;
          jogador1.idade = int.Parse(Console.ReadLine());
          Console.ResetColor();
          Console.Write("Armadura: ");
          Console.ForegroundColor = ConsoleColor.Yellow;
          jogador1.armadura = Console.ReadLine();
          Console.ResetColor();
          Console.Write("IA: ");
          Console.ForegroundColor = ConsoleColor.Yellow;
          jogador1.iA = Console.ReadLine();
          Console.ResetColor();
          
          Personagem jogador2 = new Personagem();
          jogador2.nome = "João";
          jogador2.idade = 20;
          jogador2.armadura = "MK3";
          
          Console.Clear();
          Console.WriteLine($"Partida = {jogador1.nome} VS {jogador2.nome}");
          Console.WriteLine($"Idade Jogador 1: {jogador1.idade} || Idade Jogador 2: {jogador2.idade}");
          Console.WriteLine($"Armadura Jogador 1: {jogador1.armadura} || Armadura Jogador 2: {jogador2.armadura}");
          Console.WriteLine($"Jogador 1 IA: {jogador1.iA} || Jogador 2 IA: {jogador2.iA}");

          do{
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(jogador1.nome);
            Console.ResetColor();
            Console.WriteLine(" o que deseja fazer?");
            Console.WriteLine("[1] - Ataque 1 (ataque de 10 de dano que pode acertar até 3 vezes)");
            Console.WriteLine("[2] - Ataque 2 (ataque de 20 de dano)");
            Console.WriteLine("[3] - Defesa (Diminui o dano recebido em 20)");
            Console.WriteLine("[4] - Cura (Cura de 10 a 40 pontos de vida)");
            jogador1.Escolha = int.Parse(Console.ReadLine());

            Random J2 = new Random();
            jogador2.Escolha = J2.Next(1, 4);

            switch (jogador1.Escolha)
            {
              case 1:
                if(jogador2.Escolha == 3){
                  jogador2.vida = jogador2.Defesa(jogador1.Ataque1());
                }else{
                  jogador2.vida = jogador2.vida - jogador1.Ataque1();
                }
                break;
              case 2:
                if(jogador2.Escolha == 3){
                  jogador2.vida = jogador2.Defesa(jogador1.Ataque2());
                }else{
                  jogador2.vida = jogador2.vida - jogador1.Ataque2();
                }
                break;
              case 3:
                break;
              case 4:
                jogador1.vida = jogador1.Cura();
                break;
              default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digitou coisa inválida merece tomar uma de graça");
                Console.ResetColor();
                break;
            }

            switch (jogador2.Escolha)
            {
              case 1:
                if(jogador1.Escolha == 3){
                  jogador1.vida = jogador1.Defesa(jogador2.Ataque1());
                }else{
                  jogador1.vida = jogador1.vida - jogador2.Ataque1();
                }
                break;
              case 2:
                if(jogador1.Escolha == 3){
                  jogador1.vida = jogador1.Defesa(jogador2.Ataque2());
                }else{
                  jogador1.vida = jogador1.vida - jogador2.Ataque2();
                }
                break;
              case 3:
                break;
              case 4:
                jogador2.vida = jogador2.Cura();
                break;
              default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digitou coisa inválida merece tomar uma de graça");
                Console.ResetColor();
                break;
            }

          if (jogador1.vida < 0){
            jogador1.vida = 0;
          }
          if (jogador2.vida < 0){
            jogador2.vida = 0;
          }

          Console.WriteLine($"{jogador1.nome} está com {jogador1.vida} de vida e {jogador2.nome} está com {jogador2.vida} de vida");
            

          }while(jogador1.vida > 0 && jogador2.vida > 0);

          // int vidaDoJogador2 = jogador2.Defesa(jogador2.Ataque1());
          // if(vidaDoJogador2 <= 0){
          //           Console.WriteLine("O jogador morreu");
          // }else{
          //      Console.WriteLine($"Jogador 2 depois do ataque ficou com {jogador2.vida} de vida");
          // }
        }
    }
}
