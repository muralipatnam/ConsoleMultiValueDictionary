using System;

namespace MultiValueDictionary
{
    public class CommandValidator : ICommandValidator

    {
        public  bool Validate(Command command)
        {
            bool validCommand = true;


            Actions action;
            Enum.TryParse<Actions>(command.Action.ToUpper(), out action);
            switch (action)
            {
                case Actions.ADD:
                    if (command.ArgumentsCount != 2)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.REMOVE:
                    if (command.ArgumentsCount != 2)
                    {
                        validCommand = false;
                    }
                    break;

                case Actions.KEYS:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;

                case Actions.MEMBERS:
                    if (command.ArgumentsCount != 1)
                    {
                        validCommand = false;
                    }

                    break;

                case Actions.REMOVEALL:
                    if (command.ArgumentsCount != 1)
                    {
                        validCommand = false;
                    }
                    break;
                    ;
                case Actions.CLEAR:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.KEYEXISTS:
                    if (command.ArgumentsCount != 1)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.MEMBEREXISTS:
                    if (command.ArgumentsCount != 2)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.ALLMEMBERS:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;

                case Actions.ITEMS:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.KEYCOUNT:
                    if (command.ArgumentsCount != 1)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.SORTEDBYKEY:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;
                case Actions.UPDATE:
                    if (command.ArgumentsCount != 2)
                    {
                        validCommand = false;
                    }
                    break;

                case Actions.COMMANDS:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;

                case Actions.COUNT:
                    if (command.ArgumentsCount != 0)
                    {
                        validCommand = false;
                    }
                    break;
            }

            return validCommand;
        }
    }
}
