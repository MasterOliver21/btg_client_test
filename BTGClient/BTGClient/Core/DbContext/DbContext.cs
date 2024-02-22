using BTGClient.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTGClient.Core.DbContext
{
    public class DbContext
    {
        private static DbContext _lazy;
        private static SQLiteConnection _sqlConnection;
        private const string _dbName = "client_db.db3";

        public static DbContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new DbContext();

                return _lazy;
            }
        }

        private DbContext()
        {
            _sqlConnection = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, _dbName));
            _sqlConnection.CreateTable<Client>();
            _sqlConnection.CreateTable<Address>();
        }

        public SQLiteConnection Connection
        {
            get { return _sqlConnection; }
            set { _sqlConnection = value; }
        }
    }
}
