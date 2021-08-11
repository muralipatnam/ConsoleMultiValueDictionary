using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiValueDictionary
{
    [TestClass]
    public class CommandValidatorTests
    {

        [TestMethod]
        public void Command_Valid_Test()
        {
            Command cmd = new Command();
            cmd.Action = "ADD";
            cmd.ArgumentsCount = 2;

            CommandValidator commandValidator = new CommandValidator();
           bool valid =   commandValidator.Validate(cmd);

            Assert.AreEqual(true, valid);


        }

        [TestMethod]
        public void Command_InValid_Test()
        {
            Command cmd = new Command();
            cmd.Action = "ADD";
            cmd.ArgumentsCount = 1;

            CommandValidator commandValidator = new CommandValidator();
            bool valid = commandValidator.Validate(cmd);

            Assert.AreEqual(false, valid);


        }

    }
}
