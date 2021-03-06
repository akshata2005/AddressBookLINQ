using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingLINQ
{
    public class AddressBookRepo
    {
        /// <summary>
        /// UC1 The data table
        /// </summary>
        DataTable dataTable = new DataTable();
        /// <summary>
        /// UC2 Creates the data table.
        /// </summary>
        public void CreateDataTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));

            dataTable.Rows.Add("Akshu", "sawant", "Viman nagar", "Pune", "Maharashtra", "110009", "9876778434", "akshu@yahoo.com");
            dataTable.Rows.Add("Rhoit", "Patil", "Ghansoli", "Navi Mumbai", "Maharashtra", "4000356", "7458658925", "rohit@gmail.com");
            dataTable.Rows.Add("Priyanka", "Patil", "Sangvi", "Bangalore", "Karnataka", "520147", "9821118267", "priyanka@gmail.com");
            dataTable.Rows.Add("Shubham", "Dubey", "Ram Nagar", "Bhopal", "Madhya Pradesh", "652412", "8998965896", "shubham@yahoo.com");
            dataTable.Rows.Add("Aditya", "Saitwal", "NavyNagar", "Bangalore", "Karnataka", "520147", "8659876734", "aditya@gmail.com");
            dataTable.Rows.Add("Durgesh", "Jage", "Ghantali", "Thane", "Maharashtra", "400082", "9756387459", "jage@gmail.com");
            dataTable.Rows.Add("Omakar", "Yadav", "Rajiv", "Jaipur", "Rajasthan", "600001", "8987224534", "yadav@gmail.com");
        }
        /// <summary>
        /// Display address book data table
        /// </summary>
        public void DisplayAddressBook()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Insert Contacts in a the addressBook
        /// </summary>
        /// <param name="contact"></param>
        public void InsertContacts(Contact contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Contact inserted successfully");
        }
        /// <summary>
        /// UC4 Edits the existing contact in datatable
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email)
        {
            var recordedData = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName).FirstOrDefault();
            if (recordedData != null)
            {
                recordedData.SetField("LastName", lastName);
                recordedData.SetField("Address", address);
                recordedData.SetField("City", city);
                recordedData.SetField("State", state);
                recordedData.SetField("ZipCode", zipcode);
                recordedData.SetField("EmailID", email);
                recordedData.SetField("State", state);
                Console.WriteLine("Contact edited successfully");
            }
            else
            {
                Console.WriteLine("No Contact Found");
            }
        }
        /// <summary>
        /// Delete contact from table
        /// </summary>
        /// <param name="name"></param>
        public void DeleteContact(string name)
        {
            var deleteRow = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
        }
    }
}
