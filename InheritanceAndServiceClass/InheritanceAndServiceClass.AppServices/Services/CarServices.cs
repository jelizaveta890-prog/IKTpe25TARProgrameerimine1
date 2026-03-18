using InheritanceAndServiceClass.Core.ServiceInterface;

namespace InheritanceAndServiceClass.AppServices.Services
{
    // proovige lahendada probleem, et CarServices ei 
    //saa kasutada ICarServices, kuna see on defineeritud 
    //teise projektis
    public class CarServices : ICarServices
    {
        public void GetData()
        {
            Console.WriteLine("Car Services");
        }

    }
}
