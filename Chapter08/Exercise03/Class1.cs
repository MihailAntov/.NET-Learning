namespace Exercise03;
public class intExtensions
{
    public static string ToWords(int input)
    {
         List<string> singles = new List<string>{"","one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "ten ", "eleven ","twelve ","thirteen ","fourteen ","fifteen ","sixteen ","seventeen ","eighteen ","nineteen ","twenty "};
        List<string> tens = new List<string>{"twenty ", "thirty ","forty ","fifty ","sixty ","seventy ","eighty ","ninety "};
        
        string result = "";
        if (input > 999999999)
        {
            if (input % 1000000000 > 20)
            {
                result = ToWords(input / 1000000000)+"billion "+ ToWords(input%1000000000);
            }
            else
            {
                result = ToWords(input / 1000000000)+"billion and "+ ToWords(input%1000000000);
            }
        }
        else if (input > 999999)
        {
            if (input % 1000000 > 20)
            {
                result = ToWords(input / 1000000)+"million "+ ToWords(input%1000000);
            }
            else
            {
                result = ToWords(input / 1000000)+"million and "+ ToWords(input%1000000);
            }
        }

        else if (input > 999)
        {
            if (input % 1000 > 20)
            {
                result = ToWords(input / 1000)+"thousand "+ ToWords(input%1000);
            }
            else
            {
                result = ToWords(input / 1000)+"thousand and "+ ToWords(input%1000);
            }
        }
        else if (input > 99)
        {
            if (input % 100 > 20)
            {
                result = ToWords(input / 100)+"hundred "+ ToWords(input%100);
            }
            else
            {
                result = ToWords(input / 100)+"hundred and "+ ToWords(input%100);
            }
            
        }
        else if (input > 19)
        {
            if (input % 10 == 0 && input > 1)
            {
                result = tens[input / 10 - 2];
            }
            else
            {
                result = tens[input/10 - 2]+singles[(input )%10];
            }
            
        }
        else
        {
            result = singles[input];
        }
        return result;
    }
}
