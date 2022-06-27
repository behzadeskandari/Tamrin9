using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {

        /// <summary>
        /// yek list az object dorost mikoonim Ke ye lastname ,name ke ba space joda mishe 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region FirstTry
            //Console.WriteLine("Enter The List Of Members");

            //List<Person> listOfPeople = new List<Person>();
            //List<Person> listofOtherPeople = new List<Person>() {
            //    new Person() { Name="behzad", FamilyName="eskandari",Permission = true },
            //    new Person() { Name="javad", FamilyName="javadi", Permission= false },
            //    new Person() { Name="majid", FamilyName="majidi", Permission = false },
            //    new Person() { Name="reza", FamilyName="behzadi", Permission = false }
            //};

            //    var ValueHolder = Console.ReadLine();

            //    string[] valueOne = ValueHolder.Split(' ');

            //    listOfPeople.Add(new ListOfPerson()
            //    {
            //        Name = valueOne[0],
            //        Fname = valueOne[1],
            //    });
            //   // Console.WriteLine(valueOne[0]);
            //   // Console.WriteLine(valueOne[1]);

            //   //IEnumerable<ListOfPerson> Returnedvalue =listofOtherPeople.Intersect(listOfPeople);

            //   //Returnedvalue.ToList().ForEach(x => Console.WriteLine($"Family Name {x.Fname} And Name {x.Name}"));
            #endregion
            List<Person> listofOtherPeople = new List<Person>() {
                new Person() { Name="behzad", FamilyName="eskandari",Permission = true },
                new Person() { Name="javad", FamilyName="javadi", Permission= false },
                new Person() { Name="majid", FamilyName="majidi", Permission = false },
                new Person() { Name="reza", FamilyName="behzadi", Permission = false }
            };

            Person person = new Person();

            Console.WriteLine("Enter your name and family name");
            var ValueHolder = Console.ReadLine();

            string[] valueOne = ValueHolder.Split(' ');
            person.Name = valueOne[0];
            person.FamilyName = valueOne[1];
            person.Permission = true;

            var AnswerHolder = listofOtherPeople.Where(x => x.Name == person.Name && x.FamilyName == person.FamilyName && x.Permission == true).Any();

            if (AnswerHolder)
            {
                Console.WriteLine("You are existing in the database");
            }
            else
            {
                listofOtherPeople.Add(person);
                Console.WriteLine($"Welcom Mr/Miss {person.Name} {person.FamilyName}");
            }
            person.BlockedHandler += person.AnswerHandler;
            person.CheckHandler();


        }
    }


    public class Person
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }

        public bool Permission { get; set; }
        public Person()
        {
            Permission = false;
        }
        public event EventHandler BlockedHandler;


        public void AnswerHandler(object sender,EventArgs e)
        {
            Console.WriteLine("The Event Handler Is Called In The Main");
        }

        public void CheckHandler()
        {
            if (Permission == false)
            {
                Console.WriteLine("You Are Not Blocked");
            }else {
                BlockedHandler.Invoke(this, EventArgs.Empty);
            }
        }


    }

}
