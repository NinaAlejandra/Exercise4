using System;
using System.Reflection.PortableExecutable;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
    
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Reverse a Text"
                    + "\n5. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseText();
                        break;
                    case '5':
                        CheckParanthesis(); 
                        break;
                    
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        //1. Stacken: stacken används främst för att hålla reda på exekveringsordningen i ett program och för att lagra lokala variabler inne i funktioner.
        //Den fungerar som en stapel där det senaste tillagda elementet är det första som tas bort. Åtkomst och hantering på stacken är snabb eftersom den är organiserad och strukturerad.
        //Heapen : heapen används för att lagra stora eller komplicerade saker som tar upp mycket plats som till exempel bilder, långa texter osv. Det är som en stor lagringsplats där vi kan 
        //ställa in saker och hämta dem senare när vi behöver dem. Som en virtuell låda där vi kan spara olika saker. När vi lägger till saker i heapen så kommer de att stanna där tills vi säger åt datorn att ta bort dem.
         
        //exempel: Tänk på stacken som en bok där du kan bläddra fram och tillbaka. Information som är staplat på varann i form sidor i en bok. 
         //exempel:Medan heapen är snarare ett bibliotek, med adresser till böckerna. Men böckerna kan ju byta plats. Det kan inte informationen på sidor göra. 

        //2. Value types: En variabel av en värdetyp som innehåller själva datavärdet, dessa lagras i stacken. Exempel på value types är int, char, bool etc.
        // Reference types: En variabel som innehåller en referens (adress i heapen) till platsen där datan lagras. 
        
        //3. I första metoden kopierar y bara x från början. sedan ändras värdet på y till 4 men x påverkas inte eftersom y bara har en kopia av x-värdet. Så när man returnerar x i slutet så kommer den fortfarande att bara vara 3.
        // I andra metoden skapas två instanser av MyInt där x.MyValue sätts till tre. sedan tilldelas y värdet av x, vilket innebär att både x och y nu pekar på samma objekt. Så när man returnerar x.MyValue i slutet så är det 4 för 
        // att både x och y pekar mot värdet 4. 

   
        static void ExamineList() //raderar strängen som överensstämmer 
        {

            Console.WriteLine("Welcome to the list");
            List<string> ExamineList = new List<string>();

            while (true)
            {
               
                Console.WriteLine("\nEnter + to add - to remove (or press Enter to exit to main menu):");
                string input = Console.ReadLine();

                if(string.IsNullOrEmpty(input)) // om inputen är tom när man trycker på enter så går man ur loopen
                {
                    break;
                }

                char operation = input[0]; // sparar ner det första tecknet av inputen i variabeln operation
                string item = input.Substring(1).Trim(); //sparar ner resten av inputen i variabeln item och tar bort eventuella mellanslag

                switch (operation)
                {
                    case '+': 
                        ExamineList.Add(item);
                        break;

                    case '-':
                        ExamineList.Remove(item);
                        break;

                    default:
                        Console.WriteLine("Please use + or - before text");
                        break;
                }
               
               Console.WriteLine("\nContents of the list: ");
                foreach (var listItem in ExamineList) { Console.WriteLine(listItem);
                   
                }
              Console.WriteLine($"\nCount: {ExamineList.Count}, Capacity: {ExamineList.Capacity}");
            }
            
        }
        //1. Implementation av ExamineList står ovan
        //2. Listans kapacitet ökar när antalet element i listan överstiger den nuvarande kapaciteten.
        // Dvs, om kapaciteten är fyra, och listan når upp till det så ökar kapaciteten.
        //3. Kapaciteten ökar med en viss procentandel, beroende på implementeringen. Varierar hur mycket beroende på prestanda och minnesanvändning.
        //4. Att öka kapaciteten varje gång man lägger till något skulle vara slöseri med tid och minne. Istället ökar kapaciteten när det behövs.
        //5. Nej, kapaciteten minskar inte automatiskt. Den förblir densamma för att undvika onödigt arbete med att ändra storlek hela tiden. 
        //6. När man vet exakt hur många element man kommer att ha, och när man vill undvika belastningen på prestantan som uppstår när man hanterar en dynamisk lista.
        // En egendefinierad array kan ge större kontroll över lagringsallokering och åtkomst, vilket kan va en fördel då.


     
            static void ExamineQueue() //först in först ut
        {
           
                Queue<string> ExamineQueue = new Queue<string>();
                
            while (true) 
            { 
                Console.WriteLine("Welcome to the Queue \nEnter '+' to enqueue or '-' to dequeue (or Press Enter to exit to main menu):");
                string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) 
                {
                    break;
                }

                char operation = input[0];
                string item = input.Substring (1).Trim();

                switch (operation) 
                {
                case '+':   
                        ExamineQueue.Enqueue(item);
                        break;

                case '-':
                        if (ExamineQueue.Count > 0)
                        {
                           ExamineQueue.Dequeue();
                           
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Cannot dequeue.");
                        }

                        break;
                        
                        default:
                        Console.WriteLine("Enter '+' to add something to the queue or '-' to remove");
                        break;

                }

                Console.WriteLine("\nContents of the queue: ");
                foreach (var queueItem in ExamineQueue) 
                { 
                    Console.WriteLine(queueItem); 
                }   
           
            }

        }

        static void ExamineStack() //sist in först ut, som tallriksexemplet som jag nämnde tidigare.
        {
           
            
            Stack<string> ExamineStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("Welcome to the stack");
                string input = Console.ReadLine();

                if(string.IsNullOrEmpty(input))
                {
                    break;
                }
                char operation = input[0];
                string item = input.Substring(1).Trim();

                switch (operation)
                {
                    case '+':
                    ExamineStack.Push(item);
                    break;

                    case '-':
                        
                    if (ExamineStack.Count > 0)
                    {
                          ExamineStack.Pop();
                    }
                        else
                        {
                            Console.WriteLine("Stack is empty. Cannot pop.");
                        } 
                        break;

                    default: Console.WriteLine("Enter '+' to push an element to the stack or '-' to pop it");
                        break;
                }
                Console.WriteLine("\nContents of the stack: ");
                foreach (var stackItem in ExamineStack)
                {
                    Console.WriteLine(stackItem);
                }
            }
        }
        // 1. Det är inte smart att använda en stack vid simuleringen av en ica-kö för att här gäller först in sist ut.
        // Dvs skulle det vara en riktig kö, så skulle det innebär att den som stod först i kö, skulle få hjälp sist. 
        //2. Nedan följer ReverseText metoden, la till den som nummer fem i valmöjligheterna.

        static void ReverseText()
        {
            while (true)
            {
                Console.WriteLine("\nEnter a text to reverse");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                Stack<char> reverseStack = new Stack<char>();

                foreach (var stackItem in input)
                {
                    reverseStack.Push(stackItem);
                }

                Console.WriteLine("Reversed string: ");

                while (reverseStack.Count > 0)
                {
                    Console.Write(reverseStack.Pop());
                }
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
           
            Stack<char> openingParanthesis = new Stack<char>();
            
            while (true)
            {
                Console.WriteLine("\nWelcome to the Paranthesis Check. \nInput a string with paranthesis.");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                foreach (char paranthesis in input) {

                    if (paranthesis == '(' || paranthesis == '{' || paranthesis == '[')
                    {
                        openingParanthesis.Push(paranthesis);
                    }

                    else if (paranthesis == ')'  || paranthesis == '}' || paranthesis == ']')
                    {
                        if (openingParanthesis.Count == 0)
                        {
                            Console.WriteLine("\nInvalid input"); //Syns enbart om man försöker lägga till en extra stängande parantes när det inte finns några öppnande kvar.
                        }
                        else
                        {
                            char opening = openingParanthesis.Pop(); //tar bort den översta öppnade parantesen från stacken och tilldelar den variabeln opening
                                                                //så att jag kan använda den variabeln och jämföra med den stängande parantesen och se om de matchar.




                            if (!((opening == '(' && paranthesis == ')') ||
                                (opening == '{' && paranthesis == '}') ||
                                (opening == '[' && paranthesis == ']')))
                            {
                                Console.WriteLine("\nThe paranthesis in the string is incorrect");
                                break;
                            }
                        }
                    }
                
                }
                if (openingParanthesis.Count == 0)
                {
                    Console.WriteLine("\nNo unmatched paranthesis left"); //Heltenkelt har alla paranteser matchats upp.
                                                                          //Borde eventuellt ha använt mig av en boolean, typ if match==true, så skriver konsolen att inputen är välformad. 
                }
                else
                {
                    Console.WriteLine("\nUnmatched paranthesis left: "); // visar innehållet av stacken 
                    foreach (var stackItem in openingParanthesis)
                    {
                        Console.WriteLine(stackItem);
                    }
                }
                // Den här uppgiften krävde några omgångar, försökte göra med inspiration av tidigare metoder men anpassa (går att se på tidiga commits på github)
                // men fick det att funka till slut med hjälp av ChatGpt. Förstår koden, men hade inte kommit på det själv i dagsläget. 

            }

        }

    }
}

