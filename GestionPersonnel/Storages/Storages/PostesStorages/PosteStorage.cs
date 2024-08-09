using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.Storages.PostesStorages
{
    public class PosteStorage
    {
        private readonly string _connectionString;

        public PosteStorage(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
