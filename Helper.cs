using mikhalevpr5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mikhalevpr5
{
    public class Helper
    {
        private static telecommunicationEntities1 _context; // Static private variable to manage database context

        // Method (public, so it can be accessed from any part of the program)
        // Retrieves the database context necessary for creating a connection to the database
        public static telecommunicationEntities1 GetContext()
        {
            // Checks if the connection is not established, then creates a new one
            if (_context == null)
            {
                _context = new telecommunicationEntities1(); // Creates a new database connection
            }
            return _context; // Returns the database connection
        }

        public static bool CreateClient(string login, string passHash, string firstName, string lastName)
        {
            try {
                telecommunicationEntities1 context = GetContext();

                AuthInfo authInfo = new AuthInfo();
                authInfo.login = login;
                authInfo.PasswordHash = passHash;
                context.AuthInfo.Add(authInfo);
                context.SaveChanges();

                long lastId = authInfo.AuthInfoID;

                Clients client = new Clients();
                client.AuthInfoID = lastId;
                client.FirstName = firstName;
                client.LastName = lastName;
                client.Email = null;
                client.Balance = 0;
                client.RegistrationDate = DateTime.Now;

                Console.WriteLine(lastId);
                context.Clients.Add(client);
                context.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
