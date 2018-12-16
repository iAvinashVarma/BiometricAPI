using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BiometricBLL.Models
{
	[XmlRoot("Persons")]
	public class Persons : List<Person> { }

	[MetadataType(typeof(PersonMetaData))]
	public partial class Person
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public byte Age
		{
			get
			{
				DateTime today = DateTime.Now;
				byte age = (byte)(today.Year - DateOfBirth.Year);
				if (DateOfBirth > today.AddYears(-age))
				{
					age--;
				}
				return age;
			}
		}

		public Gender Gender { get; set; }

		public DateTime DateOfBirth { get; set; }

		public bool IsRegistered { get; set; }

		public DateTime ModifiedDate { get; set; }
	}

	public partial class PersonMetaData
	{
		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Age")]
		public byte Age { get; }

		[Display(Name = "Gender")]
		public Gender Gender { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "Date Of Birth")]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "Is Registered")]
		public bool IsRegistered { get; set; }

		[Required(ErrorMessageResourceName = "RequiredField")]
		[Display(Name = "Modified Date")]
		public DateTime ModifiedDate { get; set; }
	}

	public enum Gender : byte
	{
		Unknown = 0,
		Male = 1,
		Female = 2
	}
}