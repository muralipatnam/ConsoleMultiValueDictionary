
namespace MultiValueDictionary
{
    interface ICommandValidator
    {
        
       /// <summary>
       /// Validates a command
       /// </summary>
       /// <param name="command">Command Object</param>
       /// <returns>true/false - Command valid</returns>
        bool Validate(Command command);
    }
}
