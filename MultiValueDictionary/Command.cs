using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{

    public class Command: ICommand
    {
        public string Action;
        public string Key;
        public string Value;
        public int ArgumentsCount { get; set; }

        /// <summary>
        /// THe method populates the Action, Key and value members for the command
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>true/false - Command populated</returns>
        public bool PopulateCommand(string inputString)
        {
           List<string> cmd = inputString.Split(' ').ToList();
         //   List<string> cmd = inputString.Split(new char[] { ' ' }, 2).ToList();

           bool isValid = IsValidAction(cmd[0]);

           if(isValid)
            {
                Action = cmd[0];
                ArgumentsCount = 0;
                int i = 1;

                for (; i < cmd.Count(); i++)
                {
                    if (cmd[i] == string.Empty)
                        continue;
                    else
                    {
                        Key = cmd[i];
                        i++;
                        ArgumentsCount = 1;
                        break;
                    }
                }

                for (; i < cmd.Count; i++)
                { 
                    if (cmd[i] == string.Empty)
                    {
                        Value += " ";
                    }
                    else
                    {
                        Value += cmd[i];
                    }
                    ArgumentsCount = 2;

                }
            }

            return isValid;
        }

        /// <summary>
        /// Checks if Action is valid
        /// </summary>
        /// <param name="action">Action</param>
        /// <returns>true/false - valid action</returns>
        public bool IsValidAction(string action)
        {
            bool valid;

            valid = Enum.IsDefined(typeof(Actions), action.ToUpper());
            return valid;

        }
    }
}
