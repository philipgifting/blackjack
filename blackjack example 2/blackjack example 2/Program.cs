using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_example_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int spelareKortVärde = 0;
            int dealerKortVärde = 0;
            int dealernsStartKort;
            bool boolValue = true;

            List<int> spelareAntalKort = new List<int>();
            List<int> dealerAntalKort = new List<int>();

            spelareKortVärde += giveRandomCard(); //giveRandomCard tar fram ett godtyckligt tal mellan och inklusive 1 och 11
            spelareKortVärde += giveRandomCard();
            spelareAntalKort.Add(2);

            // eftersom ess kan antingen ha värdet 1 eller 11 så blir det obligatoriskt att esset har vädet 1, om spelare får över 21 direkt.
            if (spelareKortVärde > 21)
            {
                spelareKortVärde -= 10;
            }

            dealerKortVärde += giveRandomCard();

            //Eftersom alltid dealern måste avslöja sitt egna första kort.

            dealernsStartKort = dealerKortVärde;

            dealerKortVärde += giveRandomCard();
            dealerAntalKort.Add(2);


            // eftersom ess kan antingen ha värdet 1 eller 11 så blir det obligatoriskt att esset har vädet 1, om dealern får över 21 direkt.
            if (dealerKortVärde > 21)
            {
                dealerKortVärde -= 10;
            }

            //spelarens tur

            while (true)
            {
                if (spelareKortVärde == 21)
                {
                    Console.WriteLine("Du har fått 21 och vunnit med dina " + spelareAntalKort.Count() + "kort");

                    break;
                }

                Console.WriteLine("Din hand är värd: " + spelareKortVärde.ToString() + " poäng, vill du ha ett till kort?");
                Console.WriteLine("Ja eller Nej");
                Console.WriteLine(" ");

                // vi vill bara att dealerns första kort skrivs ut endast en gång, annars skrivs samma värde ut flera gånger.
                if (boolValue == true)
                {
                    dealerFörstaKort(dealernsStartKort);
                    boolValue = false;
                }


                string svar = Console.ReadLine();
                Console.WriteLine(" ");
                svar = svar.ToLower(); //konverterar svaret till gemener, för att undvika felaktig inmatning.

                if (svar == "ja")
                {
                    spelareKortVärde += giveRandomCard();
                    spelareAntalKort.Add(1);

                    if (spelareKortVärde > 21)
                    {
                        Console.WriteLine("Du har fått över 21 och förlorat med dina " + spelareAntalKort.Count() + " kort");
                        break;
                    }

                    else
                    {
                        continue; 
                        //continue innebär att det tar dig tillbaka till början av while-loopen.
                        // detta else indrag saknar egentligen innebörd / är fullständigt värdelöst, men används för tydlighetens skull.
                    }
                }

                else if (svar == "nej")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Du har gjort en felaktig inmatning, försök igen");
                    continue;
                }
            }

            //dealerns tur

            if (spelareKortVärde <= 21)
            {
                //Om spelaren inte har fått över 21 och dealern har lägre så måste dealern dra kort.
                while (dealerKortVärde < 21 && dealerKortVärde < spelareKortVärde)
                {
                    dealerKortVärde += giveRandomCard();
                    dealerAntalKort.Add(1);
                }

                //kollar och checkar av för vem som nu har vunnit
                if (spelareKortVärde == dealerKortVärde)
                {
                    Console.WriteLine("Oavgjort!");
                    Console.WriteLine(" ");
                }

                else if (spelareKortVärde < dealerKortVärde && dealerKortVärde <= 21)
                {
                    dealerVunnit();
                }

                else if (dealerKortVärde > 21)
                {
                    Console.WriteLine("Dealern har fått över 21 och förlorat, du har vunnit!");
                }

                else if (dealerKortVärde == 21)
                {
                    dealerVunnit();
                }
            }

            else
            {
                Console.WriteLine("Dealern har vunnit, eftersom du har fått över 21 och förlorat!");
            }

            Console.WriteLine("Din hand var värd: " + spelareKortVärde.ToString());
            Console.WriteLine("Dealerns hand var värd: " + dealerKortVärde.ToString());
            Console.ReadLine();
        }

        public static int giveRandomCard() //skapar en funktion, eftersom koden återanvänds. onödigt att skriva igen och lättare vid felsökning. slumpar ett heltal x, där 1 <= x <= 11.
        {
            Random random = new Random();
            int randomValue = random.Next(1, 12);
            return randomValue;

        }
        public static void dealerVunnit() //skapar en funktion, eftersom koden återanvänds. onödigt att skriva igen och lättare vid felsökning. skriver ut att dealern har vunnit, void funktion.
        {
            string temp = "Dealern har vunnit!";
            Console.WriteLine(temp);
        }

        public static void dealerFörstaKort(int förstaKort) //funktionen behandlar dealerns första kort och skrivet ut det.
        {
            Console.WriteLine("Dealerns ena första kort är: " + förstaKort.ToString());
            Console.WriteLine(" ");
        }




    }
}
