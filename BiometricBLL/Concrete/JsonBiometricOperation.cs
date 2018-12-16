using AutoMapper;
using BiometricBLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BiometricBLL.Concrete
{
	public class JsonBiometricOperation : BiometricOperation
	{
		private const string RelativeConnectionString = @"Data/Biometric.json";
		private readonly string AbsoluteConnectionString;

		public JsonBiometricOperation()
		{
			AbsoluteConnectionString = Path.Combine(AssemblyDirectory, RelativeConnectionString);
		}

		public override IEnumerable<Person> ReadAll()
		{
			string people = File.ReadAllText(AbsoluteConnectionString);
			return JsonConvert.DeserializeObject<Persons>(people);
		}

		public override Person Create(Person entity)
		{
			var people = ReadAll().ToList();
			entity.ModifiedDate = DateTime.Now;
			people.Add(entity);
			SaveChanges(people);
			return entity;
		}

		public override Person Delete(int id)
		{
			var people = ReadAll().ToList();
			var person = people.FirstOrDefault(p => p.Id == id);
			if (person != null)
			{
				person.ModifiedDate = DateTime.Now;
				people.Remove(person);
				SaveChanges(people);
			}
			return person;
		}

		public override Person Update(int id, Person entity)
		{
			var people = ReadAll().ToList();
			var person = people.FirstOrDefault(p => p.Id == id);
			if (person != null)
			{
				entity.ModifiedDate = DateTime.Now;
				people.Remove(person);
				people.Add(entity);
				SaveChanges(people);
			}
			return entity;
		}

		private KeyValuePair<bool, Exception> SaveChanges(IEnumerable<Person> people)
		{
			bool isSave = false;
			Exception exception = null;
			try
			{
				var orderPeople = people.OrderBy(p => p.Id);
				var serialize = JsonConvert.SerializeObject(orderPeople, Formatting.Indented);
				File.WriteAllText(AbsoluteConnectionString, serialize);
				isSave = true;
			}
			catch (Exception ex)
			{
				ex = exception;
			}
			return new KeyValuePair<bool, Exception>(isSave, exception);
		}
	}
}