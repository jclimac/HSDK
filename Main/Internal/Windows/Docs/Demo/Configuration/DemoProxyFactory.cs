namespace EyeSoft.Wpf.Facilities.Demo.Configuration
{
	using System;

	using EyeSoft.Windows.Model.Demo.Contract;
	using EyeSoft.Wpf.Facilities.Demo.Configuration.Helpers;

	internal class DemoProxyFactory<T> : IDisposableFactory<T> where T : IDisposable
	{
		private readonly CustomerServiceStub stub;

		public DemoProxyFactory(bool runSlow = true) : this(new CustomerServiceStub(runSlow))
		{
		}

		public DemoProxyFactory(CustomerServiceStub stub)
		{
			this.stub = stub;
		}

		public T Create()
		{
			if (typeof(T) == typeof(ICustomerService))
			{
				return (T)(IDisposable)stub;
			}

			throw new ArgumentException();
		}
	}
}