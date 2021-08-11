using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MultiValueDictionary
{
    [TestClass]
    public class CommandTests
    {

        [TestMethod]
        public void Command_Valid_Test()
        {
            Command cmd = new Command();
            string inputString = "ADD abc 123";
          bool valid =   cmd.PopulateCommand(inputString);
          
            Assert.AreEqual(true, valid);

        }

        [TestMethod]
        public void Command_InValid_Test()
        {
            Command cmd = new Command();
            string inputString = "TEST abc 123";
            bool valid = cmd.PopulateCommand(inputString);

            Assert.AreEqual(false, valid);

        }

        [TestMethod]
        public void Action_Valid_Test()
        {
            Command cmd = new Command();
            string action = "UPDATE";
            bool valid = cmd.IsValidAction(action);

            Assert.AreEqual(true, valid);

        }

        [TestMethod]
        public void Action_InValid_Test()
        {
            Command cmd = new Command();
            string action = "MERGE";
            bool valid = cmd.IsValidAction(action);

            Assert.AreEqual(false, valid);

        }

    }
}
