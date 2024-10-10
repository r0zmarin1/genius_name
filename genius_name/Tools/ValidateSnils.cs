using genius_name.Model;
using System.Text.RegularExpressions;

namespace genius_name.Tools
{
    public class ValidateSnils
    {

        public bool validateSnils(string snils)
        {
            int sum = 0;
            int check_digit = 0;
            if (snils == null) 
            {
                return false;
            }
            else if (Regex.IsMatch("/[^0-9]/", snils))
            {
                return false;
            }
            else if (snils.Length != 11)
            {
                return false;
            }
            else
            {
                for (int i = 0; i<9; i++)
                {
                    sum += int.Parse(snils[i].ToString()) * (9 - i);
                }
                
                if (sum < 100)
                {
                    check_digit = sum;
                }
                else if (sum > 101)
                {
                    check_digit = sum % 101;
                    if(check_digit == 100)
                    {
                        check_digit = 0;
                    }
                }
            }
            if (check_digit == int.Parse(snils.Substring(snils.Length - 2)))
                return true;
            else
                return false;
        }
    }
}
