namespace CrossPlatformDesktopProject.Notifications
{
    interface INotification
    {
        string notificationText { get; set; }
        int timeLeft { get; set; }
        void Update();
    }
}
