using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    interface ICommand
    {
        /// <summary>
        /// THe method populates the Action, Key and value members for the command
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>true/false - Command populated</returns>
        bool PopulateCommand(string inputString);

       /// <summary>
       /// Checks if Actin in commandis valid
       /// </summary>
       /// <param name="action">action</param>
       /// <returns>true/false - valid Action</returns>
        bool IsValidAction(string action);
    }
}
