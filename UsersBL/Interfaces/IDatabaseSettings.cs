using System;
using System.Collections.Generic;
using System.Text;

namespace UsersBL.Interfaces
{
    public interface IUsersDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
