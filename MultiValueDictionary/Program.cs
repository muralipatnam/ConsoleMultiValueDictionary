using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    class Program
    {
        static CustomDictionary dict = new CustomDictionary();
       static CommandValidator commandValidator = new CommandValidator();

        /// <summary>
        /// Entry point for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StartCommandWindow();
        }

        /// <summary>
        ///Starts the command window 
        /// </summary>
        static void StartCommandWindow()
        {
            var userInput = string.Empty;

            //Keep reading commands and execute untill Exit command.
            while (true)
            {
                Console.Write(DisplayMessages.CommandPrompt);

                userInput = ReadUserInput();

                if (userInput.Trim().ToUpper() == "EXIT")
                {
                    break;
                }

               Command Command;
               bool isValid =  PopulateCommand(out Command, userInput);
                if (isValid == true)
                {
                    ExecuteCommand(Command);
                }
                else
                {
                    DisplayMessages.ErrorMessage("Invalid Command.");
                }

            }
        }

        /// <summary>
        /// Accept user input
        /// </summary>
        /// <returns>Returns the input entered by the user</returns>
        static string ReadUserInput()
        {
            string inputCommand = Console.ReadLine();
            return inputCommand.TrimStart();
        }

        /// <summary>
        /// Populate the command object
        /// </summary>
        /// <param name="command">The command object to be populated</param>
        /// <param name="inputString">the input string from which the command is populated</param>
        /// <returns>true/false - if command is populated successfully</returns>
        static bool PopulateCommand(out Command command, string inputString)
        {

            Command newCommand = new Command();
            bool validCommand =  newCommand.PopulateCommand(inputString);
            command = newCommand;

            return validCommand;

        }
        /// <summary>
        /// The method to call the corresponding execute method based on the action
        /// </summary>
        /// <param name="command"></param>
        static void ExecuteCommand(Command command)
        {
            Actions action;
            Enum.TryParse<Actions>(command.Action.ToUpper(), out action);

            switch (action)
            {
                case Actions.ADD:
                    Add(command);
                    break;
                case Actions.REMOVE:
                    Remove(command);
                    break;
                case Actions.KEYS:
                    Keys(command);
                    break;
                case Actions.MEMBERS:
                    Members(command);
                    break;
                case Actions.REMOVEALL:
                    RemoveAll(command);
                    break;
                case Actions.CLEAR:
                    Clear(command);
                    break;
                case Actions.KEYEXISTS:
                    KeyExists(command);
                    break;
                case Actions.MEMBEREXISTS:
                    MemberExists(command);
                    break;
                case Actions.ALLMEMBERS:
                    AllMembers(command);
                    break;
                case Actions.ITEMS:
                    Items(command);
                    break;
                case Actions.KEYCOUNT:
                    KeyCount(command);
                    break;
                case Actions.SORTEDBYKEY:
                    SortedByKey(command);
                    break;
                case Actions.UPDATE:
                    Update(command);
                    break;
                case Actions.COMMANDS:
                    Commands(command);
                    break;
                case Actions.COUNT:
                    Count(command);
                    break;
            }
        }

        /// <summary>
        /// Prints all the keys in the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void Keys(Command command)
        {

            if (commandValidator.Validate(command))
            {
                if (dict.Count == 0)
                {
                    DisplayMessages.Message(DisplayMessages.EmptySet);
                }
                else
                {
                    int keyCount = 1;

                    foreach (string i in dict.Keys())
                    {
                        Console.WriteLine(keyCount.ToString() + ") " + i);
                        keyCount++;
                    }
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid KEYS Command.");

            }
        }

        /// <summary>
        /// Calls the ADD method on the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void Add(Command command)
        {
            if (commandValidator.Validate(command))
            {
                bool itemAdded = dict.Add(command.Key, command.Value);

                if (itemAdded)
                {
                    DisplayMessages.Message(DisplayMessages.Added);
                }
                else
                {

                    DisplayMessages.ErrorMessage("member already exists for key");
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid ADD Command. Command parameters are not specified. Ex. Add abc 123");

            }
        }

        /// <summary>
        /// Calls the Method of the dictionary to get all the members
        /// </summary>
        /// <param name="command"></param>
        static void Members(Command command)
        {

            int memberCount = 1;
            if (commandValidator.Validate(command))
            {
                List<string> members = dict.Members(command.Key);

                if (members.Count() == 0)
                {

                    DisplayMessages.ErrorMessage("key does not exist");
                }
                else
                {
                    foreach (string member in members)
                    {
                        Console.WriteLine(memberCount.ToString() + ") " + member);
                        memberCount++;
                    }
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid MEMBERS Command.");

            }
        }

        /// <summary>
        /// Calls the removed method on the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void Remove(Command command)
        {
            if (commandValidator.Validate(command))
            {
                if (dict.KeyExists(command.Key))
                {
                    if (dict.MemberExists(command.Key, command.Value))
                    {
                        bool removed = dict.Remove(command.Key, command.Value);
                        if (removed == true)
                        {
                            DisplayMessages.Message(DisplayMessages.Removed);
                        }
                    }
                    else
                    {
                        DisplayMessages.ErrorMessage("Member does not exist");
                    }
                }
                else
                {
                    DisplayMessages.ErrorMessage("key does not exist");
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid Remove Command.");

            }
        }

        /// <summary>
        /// Calls the method on the dictionary to remove all the items of a key from the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void RemoveAll(Command command)
        {
            if (commandValidator.Validate(command))
            {
                bool removed = dict.RemoveAll(command.Key);

                if (removed == false)
                {

                    DisplayMessages.ErrorMessage("key does not exist");
                }
                else
                {
                    DisplayMessages.Message(DisplayMessages.Removed);
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid RemoveAll Command");

            }
        }

        /// <summary>
        /// Calls the method of the dictionary to remove all the items pairs from the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void Clear(Command command)
        {
            if (commandValidator.Validate(command))
            {
                dict.Clear();
                DisplayMessages.Message(DisplayMessages.Cleared);
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid Clear Command");
            }
        }

        /// <summary>
        /// Calls the method of the dictionary to check if a Key exists in the dictionary
        /// </summary>
        /// <param name="command"></param>
        static void KeyExists(Command command)
        {
            if (commandValidator.Validate(command))
            {
                bool keyExists = dict.KeyExists(command.Key);

                if (keyExists == true)
                {
                    DisplayMessages.Message(DisplayMessages.True);

                }
                else
                {
                    DisplayMessages.Message(DisplayMessages.False);
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid KeyExists Command");

            }
        }

        /// <summary>
        /// Calls a method on the dictionary to check if member exists for a key
        /// </summary>
        /// <param name="command"></param>
        static void MemberExists(Command command)
        {
            if (commandValidator.Validate(command))
            {
                bool memberExists = dict.MemberExists(command.Key, command.Value);

                if (memberExists == true)
                {
                    DisplayMessages.Message(DisplayMessages.True);

                }
                else
                {
                    DisplayMessages.Message(DisplayMessages.False);
                }
            }
            else
            {

                DisplayMessages.ErrorMessage("Invalid MemberExists Command");
            }
        }

        /// <summary>
        /// Calls a method of the dictionary to get all the members
        /// </summary>
        /// <param name="command"></param>
        static void AllMembers(Command command)
        {
            if (commandValidator.Validate(command))
            {
                List<string> allMembers = dict.AllMembers();

                int memberCount = 1;
                if (allMembers.Count == 0)
                {
                    DisplayMessages.Message(DisplayMessages.EmptySet);
                }
                else
                {
                    foreach (string member in allMembers)
                    {
                        Console.WriteLine(memberCount.ToString() + ") " + member);
                        memberCount++;
                    }
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid AllMembers Command.");

            }
        }

        /// <summary>
        /// Calls a method of the dictionary to get all the Items 
        /// </summary>
        /// <param name="command"></param>
        static void Items(Command command)
        {
            if (commandValidator.Validate(command))
            {
                List<DictionaryItem> dictionaryItems = dict.Items();
                int itemCount = 1;

                if (dictionaryItems.Count == 0)
                {
                    DisplayMessages.Message(DisplayMessages.EmptySet);
                }
                else
                {
                    foreach (DictionaryItem item in dictionaryItems)
                    {
                        Console.WriteLine("{0}) {1}:{2}", itemCount.ToString(), item.key, item.value);
                        itemCount++;
                    }
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid ITEMS Command. ");

            }
        }
        /// <summary>
        /// Prints the Occurences of a Key
        /// </summary>
        /// <param name="command"></param>
        static void KeyCount(Command command)
        {
            if (commandValidator.Validate(command))
            {
                int keyOccurances = 0;

                keyOccurances = dict.KeyCount(command.Key);

                DisplayMessages.Message(keyOccurances.ToString());
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid KEYCOUNT Command. ");

            }
        }

        /// <summary>
        /// Calls a method  of the dictionary to get all items sorted by the key
        /// </summary>
        /// <param name="command"></param>
        static void SortedByKey(Command command)
        {
            if (commandValidator.Validate(command))
            {
                List<DictionaryItem> sortedList = dict.SortedByKey();

                int itemCount = 1;

                if (sortedList.Count == 0)
                {
                    DisplayMessages.Message(DisplayMessages.EmptySet);
                }
                else
                {
                    foreach (DictionaryItem item in sortedList)
                    {
                        Console.WriteLine(itemCount.ToString() + ") " + item.key + ":" + item.value);
                    }
                }

            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid SORTEDBYKEY Command. ");

            }
        }

        /// <summary>
        /// Calls a method of the dictionary to update member of a key
        /// </summary>
        /// <param name="command"></param>
        static void Update(Command command)
        {
            if (commandValidator.Validate(command))
            {
                bool updated;

                updated = dict.Update(command.Key, command.Value);

                if (updated)
                {
                    DisplayMessages.Message(DisplayMessages.Updated);
                }
                else
                {

                    DisplayMessages.ErrorMessage("Key not found or multiple occurences of Key found");
                }
            }
            else
            {
                DisplayMessages.ErrorMessage("Invalid UPDATE Command.");

            }
        }

        /// <summary>
        /// Prints all the commands
        /// </summary>
        /// <param name="command"></param>
        static void Commands(Command command)
        {
            if (commandValidator.Validate(command))
            {

                foreach (Action eachCommand in Enum.GetValues(typeof(Action)))
                {
                    Console.WriteLine(eachCommand.ToString());
                }
            }
            else
            {

                DisplayMessages.ErrorMessage("Invalid COMMANDS Command.");

            }
        }

        static void Count(Command command)
        {
            if (commandValidator.Validate(command))
            {
                int count;
                count = dict.Count;
                DisplayMessages.Message(count.ToString());
            }
        }

    }
}
