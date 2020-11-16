using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework.Audio;

namespace Sprint0
{
    class CommandMute : ICommand
    {
        public void Execute()
        {
            if (SoundFactory.Instance.musicDungeonLoop.State == SoundState.Stopped)
            {
                SoundFactory.Instance.musicDungeonLoop.Play();
            }
            else
            {
                SoundFactory.Instance.musicDungeonLoop.Stop();
            }
        }
    }
}
