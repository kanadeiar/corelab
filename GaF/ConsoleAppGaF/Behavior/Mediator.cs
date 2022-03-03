namespace ConsoleAppGaF.Behavior
{
    interface IMediator
    {
        void Notify(object sender, string ev);
    }
    class ConcreteMediator : IMediator
    {
        private readonly Component1 _component1;
        /// **** другие компоненты
        public ConcreteMediator(Component1 component1)
        {
            _component1 = component1;
            _component1.SetMediator(this);
        }
        public void Notify(object sender, string ev)
        {
            if (ev == "B")
            {
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                _component1.DoB();
            }
            // ********** вызов других компонентов
        }
    }
    class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
    class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");

            _mediator.Notify(this, "B");
        }
        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");
        }
    }
}
