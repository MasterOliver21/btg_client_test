using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BTGClient.Core.Models
{
    [Table("client")]
    public class Client : BaseCore, INotifyPropertyChanged
    {
        [Column("name")]
        public string Name { get;  set; }

        [Column("last_name")]
        public string LastName { get;  set; }

        [Column("age")]
        public int? Age { get;  set; }

        [Column("address")]
        public string Address { get; set; }

        public Client()
        {
           
        }
        public Client(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
