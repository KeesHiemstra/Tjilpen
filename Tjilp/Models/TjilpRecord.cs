using Newtonsoft.Json;

using System;
using System.ComponentModel;

namespace Tjilp.Models
{
	internal class TjilpRecord : INotifyPropertyChanged
	{
		private static int lastId;

		private int id;
		private string message;
		private string[] subjects;
		private int[] referencesTo;
		private DateTime creationDate;
		private DateTime mutationDate;
		private DateTime? deletionDate;

		/// <summary>
		/// Record identfication.
		/// </summary>
		public int Id
		{
			get => id;
			set
			{
				if (id != value)
				{
					id = value;
					NotifyPropertyChanged("Id");
				}
			}
		}

		/// <summary>
		/// Tjilp message.
		/// </summary>
		public string Message
		{
			get => message;
			set
			{
				if (message != value)
				{
					message = value;
					NotifyPropertyChanged("Message");
				}
			}
		}

		/// <summary>
		/// Subjects of this tjilp.
		/// </summary>
		public string[] Subjects
		{
			get => subjects;
			set {
				if (subjects != value)
				{
					subjects = value;
					NotifyPropertyChanged("Subjects");
				}
			}
		}

		/// <summary>
		/// Referenties to earlier tjips.
		/// </summary>
		public int[] ReferencesTo
		{
			get => referencesTo;
			set {
				if (referencesTo != value)
				{
					referencesTo = value;
					NotifyPropertyChanged("Referenties");
				}
			}
		}

		/// <summary>
		/// Create date and time of this record.
		/// </summary>
		public DateTime CreationDate
		{
			get => creationDate;
			set {
				if (creationDate != value)
				{
					creationDate = value;
					NotifyPropertyChanged("CreationDate");
				}
			}
		}

		/// <summary>
		/// Mutation date and time of this record.
		/// </summary>
		public DateTime MutationDate
		{
			get => mutationDate;
			set {
				if (mutationDate != value)
				{
					mutationDate = value;
					NotifyPropertyChanged("MutationDate");
				}
			}
		}

		/// <summary>
		/// Deletion date and time of this record.
		/// </summary>
		public DateTime? DeletionDate
		{
			get => deletionDate;
			set {
				if (deletionDate != value)
				{
					deletionDate = value;
					NotifyPropertyChanged("DeletionDate");
				}
			}
		}

		/// <summary>
		/// True it the Message, Subject or ReferenceTo is changed.
		/// </summary>
		[JsonIgnore]
		public bool IsUpdated { get; set; }

		/// <summary>
		/// This tjip is deleted if the date/time not null is.
		/// </summary>
		[JsonIgnore]
		public bool Deleted
		{
			get => deletionDate.HasValue;
		}

		/// <summary>
		/// Tjilp construction.
		/// </summary>
		public TjilpRecord()
		{
			if (CreationDate == new DateTime(1, 1, 1))
			{
				CreationDate = DateTime.Now;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Save the data and update the record.
		/// </summary>
		public TjilpRecord Update()
		{
			if (Id == 0)
			{
				Id = ++lastId;
			}
			else
			{
				if (Id > lastId)
				{
					lastId = Id;
				}
			}
			mutationDate = DateTime.Now;
			return this;
		}

		/// <summary>
		/// Mark this tjip as deleted.
		/// The DeletionDate is not <see langword="null"/>.
		/// </summary>
		public void Delete()
		{
			if (!deletionDate.HasValue)
			{
				mutationDate = DateTime.Now;
				deletionDate = mutationDate;
			}
		}

		/// <summary>
		/// Undelete this tjip.
		/// </summary>
		public void UnDelete()
		{
			if (deletionDate.HasValue)
			{
				mutationDate = DateTime.Now;
				deletionDate = null;
			}
		}

		public static void UpdateLastId(int _lastId)
		{
			lastId = _lastId;
		}
		
	}
}
