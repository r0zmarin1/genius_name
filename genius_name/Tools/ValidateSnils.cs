using genius_name.Model;
using System.Text.RegularExpressions;

namespace genius_name.Tools
{
    public class ValidateSnils
    {

        public bool validateSnils(string snils)
        {
            if (snils == null) 
            {
                return false;
            }
            else if (Regex.IsMatch("/[^0-9]/", snils))
            {
                return true;
            }
            return true;
        }
    }
}
