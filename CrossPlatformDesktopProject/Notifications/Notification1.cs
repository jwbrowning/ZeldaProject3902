using Sprint0;

namespace CrossPlatformDesktopProject.Notifications
{
    class Notification1 : INotification
    {
        /* The default amount of time that a notification
         * is on screen, measured in game ticks.
         * 60 game ticks = 1 second normally*/
        const int DEFAULT_NOTIFICATION_DURATION = 90;

        public string notificationText { get; set; }
        public int timeLeft { get; set; }
        private Game1 myGame;
        public Notification1(Game1 game, string text)
        {
            myGame = game;
            notificationText = text;
            timeLeft = DEFAULT_NOTIFICATION_DURATION;
        }
        public Notification1(Game1 game, string text, int time)
        {
            myGame = game;
            notificationText = text;
            timeLeft = time;
        }

        public void Update()
        {
            this.timeLeft--;
        }

    }
}
