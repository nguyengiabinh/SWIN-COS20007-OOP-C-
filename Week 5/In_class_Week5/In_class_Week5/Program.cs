public class Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat ca = new Cat("Tom", "black");
            IPet Cat = ca;
            Console.WriteLine(Cat.Food);
            Console.ReadLine();

        }

    }
    interface IPet
    {
        void Food();
        void Sound();
    }
    public class Pet
    {
        string _name, _color;
        int _old;
        public virtual string GetSound() { return ""; }

        public Pet(string name, string color)
        {
            _name = name;
            _color = color;
        }

        public virtual string Food
        {
            get
            {
                return "";
            }
        }

        public virtual string Sound
        {
            get
            {
                return "";
            }
        }

        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        public string Color
        {
            set
            {
                _color = value;
            }
            get
            {
                return _color;
            }
        }
    }

    class Cat : Pet, IPet
    {
        public Cat(string _name, string _color) : base(_name, _color) { }
        public override string GetSound()
        {
            return "Meow Meow";
        }
        void IPet.Food()
        {
            Console.WriteLine("Fish");

        }
        void IPet.Sound()
        {
            Console.WriteLine("Meow Moew");

        }
        public override string Food
        {
            get
            {
                return "fish";
            }
        }

        public override string Sound
        {
            get
            {
                return "meow meow";

            }

        }
    }

    class Dog : Pet
    {
        public Dog(string _name, string _color) : base(_name, _color) { }

        public override string Food
        {
            get
            {
                return "bone";

            }

        }

        public override string Sound
        {
            get
            {
                return "gau gau";

            }

        }
    }
}








