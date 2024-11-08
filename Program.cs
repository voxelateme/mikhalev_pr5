using HashPasswords;
using mikhalevpr5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mikhalevpr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 hasher = new Class1();
            telecommunicationEntities1 entities = Helper.GetContext();

            Console.WriteLine("Создание новой учетной записи для пользователя");

            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите логин пользователя: ");
            string username = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            // Hash the password
            string hashedPassword = hasher.hash(password);
            Console.WriteLine("Хешированный пароль пользователя: " + hashedPassword);

            bool isSuccess = Helper.CreateClient(username, hashedPassword, firstName, lastName);

            if (isSuccess) {
                Console.WriteLine("Учетная запись добавлена");
            }
        }
    }
}
