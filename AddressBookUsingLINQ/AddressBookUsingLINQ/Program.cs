using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingLINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book using LINQ.");
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.CreateDataTable();
            addressBookRepo.DisplayAddressBook();
        }
    }
}
