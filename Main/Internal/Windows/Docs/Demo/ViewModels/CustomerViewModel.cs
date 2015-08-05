namespace EyeSoft.Windows.Model.Demo.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Windows.Input;

	using EyeSoft.Messanging;
	using EyeSoft.Validation;
	using EyeSoft.Windows.Model;
	using EyeSoft.Windows.Model.Demo.ViewModels.Validators;

	[DebuggerDisplay("{FirstName} {LastName}")]
	public class CustomerViewModel : IdentityViewModel
	{
		public CustomerViewModel(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;

			Property(() => FullName).DependsFrom(() => FirstName, () => LastName, () => Visits);
		}

		public ICommand DeleteCommand { get; private set; }

		public string FirstName
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}

		public string LastName
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}

		public string FullName
		{
			get { return "{FirstName} {LastName}".NamedFormat(FirstName, LastName); }
		}

		public int Visits
		{
			get { return GetProperty<int>(); }
			set { SetProperty(value); }
		}

		public DateTime? Visited
		{
			get { return GetProperty<DateTime?>(); }
			set { SetProperty(value); }
		}

		protected override IEnumerable<ValidationError> Validate()
		{
			return new CustomerViewModelValidator().Validate(this);
		}

		protected void Delete()
		{
			MessageBroker.Send(new DeleteCustomerMessage(this));
		}
	}
}