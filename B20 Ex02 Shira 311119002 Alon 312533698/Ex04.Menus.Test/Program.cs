namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu InterfaceMenu = Menus.CreateMainMenuInterfaces();

            InterfaceMenu.Show();

            Delegates.MainMenu DelegateMenu = Menus.CreateMainMenuDelegate();

            DelegateMenu.Show();            
        }
    }
}