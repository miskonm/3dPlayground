namespace Playground
{
    public class Test
    {
        public void Main()
        {
            var b = new B();
            var a = new A();
            a.Setup(b);
            a.DoA();
        }
    }

    public class A
    {
        private B b;

        public A()
        {
            
        }

        public A(B b)
        {
            this.b = b;
        }
        

        public void Setup(B b)
        {
            this.b = b;
        }
        
        public void DoA()
        {
            b.Do();
        }
    }

    public class B
    {
        public void Do() {}
    }
}
