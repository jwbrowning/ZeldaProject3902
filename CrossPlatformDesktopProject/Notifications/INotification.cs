using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Notifications
{
    interface INotification
    {
        string notificationText { get; set; }
        int timeLeft { get; set; }
        void Update();
    }
}
