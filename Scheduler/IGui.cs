namespace Scheduler
{
    public interface IGui
    {
        void WriteLine(string s);

        void SetLocalFile(string s);

        void SetKSISFile(string s);

        void ClearLocalFile();

        void ClearKSISFile();

        void ClearTextBox();
    }
}
