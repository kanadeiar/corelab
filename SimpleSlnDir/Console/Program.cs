IContainer container = new Container();

container.Register<ISecond, Second>();
//container.Register<ISample, Sample>();

var sample = container.Resolve<Sample>();

Console.WriteLine($"Message: {sample.GetMessage()}");

var _ = Console.ReadKey();
