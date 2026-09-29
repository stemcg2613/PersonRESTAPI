using PersonRESTAPI.Models;
using SQLite;

namespace PersonRESTAPI.DataAccess
{
    public class PersonDataAccess
    {
        SQLiteConnection Database;

        public PersonDataAccess()
        {
        }

        void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            Database.CreateTable<Person>();
        }

        public List<Person> GetPeople()
        {
            Init();

            return Database.Table<Person>().ToList();
        }

        public Person GetPerson(int id)
        {
            Init();

            return Database.Table<Person>()
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }

        public int SavePerson(Person item)
        {
            Init();

            if (item.ID != 0)
            {
                return Database.Update(item);
            }
            else
            {
                return Database.Insert(item);
            }
        }

        public int DeletePerson(Person item)
        {
            Init();

            return Database.Delete(item);
        }
    }
}