namespace WindowsSystemDiffToolsCore
{
    public interface UIListener
    {
        void sendStringToUI(string message);

        void UpdatePercentComplete(int percentComplete);

        void UpdateCompareFilesList();

        void UpdateCompareMessage(string message);

        void UpdateComparePercentComplete(int percentComplete);
    }
}
