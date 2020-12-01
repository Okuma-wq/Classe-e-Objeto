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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(jogador1.nome);
            Console.ResetColor();
            Console.WriteLine(" o que deseja fazer?");
            Console.WriteLine("[1] - Ataque 1 (ataque de 10 de dano que pode acertar até 3 vezes)");
            Console.WriteLine("[2] - Ataque 2 (ataque de 20 de dano)");
            Console.WriteLine("[3] - Defesa (Diminui o dano recebido em 20)");
            Console.WriteLine("[4] - Cura (Cura de 10 a 40 pontos de vida)");
            do{
            jogador1.Escolha = int.Parse(Console.ReadLine());

            if (jogador1.vida >= 100 && jogador1.Escolha == 4){
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Sua vida ja está no máximo, escolha outra ação");
              Console.ResetColor();
            }
            }while (jogador1.vida >= 100 && jogador1.Escolha == 4);
            
            do{
            Random J2 = new Random();
            jogador2.Escolha = J2.Next(1, 5);
            }while (jogador2.vida >= 100 && jogador2.Escolha == 4);

            

            switch (jogador1.Escolha)
            {
              case 1:
                if(jogador2.Escolha == 3){
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador2.vida = jogador2.vida - jogador2.Defesa(jogador1.Ataque1());
                  int danoReduzido = jogador2.Defesa(jogador1.Ataque1());
                  Console.WriteLine($"{jogador2.nome} se defendeu e tomou {danoReduzido} de dano!");
                }else{
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador2.vida = jogador2.vida - jogador1.Ataque1();
                  Console.WriteLine($"{jogador2.nome} levou {jogador1.Ataque1()} de dano!");
                }
                break;
              case 2:
                if(jogador2.Escolha == 3){
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador2.vida = jogador2.vida - jogador2.Defesa(jogador1.Ataque2());
                  Console.WriteLine($"{jogador2.nome} se defendeu e tomou 0 de dano!?");
                }else{
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador2.vida = jogador2.vida - jogador1.Ataque2();
                  Console.WriteLine($"{jogador2.nome} levou {jogador1.Ataque2()} de dano!");
                }
                break;
              case 3:
                break;
              case 4:
                Console.ForegroundColor = ConsoleColor.Green;
                jogador1.vida = jogador1.Cura();
                Console.WriteLine($"{jogador1.nome} se curou ficou com {jogador1.Cura()} de vida!?");
                break;
              default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digitou coisa inválida merece tomar uma de graça!!!");
                Console.ResetColor();
                break;
            }

            switch (jogador2.Escolha)
            {
              case 1:
                if(jogador1.Escolha == 3){
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador1.vida = jogador1.vida - jogador1.Defesa(jogador2.Ataque1());
                  int danoReduzido = jogador1.Defesa(jogador2.Ataque1());
                  Console.WriteLine($"{jogador1.nome} se defendeu e tomou {danoReduzido} de dano!");                  
                }else{
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador1.vida = jogador1.vida - jogador2.Ataque1();
                  Console.WriteLine($"{jogador1.nome} levou {jogador2.Ataque1()} de dano!");
                }
                break;
              case 2:
                if(jogador1.Escolha == 3){
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador1.vida = jogador1.vida - jogador1.Defesa(jogador2.Ataque2());
                  Console.WriteLine($"{jogador1.nome} se defendeu e tomou 0 de dano!?");
                }else{
                Console.ForegroundColor = ConsoleColor.Red;
                  jogador1.vida = jogador1.vida - jogador2.Ataque2();
                  Console.WriteLine($"{jogador1.nome} levou {jogador2.Ataque2()} de dano!");
                }
                break;
              case 3:
                if (jogador1.Escolha == 3 && jogador2.Escolha == 3){
                  Console.ForegroundColor = ConsoleColor.Gray;
                  Console.WriteLine("Ambos tentaram se defender ao mesmo tempo?!");
                }
                break;
              case 4:
                Console.ForegroundColor = ConsoleColor.Green;
                jogador2.vida = jogador2.Cura();
                Console.WriteLine($"{jogador2.nome} se curou ficou com {jogador2.Cura()} de vida!?");
                break;
              default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digitou coisa inválida merece tomar uma de graça");
                Console.ResetColor();
                break;
            }
          
          Console.ResetColor();
          
          if (jogador1.vida < 0){
            jogador1.vida = 0;
          }
          if (jogador2.vida < 0){
            jogador2.vida = 0;
          }

          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine($"{jogador1.nome} está com {jogador1.vida} de vida e {jogador2.nome} está com {jogador2.vida} de vida");
          Console.ResetColor();
            

          }while(jogador1.vida > 0 && jogador2.vida > 0);

          if(jogador1.vida == 0){
            Console.WriteLine($"JOGADOR 2 {jogador2.nome} É O VENCEDOR!!!");
          }
          if(jogador2.vida == 0){
            Console.WriteLine($"JOGADOR 1 {jogador1.nome} É O VENCEDOR!!!");
          }
          if(jogador1.vida == 0 && jogador2.vida == 0){
            Console.WriteLine($"{jogador1.nome} E {jogador2.nome} CAIRAM AO MESMO TEMPO, TEMOS UM EMPATE!!!");
          }

          // int vidaDoJogador2 = jogador2.Defesa(jogador2.Ataque1());
          // if(vidaDoJogador2 <= 0){
          //           Console.WriteLine("O jogador morreu");
          // }else{
          //      Console.WriteLine($"Jogador 2 depois do ataque ficou com {jogador2.vida} de vida");
          // }
        }
    }
}
