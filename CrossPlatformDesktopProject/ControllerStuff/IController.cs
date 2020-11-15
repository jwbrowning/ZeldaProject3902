using Microsoft.Xna.Framework.Input;


namespace Sprint0
{
    interface IController
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);

    }
}
