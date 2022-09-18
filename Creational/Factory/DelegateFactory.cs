namespace Creational.Factory
{
    public class Service
    {
        public string DoSomething(int value)
        {
            return $"I have {value}";
        }
    }

    public class DomainObject
    {
        private Service service;
        private int value;

        public delegate DomainObject Factory(int value);
        public DomainObject(Service service, int value)
        {
            this.service = service;
            this.value = value;
        }
        public override string ToString()
        {
            return service.DoSomething(value);
        }
    }
}
