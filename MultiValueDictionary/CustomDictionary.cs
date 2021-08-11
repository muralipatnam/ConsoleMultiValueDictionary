using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    public class CustomDictionary : ICustomDictionary
    {
        private List<DictionaryItem> dictionaryItems;

       public CustomDictionary()
        {
            dictionaryItems = new List<DictionaryItem>();
        }

    #region Properties
    
        /// <summary>
        /// Returns number of items in the dictionary
        /// </summary>
    public int Count
    {
        get
        {
            return dictionaryItems.Count;
        }

    }
    #endregion Properties

    #region Public Methods
    /// <summary>
    /// Adds a key, value pair to the dictionary if the <key,value> not already exists
    /// </summary>
    /// <param name="key"> Key to be added</param>
    /// <param name="value">Value to be added</param>
    /// <returns>bool: true if item added, false if not added</returns>
    public bool Add(string key, string value)
    {

        bool itemAdded = true;
        DictionaryItem dictObject = new DictionaryItem();
        dictObject.key = key;
        dictObject.value = value;

        int index = dictionaryItems.FindIndex(item => dictObject.key == item.key && item.value == dictObject.value);
        if (index > -1)
        {
            itemAdded = false;
        }
        else
        {
            dictionaryItems.Add(dictObject);
        }


        return itemAdded;

    }

    /// <summary>
    /// Removes <key,value> pair from the dictionary, if pair exists
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Remove(string key, string value)
    {
        bool itemRemoved;

        var index = dictionaryItems.FindIndex(i => i.key == key && i.value == value);
        if (index >= 0)  // ensure item found
        {
            dictionaryItems.RemoveAt(index);
            itemRemoved = true;
        }
        else
            itemRemoved = false;

        return itemRemoved;
    }

    /// <summary>
    /// Removes all the key,value pairs from the dictionary 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool RemoveAll(string key)
    {
        var itemsRemovedCount = dictionaryItems.RemoveAll(item => item.key == key);
        return itemsRemovedCount > 0;
    }
    /// <summary>
    /// Returns all the keys from the dictionary
    /// </summary>
    /// <returns></returns>
    public List<string> Keys()
    {
        //List<string> Keys = new List<string>();

        var Keys = dictionaryItems.Select(x => x.key).Distinct().ToList();

        return Keys;


    }

    /// <summary>
    /// Returns all the members for a key from the dictionary
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<string> Members(string key)
    {
        List<string> members = new List<string>();

        List<DictionaryItem> abc = dictionaryItems.Where(i => i.key == key).ToList();

        members = abc.Select(x => x.value).ToList();

        return members;
    }

    /// <summary>
    /// Removes all items from the dictionary
    /// </summary>
    public void Clear()
    {
        dictionaryItems.Clear();
    }

    /// <summary>
    /// Checks if dictionary contains the key
    /// </summary>
    /// <param name="key">Key to be searched</param>
    /// <returns>true - if exists, false - if key doesn't exist</returns>
    public bool KeyExists(string key)
    {
        return (dictionaryItems.FindIndex(item => item.key == key) >= 0);
    }

    /// <summary>
    /// Checks if dictionary contains the member
    /// </summary>
    /// <param name="value">The member to be searched</param>
    /// <returns>true - if exists, false - if key doesn't exist</returns>
    public bool MemberExists(string key, string value)
    {
        return (dictionaryItems.FindIndex(item => item.key == key && item.value == value) >= 0);
    }

    /// <summary>
    /// Returns all the members from the dictionary
    /// </summary>
    /// <returns>List of members</returns>
    public List<string> AllMembers()
    {
        return dictionaryItems.Select(item => item.value).ToList();
    }


    /// <summary>
    /// Returns all the items(key-value pairs) from the dictionary
    /// </summary>
    /// <returns>List of dictionary items</returns>
    public List<DictionaryItem> Items()
    {
        return dictionaryItems;
    }
    /// <summary>
    /// Returns the count of items with the key
    /// </summary>
    /// <param name="key">Key to be searched</param>
    /// <returns>Count of occurences</returns>
    public int KeyCount(string key)
    {

        List<string> members = new List<string>();

        return dictionaryItems.Where(i => i.key == key).Count();

    }

    /// <summary>
    /// Returns the dictionary items sorted by the key
    /// </summary>
    /// <returns> List of sorted dictionary items</returns>
    public List<DictionaryItem> SortedByKey()
    {
        List<DictionaryItem> SortedList = dictionaryItems.OrderBy(o => o.key).ToList();

        return SortedList;
    }

    /// <summary>
    /// Updates the value for the given key
    /// </summary>
    /// <param name="key">The key for which the values needs to be updated</param>
    /// <param name="value">THe new value</param>
    /// <returns>true - of update successful, false - if item not updated</returns>
    public bool Update(string key, string value)
    {
        bool updateSuccess;
        var items = dictionaryItems.Where(i => i.key == key).ToList();

        if (items.Count == 1)
        {
            items[0].value = value;
            updateSuccess = true;
        }
        else
        {
            updateSuccess = false;
        }

        return updateSuccess;
    }

    #endregion Public Methods
}
}


