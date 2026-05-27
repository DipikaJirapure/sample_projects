namespace WebApplication3.Services
{
    public class EmailJobService
    {
        public void SendProductCreatedEmail(string email, string message)
        {
            Console.WriteLine(
                $"Welcome email sent to {email} " + message);

            Thread.Sleep(5000);

            Console.WriteLine("Email processing completed");
        }
    }
}
