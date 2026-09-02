using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numbers = new LinkedList<int>();
        numbers.AddFirst(30);
        numbers.AddFirst(20);
        numbers.AddFirst(10);
        numbers.AddLast(40);
        numbers.AddLast(50);
        numbers.AddLast(60);
        numbers.AddLast(70);
        numbers.AddLast(80);
        numbers.AddLast(90);
        numbers.AddLast(100);


        //Node used to find the target element
        //because the LinkedList is not working by the index
        LinkedListNode<int> node30 = numbers.Find(30);
        numbers.AddBefore(node30, 25);

        LinkedListNode<int> node50 = numbers.Find(50);
        numbers.AddAfter(node50, 55);
    
        numbers.Remove(25);
        numbers.RemoveFirst();
        numbers.RemoveLast();

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        // Remove the 5th element
        LinkedListNode<int> current = numbers.First;

        for (int i = 1; i < 5; i++)
        {
            current = current.Next;
        }

        numbers.Remove(current);

        Console.WriteLine("removing the 5th element:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Person fred = new Person("Fred", "Smith", 21);
        Person smith = new Person("Smith", "Fred", 20);
        Person max = new Person("Max", "Tomford", 17);
        Person odawara = new Person("Odawara", "Hakone", 22);
        Person chen = new Person("Chen", "Jacky", 25);
        Person angel = new Person("Angel", "Walls", 29);
        Person wallter = new Person("Wallter", "White", 42);
        Person frank = new Person("Frank", "South", 15);
        Person alice = new Person("Alice", "Taylor", 20);
        Person bob = new Person("Bob", "Jones", 40);

        List<Person> people = new List<Person>();

        people.Add(fred);
        people.Add(smith);
        people.Add(max);
        people.Add(odawara);
        people.Add(chen);
        people.Add(angel);
        people.Add(wallter);
        people.Add(frank);
        people.Add(alice);
        people.Add(bob);

        
    }
    public static LinkedList<Person> ToLinkedList(List<Person> people)
        {

            LinkedList <Person> result = new LinkedList<Person>();

            foreach(Person person in people)
            {

                result.AddLast(person);

            }

            return result;
        }

        public static string PrintPeople(LinkedList<Person> people)
        {

            string result ="";

            foreach(Person person in people){
                
                    result = result + person.FullName + "" + person.Age +"\n";

    

                }
                return result;
        }

        static LinkedList<Person> SortPeople(LinkedList<Person> people)
        {
            LinkedList<Person> sortedPeople = new LinkedList<Person>();

            while (people.Count > 0)
            {
                LinkedListNode<Person> youngest = people.First;
                LinkedListNode<Person> current = people.First;

                while (current != null)
                {
                    if (current.Value.Age < youngest.Value.Age)
                    {
                        youngest = current;
                    }

                    current = current.Next;
                }

                sortedPeople.AddLast(youngest.Value);
                people.Remove(youngest);
            }

            return sortedPeople;
        }

}


    

