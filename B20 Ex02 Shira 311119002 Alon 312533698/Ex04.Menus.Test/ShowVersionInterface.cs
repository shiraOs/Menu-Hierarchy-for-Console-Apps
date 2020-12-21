using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersionInterface : IClicked
    {     
        public void Execute()
        {
            MethodsDelegates.ShowVersion();
        }
    }
}