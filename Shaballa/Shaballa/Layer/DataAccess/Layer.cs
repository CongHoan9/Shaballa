namespace Shaballa
{
    public abstract class Layer : Binding
    {
        public virtual void LogError(Exception ex)
        {
            Console.WriteLine($"Lỗi <{DateTime.Now}>: {ex.Message}");
        }
        public virtual bool CheckString(string input)
        {
            return !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
        }
    }
}
