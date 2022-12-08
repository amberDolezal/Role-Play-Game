namespace DolezalADungeon
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DolezalADungeon game = new DolezalADungeon();
            game.Run(); 
            
        }
    }
}