using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    [TestClass]
    public class CustomDictionaryTests
    {
        [TestMethod]
        public void Add_OneItem_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            bool added = dict.Add("abc","123");
            Assert.AreEqual(true, added);

        }

        [TestMethod]
        public void Add_Multiple_Items_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            bool added = dict.Add("abc", "123");
            bool added_secondItem = dict.Add("abc","123");
            Assert.AreEqual(true, added);
            Assert.AreEqual(false, added_secondItem);
        }

        [TestMethod]
        public void Remove_OneItem_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc","123");

            bool removed = dict.Remove("abc", "123");
            Assert.AreEqual(true, removed);

        }

        [TestMethod]
        public void Remove_KeyNotFound_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");

            bool removed = dict.Remove("zzz", "123");
            Assert.AreEqual(false, removed);
        }

        [TestMethod]
        public void RemoveAll_Items_Exists_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");

            bool removed = dict.RemoveAll("abc");
            Assert.AreEqual(true, removed);
        }


        [TestMethod]
        public void RemoveAll_Items_NotExists_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");

            bool removed = dict.RemoveAll("zz");
            Assert.AreEqual(false, removed);
        }

        [TestMethod]
        public void Keys_NoDuplicates_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");

            List<string> keys =  dict.Keys();

             
            Assert.AreEqual(2, keys.Count);
            Assert.AreEqual("abc",keys[0]);
            Assert.AreEqual("def", keys[1]);


        }

        [TestMethod]
        public void Keys_Duplicate_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            List<string> keys = dict.Keys();


            Assert.AreEqual(2, keys.Count);
            Assert.AreEqual("abc", keys[0]);
            Assert.AreEqual("def", keys[1]);


        }

        [TestMethod]
        public void Members_Exist_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            List<string> members = dict.Members("abc");

            Assert.AreEqual(2, members.Count);

        }


        [TestMethod]
        public void Members_Not_Exist_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            List<string> members = dict.Members("xyz");

            Assert.AreEqual(0, members.Count);

        }


        [TestMethod]
        public void Clear_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            dict.Clear();

            int count = dict.Count;
            Assert.AreEqual(0, count);

        }

        [TestMethod]
        public void KeyExists_True_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            bool keyExists = dict.KeyExists("abc");

            Assert.AreEqual(true, keyExists);

        }

        [TestMethod]
        public void KeyExists_False_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            bool keyExists = dict.KeyExists("zzz");

            Assert.AreEqual(false, keyExists);

        }


        [TestMethod]
        public void MemberExists_True_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            bool memberExists = dict.MemberExists("abc","123");

            Assert.AreEqual(true, memberExists);

        }

        [TestMethod]
        public void MemberExists_False_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            bool memberExists = dict.MemberExists("abc", "888");

            Assert.AreEqual(false, memberExists);

        }

        [TestMethod]
        public void AllMembers_Exist_Test()
        {
            CustomDictionary dict = new CustomDictionary();
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

           List<string> allmembers = dict.AllMembers();

            Assert.AreEqual(3, allmembers.Count);

        }

        [TestMethod]
        public void AllMembers_NoMembersExist_Test()
        {
            CustomDictionary dict = new CustomDictionary();
           
            List<string> allmembers = dict.AllMembers();

            Assert.AreEqual(0, allmembers.Count);
        }

        [TestMethod]
        public void KeyCount_Test()
        {
            CustomDictionary dict = new CustomDictionary();
           
            dict.Add("abc", "123");
            dict.Add("def", "567");
            dict.Add("abc", "999");

            int count = dict.KeyCount("abc");

            int zeroCount = dict.KeyCount("zzz");
            Assert.AreEqual(2, count);
            Assert.AreEqual(0, zeroCount);
        }

        [TestMethod]
        public void Update_Test()
        {
            CustomDictionary dict = new CustomDictionary();

            dict.Add("abc", "123");
            dict.Add("def", "567");
            

           bool updated = dict.Update("abc", "999");

            
            Assert.AreEqual(true, updated);

            bool originalMemberExists = dict.MemberExists("abc", "123");
            bool newMemberExists = dict.MemberExists("abc", "999");

            Assert.AreEqual(false, originalMemberExists);
            Assert.AreEqual(true, newMemberExists);
        }
    }
}
