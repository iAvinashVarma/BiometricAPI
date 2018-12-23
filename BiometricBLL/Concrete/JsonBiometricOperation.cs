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
			var people = FileProcess.Instance.ReadAllText(AbsoluteConnectionString);
			return JsonConvert.DeserializeObject<Persons>(people);
		}

		public override Person Create(Person entity)
		{
			List<Person> people = ReadAll().ToList();
			entity.ModifiedDate = DateTime.Now;
			people.Add(entity);
			SaveChanges(people);
			return entity;
		}

		public override Person Delete(int id)
		{
			List<Person> people = ReadAll().ToList();
			Person person = people.FirstOrDefault(p => p.Id == id);
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
			List<Person> people = ReadAll().ToList();
			Person person = people.FirstOrDefault(p => p.Id == id);
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
				IOrderedEnumerable<Person> orderPeople = people.OrderBy(p => p.Id);
				string serialize = JsonConvert.SerializeObject(orderPeople, Formatting.Indented);
				FileProcess.Instance.WriteAllText(AbsoluteConnectionString, serialize);
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