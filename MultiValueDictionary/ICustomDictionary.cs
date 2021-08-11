using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    interface ICustomDictionary
    {
        /// <summary>
        /// Count of dictionary Items
        /// </summary>
        int Count { get; }
        
        /// <summary>
        ///Adds Dicitonary Item to the Dictionary 
        /// </summary>
        /// <param name="key">Key of the item to be added</param>
        /// <param name="value">Value of the item to be added</param>
        /// <returns>true/false - Item Added</returns>
        bool Add(string key, string value);

        /// <summary>
        /// Removes Item from Dictionary
        /// </summary>
        /// <param name="key">Key of the item to be removed</param>
        /// <param name="value">Value of the item to be removed</param>
        /// <returns>true/false - Item removed</returns>
        bool Remove(string key, string value);
        
        /// <summary>
        /// Removes All items from the dictionary for a key
        /// </summary>
        /// <param name="key"> Key of the items to be removed</param>
        /// <returns></returns>
        bool RemoveAll(string key);
        
        /// <summary>
        /// Returns list of all keys in the dictionary
        /// </summary>
        /// <returns></returns>
        List<string> Keys();

        
        /// <summary>
        /// Members of a key in the dictionary
        /// </summary>
        /// <param name="key">Key for which members needs to be returned</param>
        /// <returns></returns>
        List<string> Members(string key);

        /// <summary>
        /// Clear the dictionary
        /// </summary>
        void Clear();

        /// <summary>
        /// Check if key exists in the dictionary
        /// </summary>
        /// <param name="key">Key to be checked if it exists</param>
        /// <returns>true/false - key exists in the dictionary</returns>
        bool KeyExists(string key);

        /// <summary>
        /// Member exists for a key in the dictionary
        /// </summary>
        /// <param name="key">Key to be checked</param>
        /// <param name="value">Member to be checked</param>
        /// <returns>true/false = Member exists</returns>
        bool MemberExists(string key, string value);


        /// <summary>
        /// All members from the dictionart
        /// </summary>
        /// <returns>All members from dictionary</returns>
        List<string> AllMembers();

        /// <summary>
        /// All key value pairs from the dictinary
        /// </summary>
        /// <returns>List of key/value pairs</returns>
        List<DictionaryItem> Items();

        /// <summary>
        /// Number of occurences of the key
        /// </summary>
        /// <param name="key"> The key to be checked for occurences</param>
        /// <returns>Occurences of the key </returns>
        int KeyCount(string key);

        /// <summary>
        /// Dictionary in sorted order by Keys
        /// </summary>
        /// <returns>List of dictionary items sorted by key</returns>
        List<DictionaryItem> SortedByKey();

        /// <summary>
        /// Update member for a key
        /// </summary>
        /// <param name="key">Key for which member needs to be updated</param>
        /// <param name="value">New value</param>
        /// <returns>true/false - items updated</returns>
        bool Update(string key, string value);

    }
}