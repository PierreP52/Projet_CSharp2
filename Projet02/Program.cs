using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet02
{
    class Program
    {
        private static Candy[] candies;

        public static void LoadCandies()//Intégration des données dans Candy
        {
            candies = new Candy[25];
            candies [0] = new Candy("Wacky Monkey", 2.0m, 10);
            candies [1] = new Candy("Toxic Wate", 2.75m, 1);
            candies [2] = new Candy("Thumbs Dipper", 1.75m, 5);
            candies [3] = new Candy("Texte Messenger", 4.50m, 2);
            candies [4] = new Candy("Ring Pop", 0.75m, 0);
            candies [5] = new Candy("Sweetarts", 1.00m, 4);
            candies [6] = new Candy("Flip Phone Pop", 3.90m, 8);
            candies [7] = new Candy("Popeye Stick", 1.25m, 5);
            candies [8] = new Candy("Sour Foami Suret", 2.90m, 5);
            candies [9] = new Candy("Runts", 1.50m, 5);
            candies [10] = new Candy("Rockets", 0.90m, 1);
            candies [11] = new Candy("Rockets Géants", 0.90m, 5);
            candies [12] = new Candy("Sifflet", 2.75m, 4);
            candies [13] = new Candy("Shock Rocks", 1.00m, 5);
            candies [14] = new Candy("Slime licker", 2.75m, 1);
            candies [15] = new Candy("Shark Bite", 3.60m, 8);
            candies [16] = new Candy("Gobstopper", 1.25m, 3);
            candies [17] = new Candy("Gyro Pop", 5.25m, 3);
            candies [18] = new Candy("Ka Dunks", 1.9m, 4);
            candies [19] = new Candy("Licky Loop", 0.9m, 6);
            candies [20] = new Candy("Wafers", 2.25m, 4);
            candies [21] = new Candy("Garbage Candy", 1.5m, 3);
            candies [22] = new Candy("Nerds Peche-Fruits", 2.0m, 7);
            candies [23] = new Candy("Nerds Raisins-Fraises", 2.0m, 4);
            candies [24] = new Candy("Nerds Framboise-Punch", 2.0m, 5);

           
        }
        public static int GetSelection(int count)//Fonction de selection du numéro du bonbon
        {

            if (count >= 1 && count <= 25)
            {
                LoadCandies();
            }
            else { Console.WriteLine("Choix erroné. Recommencez!"); Console.ReadKey(); }
                

            return count;
        }


        public static Candy GetCandy( int selection)// fonction pour retourner le bonbon
        {
            Candy candy;
            candy = candies[selection-1];

            return candy ;
        }

        public static decimal GetCoin(decimal received)//fonction relier au paiment
        {   
            decimal returned;
            string var;
            int choix;
            
                Console.WriteLine("[0] = Annuler");
                Console.WriteLine("[1] = 5c");
                Console.WriteLine("[2] = 10c");
                Console.WriteLine("[3] = 25c");
                Console.WriteLine("[4] = 1$");
                Console.WriteLine("[5] = 2$");
                repeat:
                Console.Write("->");

               
                var = Console.ReadLine();
                bool isChoix = int.TryParse(var.ToString(), out choix);//teste si la variable est un string ou un int et transformation en booleen
                if (isChoix)
                {
                        switch (choix)
                    
                            {
                            case 0:
                                returned = received;
                                received = Decimal.Negate(returned);// transformation du received en négatif
                                return received;

                            case 1:

                                received = received + 0.05m;//somme de chaque choix
                                return received;//retour de la somme total

                            case 2:

                                received = received + 0.10m;
                                return received;

                            case 3:

                                received = received + 0.25m;
                                return received;

                            case 4:

                                received = received + 1.00m;
                                return received;

                            case 5:

                                received = received + 2.00m;
                                return received;

                            default:// erreur
                                Console.WriteLine("Faites votre choix entre 0 et 5.");
                                
                                goto repeat;
                        }
                }
                else 
                {// message d'erreur
                    Console.WriteLine("Faites votre choix entre 0 et 5.");
                    
                    goto repeat; 
                }


}

        static void Main(string[] args)
        {

            while (true)
            {
                int count;
                int selection;
                string var;
                Candy candy; 

                do
                {
                    repeat:
                    Board.Print();
                    Console.Write("->");
                    var = Console.ReadLine();
                    bool isCount = int.TryParse(var.ToString(), out count);//teste si la variable est un string ou un int et transformation en booleen
                    if (isCount)
                    {
                        selection = GetSelection(count);
                    }
                    else { Console.WriteLine("Choix erroné. Recommencez!"); Console.ReadKey(); goto repeat; }// message d'erreur
                } while (count < 1 || count > 25);



                candy = GetCandy(selection);
                Board.Print(candy.Name, selection, candy.Price);// retour du choix de l'utilisateur
                

                if (candy.Stock == 0)
                {
                    Board.Print($"{candy.Name} VIDE!", selection);
                    Console.ReadKey();
                }
                else
                {
                    decimal received = 0;
                    decimal returned;
                    decimal erreur;
                   
                    

                    while (received < candy.Price) //tant que l'argent reçu est inférieur au prix
                    {
                        returned = GetCoin(received);
                        received = returned;
                        erreur = returned;
                        Board.Print(candy.Name, selection, candy.Price, received);

                        if (returned <= 0)//remise de l'argent en cas d'annulation
                        {

                            returned = Decimal.Negate(returned);//retour de la remise en positif
                            received = 0;

                            Board.Print(candy.Name, selection, candy.Price, received, returned);
                            Console.WriteLine("Annulée"); goto fin;
                        }
                        

                    }
                    
                    char answer;
                   
                    candy.Stock--;
                    returned = received - candy.Price;//calcul de la remise d'argent
                    string message = (" Prennez votre friandise...");
                    Board.Print(message, selection, candy.Price, received, returned, candy.Name);

                    Console.WriteLine("Recommencer O/N");
                    answer = char.Parse(Console.ReadLine());
                    if (answer == 'N' || answer == 'n')
                    {
                        break;// fin du programme
                    }
                    
                fin:
                Console.WriteLine("\nAppuyez sur une touche pour acheter d'autre bonbon...");
                Console.ReadKey();
                    // retour au début
                }
            }
        }
    }
}
