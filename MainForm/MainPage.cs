namespace MainForm
{
    public class MainPage
    {
        public void Open(String login)
        {
            string message = login;
            
            Console.Clear();
            Console.WriteLine($"Welcome {message}!");
        }
    }
}
