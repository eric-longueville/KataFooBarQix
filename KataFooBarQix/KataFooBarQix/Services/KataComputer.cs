using System.Text;

namespace KataFooBarQix.Services
{
    public interface IComputer
    {
        string Compute(string input);
    }
    public class KataComputer : IComputer
    {
        public string Compute(string input)
        {
            StringBuilder result = new();
            Dictionary<string, string> mapping = new();
            mapping.Add("3", "Foo");
            mapping.Add("5", "Bar");
            mapping.Add("7", "Qix");
            mapping.Add("0", "*");
            try
            {
                foreach(var currentCouple in mapping.Where(x => x.Key != "0"))
                {
                    if(int.Parse(input) % int.Parse(currentCouple.Key) == 0)
                    {
                        result.Append(currentCouple.Value);
                    }
                }
                foreach (char character in input)
                {
                    if(mapping.Any(x => x.Key == character.ToString()))
                    {
                        result.Append(mapping.First(x => x.Key == character.ToString()).Value);
                    }
                }
                if(String.IsNullOrEmpty(result.ToString()))
                {
                    result.Append(input.Replace('0', '*'));
                }
            }
            catch(Exception e)
            {
                result = new();
                result.Append("Error " + e.StackTrace + " : " + e.Message);
            }
            return result.ToString();
        }
    }
}
