using System;
using System.Collections;

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
}

class ContactManager
{
    private Hashtable contacts = new Hashtable();

    public void AddContact()
    {
        Console.WriteLine("Enter contact details:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        if (!contacts.ContainsKey(name))
        {
            Contact newContact = new Contact(name, phone);
            contacts.Add(name, newContact);

            Console.WriteLine("Contact added successfully!\n");
        }
        else
        {
            Console.WriteLine("Contact already exists with this name. Please choose a different name.\n");
        }
    }

    public void FindContact()
    {
        Console.WriteLine("Find contact by:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Phone");
        Console.Write("Enter your choice: ");
        int searchChoice = Convert.ToInt32(Console.ReadLine());

        if (searchChoice == 1)
        {
            Console.Write("Enter name to find: ");
            string nameToFind = Console.ReadLine();

            if (contacts.ContainsKey(nameToFind))
            {
                Contact foundContact = (Contact)contacts[nameToFind];
                Console.WriteLine($"Phone number for {nameToFind}: {foundContact.Phone}\n");
            }
            else
            {
                Console.WriteLine("Not found\n");
            }
        }
        else if (searchChoice == 2)
        {
            Console.Write("Enter phone number to find: ");
            string phoneToFind = Console.ReadLine();

            bool found = false;
            foreach (DictionaryEntry entry in contacts)
            {
                Contact contact = (Contact)entry.Value;
                if (contact.Phone == phoneToFind)
                {
                    Console.WriteLine($"Name for {phoneToFind}: {contact.Name}\n");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not found\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.\n");
        }
    }

    public void DisplayContacts()
    {
        Console.WriteLine("All Contacts:");

        foreach (DictionaryEntry entry in contacts)
        {
            Contact contact = (Contact)entry.Value;
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}");
        }

        Console.WriteLine();
    }

    public void DeleteContact()
    {
        Console.Write("Enter name to delete: ");
        string nameToDelete = Console.ReadLine();

        if (contacts.ContainsKey(nameToDelete))
        {
            contacts.Remove(nameToDelete);
            Console.WriteLine($"{nameToDelete} has been deleted.\n");
        }
        else
        {
            Console.WriteLine("Contact not found.\n");
        }
    }

    public void UpdateContact()
    {
        Console.Write("Enter name to update: ");
        string nameToUpdate = Console.ReadLine();

        if (contacts.ContainsKey(nameToUpdate))
        {
            Console.WriteLine("Enter new phone number: ");
            string newPhone = Console.ReadLine();

            Contact updatedContact = new Contact(nameToUpdate, newPhone);
            contacts[nameToUpdate] = updatedContact;

            Console.WriteLine($"{nameToUpdate} has been updated.\n");
        }
        else
        {
            Console.WriteLine("Contact not found.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        ContactManager contactManager = new ContactManager();

        while (true)
        {
            Console.WriteLine("Contact Manager Menu:");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. Find a contact");
            Console.WriteLine("3. Display contacts");
            Console.WriteLine("4. Delete contact by name");
            Console.WriteLine("5. Update contact by name");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    contactManager.AddContact();
                    break;
                case 2:
                    contactManager.FindContact();
                    break;
                case 3:
                    contactManager.DisplayContacts();
                    break;
                case 4:
                    contactManager.DeleteContact();
                    break;
                case 5:
                    contactManager.UpdateContact();
                    break;
                case 6:
                    Console.WriteLine("Exiting the Contact Manager. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
