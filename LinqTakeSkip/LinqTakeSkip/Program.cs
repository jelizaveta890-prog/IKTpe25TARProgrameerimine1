namespace LinqTakeSkip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ meetodi");
            Console.WriteLine("1. Skip ");
            Console.WriteLine("2. SkipWhile ");
            Console.WriteLine("3. TakeWhile ");
            //siin kasutada switchi ja peab saama Skip meetodoi esile kutsuda 
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Skip();
                    break;

                case 2:
                    SkipWhile();
                    break;

                case 3:
                    TakeWhile();
                    break;

                default:
                    Console.WriteLine("vale valik");
                    break;

            }
        }

        public static void Skip()
        {

            Console.WriteLine("------------Skip------------");
            //kasuta skip ja jätta kolm tükki vahele
            var skip = PeopleList.people.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }
        }

        //teete uue meetodi, aga kasutame SkipWhile ja vanemad, kui 18 peab olema tingimus
        public static void SkipWhile()
        {

            Console.WriteLine("------------SkipWhile------------");
            //mis tähendab: => . See tähendab lambda märki
            //abil saab kasutada pikkema classi asemel lühendit
            //koos oleva muutujaga, mis antud juhul on x .
            var SkipWhile = PeopleList.people.SkipWhile(x => x.Age > 18);

            foreach (var item in SkipWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            //SkipWhile jätab loendis nii kaua vahele ridu kuni vastab tingimustele
            //e antud juhul jätab read vahele kuni leiab 18 a isiku ja
            //peale seda hakkab infot jälle kuvama olemata vanuse tingimusest 
        }
        //kasutada TakeWhile ja kutsuda see esile Switchis
        //tingimus on Age > 18

        //vooskeem teha TakeWhile meetodist
        public static void TakeWhile()
        {

            Console.WriteLine("------------TakeWhile------------");

            var takeWhileResult = PeopleList.people.TakeWhile(x => x.Age > 18);

            foreach (var item in takeWhileResult)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            //TakeWhile näitab isikud kuni vastab tingimustele
            //e antud juhul näitab andmeid kuni  leiab 18 a. isiku ja
            //peale seda enam ei näita andmeid 
        }
    }
}
