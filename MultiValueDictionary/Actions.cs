using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public enum Actions
    {
        ADD,
        REMOVE,
        KEYS,
        ITEMS, //Returns all keys in the dictionary and all of their members. Returns nothing if there are none. 
        MEMBERS,
        REMOVEALL, // Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
        CLEAR, // Removes all keys and all members from the dictionary
        KEYEXISTS, // Returns whether a key exists or not
        MEMBEREXISTS, // Returns whether a member exists withing a key. Returns false if the key does not exists
        ALLMEMBERS, // Returns all the members in the dictionary, Returns nothing if there are none. 
        KEYCOUNT, // Returns number of occurences of key. Returns 0 if key doesn't exist. Murali
        SORTEDBYKEY,
        UPDATE,
        UPDATEALL,
        COMMANDS,
        COUNT
    }
}
