public class BaseCommandInvoker 
{
    public virtual void ExcuteCommand(ICommand command)
    {
        command.Execute();
    }
    public virtual void UndoCommand(ICommandUndo command)
    {
        command.Undo();
    }
}
