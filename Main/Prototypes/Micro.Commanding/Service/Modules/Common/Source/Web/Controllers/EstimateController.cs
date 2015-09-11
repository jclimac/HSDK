﻿namespace WebApplication1.Controllers
{
	using System;
	using System.Web.Http;

	using Commanding;

	using Domain;

	public class EstimateController : ApiController
	{
		private readonly IEstimateRepository repository;

		public EstimateController(IEstimateRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public IHttpActionResult GetDescription(Guid id)
		{
			var estimate = repository.GetById(id);

			return estimate != null ? Ok(estimate.Description) : Ok((string)null);
		}

		[HttpGet]
		public IHttpActionResult GetCustomerName(Guid id)
		{
			var estimate = repository.GetById(id);

			return estimate != null ? Ok(estimate.CustomerName) : Ok((string)null);
		}

		[HttpPut]
		public IHttpActionResult UpdateDescription(UpdateEstimateDescriptionCommand command)
		{
			var estimate = repository.GetById(command.EstimateId) ?? new Estimate { Id = command.EstimateId };

			estimate.Description = command.Description;

			repository.Save(estimate);

			repository.Commit();

			return Ok();
		}

		[HttpPut]
		public IHttpActionResult UpdateCustomerName(UpdateCustomerNameCommand command)
		{
			var estimate = repository.GetById(command.EstimateId) ?? new Estimate { Id = command.EstimateId };

			estimate.CustomerName = command.CustomerName;

			repository.Save(estimate);

			repository.Commit();

			return Ok();
		}

		protected override void Dispose(bool disposing)
		{
			repository.Dispose();

			base.Dispose(disposing);
		}
	}
}