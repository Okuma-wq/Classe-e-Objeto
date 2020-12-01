using System;
namespace Personagens
{
    public class Personagem
    {
        public string nome;
        public int idade;
        public string armadura;
        public string iA = "Jarvis";

        public int vida = 100;
        public int Escolha = 0;
        public int EscolhaJ2 = 0;

        public int dano;
        
        public int Ataque1(){
            Random numAleatorio = new Random();
            dano = 10 * numAleatorio.Next(1, 4);
            return dano;
        }

        public int Ataque2(){
            dano = 20;
            return dano;
        }

        public int Defesa(int dano){

            int danoReduzido = dano - 20;
            
            if (danoReduzido <= 0){
                danoReduzido = 0;
            }

            this.vida = this.vida - danoReduzido;

            return this.vida = this.vida - danoReduzido;
        }

        public int Cura(){
            Random numAleatorio = new Random();
            int VdCurada = 10 * numAleatorio.Next(1, 5);

            this.vida = this.vida + VdCurada;

            if (this.vida >= 100){
                this.vida = 100;
            }

            return this.vida;
        }
    }
}